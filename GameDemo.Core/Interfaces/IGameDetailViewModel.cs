using System.Threading.Tasks;
using GameDemo.Core.Models;

namespace GameDemo.Core.Interfaces
{
    public interface IGameDetailViewModel : IBaseInterface
    {
        Game SelectedGame { get; }
        Task Load();
        byte[] ImageData { get; }
        string ImageUrl { get; }
    }
}
