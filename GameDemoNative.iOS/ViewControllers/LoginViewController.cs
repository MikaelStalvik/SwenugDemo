using CoreGraphics;
using GameDemo.Core.Interfaces;
using GameDemoNative.iOS.Helpers;
using UIKit;
using XLabs.Ioc;

namespace GameDemoNative.iOS.ViewControllers
{
    public class LoginViewController : UIViewController
    {
        private ILoginViewModel _viewModel;
        private UIButton _loginButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Login";
            View.BackgroundColor = UIColor.White;
            _viewModel = Resolver.Resolve<ILoginViewModel>();
            var yo = 80;
            var w = View.Bounds.Width - (IosConstants.Margin * 2);

            var textField = new UITextField(new CGRect(IosConstants.Margin, yo, w, 40));
            textField.Placeholder = "Enter username";
            textField.Text = _viewModel.Username;
            textField.EditingChanged += (sender, args) =>
            {
                _viewModel.Username = ((UITextField) sender).Text;
            };
            View.Add(textField);
            yo += 50;

            textField = new UITextField(new CGRect(IosConstants.Margin, yo, w, 40));
            textField.Text = _viewModel.Password;
            textField.Placeholder = "Enter password";
            textField.EditingChanged += (sender, args) =>
            {
                _viewModel.Password = ((UITextField)sender).Text;
            };
            View.Add(textField);
            yo += 60;

            _loginButton = new UIButton(new CGRect(IosConstants.Margin, yo, w, 50));
            _loginButton.SetTitle("LOGIN", UIControlState.Normal);
            _loginButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            _loginButton.TouchUpInside += (sender, args) =>
            {
                _viewModel.LoginCommand.Execute(null);
            };
            View.Add(_loginButton);
            UpdateLoginButtonState();

            _viewModel.PropertyChanged += (sender, args) =>
            {
                UpdateLoginButtonState();
                if (args.PropertyName.Equals(nameof(_viewModel.ErrorMessage)))
                {
                    var error = new UIAlertView("Error", _viewModel.ErrorMessage, null, "Ok", null);
                    error.Show();
                }
            };
        }

        private void UpdateLoginButtonState()
        {
            _loginButton.Enabled = _viewModel.CanLogin;
            _loginButton.BackgroundColor = _viewModel.CanLogin ? UIColor.Black : UIColor.Gray;
        }
    }
}