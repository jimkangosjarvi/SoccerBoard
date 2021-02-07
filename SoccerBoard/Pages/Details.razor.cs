using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SoccerBoard.Interfaces;
using SoccerBoard.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoccerBoard.Pages
{
    public partial class Details
    {
        [Inject]
        private IJSRuntime Jsr { set; get; }

        [Inject]
        private IGameHttpRepository Ighr { set; get; }

        [Parameter]
        public string Id { get; set; }
        
        private Game game;

        private async void GoBack()
        {
            await Jsr.InvokeAsync<object>("GoBack.historyGo", -1);
        }
        protected  async override void OnParametersSet()
        {

            List<Game> games = Ighr.CachedGames();
            
            //InCase of reload page
            if (games == null) games = await Ighr.GetGames("");

            game = games.FirstOrDefault(a => a.Id.ToString().Equals(Id));
            
            StateHasChanged();
        }
    }
}
