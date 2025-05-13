using Main.Scripts.Infrastructure.Factory;
using Main.Scripts.Infrastructure.States;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Инпут сервис 

        this.Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }
}
