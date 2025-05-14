using CodeBase.Common.Services.Input;
using CodeBase.Gameplay.Guns;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class HeroAttack
    {
        private readonly IInputService _inputService;
        private readonly HeroAnimator _heroAnimator;
        private readonly GunHolder _gunHolder;

        public HeroAttack(
            IInputService inputService, 
            HeroAnimator heroAnimator,
            GunHolder gunHolder)
        {
            _gunHolder = gunHolder;
            _inputService = inputService;
            _heroAnimator = heroAnimator;
        }

        public void Do()
        {
            _heroAnimator.SetAttack();
            _gunHolder.CurrentGun.Attack();
        }

        public bool IsAttacking()
        {
            return _heroAnimator.IsAttackAnimationPlaying() || (_inputService.IsAttacking() && _gunHolder.CurrentGun.CanAttack);
        }
    }
}