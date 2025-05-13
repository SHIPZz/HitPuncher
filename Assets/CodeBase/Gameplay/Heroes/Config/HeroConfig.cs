using UnityEngine;

namespace CodeBase.Gameplay.Heroes.Config
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Configs/HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        [Header("Attack Settings")]
        [SerializeField] private float _attackDamage = 10f;
        [SerializeField] private float _attackRange = 2f;
        [SerializeField] private LayerMask _attackLayerMask;

        public float AttackDamage => _attackDamage;
        public float AttackRange => _attackRange;
        public LayerMask AttackLayerMask => _attackLayerMask;
    }
} 