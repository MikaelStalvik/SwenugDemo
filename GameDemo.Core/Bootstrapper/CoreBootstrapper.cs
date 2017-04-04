using GameDemo.Core.Classes;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Services;
using GameDemo.Core.ViewModels;
using XLabs.Ioc;

namespace GameDemo.Core.Bootstrapper
{
    public class CoreBootstrapper
    {
        public void SetupCore()
        {
            var container = Resolver.Resolve<IDependencyContainer>();
            container.RegisterSingle<IGamePayload, GamePayload>();
            container.Register<IDataService, DataService>();
            container.Register<ILoginViewModel, LoginViewModel>();
            container.Register<IMainViewModel, MainViewModel>();
            container.Register<IGameDetailViewModel, GameDetailViewModel>();
        }
    }
}
