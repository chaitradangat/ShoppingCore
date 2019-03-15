using ShoppingCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Sellers
{
    public class SellerAddress
    {
        public int SellerAddressID { get; set; }

        public int AddressID { get; set; }

        public int SellerInformationID { get; set; }

        public int SellerID { get; set; }


        public SellerInformation SellerInformation { get; set; }

        public Address Address { get; set; }



    }
}
