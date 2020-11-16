using UnityEngine;

namespace Testing
{
    public class MockRandomName : MonoBehaviour, IName
    {
        private readonly string[] _names = new string[3]
        {
            "Cube",
            "Capsule",
            "Sphere"
        };
        public int Count => _names.Length;

        public string GetName(int index)
        {
            return _names[index];
        }
    }
}