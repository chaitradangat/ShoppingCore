using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;

namespace ShoppingCore.Domain.Sellers
{
    public class Seller : IEntity,ISeller
    {
        public int SellerID { get; set; }

        public User User { get; set; }

        //public int UserID { get; set; }

        public string BusinessName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Product> Products { get; set; }

        public Seller()
        {
            Products = new List<Product>();
        }
    }
}