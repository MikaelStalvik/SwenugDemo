using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GameDemo.Core.Interfaces;
using XLabs.Ioc;

namespace GameDemo.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for MainViewPage.xaml
    /// </summary>
    public partial class MainViewPage : Page
    {
        private readonly IMainViewModel _viewModel;
        public MainViewPage()
        {
            InitializeComponent();
            _viewModel = Resolver.Resolve<IMainViewModel>();
            DataContext = _viewModel;
        }

        private async void MainViewPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadData();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedIndex = ((ListBox) sender).SelectedIndex;
            _viewModel.SelectGame(_viewModel.Games[selectedIndex]);
        }
    }
}
