using Main.Scripts.Infrastructure.Factory;
using Main.Scripts.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public GameObject inputPrefab;

        public override void InstallBindings()
        {
            this.Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            this.Container.Bind<GameBootstrap>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}