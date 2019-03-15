using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        IEntity Execute(UserModel model);
    }
}