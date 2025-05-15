namespace CodeBase.Gameplay.Enemies.Services
{
    public interface IEnemyService
    {
        void AddEnemy(Enemy enemy);
        bool AreAllEnemiesDead();
    }
} 