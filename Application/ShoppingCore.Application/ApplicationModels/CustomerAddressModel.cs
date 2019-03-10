using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CustomerAddressModel : IAppModel
    {
        public CustomerAddressModel()
        {

        }

        public int CustomerAddressID { get; set; }

        public int AddressID { get; set; }

        public int CustomerID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string AddressLine5 { get; set; }

        public string LandMark { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }

        public AddressTypeEnum AddressType { get; set; }
    }
}
