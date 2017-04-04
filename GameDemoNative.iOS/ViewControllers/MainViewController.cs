using CoreGraphics;
using GameDemo.Core.Interfaces;
using GameDemoNative.iOS.DataSources;
using UIKit;
using XLabs.Ioc;

namespace GameDemoNative.iOS.ViewControllers
{
    public class MainViewController : UIViewController
    {
        private IMainViewModel _viewModel;
        private UITableView _tableView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            Title = "MAIN PAGE";

            _viewModel = Resolver.Resolve<IMainViewModel>();
            _tableView = new UITableView(new CGRect(0, View.Frame.Top, View.Frame.Width, View.Frame.Height));

            View.Add(_tableView);
        }

        public override async void ViewWillAppear(bool animated)
        {
            await _viewModel.LoadData();
            _tableView.Source = new GamesDataSource(_viewModel);
            _tableView.ReloadData();
        }
    }
}