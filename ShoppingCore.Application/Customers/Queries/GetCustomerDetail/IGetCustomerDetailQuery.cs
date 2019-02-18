using ShoppingCore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Customers.Queries.GetCustomerDetail
{
    public interface IGetCustomerDetailQuery
    {
        IAppModel Execute(int CustomerID);
    }
}
