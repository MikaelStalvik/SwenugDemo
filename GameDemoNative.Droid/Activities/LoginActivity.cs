using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GameDemo.Core.Interfaces;
using GameDemoNative.Droid.Bootstrapper;
using GameDemoNative.Droid.Classes;
using XLabs.Ioc;
using AlertDialog = Android.App.AlertDialog;

namespace GameDemoNative.Droid.Activities
{
    [Activity(Label = "GameDemoNative.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : AppCompatActivity
    {
        private ILoginViewModel _viewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DroidGameApp.CurrentContext = this;

            var bootstrapper = new DroidAppBootstrapper();
            bootstrapper.SetupApplication();

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.LoginActivityLayout);

            _viewModel = Resolver.Resolve<ILoginViewModel>();

            var editText = FindViewById<EditText>(Resource.Id.editTextUsername);
            editText.Text = _viewModel.Username;
            editText.TextChanged += (sender, args) =>
            {
                _viewModel.Username = ((EditText)sender).Text;
            };

            editText = FindViewById<EditText>(Resource.Id.editTextPassword);
            editText.Text = _viewModel.Password;
            editText.TextChanged += (sender, args) =>
            {
                _viewModel.Password = ((EditText) sender).Text;
            };

            var loginButton = FindViewById<Button>(Resource.Id.buttonLogin);
            loginButton.Click += (sender, args) =>
            {
                _viewModel.LoginCommand.Execute(null);
            };

            _viewModel.PropertyChanged += (sender, args) =>
            {
                loginButton.Enabled = _viewModel.CanLogin;
                if (args.PropertyName.Equals(nameof(_viewModel.ErrorMessage)))
                {
                    var alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Error");
                    alert.SetMessage("Could not login.");
                    alert.SetPositiveButton("OK", (senderAlert, arg) => {
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            };
        }
    }
}

