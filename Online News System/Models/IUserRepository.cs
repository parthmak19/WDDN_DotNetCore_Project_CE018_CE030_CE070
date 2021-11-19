using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Models
{
   public interface IUserRepository
    {
        User Add(User user);
        User Update(User user);
        User hasUser(string Username, string Password);
        IEnumerable<User> GetAllUsers();
        User GetUser(int Id);

        User checkUser(String Username);
        User GetUsername(String name);
        int GetId(String name);
    }
}
