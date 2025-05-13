using CodeBase.Gameplay.Common.Cooldowns;
using CodeBase.Gameplay.Common.Health;
using CodeBase.Gameplay.Common.HitDetection;
using UnityEngine;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class DoubleAttackComponent : MonoBehaviour
    {
        [SerializeField] private Transform _firstShootPoint;
        [SerializeField] private Transform _secondShootPoint;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private int _maxHits = 10;
        [SerializeField] private float _doubleAttackCooldown = 1f;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _castDistance = 2f;
        
        private HitDetector _hitDetector;
        private Cooldown _cooldown;
        
        public bool CanDoubleAttack => _cooldown.IsReady.Value;

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
            
            _hitDetector.ClearHits();
        }
        
        public void OnSecondAttackAnimation()
        {
            foreach (Health health in _hitDetector.DetectHits<Health>(_secondShootPoint.position, _secondShootPoint.forward, _castDistance))
            {
                health.TakeDamage(_damage);
            }
            
            _hitDetector.ClearHits();
        }
    }
} 