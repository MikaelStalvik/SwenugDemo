
using GameDemo.Core.Interfaces;
using Xamarin.Forms;

namespace GameDemo.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly ILoginViewModel _viewModel;

        public LoginPage(ILoginViewModel viewModel)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = viewModel;

            BindingContext = _viewModel;
        }
    }
}
