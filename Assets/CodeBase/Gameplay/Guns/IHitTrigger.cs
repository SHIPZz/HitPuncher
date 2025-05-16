using System;
using UnityEngine;

namespace CodeBase.Gameplay.Guns
{
    public interface IHitTrigger
    {
        IObservable<RaycastHit> OnHit { get; }
    }
}