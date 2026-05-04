using System.ComponentModel.DataAnnotations;

namespace RecipeApi.DTOs
{
    public class CreateIngredientDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0.1, 1000)]
        public decimal Quantity { get; set; }

        [Required]
        public string Unit { get; set; }
    }
}