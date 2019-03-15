using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Interfaces;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.ApplicationModels;


namespace ShoppingCore.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand :ICreateUserCommand
    {
        private readonly IPersistence<IEntity> _persistence;

        private readonly IDomainFactory _factory;

        public CreateUserCommand(IPersistence<IEntity> persistence, IDomainFactory factory)
        {
            _persistence = persistence;

            _factory = factory;
        }

        public IEntity Execute(UserModel model)
        {
            ValidateUserModel(model);

            var user = ConvertToDomainModel(model) as User;

            _persistence.Users.Add(user);

            return user;
        }

        private IEntity ConvertToDomainModel(UserModel userModel)
        {
           var user =  (User)_factory.GetEntity<IUser>();

            user.UserName = userModel.UserName;

            user.Password = userModel.Password;

            user.UserRole = userModel.UserRole;

            user.IsAutheticated = userModel.IsAutheticated;

            user.AutheticationType = userModel.AutheticationType;

            return user;
        }

        private IAppModel ConvertToAppModel(IEntity entity)
        {
            var user = entity as User;

            var userModel = new UserModel() {
                AutheticationType = user.AutheticationType,
                IsAutheticated = user.IsAutheticated,
                UserName = user.UserName,
                Password = user.Password,
                UserRole = user.UserRole,
                UserID = user.UserID
            };

            return userModel;
        }

        //this method is used for most of business constraints and logic
        private void ValidateUserModel(UserModel model)
        {
            var user = _persistence.Users.List().Where(u => u.UserName == model.UserName).FirstOrDefault();

            if (user != null)
            {
                throw new Exception(string.Format("User with username {0} already exists",model.UserName));
            }
        }
    }
}
