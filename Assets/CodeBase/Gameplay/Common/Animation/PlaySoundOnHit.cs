using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Heroes.ActionComponents;
using CodeBase.UI.Sound;
using CodeBase.UI.Sound.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Common.Animation
{
    public class PlaySoundOnHit : MonoBehaviour
    {
        [SerializeField] private SoundTypeId _soundTypeId = SoundTypeId.HitPunch;
        
        private ISoundService _soundService;
        private List<IHitTrigger> _hitTriggers;

        [Inject]
        private void Construct(ISoundService soundService)
        {
            _soundService = soundService;
        }
        
        private void Awake()
        {
            _hitTriggers = GetComponents<IHitTrigger>().ToList();
            
            _hitTriggers.ForEach(x => x.OnHit.Subscribe(_ => _soundService.Play(_soundTypeId)));
        }
    }
}