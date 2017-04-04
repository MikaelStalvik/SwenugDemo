using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GameDemo.Core.Interfaces;
using GameDemo.Wpf.Pages;

namespace GameDemo.Wpf.Classes
{
    public class WpfGameApp : IGameApp
    {
        private readonly Dictionary<Type, Type> _viewMapperDictionary = new Dictionary<Type, Type>
        {
            {typeof(ILoginViewModel), typeof(LoginPage)},
            {typeof(IMainViewModel), typeof(MainViewPage)},
            {typeof(IGameDetailViewModel), typeof(GameDetailPage)},
        };

        public void OpenPage(Type pageType, object param = null)
        {
            var concreteType = _viewMapperDictionary[pageType];
            var page = (Page)Activator.CreateInstance(concreteType);
            var mv = (MainWindow) Application.Current.MainWindow;
            mv.NavigationContainer.Navigate(page);
        }
    }
}
