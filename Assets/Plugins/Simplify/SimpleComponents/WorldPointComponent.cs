using UnityEngine;

namespace Simplify.SimpleComponents
{
    public class WorldPointComponent : MonoBehaviour, IWorldPoint
    {
        [SerializeField] 
        private WorldPoint worldPoint;
        public Quaternion LocalRotation
        {
            get => worldPoint.LocalRotation;
            set => worldPoint.LocalRotation = value;
        }

        public Quaternion Rotation
        {
            get => worldPoint.Rotation;
            set => worldPoint.Rotation = value;
        }

        public Vector3 LocalEulerRotation
        {
            get => worldPoint.LocalEulerRotation;
            set => worldPoint.LocalEulerRotation = value;
        }

        public Vector3 LocalPosition
        {
            get => worldPoint.LocalPosition;
            set => worldPoint.LocalPosition = value;
        }
        
        public Vector3 Position
        {
            get => worldPoint.Position;
            set => worldPoint.Position = value;
        }

        public Vector3 Forward => worldPoint.Forward;
        public Vector3 Back => worldPoint.Back;
        public Vector3 Right => worldPoint.Right;
        public Vector3 Left => worldPoint.Left;
        public Vector3 Up => worldPoint.Up;
        public Vector3 Down => worldPoint.Down;

        private void OnValidate()
        {
            if (worldPoint.parent == null)
                worldPoint.parent = transform;
        }
    }
}
