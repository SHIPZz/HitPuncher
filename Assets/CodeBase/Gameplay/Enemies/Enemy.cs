using CodeBase.Gameplay.Common.Healths;
using UnityEngine;

namespace CodeBase.Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Health _health;
        
        public bool IsDead => _health.Dead;
    }
} 