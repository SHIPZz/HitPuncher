using System;
using System.Collections.Generic;
using CodeBase.Gameplay.Common.Healths;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.BodyPartDetachments
{
    [Serializable]
    public class BodyPartConfig
    {
        public GameObject bodyPart;
        public float healthThreshold;
        public Vector3 fallDirection = Vector3.down;
        public float fallDistance = 2f;
        public float fallDuration = 1f;
        public Ease fallEase = Ease.OutBounce;
        public bool hasFallen;
    }

    public class BodyPartDetachment : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private List<BodyPartConfig> _bodyParts = new List<BodyPartConfig>();

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
            
            config.bodyPart.transform.DOMove(config.fallDirection, config.fallDuration)
                .SetEase(config.fallEase)
                .OnComplete(() => config.bodyPart.gameObject.SetActive(false));
            
        }
    }
} 