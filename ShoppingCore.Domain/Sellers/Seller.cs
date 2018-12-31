using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;


namespace ShoppingCore.Domain.Sellers
{
    public class Seller : IEntity
    {
        public int SellerId { get; set; }

        public string BusinessName { get; set; }
    }
}