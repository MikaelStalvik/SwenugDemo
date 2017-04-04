using System.ComponentModel;
using System.IO;
using GameDemo.Core.Interfaces;
using Xamarin.Forms;
using XLabs.Ioc;

namespace GameDemo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        IGameDetailViewModel _viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            _viewModel = Resolver.Resolve<IGameDetailViewModel>();
            _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
            BindingContext = _viewModel;
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            // Update controls that are not bound in XAML:
            switch (propertyChangedEventArgs.PropertyName)
            {
                case nameof(_viewModel.SelectedGame):
                    GameName.Text = _viewModel.SelectedGame.Name;
                    break;

                case nameof(_viewModel.ImageData):
                    if (_viewModel.ImageData != null)
                    {
                        Image.Source = ImageSource.FromStream(() => new MemoryStream(_viewModel.ImageData));
                    }
                    break;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.Load();
        }
    }
}
