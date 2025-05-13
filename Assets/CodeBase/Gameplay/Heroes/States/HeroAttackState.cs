using CodeBase.Gameplay.Heroes.ActionComponents;
using Zenject;

namespace CodeBase.Gameplay.Heroes.States
{
    public class HeroAttackState : IHeroState
    {
        private readonly HeroAttack _heroAttack;
        private readonly HeroAnimator _heroAnimator;
        private readonly HeroStateMachine _stateMachine;

        [Inject]
        public HeroAttackState(
            HeroAttack heroAttack,
            HeroStateMachine stateMachine)
        {
            _heroAttack = heroAttack;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _heroAttack.Do();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            if (!_heroAttack.IsAttacking()) 
                _stateMachine.Enter<HeroIdleState>();
        }
    }
} 