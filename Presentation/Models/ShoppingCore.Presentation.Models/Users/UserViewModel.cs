using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;
using ShoppingCore.Presentation.Models.Interfaces;

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
    }
}