using System;

namespace CodeBase.Gameplay.Common.Healths
{
    public interface IDamageTakenTrigger
    {
        public IObservable<float> DamageTaken { get; }
    }
}