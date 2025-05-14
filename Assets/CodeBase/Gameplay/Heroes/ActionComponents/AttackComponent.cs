using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Common.Cooldowns;
using CodeBase.Gameplay.Common.Healths;
using CodeBase.Gameplay.Common.HitDetection;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private int _maxHits = 10;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _damage =2f;
        [SerializeField] private float _castDistance =2f;

        private HitDetector _hitDetector;
        private Cooldown _cooldown;
        
        public IReadOnlyReactiveProperty<bool> CanAttack => _cooldown.IsReady;

        private void Awake()
        {
            _hitDetector = new HitDetector(_maxHits, _mask);
            _cooldown = new Cooldown(transform);
        }

        public void Attack()
        {
            if (!_cooldown.IsReady.Value)
                return;

            _cooldown.StartCooldown(_attackCooldown);
        }

        public void OnAttackAnimation()
        {
            foreach (Health health in _hitDetector.DetectHits<Health>(_shootPoint.position, _shootPoint.forward,_castDistance))
            {
                health.TakeDamage(_damage);
            }

            _hitDetector.ClearHits();
        }
    }
}