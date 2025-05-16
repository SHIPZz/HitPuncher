using System;
using UniRx;

namespace CodeBase.Gameplay.Enemies.Services
{
    public interface IEnemyService
    {
        void AddEnemy(Enemy enemy);
        bool AreAllEnemiesDead();
        void DestroyAll();
        IObservable<Unit> AllEnemiesDead { get; }
    }
} 