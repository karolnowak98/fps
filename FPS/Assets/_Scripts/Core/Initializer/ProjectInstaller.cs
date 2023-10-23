using Zenject;
using FPS.Core.Input.Logic;
using FPS.Game.Input.Logic;

namespace FPS.Core.Initializer
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().AsSingle().NonLazy();
            Container.Bind<IInitializable>().To<InputManager>().FromResolve();
        }
    }
}