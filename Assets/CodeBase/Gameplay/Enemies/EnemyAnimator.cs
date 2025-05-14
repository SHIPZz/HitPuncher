using UnityEngine;
using CodeBase.Gameplay.Common.Animation;

namespace CodeBase.Gameplay.Enemies
{
    public class EnemyAnimator : IDamageTakenAnimator, IDeathAnimator
    {
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int DeathHash = Animator.StringToHash("Death");
        private static readonly int IdleHash = Animator.StringToHash("IsIdle");

        private readonly Animator _animator;

        public EnemyAnimator(Animator animator) => _animator = animator;

        public void PlayHitAnimation()
        {
            _animator.SetTrigger(HitHash);
        }

        public void PlayDeathAnimation()
        {
            _animator.SetTrigger(DeathHash);
        }

        public void SetIdle()
        {
            _animator.SetBool(IdleHash, true);
        }
    }
} 