﻿using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class UserModel : IAppModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        public IEntity MorphAppModel()
        {
            throw new System.NotImplementedException();
        }

        public IAppModel MorphDomainModel()
        {
            throw new System.NotImplementedException();
        }

        public IAppModel ConvertToAppModel()
        {
            throw new System.NotImplementedException();
        }

        public IEntity ConvertToDomainModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
