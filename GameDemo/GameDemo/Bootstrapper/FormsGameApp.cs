using System;
using System.Collections.Generic;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;
using GameDemo.Views;
using Xamarin.Forms;

namespace GameDemo.Bootstrapper
{
    public class FormsGameApp : IGameApp
    {
        private readonly IGamePayload _payload;

        private readonly Dictionary<Type, Type> _viewMapperDictionary = new Dictionary<Type, Type>
        {
            {typeof(ILoginViewModel), typeof(LoginPage)},
            {typeof(IMainViewModel), typeof(GamesPage)},
            {typeof(IGameDetailViewModel), typeof(ItemDetailPage)},
        };

        public FormsGameApp(IGamePayload payload)
        {
            _payload = payload;
        }

        public void OpenPage(Type pageType, object param = null)
        {
            var concreteType = _viewMapperDictionary[pageType];
            var page = (Page)Activator.CreateInstance(concreteType);

            _payload.PayloadObject = (Game)param;

            if (pageType == typeof(IMainViewModel))
            {
                // Replace page
                Navigation.PushAsync(page,false);
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            else
            {
                // Push page
                Navigation.PushAsync(page);
            }
        }

        public INavigation Navigation => NavigationPage.Navigation;
        public NavigationPage NavigationPage { get; set; }
    }
}