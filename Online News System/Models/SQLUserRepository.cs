using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        User IUserRepository.Add(User user) 
        {
            context.User.Add(user);
            context.SaveChanges();
            return user;
        }
        User IUserRepository.Update(User user)
        {
            context.User.Update(user);
            context.SaveChanges();
            return user;
        }
        User IUserRepository.hasUser(string Username, string Password)
        {
            return context.User.FirstOrDefault(u => u.Username == Username && u.Password == Password);
        }
        IEnumerable<User> IUserRepository.GetAllUsers()
        {
            return context.User;
        }
        User IUserRepository.GetUser(int Id)
        {
            return context.User.Find(Id);
        }
        User IUserRepository.checkUser(string Username)
        {
            return context.User.FirstOrDefault(u => u.Username == Username);
        }
        User IUserRepository.GetUsername(String name)
        {
            return context.User.FirstOrDefault(u => u.Username == name);
        }
        int IUserRepository.GetId(String name)
        {
            return context.User.FirstOrDefault(u => u.Username == name).Id;
        }

    }
}
