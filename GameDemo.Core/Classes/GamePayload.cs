using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;

namespace GameDemo.Core.Classes
{
    public class GamePayload : IGamePayload
    {
        public Game PayloadObject { get; set; }
    }
}
