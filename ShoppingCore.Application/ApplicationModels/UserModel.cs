﻿using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class UserModel : IAppModel,IUser
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        
    }
}
