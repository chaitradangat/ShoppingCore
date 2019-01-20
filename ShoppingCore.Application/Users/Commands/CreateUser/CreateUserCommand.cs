using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;

namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    class CreateUserCommand :ICreateUserCommand
    {
        private readonly IDatabaseService _database;
        private readonly IUserFactory _factory;


        public CreateUserCommand(IDatabaseService database,IUserFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CreateUserModel model)
        {
            var user = _factory.Create(model.UserName, model.Password);
            _database.Users.Add(user);
            _database.Save();
        }
    }
}
