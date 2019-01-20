using ShoppingCore.Domain.Users;

namespace ShoppingCore.Application.Users.Commands.CreateUser.Factory
{
    public interface IUserFactory
    {
        User Create(string username,string password);
    }
}