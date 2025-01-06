namespace Talab.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public List<Recipe>? Recipe { get; set; }
        public List<FavoriteRecipes>? FavoriteRecipes { get; set; }
    }
}
