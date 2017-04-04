using GameDemo.Core.Bootstrapper;
using GameDemo.Core.Interfaces;
using GameDemoNative.Droid.Classes;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;

namespace GameDemoNative.Droid.Bootstrapper
{
    public class DroidAppBootstrapper
    {
        private readonly TinyContainer _tinyContainer;

        public DroidAppBootstrapper()
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

            _tinyContainer.RegisterSingle<IGameApp, DroidGameApp>();
        }
    }
}