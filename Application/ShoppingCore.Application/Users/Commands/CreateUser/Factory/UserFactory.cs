using ShoppingCore.Domain.Users;

namespace ShoppingCore.Application.Users.Commands.CreateUser.Factory
{
    public class UserFactory : IUserFactory
    {
        public User Create(string username, string password)
        {
            User u = new User();
            u.UserName = username;
            u.Password = password;
            return u;
        }
    }
}
