using UnityEngine;

namespace CodeBase.Gameplay.Effects.Configs
{
    [CreateAssetMenu(fileName = "EffectConfig", menuName = "Configs/Effects/EffectConfig")]
    public class EffectConfig : ScriptableObject
    {
        [SerializeField] private Effect _prefab;
        [SerializeField] private EffectTypeId _id;

        public Effect Prefab => _prefab;
        public EffectTypeId Id => _id;
    }
} 