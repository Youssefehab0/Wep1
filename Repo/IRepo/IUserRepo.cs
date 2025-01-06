using Talab.Models.Entities;

namespace Talab.Repo.IRepo
{
    public interface IUserRepo
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUserById(int id);
        public Task<User> UserDetails(int id);
        public Task Adduser (User user);
        public Task Updateuser (int id,User user);
        public Task Deleteuser (int id);
    }
}
