using CodeBase.Gameplay.Heroes.Config;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private HeroConfig _heroConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_heroConfig);
        }
    }
}