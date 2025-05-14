using Main.Scripts.Infrastructure.Factory;
using Main.Scripts.Infrastructure.States;
using Zenject;

namespace Main.Scripts.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Инпут сервис 

            this.Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

            this.Container.Bind<GameBootstrap>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}