using Moq;
using MovieManager1.Models;
using MovieManager1.Repository;
using MovieManager1.Services;
using Xunit;

namespace MovieManager.Tests;

public class MovieServiceTests
{
    [Fact] // Det här talar om för Visual Studio att det är en test-metod
    public async Task GetAllMoviesAsync_ShouldReturnListOfMovies()
    {
        // --- ARRANGE (Ordna) ---

        // 1. Vi skapar en fejk-lista med filmer som vi vill att vårt "låtsas-repo" ska ge oss
        var mockMovies = new List<Movies>
        {
            new Movies { Id = 1, Title = "Inception", Director = "Nolan" },
            new Movies { Id = 2, Title = "Interstellar", Director = "Nolan" }
        };

        // 2. Vi skapar vårt "låtsas-skafferi" (Mock)
        var mockRepo = new Mock<IMovieRepository>();

        // 3. Vi ställer in så att när någon ropar på GetAllAsync, så svarar vi med vår lista
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockMovies);

        // 4. Vi skapar den riktiga servicen (Kocken) och ger den vårt låtsas-skafferi
        var service = new MovieService(mockRepo.Object);

        var result = await service.GetAllMoviesAsync();

        // --- ASSERT (Kontrollera) ---
        // 1. Kolla att vi faktiskt fick ett resultat (att det inte är null)
        Assert.NotNull(result);

        // 2. Kolla att vi fick exakt 2 filmer (eftersom vi la 2 i vår mock-lista)
        Assert.Equal(2, result.Count());

        // 3. Kolla att den första filmen heter "Inception"
        Assert.Equal("Inception", result.First().Title);
    }

    [Fact]
    public async Task AddMovieAsync_ShouldCallRepositoryAdd()
    {
        // --- ARRANGE ---
        var mockRepo = new Mock<IMovieRepository>();
        var service = new MovieService(mockRepo.Object);

        // Vi skapar filmen vi vill lägga till
        var newMovie = new Movies { Id = 3, Title = "Batman", Director = "Nolan" };

        // --- ACT ---
        await service.AddMovieAsync(newMovie);

        // --- ASSERT ---
        // Här använder vi något coolt: Verify! 
        // Vi kollar om Servicen verkligen anropade Repositoryts AddAsync-metod exakt 1 gång.
        mockRepo.Verify(repo => repo.AddAsync(newMovie), Times.Once);
    }

    [Fact]
    public async Task SearchMoviesAsync_ShouldReturnMatchingMovies()
    {
        // --- ARRANGE ---
        var mockrepo = new Mock<IMovieRepository>();

        // Vi skapar filmen vi förväntar oss att hitta
        var expectedMovies = new List<Movies> {
        new Movies { Id = 4, Title = "matrix", Director = "idk" }
    };

        // VIKTIGT: Här lär vi roboten vad den ska svara!
        mockrepo.Setup(repo => repo.SearchAsync("matrix"))
                .ReturnsAsync(expectedMovies);

        var service = new MovieService(mockrepo.Object);

        // --- ACT ---
        // Här kör vi sökningen
        var result = await service.SearchMoviesAsync("matrix");

        // --- ASSERT ---
        Assert.NotNull(result); // Kolla att vi fick något svar
        Assert.Single(result);  // Kolla att vi fick exakt 1 film
        Assert.Equal("matrix", result.First().Title); // Kolla att det var rätt film

        // Bonus: Kolla att servicen faktiskt anropade repositoryt
        mockrepo.Verify(repo => repo.SearchAsync("matrix"), Times.Once);
    }


    [Fact]
    public async Task DeleteMovieAsync_ShouldCallRepositoryDelete()
    {
        // Arrange
        var mockrepo = new Mock<IMovieRepository>();
        var service = new MovieService(mockrepo.Object);

        // Act - Här utför vi handlingen först!
        await service.DeleteMovieAsync(1);

        // Assert - SEN kontrollerar vi att roboten (mocken) blev anropad
        mockrepo.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }
}