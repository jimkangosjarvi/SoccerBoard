using Microsoft.AspNetCore.Components;
using SoccerBoard.Interfaces;
using SoccerBoard.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoccerBoard.Pages
{
    public partial class Details
    {
        [Inject]
        private IGameHttpRepository Ighr { set; get; }

        [Parameter]
        public string Id { get; set; }
        
        private Game game;

        private List<MatchEvent> matchevents;

        protected  async override void OnParametersSet()
        {

            List<Game> games = Ighr.CachedGames();
            
            //InCase of reload page
            if (games == null) games = await Ighr.GetGames("");

            game = games.FirstOrDefault(a => a.Id.ToString() == Id);
            
            if (game != null) matchevents = game.MatchEvents;
            
            StateHasChanged();
        }
    }
}
