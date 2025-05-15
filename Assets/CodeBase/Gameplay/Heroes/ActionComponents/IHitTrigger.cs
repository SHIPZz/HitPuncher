using System;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Heroes.ActionComponents
{
    public interface IHitTrigger
    {
        IObservable<RaycastHit> OnHit { get; }
    }
}