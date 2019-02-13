using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Interfaces
{
   public interface IUser
    {
         int UserID { get; set; }

         string UserName { get; set; }

         string Password { get; set; }

         bool IsAutheticated { get; set; }

         AutheticationType AutheticationType { get; set; }

         UserRole UserRole { get; set; }
    }
}
