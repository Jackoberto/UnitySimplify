using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simplify.SimpleComponents
{
    public class WorldPointArrayComponent : MonoBehaviour, IReadOnlyList<WorldPoint>
    {
        [SerializeField] 
        private List<WorldPoint> worldPoints;
        private void Awake()
        {
            foreach (var worldPoint in this)
            {
                worldPoint.SetStartPosition();
            }
        }
        private void OnValidate()
        {
            if (worldPoints == null)
                return;
            foreach (var worldPoint in this)
            {
                if (worldPoint.parent == null)
                    worldPoint.parent = transform;
            }
        }
        public WorldPoint this[int index] => worldPoints[index];
        public int Count => worldPoints.Count;
        public IEnumerator<WorldPoint> GetEnumerator() => worldPoints.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
