using SoccerBoard.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerBoard.Interfaces
{

    public interface IGameHttpRepository
    {
        public Task<List<Game>> GetGames(string teamname);
        public List<Game> CachedGames();
        public Game SelectedGame { set; get; }
        public event Action OnGameSelectedEvent;
    }

}
