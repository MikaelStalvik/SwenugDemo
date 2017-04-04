using System;
using System.Collections.Generic;
using GameDemo.Core.Interfaces;
using GameDemoNative.iOS.ViewControllers;
using UIKit;

namespace GameDemoNative.iOS.Classes
{
    public class IosGameApp : IGameApp
    {
        private readonly Dictionary<Type, Type> _viewMapperDictionary = new Dictionary<Type, Type>
        {
            {typeof(ILoginViewModel), typeof(LoginViewController)},
            {typeof(IMainViewModel), typeof(MainViewController)},
            {typeof(IGameDetailViewModel), typeof(GameDetailViewController)},
        };

        public void OpenPage(Type pageType, object param = null)
        {
            var concreteType = _viewMapperDictionary[pageType];
            var vc = (UIViewController)Activator.CreateInstance(concreteType);

            var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
            if (pageType == typeof(IMainViewModel))
            {
                // Create a new root window with a UINavigationController
                var mainNavigationController = new UINavigationController(vc);
                appDelegate.Window.RootViewController = mainNavigationController;
            }
            else
            {
                var navigationController = (UINavigationController)appDelegate.Window.RootViewController;
                navigationController?.PushViewController(vc, true);
            }
        }
    }
}