using CodeBase.Gameplay.Cameras;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private CameraConfig _cameraConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_cameraConfig);
        }
    }
}