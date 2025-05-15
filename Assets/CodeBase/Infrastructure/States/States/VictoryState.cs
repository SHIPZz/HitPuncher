using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Guns;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Victory;
using UnityEngine;

namespace CodeBase.Infrastructure.States.States
{
    public class VictoryState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IHeroProvider _heroProvider;
        private readonly ICameraProvider _cameraProvider;

        public VictoryState(IWindowService windowService, IHeroProvider heroProvider, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _windowService = windowService;
            _heroProvider = heroProvider;
        }

        public void Enter()
        {
            ExtractCamera();
            
            DestroyHero();

            _windowService.CloseAll();
            _windowService.OpenWindow<VictoryWindow>();
        }

        private void DestroyHero()
        {
            Gun currentGun = _heroProvider.Hero.GetComponent<GunHolder>().CurrentGun;
            
            Object.Destroy(_heroProvider.Hero.gameObject);
            
            Object.Destroy(currentGun.gameObject);
            
            _heroProvider.ClearHero();
        }

        private void ExtractCamera() => _cameraProvider.MainCamera.transform.SetParent(null);

        public void Exit() { }
    }
}