using CodeBase.Gameplay.Common.Healths;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Animation
{
    public class PlayHitAnimationOnDamage : MonoBehaviour
    {
        [SerializeField] private Transform _headTransform;
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private float _moveBackDistance = 0.3f;
        [SerializeField] private float _tiltAngle = 15f;

        [SerializeField] private Ease _moveBackEase = Ease.OutQuad;
        [SerializeField] private Ease _returnEase = Ease.InQuad;

        private IDamageTakenTrigger _damageTakenTrigger;
        private Vector3 _originalHeadPosition;
        private Quaternion _originalHeadRotation;
        private Sequence _hitSequence;

        private void Awake()
        {
            _damageTakenTrigger = GetComponent<IDamageTakenTrigger>();
            _originalHeadPosition = _headTransform.localPosition;
            _originalHeadRotation = _headTransform.localRotation;

            CreateSequence();

            _damageTakenTrigger.DamageTaken
                .Subscribe(_ => PlayHitAnimation())
                .AddTo(this);
        }

        private void CreateSequence()
        {
            _hitSequence = DOTween.Sequence();
            _hitSequence.SetAutoKill(false);
            _hitSequence.Pause();

            _hitSequence.Join(
                _headTransform.DOLocalMoveZ(
                    _originalHeadPosition.z - _moveBackDistance,
                    _animationDuration * 0.5f)
                    .SetEase(_moveBackEase)
            );

            _hitSequence.Join(
                _headTransform.DOLocalRotate(
                    new Vector3(_tiltAngle, 0f, 0f),
                    _animationDuration * 0.5f)
                    .SetEase(_moveBackEase)
            );

            _hitSequence.Append(
                _headTransform.DOLocalMove(
                    _originalHeadPosition,
                    _animationDuration * 0.5f)
                    .SetEase(_returnEase)
            );

            _hitSequence.Join(
                _headTransform.DOLocalRotate(
                    _originalHeadRotation.eulerAngles,
                    _animationDuration * 0.5f)
                    .SetEase(_returnEase)
            );
        }

        private void PlayHitAnimation()
        {
            if (_hitSequence.IsActive())
            {
                _hitSequence.Restart();
            }
        }

        private void OnDestroy()
        {
            _hitSequence?.Kill();
        }
    }
}
