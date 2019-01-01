using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Users
{
    class User : IEntity
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }
    }
}
