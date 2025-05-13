using CodeBase.Common.Services.Input;
using CodeBase.Gameplay.Guns;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class HeroDoubleAttack
    {
        private readonly IInputService _inputService;
        private readonly HeroAnimator _heroAnimator;
        private readonly GunHolder _gunHolder;

        public HeroDoubleAttack(
            IInputService inputService, 
            HeroAnimator heroAnimator,
            GunHolder gunHolder)
        {
            _inputService = inputService;
            _heroAnimator = heroAnimator;
            _gunHolder = gunHolder;
        }
        
        public void Do()
        {
            if (!_gunHolder.CurrentGun.CanDoubleAttack)
                return;
                
            _heroAnimator.SetDoubleAttack();
            _gunHolder.CurrentGun.DoubleAttack();
        }

        public bool IsAttacking()
        {
            return _heroAnimator.IsDoubleAttackAnimationPlaying() || (_inputService.IsDoubleAttacking() && _gunHolder.CurrentGun.CanDoubleAttack);
        }
    }
}