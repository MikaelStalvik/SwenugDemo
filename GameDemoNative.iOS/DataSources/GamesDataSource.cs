using System;
using System.Threading.Tasks;
using Foundation;
using GameDemo.Core.Interfaces;
using GameDemoNative.iOS.Cells;
using UIKit;

namespace GameDemoNative.iOS.DataSources
{
    public class GamesDataSource : UITableViewSource
    {
        public static readonly NSString GameCellId = new NSString("GameCell");
        private readonly IMainViewModel _viewModel;

        public GamesDataSource(IMainViewModel viewModel)
        {
            _viewModel = viewModel;            
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return GameCell.CellHeight;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(GameCellId);
            if (cell == null)
            {
                cell = new GameCell(GameCellId);
            }
            var row = indexPath.Row;
            var gameCell = cell as GameCell;
            var game = _viewModel.Games[row];
            gameCell?.UpdateCell(game);
            
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _viewModel.Games?.Count ?? 0;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _viewModel.SelectGame(_viewModel.Games[indexPath.Row]);
        }
    }
}