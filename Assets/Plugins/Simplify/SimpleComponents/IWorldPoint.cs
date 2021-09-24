using UnityEngine;

namespace Simplify.SimpleComponents
{
    public interface IWorldPoint
    {
        public Quaternion LocalRotation { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 LocalEulerRotation { get; set; }
        public Vector3 LocalPosition { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 StartPosition { get; }
        public Vector3 Forward { get; }
        public Vector3 Back { get; }
        public Vector3 Right { get; }
        public Vector3 Left { get; }
        public Vector3 Up { get; }
        public Vector3 Down { get; }
    }
}