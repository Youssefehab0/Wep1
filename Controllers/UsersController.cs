using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Talab.Models;
using Talab.Models.Entities;
using Talab.Repo.IRepo;

namespace Talab.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _context;

        public UsersController(IUserRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetUsers());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var User = await _context.UserDetails(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( User user)
        {
            await _context.Adduser(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, User user)
        {
            await _context.Updateuser(id, user);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Deleteuser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
