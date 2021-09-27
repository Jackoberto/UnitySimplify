using UnityEngine;
using UnityEngine.AI;

namespace Simplify.SimpleComponents.Example
{
    public class SimpleAI : MonoBehaviour
    {
        [SerializeField] private WorldPointArrayComponent worldPointArrayComponent;
        [SerializeField] private NavMeshAgent navMeshAgent;
        private int PathIndex { get; set; }

        private void IncrementPathIndex()
        {
            PathIndex++;
            if (PathIndex >= worldPointArrayComponent.Count)
                PathIndex = 0;
        }

        private Vector3 GetNextPath()
        {
            var pos = worldPointArrayComponent[PathIndex].StartPosition;
            IncrementPathIndex();
            return pos;
        }

        private void Awake()
        {
            navMeshAgent.SetDestination(GetNextPath());
        }

        private void FixedUpdate()
        {
            if (!navMeshAgent.hasPath)
            {
                navMeshAgent.SetDestination(GetNextPath());
            }
        }
    }
}