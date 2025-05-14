using CodeBase.Gameplay.Common.Animation;
using UnityEngine;

namespace CodeBase.Gameplay.Enemies
{
    public class EnemyController : MonoBehaviour, IDamageTakenAnimator, IDeathAnimator
    {
        [SerializeField] private Animator _animator;

        private static readonly int HitTrigger = Animator.StringToHash("Hit");
        private static readonly int DeathTrigger = Animator.StringToHash("Death");

        private void Start()
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
        }

        public void PlayHitAnimation()
        {
            if (_animator != null)
            {
                _animator.SetTrigger(HitTrigger);
            }
        }

        public void PlayDeathAnimation()
        {
            if (_animator != null)
            {
                _animator.SetTrigger(DeathTrigger);
            }
        }
    }
}