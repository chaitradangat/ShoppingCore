using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Interfaces;
//using ShoppingCore.Presentation.Models;

namespace ShoppingCore.Presentation.Models.Users
{
    public class UserViewModel : IPresentationModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        public UserViewModel()
        {

        }

        public static implicit operator UserViewModel(UserModel user)
        {
            return new UserViewModel {

                UserID = user.UserID,
                UserName = user.UserName,
                Password = user.Password,
                AutheticationType = user.AutheticationType,
                UserRole = user.UserRole,
                IsAutheticated = user.IsAutheticated

            }; 
        }

        //https://github.com/dotnet/roslyn/issues/30824

        //public static implicit operator IQueryable<UserViewModel>(IQueryable<UserModel> users)
        //{
        //    return null;
        //}

    }
}