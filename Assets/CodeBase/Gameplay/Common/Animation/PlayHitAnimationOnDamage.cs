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
        private IDamageTakenAnimator _animator;
        private Vector3 _originalHeadPosition;
        private Quaternion _originalHeadRotation;

        private void Awake()
        {
            _damageTakenTrigger = GetComponent<IDamageTakenTrigger>();
            _animator ??= GetComponent<IDamageTakenAnimator>();
            _originalHeadPosition = _headTransform.localPosition;
            _originalHeadRotation = _headTransform.localRotation;

            _damageTakenTrigger.DamageTaken
                .Subscribe(_ => PlayHitAnimation())
                .AddTo(this);
        }

        private void PlayHitAnimation()
        {
            var sequence = DOTween.Sequence();
            
            sequence.Join(
                _headTransform.DOLocalMoveZ(
                        _originalHeadPosition.z - _moveBackDistance, 
                        _animationDuration * 0.5f)
                    .SetEase(_moveBackEase));
            
            sequence.Join(
                _headTransform.DOLocalRotate(
                        new Vector3(_tiltAngle, 0f, 0f),
                        _animationDuration * 0.5f)
                    .SetEase(_moveBackEase));

            sequence.Append(
                _headTransform.DOLocalMove(
                        _originalHeadPosition, 
                        _animationDuration * 0.5f)
                    .SetEase(_returnEase));
            
            sequence.Join(
                _headTransform.DOLocalRotate(
                        _originalHeadRotation.eulerAngles,
                        _animationDuration * 0.5f)
                    .SetEase(_returnEase));

            sequence.OnComplete(() => sequence.Kill());
        }
    }
}