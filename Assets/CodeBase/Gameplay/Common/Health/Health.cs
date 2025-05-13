using System;
using UnityEngine;
using UniRx;

namespace CodeBase.Gameplay.Common.Health
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100f;

        private readonly ReactiveProperty<float> _currentHealth = new ReactiveProperty<float>();
        private readonly Subject<Unit> _died = new Subject<Unit>();

        public IReadOnlyReactiveProperty<float> CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;
        public IObservable<Unit> Died => _died;

        public void SetMaxHealth(float maxHealth) => _maxHealth = maxHealth;

        public void SetHealth(float health)
        {
            _currentHealth.Value = Mathf.Clamp(health, 0, _maxHealth);

            if (_currentHealth.Value <= 0)
            {
                _died.OnNext(Unit.Default);
            }
        }
        
        public void Heal(float heal) => SetHealth(_currentHealth.Value + heal);

        public void TakeDamage(float damage)
        {
            if (_currentHealth.Value <= 0)
                return;

            SetHealth(_currentHealth.Value - damage);
        }
    }
}