using UnityEngine;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class AttackComponent : BaseAttackComponent
    {
        [SerializeField] private Transform _shootPoint;

        public void OnAttackAnimation()
        {
            ProcessHit(_shootPoint);
        }
    }
}