using System;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;
using UIKit;
using XLabs.Ioc;

namespace GameDemoNative.iOS.Cells
{
    public sealed class GameCell : UITableViewCell
    {
        public const int CellHeight = 56;
        private readonly UILabel _titleLabel;
        private readonly UILabel _infoLabel;
        private readonly UIImageView _boxShotImageView;

        public GameCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            _boxShotImageView = new UIImageView(new CGRect(4, 4, 48, 48));
            _titleLabel = new UILabel(new CGRect(56, 4, ContentView.Bounds.Width - 8 - 56, 24));
            _titleLabel.TextColor = UIColor.Black;
            _infoLabel = new UILabel(new CGRect(56, _titleLabel.Frame.Y + _titleLabel.Frame.Height + 4, ContentView.Bounds.Width - 8 - 56, 24));
            _infoLabel.TextColor = UIColor.DarkGray;
            ContentView.AddSubviews(_boxShotImageView, _titleLabel, _infoLabel);
        }

        public async Task UpdateCell(Game game)
        {
            var vm = Resolver.Resolve<IMainViewModel>();
            _titleLabel.Text = game.Name;
            _infoLabel.Text = $"{game.ReleaseYear}, {game.Publisher}";

            var imageData = await vm.GetPicture(game);
            var data = NSData.FromArray(imageData);
            _boxShotImageView.Image = UIImage.LoadFromData(data);
        }
    }
}