using CodeBase.Common.Services.Input;
using CodeBase.Gameplay.Heroes.ActionComponents;
using Zenject;

namespace CodeBase.Gameplay.Heroes.States
{
    public class HeroIdleState : IHeroState
    {
        private readonly HeroAttack _heroAttack;
        private readonly HeroStateMachine _stateMachine;
        private readonly HeroAnimator _heroAnimator;
        private readonly HeroMovement _heroMovement;
        private readonly HeroDoubleAttack _heroDoubleAttack;

        [Inject]
        public HeroIdleState(
            HeroMovement heroMovement,
            HeroAttack heroAttack,
            IInputService inputService,
            HeroStateMachine stateMachine, 
            HeroDoubleAttack heroDoubleAttack)
        {
            _heroMovement = heroMovement;
            _heroAttack = heroAttack;
            _stateMachine = stateMachine;
            _heroDoubleAttack = heroDoubleAttack;
        }

        public void Enter()
        {
            _heroMovement.SetIdle();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            if (_heroAttack.IsAttacking())
            {
                _stateMachine.Enter<HeroAttackState>();
            }
            else if (_heroDoubleAttack.IsAttacking())
            {
                _stateMachine.Enter<HeroDoubleAttackState>();
            }
        }
    }
} 