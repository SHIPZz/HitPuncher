using CodeBase.Gameplay.Common.Healths;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Animation
{
    public class PlayDeathAnimationOnDeath : MonoBehaviour
    {
        [SerializeField] private float _destroyDelay = 2f;

        private IDeathAnimator _animator;
        private IDeathTrigger _deathTrigger;

        private void Awake()
        {
            _deathTrigger = GetComponent<Health>();

            _animator ??= GetComponent<IDeathAnimator>();
        }

        private void Start()
        {
            _deathTrigger.Died
                .Subscribe(_ => OnDeath())
                .AddTo(this);
        }

        private void OnDeath()
        {
            _animator?.PlayDeathAnimation();

            var colliders = GetComponents<Collider>();

            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }

            Destroy(gameObject, _destroyDelay);
        }
    }
}