using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GameDemo.Core.Models;

namespace GameDemo.Core.Interfaces
{
    public interface IMainViewModel : IBaseInterface
    {
        ObservableCollection<Game> Games { get; set; }
        Task LoadData();
        void SelectGame(Game game);
        Task<byte[]> GetPicture(Game game);
    }
}
