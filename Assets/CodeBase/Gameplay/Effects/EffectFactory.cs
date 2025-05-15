using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Effects
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;

        public EffectFactory(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        public void CreateEffect(EffectTypeId effectTypeId, Vector3 position)
        {
            var config = _staticDataService.GetEffectConfig(effectTypeId);
            var effect = _instantiator.InstantiatePrefabForComponent<Effect>(config.Prefab, position, Quaternion.identity, null);
            effect.Play();
        }
    }
} 