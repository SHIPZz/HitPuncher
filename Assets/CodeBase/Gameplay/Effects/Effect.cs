using UnityEngine;

namespace CodeBase.Gameplay.Effects
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public void Play()
        {
            _particleSystem.Play();
            Destroy(gameObject,1f);
        }
    }
} 