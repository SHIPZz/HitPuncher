using UnityEngine;

namespace CodeBase.Gameplay.Heroes.Config
{
    public readonly struct AttackPointInfo
    {
        public Vector3 Position { get; }
        public Vector3 Direction { get; }
        public float Range { get; }
        public LayerMask LayerMask { get; }

        public AttackPointInfo(Vector3 position, Vector3 direction, float range, LayerMask layerMask)
        {
            Position = position;
            Direction = direction;
            Range = range;
            LayerMask = layerMask;
        }
    }
} 