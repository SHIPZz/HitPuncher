using System;
using System.Collections.Generic;
using UniRx;
using Object = UnityEngine.Object;

namespace CodeBase.Gameplay.Enemies.Services
{
    public class EnemyService : IEnemyService
    {
        private readonly List<Enemy> _enemies = new();
        private readonly Subject<Unit> _allEnemiesDead = new();

        public IObservable<Unit> AllEnemiesDead => _allEnemiesDead;

        public void AddEnemy(Enemy enemy)
        {
            if (!_enemies.Contains(enemy))
                _enemies.Add(enemy);
        }

        public bool AreAllEnemiesDead()
        {
            if (_enemies.Count > 0 && _enemies.TrueForAll(enemy => enemy == null || enemy.IsDead))
            {
                _allEnemiesDead.OnNext(Unit.Default);
                return true;
            }
            
            return false;
        }

        public void DestroyAll()
        {
            _enemies.RemoveAll(x => x == null);
            
            _enemies.ForEach(enemy => Object.Destroy(enemy.gameObject));
        }
    }
}