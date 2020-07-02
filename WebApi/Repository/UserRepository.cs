using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Username = "pai",
                    Password = "123",
                    Role = "pais"
                },
                new User()
                {
                    Id = 1,
                    Username = "filho",
                    Password = "123",
                    Role = "filhos"
                }
            };

            return users.FirstOrDefault(c => c.Username.ToLower() == username.ToLower() && c.Password == password);
        }
    }
}
