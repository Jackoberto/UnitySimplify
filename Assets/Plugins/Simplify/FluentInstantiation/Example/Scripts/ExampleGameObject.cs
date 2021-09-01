using UnityEngine;

namespace Simplify.FluentInstantiation.Example
{
    public class ExampleGameObject : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int money;
        public void Setup(int health, int money)
        {
            this.health = health;
            this.money = money;
        }
    }
}