using ShoppingCore.Domain.Interfaces;
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

        public virtual ICollection<SellerBusinessAddress> SellerBusinessAddresses { get; set; }

        public SellerBusiness()
        {
            Sellers = new HashSet<Seller>();

            SellerBusinessAddresses = new HashSet<SellerBusinessAddress>();
        }
    }
}