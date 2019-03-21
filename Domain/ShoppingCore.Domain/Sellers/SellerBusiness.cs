using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Products;

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Sellers
{
    public class SellerBusiness : IEntity
    {
        public int SellerBusinessID { get; set; }

        public string BusinessName { get; set; }
        /*
            Todo: add more business specific fields tax,registration,etc
        */
        public virtual ICollection<Seller> Sellers { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<SellerBusinessAddress> SellerBusinessAddresses { get; set; }

        public SellerBusiness()
        {
            SellerBusinessAddresses = new HashSet<SellerBusinessAddress>();

            Products = new HashSet<Product>();

            Sellers = new HashSet<Seller>();
        }
    }
}