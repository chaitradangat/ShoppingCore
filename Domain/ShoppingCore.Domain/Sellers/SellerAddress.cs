using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Common;


namespace ShoppingCore.Domain.Sellers
{
    public class SellerAddress : IEntity
    {
        public int SellerAddressID { get; set; }

        public int AddressID { get; set; }

        public int SellerID { get; set; }

        public Address Address { get; set; }

        public Seller Seller { get; set; }
    }
}
