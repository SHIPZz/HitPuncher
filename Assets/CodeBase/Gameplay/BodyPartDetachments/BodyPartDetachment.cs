using System.Collections.Generic;
using CodeBase.Gameplay.Common.Healths;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.BodyPartDetachments
{
    public class BodyPartDetachment : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private List<BodyPartConfig> _bodyParts = new List<BodyPartConfig>();

        private Tween _moveTween;

        private void Awake()
        {
            if (_health == null)
                _health = GetComponent<Health>();

            _health.DamageTaken.Subscribe(OnHealthChanged).AddTo(this);
        }

        private void OnHealthChanged(float currentHealth)
        {
            foreach (var bodyPart in _bodyParts)
            {
                if (!bodyPart.hasFallen && currentHealth <= bodyPart.healthThreshold)
                {
                    DetachBodyPart(bodyPart);
                }
            }
        }

        private void DetachBodyPart(BodyPartConfig config)
        {
            if (config.bodyPart == null)
                return;

            config.hasFallen = true;

            Vector3 targetLocalPos = config.bodyPart.transform.localPosition + config.fallDirection;

            _moveTween?.Kill();

            _moveTween = config.bodyPart.transform.DOLocalMove(targetLocalPos, config.fallDuration)
                .SetEase(config.fallEase)
                .OnComplete(() => config.bodyPart.gameObject.SetActive(false));
        }

        private void OnDestroy()
        {
            _moveTween?.Kill();
        }
    }
}