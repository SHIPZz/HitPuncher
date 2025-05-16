using System;
using DG.Tweening;

namespace CodeBase.Gameplay.Cameras
{
    public class CameraShakeService : ICameraShakeService, IDisposable
    {
        private readonly ICameraProvider _cameraProvider;
        private Tween _tween;

        public CameraShakeService(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }

        public void Shake(float duration, float strength, int vibrato, float randomness)
        {
            _tween?.Kill(true);

            _tween = _cameraProvider.MainCamera.transform.DOShakeRotation(duration, strength, vibrato, randomness);
        }

        public void Dispose()
        {
            _tween?.Kill();
        }
    }
}