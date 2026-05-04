using Moq;
using RecipeApi.DTOs;
using RecipeApi.Models;
using RecipeApi.Repositories;
using RecipeApi.Services;
using Xunit;

namespace RecipeApi.Tests
{
    public class RecipeServiceTests
    {
        private readonly Mock<IRecipeRepository> _mockRepo;
        private readonly RecipeService _service;

        public RecipeServiceTests()
        {
            _mockRepo = new Mock<IRecipeRepository>();
            _service = new RecipeService(_mockRepo.Object);
        }

        // Test 1: GetAllRecipes returnerar lista
        [Fact]
        public async Task GetAllRecipesAsync_ReturnsListOfRecipes()
        {
            // Arrange
            var recipes = new List<Recipe> { new Recipe { Id = 1, Name = "Pannkakor" } };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(recipes);

            // Act
            var result = await _service.GetAllRecipesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        // Test 2: GetRecipeById returnerar recept om det finns
        [Fact]
        public async Task GetRecipeByIdAsync_ExistingId_ReturnsRecipe()
        {
            // Arrange
            var recipe = new Recipe { Id = 1, Name = "Test Recipe" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(recipe);

            // Act
            var result = await _service.GetRecipeByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Recipe", result.Name);
        }

        // Test 3: GetRecipeById returnerar null om det inte finns
        [Fact]
        public async Task GetRecipeByIdAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Recipe?)null);

            // Act
            var result = await _service.GetRecipeByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        // Test 4: CreateRecipe skapar och returnerar recept
        [Fact]
        public async Task CreateRecipeAsync_ValidDto_ReturnsCreatedRecipe()
        {
            // Arrange
            var dto = new CreateRecipeDto
            {
                Name = "Nytt Recept",
                Ingredients = new List<CreateIngredientDto>(),
                Instructions = new List<string>()
            };

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Recipe>()))
                     .ReturnsAsync((Recipe r) => { r.Id = 1; return r; });

            // Act
            var result = await _service.CreateRecipeAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Nytt Recept", result.Name);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Recipe>()), Times.Once);
        }

        // Test 5: Search filtrerar korrekt
        [Fact]
        public async Task SearchRecipesAsync_ValidTerm_ReturnsFilteredList()
        {
            // Arrange
            var recipes = new List<Recipe> { new Recipe { Id = 1, Name = "Pannkakor" } };
            _mockRepo.Setup(r => r.SearchAsync("Pannkaka")).ReturnsAsync(recipes);

            // Act
            var result = await _service.SearchRecipesAsync("Pannkaka");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Pannkakor", result.First().Name);
        }
    }
}