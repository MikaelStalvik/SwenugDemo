using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using GameDemo.Core.Interfaces;
using GameDemoNative.Droid.Activities;
using Java.Lang;

namespace GameDemoNative.Droid.Classes
{
    public class DroidGameApp : IGameApp
    {
        public static Context CurrentContext;

        private readonly Dictionary<Type, Type> _viewMapperDictionary = new Dictionary<Type, Type>
        {
            {typeof(ILoginViewModel), typeof(LoginActivity)},
            {typeof(IMainViewModel), typeof(MainViewActivity)},
            {typeof(IGameDetailViewModel), typeof(GameDetailsActivity)},
        };

        public void OpenPage(Type pageType, object param = null)
        {
            var concreteType = _viewMapperDictionary[pageType];
            var concreteTypeJava = Class.FromType(concreteType);
            var intent = new Intent(Application.Context, concreteTypeJava);
            CurrentContext.StartActivity(intent);
        }
    }
}