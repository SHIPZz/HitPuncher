using UnityEngine;
using System.Collections.Generic;

namespace CodeBase.Gameplay.Common.HitDetection
{
    public class HitDetector
    {
        private readonly RaycastHit[] _hits;
        private readonly int _maxHits;
        private readonly LayerMask _layerMask;

        public HitDetector(int maxHits, LayerMask layerMask)
        {
            _maxHits = maxHits;
            _hits = new RaycastHit[maxHits];
            _layerMask = layerMask;
        }

        public IEnumerable<T> DetectHits<T>(Vector3 origin, Vector3 direction, float distance) where T : Component
        {
            int hitCount = Physics.RaycastNonAlloc(origin, direction, _hits, distance, _layerMask);

            Debug.Log($"hitcount - {hitCount}");
            
            Debug.DrawRay(origin, direction * distance, Color.yellow,1f);
            
            for (int i = 0; i < hitCount; i++)
            {
                if (_hits[i].collider.TryGetComponent<T>(out var component))
                {
                    Debug.Log($"{component.gameObject.name}");
                    yield return component;
                }
            }
        }

        public void ClearHits()
        {
            for (int i = 0; i < _maxHits; i++)
            {
                _hits[i] = default;
            }
        }
    }
} 