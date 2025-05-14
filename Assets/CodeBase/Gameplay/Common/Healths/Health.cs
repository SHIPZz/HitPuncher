using System;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Healths
{
    public class Health : MonoBehaviour, IDamageTakenTrigger, IDeathTrigger
    {
        [SerializeField] private float _maxHealth = 100f;

        private ReactiveProperty<float> _currentHealth = new();
        private readonly Subject<Unit> _died = new Subject<Unit>();
        private readonly Subject<float> _onDamageTaken = new();

        public IReadOnlyReactiveProperty<float> CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;
        public IObservable<Unit> Died => _died;
        public IObservable<float> DamageTaken => _onDamageTaken;

        private void Awake()
        {
            _currentHealth.Value = _maxHealth;
        }

        public void SetMaxHealth(float maxHealth) => _maxHealth = maxHealth;

        public void Heal(float heal) => SetHealth(_currentHealth.Value + heal);

        public void TakeDamage(float damage)
        {
            if (_currentHealth.Value <= 0)
                return;

            SetHealth(_currentHealth.Value - damage);
            _onDamageTaken.OnNext(_currentHealth.Value);
        }

        private void SetHealth(float health)
        {
            _currentHealth.Value = Mathf.Clamp(health, 0, _maxHealth);

            if (_currentHealth.Value <= 0)
            {
                _died.OnNext(Unit.Default);
            }
        }
    }
}