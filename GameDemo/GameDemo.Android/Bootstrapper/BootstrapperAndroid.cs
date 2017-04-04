using GameDemo.Bootstrapper;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;

namespace GameDemo.Droid.Bootstrapper
{
    public static class BootstrapperAndroid
    {
        public static void SetupIoC()
        {
            var container = TinyIoCContainer.Current;
            var tinyContainer = new TinyContainer(container);
            container.Register<IDependencyContainer>(tinyContainer);
            if (!Resolver.IsSet)
                Resolver.SetResolver(new TinyResolver(container));


            // Set up Forms IoC
            FormsBootstrapper.SetupForms();
        }
    }
}