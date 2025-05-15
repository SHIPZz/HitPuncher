﻿using CodeBase.Common.Services.Persistent;
using CodeBase.Common.Services.SaveLoad;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.StaticData;
using CodeBase.UI.Game;
using CodeBase.UI.LoadingCurtains;
using CodeBase.UI.Menu;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Settings;
using CodeBase.UI.Victory;

namespace CodeBase.Infrastructure.States.States
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IWindowService _windowService;
        private readonly IPersistentService _persistentService;
        private readonly ISaveOnApplicationPauseSystem _saveOnApplicationPauseSystem;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IStateMachine stateMachine,
            IWindowService windowService,
            IPersistentService persistentService,
            ISaveOnApplicationPauseSystem saveOnApplicationPauseSystem,
            IStaticDataService staticDataService)
        {
            _windowService = windowService;
            _persistentService = persistentService;
            _saveOnApplicationPauseSystem = saveOnApplicationPauseSystem;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            LoadData();
            
            _staticDataService.LoadAll();

            BindWindows();

            _windowService.OpenWindow<LoadingCurtainWindow>();

            _saveOnApplicationPauseSystem.Initialize();

            _stateMachine.Enter<LoadingMenuState>();
        }

        private void LoadData()
        {
            _persistentService.LoadAll();
        }

        private void BindWindows()
        {
            _windowService.Bind<MenuWindow, MenuWindowController>();
            _windowService.Bind<LoadingCurtainWindow, LoadingCurtainWindowController>();
            _windowService.Bind<SettingsWindow, SettingsWindowController>();
            _windowService.Bind<VictoryWindow, VictoryWindowController>();
            _windowService.Bind<GameWindow, GameWindowController>();
        }

        public void Exit() { }
    }
}