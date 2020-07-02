using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public static class UserService
    {
        public static User Login(string username, string password)
        {
            return UserRepository
                    .Get(username, 
                        password);
        }
    }
}
