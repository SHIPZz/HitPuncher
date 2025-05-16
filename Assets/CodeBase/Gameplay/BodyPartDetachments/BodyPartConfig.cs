using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.BodyPartDetachments
{
    [Serializable]
    public class BodyPartConfig
    {
        public GameObject bodyPart;
        public float healthThreshold;
        public Vector3 fallDirection = Vector3.down;
        public float fallDuration = 1f;
        public Ease fallEase = Ease.OutBounce;
        public bool hasFallen;
    }
}