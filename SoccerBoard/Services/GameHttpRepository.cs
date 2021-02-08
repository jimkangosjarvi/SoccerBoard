using SoccerBoard.Interfaces;
using SoccerBoard.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoccerBoard.Services
{
    public class GameHttpRepository : IGameHttpRepository
    {
        public event Action OnGameSelectedEvent;

        private static string ReqUrl => $"https://functionapp2018071101324.blob.core.windows.net/data/matches_latest.json";
        
        private List<Game> _gameList;
        private Game _selectedgame;
        

        public List<Game> CachedGames()
        {
            return _gameList;
        }

        public async Task<List<Game>> GetGames(string teamname)
        {

            try
            {
                SelectedGame = null;
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(ReqUrl);
                if (response.IsSuccessStatusCode)
                {
                    _gameList = JsonSerializer.Deserialize<List<Game>>(await response.Content.ReadAsStringAsync());
                }
                if (_gameList != null)
                {
                    _gameList.Sort((x, y) => -DateTime.Compare(x.MatchDate ?? DateTime.MaxValue, y.MatchDate ?? DateTime.MaxValue));
                } else
                {
                    _gameList = new List<Game>(); //Make a empty List
                }
            }
            catch (Exception)
            {
                _gameList = new List<Game>(); //We dont tell user, that an error occured, just show a empty list for now
            }
                  
            return _gameList;
        }

        public Game SelectedGame
        {
            set {
                _selectedgame = value;
                OnGameSelectedEvent?.Invoke();
            }
            get => _selectedgame;
        }
    }
}
