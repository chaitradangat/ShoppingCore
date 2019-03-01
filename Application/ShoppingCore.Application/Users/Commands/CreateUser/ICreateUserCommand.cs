using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        IEntity Execute(UserModel model);
    }
}