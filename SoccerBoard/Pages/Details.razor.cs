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
        private IJSRuntime Ijsr { set; get; }
        
        [Inject]
        private IGameHttpRepository Ighr { set; get; }
        
        [Parameter]
        public string Id { get; set; }
        
        private Game _game;

        private async void GoBack()
        {
            var module = await Ijsr.InvokeAsync<IJSObjectReference>("import", "/js/GoBack.js");
            await module.InvokeAsync<object>("historyGo", -1);
        }
        protected async override void OnParametersSet()
        {

            IList<Game> games = Ighr.CachedGames();
            
            //InCase of reload page
            if (games == null) games = await Ighr.GetGames("");

            if (games!=null) _game = games.FirstOrDefault(a => a.Id.ToString().Equals(Id));
            Ighr.SelectedGame = _game;
            StateHasChanged();
        }
    }
}
