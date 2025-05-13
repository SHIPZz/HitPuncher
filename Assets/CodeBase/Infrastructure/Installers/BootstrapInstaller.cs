﻿using CodeBase.Common.Services.Input;
using CodeBase.Common.Services.Persistent;
using CodeBase.Common.Services.SaveLoad;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.Factory;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Infrastructure.States.States;
using CodeBase.StaticData;
using CodeBase.UI.Services;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Sound.Services;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindAssetManagementServices();
            BindCommonServices();
            BindUIServices();
            BindStates();

            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
        }
        

        private void BindUIServices()
        {
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IUIProvider>().To<UIProvider>().AsSingle();
            Container.BindInterfacesTo<StaticDataService>().AsSingle();
        }
        
        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingMenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadGameState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameState>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IPersistentService>().To<PersistentService>().AsSingle();
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            Container.Bind<ISaveLoadSystem>().To<PlayerPrefsSaveLoadSystem>().AsSingle();
            Container.BindInterfacesTo<SoundService>().AsSingle();
            Container.BindInterfacesTo<SoundFactory>().AsSingle();
            Container.BindInterfacesTo<SaveOnApplicationFocusChangedSystem>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IStateMachine>().Enter<BootstrapState>();
        }
    }
}