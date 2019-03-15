using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IAddress
    {
        int AddressID { get; set; }

        string AddressLine1 { get; set; }

        string AddressLine2 { get; set; }

        string AddressLine3 { get; set; }

        string AddressLine4 { get; set; }

        string AddressLine5 { get; set; }

        string LandMark { get; set; }

        string City { get; set; }

        string District { get; set; }

        string Country { get; set; }

        string PinCode { get; set; }

        AddressTypeEnum AddressType { get; set; }

        //Product Product { get; set; }

        //Customer Customer { get; set; }
    }
}
