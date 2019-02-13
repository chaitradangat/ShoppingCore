using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Common;

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

        IProduct Product { get; set; }

        ICustomer Customer { get; set; }
    }
}
