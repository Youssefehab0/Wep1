using Talab.Models.Entities;
using Talab.Models.ViewModel;

namespace Talab.Repo.IRepo
{
    public interface IRecipeRepo
    {
        public Task<List<Recipe>> GetAllRecipes();
        public Task<Recipe> GetRecipe(int id);
        public Task<RecipesViewModel> GetRecipeById(int id);
        public Task AddRecipe(RecipesViewModel viewModel);
        public Task DeleteRecipe(int id);
        public Task UpdateRecipe(int id ,RecipesViewModel viewModel);

    }
}
