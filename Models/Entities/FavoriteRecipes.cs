using System.ComponentModel.DataAnnotations.Schema;

namespace Talab.Models.Entities
{
    public class FavoriteRecipes
    {
        public int FavoriteRecipesId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
    }
}
