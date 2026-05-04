using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeApi.Controllers;
using RecipeApi.DTOs;
using RecipeApi.Models;
using RecipeApi.Services;
using Xunit;

namespace RecipeApi.Tests
{
    public class RecipesControllerTests
    {
        private readonly Mock<IRecipeService> _mockService;
        private readonly RecipesController _controller;

        public RecipesControllerTests()
        {
            _mockService = new Mock<IRecipeService>();
            _controller = new RecipesController(_mockService.Object);
        }

        
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfRecipes()
        {
            _mockService.Setup(s => s.GetAllRecipesAsync()).ReturnsAsync(new List<Recipe>());
            var result = await _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        
        [Fact]
        public async Task GetById_NonExistingId_ReturnsNotFound()
        {
            _mockService.Setup(s => s.GetRecipeByIdAsync(999)).ReturnsAsync((Recipe?)null);
            var result = await _controller.GetById(999);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        
        [Fact]
        public async Task Create_ValidDto_ReturnsCreatedResult()
        {
            var dto = new CreateRecipeDto { Name = "Test Recept", Ingredients = new(), Instructions = new() };
            var createdRecipe = new Recipe { Id = 1, Name = "Test Recept" };

            _mockService.Setup(s => s.CreateRecipeAsync(dto)).ReturnsAsync(createdRecipe);

            var result = await _controller.Create(dto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
        }
    }
}