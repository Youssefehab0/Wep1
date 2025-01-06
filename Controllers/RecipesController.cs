using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Talab.Models;
using Talab.Models.Entities;
using Talab.Models.ViewModel;
using Talab.Repo.IRepo;

namespace Talab.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeRepo _context;
        private readonly Appdbcontext db;
        private readonly IUserRepo _userRepo;


        public RecipesController(IRecipeRepo context, Appdbcontext db , IUserRepo userRepo)
        {
            _context = context;
            this.db = db;
            this._userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllRecipes());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var rec = await _context.GetRecipe(id);
            return View(rec);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var User = await _userRepo.GetUsers();
            var cat = db.Category.ToList();
            RecipesViewModel recipesViewModel = new RecipesViewModel()
            {
                User = User,
                Category = cat
            };
            return View(recipesViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RecipesViewModel viewModel)
        {
            await _context.AddRecipe(viewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _context.GetRecipeById(id);
            return View(recipe);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, RecipesViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }
            await _context.UpdateRecipe(id,viewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var rec = await _context.GetRecipe(id);
            return View(rec);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteRecipe(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
