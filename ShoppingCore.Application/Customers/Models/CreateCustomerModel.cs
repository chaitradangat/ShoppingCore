using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Customers.Models
{
    public class CustomerModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
