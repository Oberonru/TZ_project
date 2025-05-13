using UnityEngine;

namespace Main.Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateGameObject(string path);
        GameObject CreateGameObjectInPoint(string path, Vector3 initialPoint);
    }
}