using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simplify.SimpleComponents
{
    public class WorldPointArrayComponent : MonoBehaviour, IEnumerable<WorldPoint>
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
        
        public List<WorldPoint> WorldPoints => worldPoints;

        public WorldPoint this[int index]
        {
            get => worldPoints[index];
            set => worldPoints[index] = value;
        }

        public int Length => worldPoints.Count;

        public IEnumerator<WorldPoint> GetEnumerator() => worldPoints.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
