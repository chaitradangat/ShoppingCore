using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CustomerModel : IAppModel
    {
        #region -Properties required for new customer creation-
        public int? CustomerID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<CustomerAddressModel> Addresses { get; set; }

        #endregion

        #region -Properties required for new user creation-

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        #endregion

        public CustomerModel()
        {
            Addresses = new HashSet<CustomerAddressModel>();

            UserRole = UserRole.Customer;
        }
    }
}
