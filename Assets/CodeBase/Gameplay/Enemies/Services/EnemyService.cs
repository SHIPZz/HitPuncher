using System.Collections.Generic;

namespace CodeBase.Gameplay.Enemies.Services
{
    public class EnemyService : IEnemyService
    {
        private readonly List<Enemy> _enemies = new();

        public void AddEnemy(Enemy enemy)
        {
            if (!_enemies.Contains(enemy))
                _enemies.Add(enemy);
        }

        public bool AreAllEnemiesDead()
        {
            return _enemies.Count > 0 && _enemies.TrueForAll(enemy => enemy == null);
        }
    }
}