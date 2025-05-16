using CodeBase.Common.Services.Levels;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Enemies;
using CodeBase.Gameplay.Enemies.Factory;
using CodeBase.Gameplay.Enemies.Services;
using CodeBase.Gameplay.Guns;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Factory;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.UI.Game;
using CodeBase.UI.Services.Window;
using UnityEngine;

namespace CodeBase.Infrastructure.States.States
{
    public class GameState : IState, IUpdateable
    {
        private readonly IWindowService _windowService;
        private readonly IHeroFactory _heroFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly ILevelProvider _levelProvider;
        private readonly IEnemyService _enemyService;
        private readonly IStateMachine _stateMachine;
        private readonly IHeroProvider _heroProvider;

        public GameState(
            IWindowService windowService,
            ICameraProvider cameraProvider,
            ILevelProvider levelProvider,
            IHeroFactory heroFactory,
            IEnemyFactory enemyFactory,
            IEnemyService enemyService,
            IStateMachine stateMachine,
            IHeroProvider heroProvider)
        {
            _levelProvider = levelProvider;
            _cameraProvider = cameraProvider;
            _heroFactory = heroFactory;
            _enemyFactory = enemyFactory;
            _enemyService = enemyService;
            _windowService = windowService;
            _stateMachine = stateMachine;
            _heroProvider = heroProvider;
        }

        public void Enter()
        {
            Hero hero = _heroFactory.Create(_levelProvider.PlayerSpawnPosition, _levelProvider.PlayerSpawnPosition.position, Quaternion.identity);
            _heroProvider.SetHero(hero);
            _cameraProvider.Init(hero.GetComponentInChildren<Camera>());

            CreateEnemies();

            _windowService.OpenWindow<GameWindow>();
        }

        public void Update()
        {
            if (_enemyService.AreAllEnemiesDead())
            {
                _stateMachine.Enter<VictoryState>();
            }
        }

        public void Exit()
        {
            DestroyEnemies();
            ExtractCamera();
            DestroyHero();
        }

        private void DestroyHero()
        {
            Gun currentGun = _heroProvider.Hero.GetComponent<GunHolder>().CurrentGun;
            
            Object.Destroy(_heroProvider.Hero.gameObject);
            
            Object.Destroy(currentGun.gameObject);
            
            _heroProvider.ClearHero();
        }

        private void DestroyEnemies() => _enemyService.DestroyAll();

        private void ExtractCamera() => _cameraProvider.MainCamera.transform.SetParent(null);

        private void CreateEnemies()
        {
            Enemy enemy = _enemyFactory.Create(null, _levelProvider.EnemySpawnPoint.position, Quaternion.identity);
            _enemyService.AddEnemy(enemy);
        }
    }
}