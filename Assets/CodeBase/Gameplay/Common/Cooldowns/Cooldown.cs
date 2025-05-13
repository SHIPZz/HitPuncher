using System;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Cooldowns
{
    [Serializable]
    public class Cooldown
    {
        private readonly ReactiveProperty<bool> _isReady = new ReactiveProperty<bool>(true);
        private readonly Transform _owner;

        public IReadOnlyReactiveProperty<bool> IsReady => _isReady;

        public Cooldown(Transform owner)
        {
            _owner = owner;
        }

        public void StartCooldown(float duration)
        {
            if (!_isReady.Value)
                return;

            _isReady.Value = false;
            
            Observable.Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(_ => _isReady.Value = true)
                .AddTo(_owner);
        }
    }
} 