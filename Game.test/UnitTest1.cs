using Moq;
using GameManager.Models;
using GameManager.Repository;
using GameManager.Services;
using System.ComponentModel.DataAnnotations;



namespace GameManager.Tests
{
    public class Gametester
    {
        [Fact]
        public async Task GetAllGamesAsync_ShouldReturnListOfGames()
        {
            // 1. ARRANGE
            var mockRepo = new Mock<IGameRepository>();

            var testGames = new List<Game>
    {
        new Game { Id = 1, Name = "Elden ring", Description = "Rpg", Year = 2022 },
        new Game { Id = 2, Name = "Devil may cry", Description = "Hack and slash", Year = 2018 }
    }; // <--- Här var semikolonet som fattades!

            // Vi lär roboten att skicka tillbaka din lista
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(testGames);

            var service = new GameService(mockRepo.Object);

            // 2. ACT
            var result = await service.GetAllGamesAsync();

            // 3. ASSERT
            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Vi kollar att vi fick de 2 spelen
        }


        [Fact] 

        public async Task GetGameByIdAsync_ShouldReturnCorrectGame()
        {
             var moqrepo = new Mock<IGameRepository>(); 

              var expectedGame = new Game { Id = 3, Name = "Silent Hill 2", Description = "Horror", Year = 2001 };


             moqrepo.Setup(repo => repo.GetByIdAsync(3)).ReturnsAsync(expectedGame);

            var service = new GameService(moqrepo.Object);

            var result = await service.GetGameIdAsync(3);


            Assert.NotNull(result);
            Assert.Equal(expectedGame.Name, result.Name);
            Assert.Equal(3, result.Id);

        }


        [Fact]
        public async Task AddGameAsync_ShouldCallRepositoryAdd()
        {
               var mockRepo = new Mock<IGameRepository>();  

              var service = new GameService(mockRepo.Object);


            var newGame = new Game { Id = 5, Name = "Resident Evil Village", Description = "Horror", Year = 2021 };


            await service.AddGameAsync(newGame);


            mockRepo.Verify(repo => repo.AddAsync(newGame) ,Times.Once);


        }

        [Fact]
        public async Task DeleteGameAsync_ShouldCallRepositoryDelete()
        {
            var mockRepo = new Mock<IGameRepository>();

            var service = new GameService(mockRepo.Object);

            // --- ARRANGE ---
     

            // Vi bestämmer vilket ID som ska tas bort
            int gameIdToDelete = 10;

            // --- ACT ---
            await service.DeleteGameAsync(gameIdToDelete);

            // --- ASSERT ---
            // Vi kollar att roboten faktiskt fick ordern att ta bort just ID 10
            mockRepo.Verify(repo => repo.DeleteAsync(gameIdToDelete), Times.Once);


        }

        [Fact]
        public async Task UpdateGameAsync_ShouldCallRepositoryUpdate()
        {
            // --- ARRANGE ---
            var mockRepo = new Mock<IGameRepository>();
            var service = new GameService(mockRepo.Object);

            // Vi skapar spelet som vi vill uppdatera
            var updatedGame = new Game { Id = 1, Name = "Elden Ring: Shadow of the Erdtree", Description = "Rpg", Year = 2024 };

            // --- ACT ---
            await service.UpdateGameAsync(updatedGame);

            // --- ASSERT ---
            // Vi kollar att roboten fick ordern att köra UpdateAsync med rätt spel
            mockRepo.Verify(repo => repo.UpdateAsync(updatedGame), Times.Once);
        }


    }
}
