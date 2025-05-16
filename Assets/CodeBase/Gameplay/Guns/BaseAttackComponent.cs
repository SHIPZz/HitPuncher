using System;
using System.Linq;
using CodeBase.Gameplay.Common.Cooldowns;
using CodeBase.Gameplay.Common.Healths;
using CodeBase.Gameplay.Common.HitDetection;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Guns
{
    public abstract class BaseAttackComponent : MonoBehaviour, IHitTrigger
    {
        [SerializeField] protected LayerMask Mask;
        [SerializeField] protected int MaxHits = 10;
        [SerializeField] protected float Damage = 1f;
        [SerializeField] protected float CastDistance = 2f;
        [SerializeField] protected float Cooldown;

        private readonly Subject<RaycastHit> _onHit = new();

        protected Cooldown CooldownComponent;
        
        private HitDetector _hitDetector;
        
        public IObservable<RaycastHit> OnHit => _onHit;
        public bool CanAttack => CooldownComponent.IsReady.Value;

        protected virtual void Awake()
        {
            _hitDetector = new HitDetector(MaxHits, Mask);
            CooldownComponent = new Cooldown(transform);
        }
        
        public virtual void Attack()
        {
            if (!CanAttack)
                return;

            CooldownComponent.StartCooldown(Cooldown);
        }

        protected void ProcessHit(Transform shootPoint)
        {
            foreach (Health health in _hitDetector.DetectHits<Health>(shootPoint.position, shootPoint.forward, CastDistance))
            {
                health.TakeDamage(Damage);
            }
            
            SendHitEvent();
        }

        private void SendHitEvent() => _onHit.OnNext(_hitDetector.Hits.FirstOrDefault());
    }
} 