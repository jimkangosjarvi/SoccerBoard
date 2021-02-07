using Microsoft.AspNetCore.Components;
using SoccerBoard.Interfaces;
using SoccerBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerBoard.Components
{
    public partial class GameTable
    {
        [Inject]
        private NavigationManager navigationManager { set; get; }

        [Parameter]
        public List<Game> games { set; get; }

        private void OpenDetails(int Id)
        {
            navigationManager.NavigateTo($"/Details/{Id}");
        }
    }
}
