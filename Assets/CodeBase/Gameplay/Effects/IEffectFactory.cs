using UnityEngine;

namespace CodeBase.Gameplay.Effects
{
    public interface IEffectFactory
    {
        void CreateEffect(EffectTypeId effectTypeId, Vector3 position);
    }
} 