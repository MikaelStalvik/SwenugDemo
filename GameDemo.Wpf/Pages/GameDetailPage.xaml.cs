using System.Windows;
using System.Windows.Controls;
using GameDemo.Core.Interfaces;
using XLabs.Ioc;

namespace GameDemo.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for GameDetailPage.xaml
    /// </summary>
    public partial class GameDetailPage : Page
    {
        private readonly IGameDetailViewModel _viewModel;

        public GameDetailPage()
        {
            InitializeComponent();
            _viewModel = Resolver.Resolve<IGameDetailViewModel>();
            DataContext = _viewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).NavigationContainer.GoBack();
        }

        private async void GameDetailPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.Load();
        }
    }
}
