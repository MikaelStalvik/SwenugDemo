using GameDemo.Core.Bootstrapper;
using GameDemo.Core.Interfaces;
using Xamarin.Forms;
using XLabs.Ioc;

namespace GameDemo.Bootstrapper
{
    public static class FormsBootstrapper
    {
        public static void SetupForms()
        {
            var container = Resolver.Resolve<IDependencyContainer>();

            // container.Register ...

            // container.RegisterSingle<ILogManager, LogManager>();
            // container.Register<IForgotPasswordViewModel, ForgotPasswordViewModel>();


            container.RegisterSingle<IGameApp, FormsGameApp>();

            // Set up Core IoC
            new CoreBootstrapper().SetupCore();
        }
    }
}
