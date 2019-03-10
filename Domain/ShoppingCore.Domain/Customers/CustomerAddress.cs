using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Common;

namespace ShoppingCore.Domain.Customers
{
    public class CustomerAddress : IEntity
    {
        public int CustomerAddressID { get; set; }

        public int CustomerID { get; set; }

        public int AddressID { get; set; }

        public virtual Address Address { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
