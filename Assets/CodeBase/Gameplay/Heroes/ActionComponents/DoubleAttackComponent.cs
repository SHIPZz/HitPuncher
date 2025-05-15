using System;
using System.Linq;
using CodeBase.Gameplay.Common.Cooldowns;
using CodeBase.Gameplay.Common.Healths;
using CodeBase.Gameplay.Common.HitDetection;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class DoubleAttackComponent : MonoBehaviour, IHitTrigger
    {
        [SerializeField] private Transform _firstShootPoint;
        [SerializeField] private Transform _secondShootPoint;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private int _maxHits = 10;
        [SerializeField] private float _doubleAttackCooldown = 1f;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _castDistance = 2f;
        
        private readonly Subject<RaycastHit> _onHit = new();
        
        private HitDetector _hitDetector;
        private Cooldown _cooldown;
        
        public bool CanDoubleAttack => _cooldown.IsReady.Value;
        public IObservable<RaycastHit> OnHit => _onHit;

        private void Awake()
        {
            _hitDetector = new HitDetector(_maxHits, _mask);
            _cooldown = new Cooldown(transform);
        }

        public void DoubleAttack()
        {
            if (!_cooldown.IsReady.Value)
                return;

            _cooldown.StartCooldown(_doubleAttackCooldown);
        }

        public void OnFirstAttackAnimation()
        {
            foreach (Health health in _hitDetector.DetectHits<Health>(_firstShootPoint.position, _firstShootPoint.forward, _castDistance))
            {
                health.TakeDamage(_damage);
            }
            
            SendHitEvent();
        }

        public void OnSecondAttackAnimation()
        {
            foreach (Health health in _hitDetector.DetectHits<Health>(_secondShootPoint.position, _secondShootPoint.forward, _castDistance))
            {
                health.TakeDamage(_damage);
            }
            
            SendHitEvent();
            
            _hitDetector.ClearHits();
        }

        private void SendHitEvent()
        {
            _onHit.OnNext(_hitDetector.Hits.FirstOrDefault());
        }
    }
} 