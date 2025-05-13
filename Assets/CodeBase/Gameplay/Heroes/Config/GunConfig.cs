using UnityEngine;

namespace CodeBase.Gameplay.Heroes.Config
{
    [CreateAssetMenu(fileName = "GunConfig", menuName = "Configs/GunConfig")]
    public class GunConfig : ScriptableObject
    {
        [Header("Attack Settings")]
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _range = 2f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _attackCooldown = 0.5f;
        
        [Header("Double Attack Settings")]
        [SerializeField] private bool _isDoubleAttackAvailable = true;
        [SerializeField] private float _doubleAttackCooldown = 1f;

        public float Damage => _damage;
        public float Range => _range;
        public LayerMask LayerMask => _layerMask;
        public float AttackCooldown => _attackCooldown;
        public bool IsDoubleAttackAvailable => _isDoubleAttackAvailable;
        public float DoubleAttackCooldown => _doubleAttackCooldown;
    }
} 