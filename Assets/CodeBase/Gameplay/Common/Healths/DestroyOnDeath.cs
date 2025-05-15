using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Healths
{
    public class DestroyOnDeath : MonoBehaviour
    {
        [SerializeField] private float _destroyDelay = 2f;
        
        private IDeathTrigger _deathTrigger;

        private void Awake()
        {
            _deathTrigger = GetComponent<IDeathTrigger>();
            
            _deathTrigger
                .Died
                .Subscribe(_ => Destroy(gameObject, _destroyDelay))
                .AddTo(this);
        }
    }
}