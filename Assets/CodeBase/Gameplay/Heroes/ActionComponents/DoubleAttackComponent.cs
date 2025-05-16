using UnityEngine;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class DoubleAttackComponent : BaseAttackComponent
    {
        [SerializeField] private Transform _firstShootPoint;
        [SerializeField] private Transform _secondShootPoint;

        public void OnFirstAttackAnimation()
        {
            ProcessHit(_firstShootPoint);
        }

        public void OnSecondAttackAnimation()
        {
            ProcessHit(_secondShootPoint);
        }
    }
} 