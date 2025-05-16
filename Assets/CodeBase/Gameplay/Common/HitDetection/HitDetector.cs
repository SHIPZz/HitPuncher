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

        public IReadOnlyCollection<RaycastHit> Hits => _hits;

        public IEnumerable<T> DetectHits<T>(Vector3 origin, Vector3 direction, float distance) where T : Component
        {
            int hitCount = Physics.RaycastNonAlloc(origin, direction, _hits, distance, _layerMask);

            Debug.DrawRay(origin, direction * distance, Color.yellow,1f);
            
            for (int i = 0; i < hitCount; i++)
            {
                if (_hits[i].collider.TryGetComponent<T>(out var component))
                {
                    Debug.Log($"{component.gameObject.name} hit");
                    yield return component;
                }
            }
        }
    }
} 