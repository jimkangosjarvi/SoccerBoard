using SoccerBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerBoard.Interfaces
{

    public interface IGameHttpRepository
    {
        Task<List<Game>> GetGames(string teamname);
        List<Game> CachedGames();
    }

}
