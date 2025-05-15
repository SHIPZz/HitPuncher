using CodeBase.Constants;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public EnemyFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public Enemy Create(Transform parent, Vector3 position, Quaternion rotation)
        {
            Enemy enemyPrefab = _assetProvider.LoadAsset<Enemy>(AssetPath.Enemy);
            Enemy enemy = _instantiator.InstantiatePrefabForComponent<Enemy>(enemyPrefab, position, rotation, parent);
            return enemy;
        }
    }
} 