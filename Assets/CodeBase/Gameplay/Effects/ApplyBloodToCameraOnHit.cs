using System.Collections.Generic;
using System.Linq;
using CodeBase.Animations;
using CodeBase.Gameplay.Heroes.ActionComponents;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Effects
{
    public class ApplyBloodToCameraOnHit : MonoBehaviour
    {
        [SerializeField] private VignetteAnimator _vignetteAnimator;

        private List<IHitTrigger> _hitTriggers;

        private void Awake()
        {
            _hitTriggers = GetComponents<IHitTrigger>().ToList();

            _hitTriggers.ForEach(x =>
                x.OnHit.Subscribe(_ => _vignetteAnimator.Play()).AddTo(this));
        }
    }
}