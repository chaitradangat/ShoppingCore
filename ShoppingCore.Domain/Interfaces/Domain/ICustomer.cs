using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Interfaces
{
    public interface ICustomer
    {
        int CustomerID { get; set; }

        int UserID { get; set; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        string Gender { get; set; }

        DateTime? DateOfBirth { get; set; }

        List<Address> Addresses { get; set; }
    }
}
