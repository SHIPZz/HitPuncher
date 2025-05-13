using CodeBase.Gameplay.Heroes.ActionComponents;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Heroes.States
{
    public class HeroDoubleAttackState : IHeroState
    {
        private readonly HeroDoubleAttack _heroDoubleAttack;
        private readonly HeroAnimator _heroAnimator;
        private readonly HeroStateMachine _stateMachine;

        [Inject]
        public HeroDoubleAttackState(HeroStateMachine stateMachine, HeroDoubleAttack heroDoubleAttack)
        {
            _stateMachine = stateMachine;
            _heroDoubleAttack = heroDoubleAttack;
        }

        public void Enter()
        {
            _heroDoubleAttack.Do();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            if (!_heroDoubleAttack.IsAttacking()) 
                _stateMachine.Enter<HeroIdleState>();
        }
    }
}