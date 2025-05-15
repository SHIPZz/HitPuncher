using CodeBase.Constants;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Heroes.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public HeroFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public Hero Create(Transform parent, Vector3 at, Quaternion rotation)
        {
            var prefab = _assetProvider.LoadAsset<Hero>(AssetPath.Hero);
            
            return _instantiator.InstantiatePrefabForComponent<Hero>(prefab, at, rotation, parent);
        }
    }
}