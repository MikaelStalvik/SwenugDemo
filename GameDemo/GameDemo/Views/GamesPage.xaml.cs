using System;
using GameDemo.Bootstrapper;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;
using GameDemo.ViewModels;

using Xamarin.Forms;
using XLabs.Ioc;

namespace GameDemo.Views
{
    public partial class GamesPage : ContentPage
    {
        private IMainViewModel _viewModel;

        public GamesPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = Resolver.Resolve<IMainViewModel>();

            BindingContext = _viewModel;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
           _viewModel.SelectGame((Game) args.SelectedItem);
        }

       protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadData();
        }
    }

}
