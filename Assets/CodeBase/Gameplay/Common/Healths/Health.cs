using System;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Healths
{
    public class Health : MonoBehaviour, IDamageTakenTrigger, IDeathTrigger
    {
        [SerializeField] private float _maxHealth = 100f;

        [SerializeField] private float _currentHealth = new();

        private readonly Subject<Unit> _died = new Subject<Unit>();
        private readonly Subject<float> _onDamageTaken = new();

        public IObservable<Unit> Died => _died;
        public IObservable<float> DamageTaken => _onDamageTaken;

        public bool Dead { get; private set; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHealth <= 0)
                return;

            SetHealth(_currentHealth - damage);
        }

        private void SetHealth(float health)
        {
            _currentHealth = Mathf.Clamp(health, 0, _maxHealth);

            _onDamageTaken.OnNext(_currentHealth);

            if (_currentHealth <= 0)
            {
                _died.OnNext(Unit.Default);
                Dead = true;
            }
        }
    }
}