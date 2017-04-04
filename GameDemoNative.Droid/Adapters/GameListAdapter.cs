using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GameDemo.Core.Interfaces;
using GameDemoNative.Droid.Classes;

namespace GameDemoNative.Droid.Adapters
{
    public class GameListHolder : RecyclerView.ViewHolder
    {
        public ImageView GameImageView { get; private set; }
        public TextView GameNameTextView { get; private set; }
        public TextView GameInfoTextView { get; private set; }

        public GameListHolder(View itemView, Action<int> clickAction) : base(itemView)
        {
            GameImageView = itemView.FindViewById<ImageView>(Resource.Id.imageViewGameImage);
            GameNameTextView = itemView.FindViewById<TextView>(Resource.Id.textViewGameTitle);
            GameInfoTextView = itemView.FindViewById<TextView>(Resource.Id.textViewGameDetails);
            itemView.Click += (sender, e) => clickAction(AdapterPosition);
        }
    }
    public class GameListAdapter : RecyclerView.Adapter
    {
        private readonly IMainViewModel _viewModel;
        public event EventHandler<int> ItemClick;

        public GameListAdapter(IMainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.GameCellLayout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new GameListHolder(itemView, OnClick);
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var game = _viewModel.Games[position];

            var holder = viewHolder as GameListHolder;
            holder.GameNameTextView.Text = game.Name;
            holder.GameInfoTextView.Text = $"{game.ReleaseYear}, {game.Publisher}";

            var bitmap = await _viewModel.GetPicture(game);
            holder.GameImageView.SetImageBitmap(DroidHelpers.BytesToBitmap(bitmap));
        }

        public override int ItemCount
        {
            get
            {
                if (_viewModel != null && _viewModel.Games != null)
                {
                    return _viewModel.Games.Count;
                }
                return 0;
            }
        }
    }
}