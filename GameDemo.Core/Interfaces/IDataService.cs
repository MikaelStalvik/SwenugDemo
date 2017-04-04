using System.Collections.Generic;
using System.Threading.Tasks;
using GameDemo.Core.Models;

namespace GameDemo.Core.Interfaces
{
    public interface IDataService
    {
        bool Login(string username, string password);
        Game GetGame(int id);
        Task<IEnumerable<Game>> GetGames();
        Task<byte[]> GetPicture(Game game);
        string ImageUrl(Game game);
    }
}
