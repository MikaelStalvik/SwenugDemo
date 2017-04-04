using GameDemo.Bootstrapper;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;

namespace GameDemo.iOS.Bootstrapper
{
    public static class BootstrapperIos
    {
        public static void SetupIoC()
        {
            var container = TinyIoCContainer.Current;
            var tinyContainer = new TinyContainer(container);
            container.Register<IDependencyContainer>(tinyContainer);
            Resolver.SetResolver(new TinyResolver(container));

            // tinyContainer.RegisterSingle<IDevice, IosDevice>();

            // Set up Forms IoC
            FormsBootstrapper.SetupForms();
        }
    }
}