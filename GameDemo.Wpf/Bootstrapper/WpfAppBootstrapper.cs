using GameDemo.Core.Bootstrapper;
using GameDemo.Core.Interfaces;
using GameDemo.Wpf.Classes;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;

namespace GameDemo.Wpf.Bootstrapper
{
    public class WpfAppBootstrapper
    {
        private readonly TinyContainer _tinyContainer;

        public WpfAppBootstrapper()
        {
            var container = TinyIoCContainer.Current;
            _tinyContainer = new TinyContainer(container);
            container.Register<IDependencyContainer>(_tinyContainer);
            Resolver.SetResolver(new TinyResolver(container));
        }

        public void SetupApplication()
        {
            var coreBootstrapper = new CoreBootstrapper();
            coreBootstrapper.SetupCore();

            _tinyContainer.RegisterSingle<IGameApp, WpfGameApp>();
        }
    }
}
