namespace CodeBase.Gameplay.Cameras
{
    public interface ICameraShakeService
    {
        void Shake(float duration, float strength, int vibrato, float randomness);
    }
}