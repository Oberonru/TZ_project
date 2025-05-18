using UnityEngine;

namespace Main.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        public GameObject CreateGameObject(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject CreateGameObjectInPoint(string path, Vector3 initialPoint)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, initialPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
    }
}