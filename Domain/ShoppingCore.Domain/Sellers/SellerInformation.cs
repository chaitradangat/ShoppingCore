using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Sellers
{
    public class SellerInformation : IEntity
    {
        public int SellerInformationID { get; set; }

        public int SellerID { get; set; }

        public string BusinessName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual SellerAddress SellerAddress { get; set; }

        public SellerInformation()
        {
            Users = new HashSet<User>();
        }
    }
}
