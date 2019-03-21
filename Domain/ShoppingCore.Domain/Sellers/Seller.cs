using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Users;

using System;
using System.Collections.Generic;

namespace ShoppingCore.Domain.Sellers
{
    public class Seller : IEntity,ISeller
    {
        //Keys
        public int? SellerID { get; set; }

        public int UserID { get; set; }

        public int SellerBusinessID { get; set; }

        
        //properties
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }


        //navigation properties
        public virtual User User { get; set; }

        public virtual SellerBusiness SellerBusiness { get; set; }

        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }

        
        //ctor
        public Seller()
        {
            SellerAddresses = new HashSet<SellerAddress>();
        }
    }
}