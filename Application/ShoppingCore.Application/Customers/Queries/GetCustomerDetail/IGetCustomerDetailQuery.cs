using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCore.Application.Customers.Queries.GetCustomerDetail
{
    public interface IGetCustomerDetailQuery
    {
        IAppModel Execute(int CustomerID);

        //this property will be later generalized to CustomerModel or better IAppModel
        IQueryable<Customer> Execute();
    }
}
