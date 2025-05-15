using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        [Header("Camera Shake Settings")]
        [SerializeField] private float _shakeDuration = 0.3f;
        [SerializeField] private float _shakeStrength = 30f;
        [SerializeField] private int _shakeVibrato = 1;
        [SerializeField] private float _shakeRandomness = 5f;

        public float ShakeDuration => _shakeDuration;
        public float ShakeStrength => _shakeStrength;
        public int ShakeVibrato => _shakeVibrato;
        public float ShakeRandomness => _shakeRandomness;
    }
} 