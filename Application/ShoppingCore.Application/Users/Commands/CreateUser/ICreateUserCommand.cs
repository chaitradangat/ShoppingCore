using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        void Execute(CreateUserModel model);
    }
}