using CodeBase.Gameplay.Guns;
using CodeBase.Gameplay.Heroes.ActionComponents;
using CodeBase.Gameplay.Heroes.Config;
using CodeBase.Gameplay.Heroes.States;
using CodeBase.Gameplay.Heroes.States.Factory;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Heroes.Installer
{
    public class HeroInstaller : MonoInstaller<HeroInstaller>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GunHolder _gunHolder;
        
        public override void InstallBindings()
        {
            BindAnimator();

            Container.BindInstance(_gunHolder);

            Container.BindInterfacesTo<HeroStateFactory>().AsSingle();

            BindStates();
            HeroActions();
        }

        private void HeroActions()
        {
            Container.BindInterfacesAndSelfTo<HeroAttack>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroDoubleAttack>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroMovement>().AsSingle();
        }

        private void BindAnimator()
        {
            Container.BindInstance(_animator);
            Container.BindInterfacesAndSelfTo<HeroAnimator>().AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<HeroStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroAttackState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroIdleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroDoubleAttackState>().AsSingle();
        }
    }
} 