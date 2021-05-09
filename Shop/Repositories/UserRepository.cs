using System.Collections.Generic;
using System.Linq;
using Shop.Models;

namespace Shop.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password) {
            var users = new List<User>();
            users.Add(new User {Id = 1 , UserName = "Batman", Password = "Batman", Role="Manager"});
            users.Add(new User {Id = 1 , UserName = "Batman", Password = "Batman", Role="Manager"});
            return 
            users.Where(x=>x.UserName.ToLower() == username.ToLower() 
                        && x.Password.ToLower() == password.ToLower())
                    .FirstOrDefault();

            
        }
    }
}