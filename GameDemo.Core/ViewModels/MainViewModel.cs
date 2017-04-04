using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;
using GameDemo.ViewModels;

namespace GameDemo.Core.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IDataService _dataService;
        private readonly IGameApp _app;
        private readonly IGamePayload _payload;

        public MainViewModel(IDataService dataService, IGameApp app, IGamePayload payload)
        {
            _dataService = dataService;
            _app = app;
            _payload = payload;
        }

        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> Games
        {
            get { return _games; }
            set { _games = value; OnPropertyChanged(); }
        }

        public async Task LoadData()
        {
            var data = await _dataService.GetGames();
            Games = new ObservableCollection<Game>(data);    
        }

        public void SelectGame(Game game)
        {
            _payload.PayloadObject = game;
            _app.OpenPage(typeof(IGameDetailViewModel), game);
        }

        public async Task<byte[]> GetPicture(Game game)
        {
            return await _dataService.GetPicture(game);
        }
    }
}

