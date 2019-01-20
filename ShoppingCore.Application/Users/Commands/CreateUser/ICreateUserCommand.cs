using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    interface ICreateUserCommand
    {
        void Execute(CreateUserModel model);
    }
}