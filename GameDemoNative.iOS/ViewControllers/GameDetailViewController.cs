using CoreGraphics;
using Foundation;
using GameDemo.Core.Interfaces;
using GameDemoNative.iOS.Helpers;
using UIKit;
using XLabs.Ioc;

namespace GameDemoNative.iOS.ViewControllers
{
    public class GameDetailViewController : UIViewController
    {
        private IGameDetailViewModel _viewModel;
        private UIImageView _boxShotImageView;
        private UILabel _publisherLabel;
        private UILabel _yearLabel;
        private UILabel _platformLabel;
        private UILabel _descriptionLabel;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            _viewModel = Resolver.Resolve<IGameDetailViewModel>();

            var yo = 80;
            var w = View.Bounds.Width - (IosConstants.Margin * 2);

            _boxShotImageView = new UIImageView(new CGRect(IosConstants.Margin, yo, 128, 128));

            var xo = IosConstants.Margin + 128 + IosConstants.Margin;
            _publisherLabel = new UILabel(new CGRect(xo, yo, 140, 24));
            _yearLabel = new UILabel(new CGRect(xo, _publisherLabel.Frame.Y + _publisherLabel.Frame.Height + 8, 140, 24));
            _platformLabel = new UILabel(new CGRect(xo, _yearLabel.Frame.Y + _yearLabel.Frame.Height + 8, 140, 24));
            yo += 128 + IosConstants.Margin;

            _descriptionLabel = new UILabel(new CGRect(IosConstants.Margin, yo, w, 200));
            _descriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
            _descriptionLabel.Lines = 0;

            View.AddSubviews(_boxShotImageView, _publisherLabel, _yearLabel, _platformLabel, _descriptionLabel);
        }

        public override async void ViewWillAppear(bool animated)
        {
            await _viewModel.Load();
            Title = _viewModel.SelectedGame.Name;
            _publisherLabel.Text = _viewModel.SelectedGame.Publisher;
            _yearLabel.Text = _viewModel.SelectedGame.ReleaseYear.ToString();
            _platformLabel.Text = _viewModel.SelectedGame.Platform;
            _descriptionLabel.Text = _viewModel.SelectedGame.Description;
            var data = NSData.FromArray(_viewModel.ImageData);
            _boxShotImageView.Image = UIImage.LoadFromData(data);
        }
    }
}