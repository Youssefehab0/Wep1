using System.ComponentModel.DataAnnotations.Schema;
using Talab.Models.Entities;

namespace Talab.Models.ViewModel
{
    public class RecipesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public int UserId { get; set; }
        public List<User>? User { get; set; }
        public int CatId { get; set; }
        public List<Category>? Category { get; set; }
        public List<FavoriteRecipes>? FavoriteRecipes { get; set; }
    }
}
