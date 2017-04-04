using System.Threading.Tasks;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;
using GameDemo.ViewModels;

namespace GameDemo.Core.ViewModels
{
    public class GameDetailViewModel : BaseViewModel, IGameDetailViewModel
    {
        private readonly IGamePayload _payload;
        private readonly IDataService _dataService;
        private Game _selectedGame = new Game {Name = "Loading..."};
        private byte[] _imageData;

        public GameDetailViewModel(IGamePayload payload, IDataService dataService)
        {
            _payload = payload;
            _dataService = dataService;
        }

        public async Task Load()
        {
            SelectedGame = _payload.PayloadObject;
            ImageData = await _dataService.GetPicture(SelectedGame);
        }

        public Game SelectedGame
        {
            get { return _selectedGame; }
            private set
            {
                if (value == _selectedGame)
                    return;

                _selectedGame = value;
                OnPropertyChanged();
                ImageUrl = _dataService.ImageUrl(_selectedGame);
            }
        }

        public byte[] ImageData
        {
            get { return _imageData; }
            private set
            {
                if (_imageData == value)
                    return;

                _imageData = value;
                OnPropertyChanged();
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get {  return _imageUrl;}
            set { _imageUrl = value; OnPropertyChanged(); }
        }
    }
}
