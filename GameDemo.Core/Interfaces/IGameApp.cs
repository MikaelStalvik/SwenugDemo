using System;

namespace GameDemo.Core.Interfaces
{
    public interface IGameApp
    {
        void OpenPage(Type pageType, object param = null);
    }
}
