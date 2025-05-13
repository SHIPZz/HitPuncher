using UnityEngine;

namespace CodeBase.Gameplay.Guns
{
    public class GunHolder : MonoBehaviour
    {
        [SerializeField] private Gun _gun;

        public Gun CurrentGun => _gun;
    }
}