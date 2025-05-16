using UnityEngine;

namespace CodeBase.Gameplay.Guns
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