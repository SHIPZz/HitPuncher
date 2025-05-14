using System;
using UniRx;

namespace CodeBase.Gameplay.Common.Healths
{
    public interface IDeathTrigger
    {
        public IObservable<Unit> Died { get; }
    }
}