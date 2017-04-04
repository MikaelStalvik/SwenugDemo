using System.Windows.Input;
using GameDemo.Core.Interfaces;
using GameDemo.ViewModels;
using PCL.Helpers;

namespace GameDemo.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private bool _canLogin;

        public bool CanLogin
        {
            get { return _canLogin; }
            private set
            {
                _canLogin = value;
                OnPropertyChanged();
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
                CanLogin = CredentialsAreOk();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                CanLogin = CredentialsAreOk();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        private bool CredentialsAreOk(object o = null)
        {
            return !string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password);
        } 

        public LoginViewModel(IDataService dataService, IGameApp gameApp)
        {
#if DEBUG
            Username = "demo";
            Password = "12345";
#endif
            LoginCommand = new Command(o =>
            {
                if (dataService.Login(Username, Password))
                {
                    gameApp.OpenPage(typeof(IMainViewModel));
                }
                else
                {
                    ErrorMessage = "Unable to login user";
                }
            }, CredentialsAreOk);
        }
    }
}
