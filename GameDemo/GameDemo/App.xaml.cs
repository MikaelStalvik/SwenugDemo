using GameDemo.Bootstrapper;
using GameDemo.Core.Interfaces;
using GameDemo.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Ioc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GameDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static FormsGameApp GameApp => (FormsGameApp) Resolver.Resolve<IGameApp>();

        public static void SetMainPage()
        {
            var loginPage = Resolver.Resolve<LoginPage>();
            var navigationPage = new NavigationPage(loginPage)
            {
                Title = "Login",
                Icon = Device.OnPlatform("tab_about.png", null, null)
            };

            GameApp.NavigationPage = navigationPage;

            Current.MainPage = navigationPage;

            // loginPage;
        }
    }
}
