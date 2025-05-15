using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Healths
{
    public class DisableCollidersOnDeath : MonoBehaviour
    {
        private IDeathTrigger _deathTrigger;

        private void Awake()
        {
            _deathTrigger = GetComponent<IDeathTrigger>();

            _deathTrigger
                .Died
                .Subscribe(_ => DisableColliders())
                .AddTo(this);
        }

        private void DisableColliders()
        {
            foreach (var collider in GetComponents<Collider>())
            {
                collider.enabled = false;
            }

            foreach (Collider collider in GetComponentsInChildren<Collider>(true))
            {
                collider.enabled = false;
            }
        }
    }
}