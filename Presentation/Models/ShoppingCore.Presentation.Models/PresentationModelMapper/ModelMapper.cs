using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ShoppingCore.Application;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Presentation.Models.Users;


namespace ShoppingCore.Presentation.Models.PresentationModelMapper
{
    public static class ModelMapper
    {
        public static UserViewModel MapToUserViewModel(this UserModel user)
        {
            return
                new UserViewModel
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    Password = user.Password,
                    AutheticationType = user.AutheticationType,
                    UserRole = user.UserRole,
                    IsAutheticated = user.IsAutheticated
                };
        }

    }
}
