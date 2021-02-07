using Microsoft.AspNetCore.Components;
using SoccerBoard.Interfaces;
using SoccerBoard.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerBoard.Pages
{
    public partial class Index
    {

        [Inject]
        private IGameHttpRepository Ighr { set; get; }

        [Inject]
        private NavigationManager NavigationManager { set; get; }

        private List<Game> games;

        protected override async Task OnInitializedAsync()
        {
            await RefreshCustomerList("");
        }
        
        void OpenDetails(int Id)
        {
            NavigationManager.NavigateTo($"/Details/{Id}");
        }
        
        private async Task RefreshCustomerList(string teamname)
        {
            games= await Ighr.GetGames(teamname);

            //We have a sort on teamname
            if (teamname.Length>0)
            {
                games=games.Where(t => t.HomeTeam.Name.ToLower().Contains(teamname.ToLower()) 
                || t.AwayTeam.Name.ToLower().Contains(teamname.ToLower())).ToList();
            }
                
            StateHasChanged();
        }
    }
}
