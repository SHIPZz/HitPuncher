using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _strength = 0.3f;
        [SerializeField] private int _vibrato = 10;
        [SerializeField] private float _randomness = 90f;

        private Vector3 _originalPosition;

        private void Awake()
        {
            _originalPosition = transform.localPosition;
        }

        public void Shake()
        {
            transform.DOKill();
            transform.localPosition = _originalPosition;
            transform.DOShakePosition(
                _duration,
                _strength,
                _vibrato,
                _randomness,
                false,
                true
            );
        }
    }
}