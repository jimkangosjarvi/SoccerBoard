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

        private string reqUrl => $"https://functionapp2018071101324.blob.core.windows.net/data/matches_latest.json";
        
        private List<Game> gameList;
        private Game selectedgame;
        

        public List<Game> CachedGames()
        {
            return gameList;
        }

        public async Task<List<Game>> GetGames(string teamname)
        {

            try
            {
                SelectedGame = null;
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(reqUrl);
                if (response.IsSuccessStatusCode)
                {
                    gameList = JsonSerializer.Deserialize<List<Game>>(await response.Content.ReadAsStringAsync()); ;

                }
                if (gameList != null)
                {
                    gameList.Sort(new Comparison<Game>((x, y) => -DateTime.Compare(x.MatchDate ?? DateTime.MaxValue, y.MatchDate ?? DateTime.MaxValue)));
                } else
                {
                    gameList = new List<Game>(); //Make a empty List
                }
            }
            catch (Exception ex)
            {
                
            }
                  
            return gameList;
        }

        public Game SelectedGame
        {
            set {
                selectedgame = value;
                OnGameSelectedEvent?.Invoke();
            }
            get
            {
                return selectedgame;
            }
        }
    }
}
