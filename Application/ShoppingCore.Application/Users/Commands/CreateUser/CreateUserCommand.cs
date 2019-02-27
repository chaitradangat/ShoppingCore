using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand :ICreateUserCommand
    {
        private readonly IPersistence<IEntity> _persistence;
        private readonly IUserFactory _factory;


        public CreateUserCommand(IPersistence<IEntity> persistence, IUserFactory factory)
        {
            _persistence = persistence;
            _factory = factory;
        }

        public void Execute(CreateUserModel model)
        {
            var user = _factory.Create(model.UserName, model.Password);

            _persistence.Users.Add(user);
        }
    }
}
