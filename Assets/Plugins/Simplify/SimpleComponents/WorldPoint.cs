using UnityEngine;

namespace Simplify.SimpleComponents
{
    public class WorldPoint : MonoBehaviour
    {
        [SerializeField] private Vector3 position = Vector3.one;
        public Vector3 rotationEuler = Vector3.zero;
        public Quaternion Rotation => Quaternion.Euler(rotationEuler);

        public Vector3 Position
        {
            get => position;
            set => position = value;
        }

        public Vector3 Forward => Rotation * Vector3.forward;
        public Vector3 Back => Rotation * Vector3.back;
        public Vector3 Right => Rotation * Vector3.right;
        public Vector3 Left => Rotation * Vector3.left;
        public Vector3 Up => Rotation * Vector3.up;
        public Vector3 Down => Rotation * Vector3.down;
    }
}
