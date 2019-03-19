using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Users;

namespace ShoppingCore.Domain.Sellers
{
    public class Seller : IEntity,ISeller
    {
        public int? SellerID { get; set; }

        public int SellerBusinessID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual User User { get; set; } //#seller corresponds to one user

        public virtual SellerBusiness SellerBusiness { get; set; } //#seller belongs to one sellerbusiness

        public virtual ICollection<Product> Products { get; set; } //#seller can sell multiple products

        public virtual ICollection<SellerAddress> SellerAddresses { get; set; } //#seller can have multiple locations

        public Seller()
        {
            Products = new HashSet<Product>();

            SellerAddresses = new HashSet<SellerAddress>();
        }
    }
}