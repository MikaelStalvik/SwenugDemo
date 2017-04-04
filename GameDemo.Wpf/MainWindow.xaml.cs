using System.Windows;
using GameDemo.Wpf.Pages;

namespace GameDemo.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            NavigationContainer.Navigate(new LoginPage());
        }
    }
}
