using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Heroes.ActionComponents;
using CodeBase.UI.Sound;
using CodeBase.UI.Sound.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Effects
{
    public class PlayEffectOnHit : MonoBehaviour
    {
        [SerializeField] private EffectTypeId _soundTypeId = EffectTypeId.PunchEffect;
        
        [Header("Position Settings")]
        [SerializeField] private bool _useCustomPosition;
        [SerializeField] private Vector3 _customPosition;
        
        [SerializeField] private bool _addRandomOffset;
        [SerializeField] private float _randomOffsetRadius = 0.5f;
        
        private List<IHitTrigger> _hitTriggers;
        private IEffectFactory _effectFactory;

        [Inject]
        private void Construct(IEffectFactory effectFactory) => 
            _effectFactory = effectFactory;

        private void Awake()
        {
            _hitTriggers = GetComponents<IHitTrigger>().ToList();
            _hitTriggers.ForEach(SubscribeToHit);
        }

        private void SubscribeToHit(IHitTrigger hitTrigger) => 
            hitTrigger.OnHit.Subscribe(PlayEffect).AddTo(this);

        private void PlayEffect(RaycastHit hit)
        {
            Vector3 position = _useCustomPosition ? 
                transform.TransformPoint(_customPosition) : 
                hit.point;

            if (_addRandomOffset)
                position += Random.insideUnitSphere * _randomOffsetRadius;

            _effectFactory.CreateEffect(_soundTypeId, position);
        }
    }
}