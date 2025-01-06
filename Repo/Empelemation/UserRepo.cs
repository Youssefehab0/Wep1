using Microsoft.EntityFrameworkCore;
using Talab.Models;
using Talab.Models.Entities;
using Talab.Repo.IRepo;

namespace Talab.Repo.Empelemation
{
    public class UserRepo : IUserRepo
    {
        private readonly Appdbcontext _context;

        public UserRepo(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> UserDetails(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task Adduser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Deleteuser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(v=>v.UserId==id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
        }



        public async Task Updateuser(int id, User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
