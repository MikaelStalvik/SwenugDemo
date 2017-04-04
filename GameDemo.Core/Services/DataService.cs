using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;

namespace GameDemo.Core.Services
{
    public class DataService : IDataService
    {
        private readonly List<Game> _games = new List<Game>
        {
            new Game
            {
                Id = 0,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Name = "The Secret Of Monkey Island",
                Platform = "Amiga, Atari, PC",
                Publisher = "US Gold",
                ReleaseYear = 1990,
            },
            new Game
            {
                Id = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Name = "Turrican II: The Final Fight",
                Platform = "Amiga, Atari, PC",
                Publisher = "Rainow Arts",
                ReleaseYear = 1991
            },
            new Game
            {
                Id = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Name = "Super Mario World",
                Platform = "SNES",
                Publisher = "Nintendo",
                ReleaseYear = 1990
            },
            new Game
            {
                Id = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Name = "Mega Man 2",
                Platform = "NES",
                Publisher = "Capcom",
                ReleaseYear = 1989
            },
        };

        public bool Login(string username, string password)
        {
            if (username.Equals("demo") && password.Equals("12345"))
                return true;
            return false;
        }

        public Game GetGame(int id)
        {
            return _games.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            await Task.Delay(500);
            return _games;
        }


        private Dictionary<int, string>  PictureUrls = new Dictionary<int, string>
            {
                {
                    0,
                    "https://oldschoolgameblog.com/wp-content/uploads/2015/01/the-secret-of-monkey-island-commodore-amiga.jpg"
                },
                {
                    1,
                    "http://www.mobygames.com/images/covers/l/48651-turrican-ii-the-final-fight-dos-front-cover.jpg"
                },
                {
                    2,
                    "http://images1.the-daily.buzz/live/articles/super-mario-world_6450dac195d9f4b7fafd53df7e44d203.jpg"
                },
                {
                    3,
                    "https://gamefaqs.akamaized.net/box/0/9/6/22096_front.jpg"
                },
            };

        public async Task<byte[]> GetPicture(Game game)
        {
            var client = new HttpClient();
            return await client.GetByteArrayAsync(PictureUrls[game.Id]);
        }

        public string ImageUrl(Game game)
        {
            return PictureUrls[game.Id];
        }
    }
}
