namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public class HeroMovement
    {
         private readonly HeroAnimator _heroAnimator;
         
         public HeroMovement(HeroAnimator heroAnimator)
         {
             _heroAnimator = heroAnimator;
         }

        public void SetIdle()
        {
            _heroAnimator.SetIdle();
        }
    }
}