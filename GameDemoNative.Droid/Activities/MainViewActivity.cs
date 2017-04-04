using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using GameDemo.Core.Interfaces;
using GameDemoNative.Droid.Adapters;
using XLabs.Ioc;

namespace GameDemoNative.Droid.Activities
{
    [Activity(Label = "MainMenuActivity")]
    public class MainViewActivity : AppCompatActivity
    {
        private IMainViewModel _viewModel;
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private GameListAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainViewActivityLayout);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.gamesListRecyclerView);

            _viewModel = Resolver.Resolve<IMainViewModel>();
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await _viewModel.LoadData();
            _adapter = new GameListAdapter(_viewModel);
            _adapter.ItemClick += (sender, i) =>
            {
                var game = _viewModel.Games[i];
                _viewModel.SelectGame(game);
            };
            _recyclerView.SetAdapter(_adapter);
            _layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            //_layoutManager = new GridLayoutManager(this, 2);
            _recyclerView.SetLayoutManager(_layoutManager);
        }
    }
}