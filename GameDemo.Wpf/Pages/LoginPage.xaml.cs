using System.Windows;
using System.Windows.Controls;
using GameDemo.Core.Interfaces;
using XLabs.Ioc;

namespace GameDemo.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            var viewModel = Resolver.Resolve<ILoginViewModel>();
            DataContext = viewModel;

            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals(nameof(viewModel.ErrorMessage)))
                {
                    MessageBox.Show("Could not login");
                }
            };
        }
    }
}
