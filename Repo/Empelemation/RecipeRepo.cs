using Microsoft.EntityFrameworkCore;
using Talab.Models;
using Talab.Models.Entities;
using Talab.Models.ViewModel;
using Talab.Repo.IRepo;

namespace Talab.Repo.Empelemation
{
    public class RecipeRepo : IRecipeRepo
    {
        private readonly Appdbcontext _context;

        public RecipeRepo(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<List<Recipe>> GetAllRecipes()
        {
            var appdbcontext = _context.Recipe.Include(r => r.Category).Include(r => r.User);
            return await appdbcontext.ToListAsync();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var recipe = await _context.Recipe
                .Include(r => r.Category)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return null;
            }
            return recipe;
        }
        public async Task AddRecipe(RecipesViewModel viewModel)
        {
            Recipe recipe = new Recipe()
            {
                CatId = viewModel.CatId,
                UserId = viewModel.UserId,
                Ingredients = viewModel.Ingredients,
                Instructions = viewModel.Instructions,
                Name = viewModel.Name,
            };
            _context.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipe(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<RecipesViewModel> GetRecipeById(int id)
        {
            if (id == null)
            {
                return null;
            }
            var recipe = await _context.Recipe.FindAsync(id);
            var users = await _context.Users.ToListAsync();
            var cat = await _context.Category.ToListAsync();
            if (recipe == null)
            {
                return null;
            }
            RecipesViewModel viewModel = new RecipesViewModel()
            {
                CatId = recipe.CatId,
                UserId = recipe.UserId,
                Instructions = recipe.Instructions,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients,
                User = users,
                Category = cat,
            };
            return viewModel;
        }

        public async Task UpdateRecipe(int id,RecipesViewModel viewModel)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                recipe.CatId = viewModel.CatId;
                recipe.UserId = viewModel.UserId;
                recipe.Ingredients = viewModel.Ingredients;
                recipe.Instructions = viewModel.Instructions;
                recipe.Name = viewModel.Name;
                _context.Recipe.Update(recipe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
