using System.Windows.Input;

namespace GameDemo.Core.Interfaces
{
    public interface ILoginViewModel : IBaseInterface
    {
        string Username { get; set; }
        string Password { get; set; }
        string ErrorMessage { get; }
        bool CanLogin { get; }
        ICommand LoginCommand { get; }
    }
}
