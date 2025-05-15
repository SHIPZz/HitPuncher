using UnityEngine;

namespace CodeBase.Gameplay.Enemies.Factory
{
    public interface IEnemyFactory
    {
        Enemy Create(Transform parent, Vector3 position, Quaternion rotation);
    }
} 