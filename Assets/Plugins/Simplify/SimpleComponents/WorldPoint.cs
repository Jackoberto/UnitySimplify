using System;
using UnityEngine;

namespace Simplify.SimpleComponents
{
    [Serializable]
    public class WorldPoint : IWorldPoint
    { 
        [SerializeField]
        private Vector3 localPosition = Vector3.one;
        [SerializeField]
        private Vector3 localRotation = Vector3.zero;
        [HideInInspector]
        public Transform parent;
        public WorldPoint(Transform parent)
        {
            this.parent = parent;
        }
        public Quaternion LocalRotation
        {
            get => Quaternion.Euler(localRotation);
            set => localRotation = value.eulerAngles;
        }

        public Quaternion Rotation
        {
            get => parent.rotation * LocalRotation;
            set => LocalRotation = Quaternion.Inverse(parent.rotation) * value;
        }

        public Vector3 LocalEulerRotation
        {
            get => localRotation;
            set => localRotation = value;
        }

        public Vector3 LocalPosition
        {
            get => localPosition;
            set => localPosition = value;
        }
        
        public Vector3 Position
        {
            get => localPosition + parent.position;
            set => localPosition = value - parent.position;
        }

        public Vector3 Forward => Rotation * Vector3.forward;
        public Vector3 Back => Rotation * Vector3.back;
        public Vector3 Right => Rotation * Vector3.right;
        public Vector3 Left => Rotation * Vector3.left;
        public Vector3 Up => Rotation * Vector3.up;
        public Vector3 Down => Rotation * Vector3.down;
    }
}