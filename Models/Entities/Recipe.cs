using System.ComponentModel.DataAnnotations.Schema;

namespace Talab.Models.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public int UserId {  get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public Category Category { get; set; }
        public List<FavoriteRecipes>? FavoriteRecipes { get; set; }
    }
}
