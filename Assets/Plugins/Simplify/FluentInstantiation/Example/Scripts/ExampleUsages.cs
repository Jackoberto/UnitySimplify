using UnityEngine;

namespace Simplify.FluentInstantiation.Example
{
    public class ExampleUsages : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private ExampleGameObject exampleGameObject;

        private void Start()
        {
            var positionedAndRotatedObject = FluentInstantiation
                .InstantiateObject(prefab)
                .AtPosition(new Vector3(1, 1, 2))
                .WithRotation(Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)))
                .Instantiate();
            positionedAndRotatedObject.name = "Positioned Object";
            
            var parentedObject = FluentInstantiation
                .InstantiateObject(prefab)
                .ParentedTo(transform)
                .Instantiate();
            parentedObject.name = "Parented Object";
            
            var positionedObject = FluentInstantiation
                .InstantiateObject(prefab)
                .AtPosition(new Vector3(1, 7, 1))
                .Instantiate();
            positionedObject.name = "Positioned Object";
            
            var positionedAndParentedObject = FluentInstantiation
                .InstantiateObject(prefab)
                .AtPosition(new Vector3(1, 7, 1))
                .WithRotation(Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)))
                .ParentedTo(transform)
                .Instantiate();
            positionedAndParentedObject.name = "Positioned and Parent Object";

            var positionedRotatedAndParentedObject = FluentInstantiation
                .InstantiateObject(prefab)
                .AtPosition(new Vector3(1, 2, 3))
                .WithRotation(Quaternion.AngleAxis(90, Vector3.forward))
                .ParentedTo(transform)
                .Instantiate();
            positionedRotatedAndParentedObject.name = "Positioned, Rotated and Parent Object";

            FluentInstantiation
                .InstantiateObject(exampleGameObject)
                .WithSetupMethod(t => t.Setup(50, 100))
                .WithSetupMethod(t => t.name = "Configured Object")
                .WithSetupMethod(t =>
                {
                    var components = t.GetComponents<Component>();
                    foreach (var component in components)
                    {
                        Debug.Log(component.GetType().Name);
                    }
                })
                .ParentedTo(transform)
                .Instantiate();
        }
    }
}