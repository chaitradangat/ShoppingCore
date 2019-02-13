using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Interfaces
{
    public interface ISeller
    {
         int SellerID { get; set; }

         int UserID { get; set; }

         string BusinessName { get; set; }

         string FirstName { get; set; }

         string MiddleName { get; set; }

         string LastName { get; set; }

         string Gender { get; set; }

         DateTime DateOfBirth { get; set; }

         IList<IProduct> Products { get; set; }
    }
}
