using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GameDemo.Core.Interfaces;
using GameDemoNative.Droid.Classes;
using XLabs.Ioc;

namespace GameDemoNative.Droid.Activities
{
    [Activity(Label = "GameDetailsActivity")]
    public class GameDetailsActivity : AppCompatActivity
    {
        private TextView _titleTextView;
        private TextView _publisherTextView;
        private TextView _releaseYearTextView;
        private TextView _platformTextView;
        private TextView _descriptionTextView;
        private ImageView _boxShotImageView;
        private IGameDetailViewModel _viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GameDetailLayout);
            _titleTextView = FindViewById<TextView>(Resource.Id.textViewDetailTitle);
            _publisherTextView = FindViewById<TextView>(Resource.Id.textViewPublisher);
            _releaseYearTextView = FindViewById<TextView>(Resource.Id.textViewReleaseYear);
            _platformTextView = FindViewById<TextView>(Resource.Id.textViewPlatform);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.textViewDescription);
            _boxShotImageView = FindViewById<ImageView>(Resource.Id.imageViewLarge);
            _viewModel = Resolver.Resolve<IGameDetailViewModel>();
            _titleTextView.Text = _viewModel.SelectedGame.Name;
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await _viewModel.Load();
            _boxShotImageView.SetImageBitmap(DroidHelpers.BytesToBitmap(_viewModel.ImageData));
            Title = _viewModel.SelectedGame.Name;
            _publisherTextView.Text = _viewModel.SelectedGame.Publisher;
            _releaseYearTextView.Text = _viewModel.SelectedGame.ReleaseYear.ToString();
            _platformTextView.Text = _viewModel.SelectedGame.Platform;
            _descriptionTextView.Text = _viewModel.SelectedGame.Description;
            _titleTextView.Text = _viewModel.SelectedGame.Name;
        }
    }
}