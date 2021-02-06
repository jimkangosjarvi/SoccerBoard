using Bunit;
using Microsoft.Extensions.DependencyInjection;
using SoccerBoard.Interfaces;
using SoccerBoard.Models;
using SoccerBoard.Pages;
using SoccerBoard.Services;
using System.Collections.Generic;
using Xunit;

namespace SoccerBoardXTest
{
    public class ServiceTest
    {
        [Fact]
        public async void TestHIFKCount()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<IGameHttpRepository>(new GameHttpRepository());
            // Act
            IGameHttpRepository repository = new GameHttpRepository();
            List<Game> gamelist = await repository.GetGames("hifk");
            // Assert
            Assert.Equal(198, gamelist.Count);

        }
    }
}
