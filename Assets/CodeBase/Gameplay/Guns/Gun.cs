using CodeBase.Gameplay.Heroes.ActionComponents;
using UnityEngine;

namespace CodeBase.Gameplay.Guns
{
    public class Gun : MonoBehaviour
    {
        private AttackComponent _attackComponent;
        private DoubleAttackComponent _doubleAttackComponent;

        public bool CanAttack => _attackComponent.CanAttack;

        public bool CanDoubleAttack => _doubleAttackComponent != null && _doubleAttackComponent.CanAttack;

        private bool HasDoubleAttack => _doubleAttackComponent != null;

        private void Awake()
        {
            _attackComponent = GetComponent<AttackComponent>();

            _doubleAttackComponent = GetComponent<DoubleAttackComponent>();
        }

        public void Attack()
        {
            _attackComponent.Attack();
        }

        public void DoubleAttack()
        {
            if (HasDoubleAttack)
                _doubleAttackComponent.Attack();
        }
    }
}