using CodeBase.Gameplay.Common.Healths;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Animation
{
    public class PlayHitAnimationOnDamage : MonoBehaviour
    {
        private IDamageTakenTrigger _damageTakenTrigger;

        private IDamageTakenAnimator _animator;

        private void Awake()
        {
            _damageTakenTrigger = GetComponent<IDamageTakenTrigger>();

            _animator ??= GetComponent<IDamageTakenAnimator>();
        }

        private void Start()
        {
            _damageTakenTrigger.DamageTaken
                .Subscribe(_ => _animator?.PlayHitAnimation())
                .AddTo(this);
        }
    }
}