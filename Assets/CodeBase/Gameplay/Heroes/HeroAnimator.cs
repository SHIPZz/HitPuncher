using UnityEngine;
using CodeBase.Gameplay.Common.Animation;

namespace CodeBase.Gameplay.Heroes
{
    public class HeroAnimator
    {
        private static readonly int AttackHash = Animator.StringToHash("IsAttacking");
        private static readonly int DoubleAttackHash = Animator.StringToHash("IsDoubleAttacking");
        private static readonly int IdleHash = Animator.StringToHash("IsIdle");
        
        private static readonly int AttackStateHash = Animator.StringToHash("Attack");
        private static readonly int DoubleAttackStateHash = Animator.StringToHash("DoubleAttack");

        private readonly Animator _animator;

        public HeroAnimator(Animator animator) => _animator = animator;

        public void SetAttack()
        {
            _animator.SetBool(AttackHash, true);
            _animator.SetBool(IdleHash, false);
            _animator.SetBool(DoubleAttackHash, false);
        }

        public void SetIdle()
        {
            _animator.SetBool(AttackHash, false);
            _animator.SetBool(DoubleAttackHash, false);
            _animator.SetBool(IdleHash, true);
        }

        public void SetDoubleAttack()
        {
            _animator.SetBool(IdleHash, false);
            _animator.SetBool(AttackHash, false);
            _animator.SetBool(DoubleAttackHash, true);
        }

        public bool IsAttackAnimationPlaying() => 
            IsAnimationPlaying(AttackStateHash);

        public bool IsDoubleAttackAnimationPlaying() => 
            IsAnimationPlaying(DoubleAttackStateHash);

        private bool IsAnimationPlaying(int animationHash)
        {
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.shortNameHash == animationHash && stateInfo.normalizedTime < 1f;
        }
    }
}