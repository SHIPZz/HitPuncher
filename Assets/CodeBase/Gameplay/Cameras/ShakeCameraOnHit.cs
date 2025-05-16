using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Cameras.Configs;
using CodeBase.Gameplay.Guns;
using CodeBase.Gameplay.Heroes.ActionComponents;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Cameras
{
    public class ShakeCameraOnHit : MonoBehaviour
    {
        private ICameraShakeService _cameraShakeService;
        private CameraConfig _cameraConfig;
        private List<IHitTrigger> _hitTriggers;

        [Inject]
        private void Construct(ICameraShakeService cameraShakeService, CameraConfig cameraConfig)
        {
            _cameraShakeService = cameraShakeService;
            _cameraConfig = cameraConfig;
        }

        private void Awake()
        {
            _hitTriggers = GetComponents<IHitTrigger>().ToList();
            _hitTriggers.ForEach(x => x.OnHit.Subscribe(_=> ShakeCamera()).AddTo(this));
        }

        private void ShakeCamera()
        {
            _cameraShakeService.Shake(
                _cameraConfig.ShakeDuration,
                _cameraConfig.ShakeStrength,
                _cameraConfig.ShakeVibrato,
                _cameraConfig.ShakeRandomness);
        }
    }
}