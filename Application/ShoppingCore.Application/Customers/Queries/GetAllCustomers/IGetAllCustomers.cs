using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCore.Application.Customers.Queries.GetAllCustomers
{
    public interface IGetAllCustomers
    {
        //IEnumerable<IAppModel> Execute();

        //IEnumerable<T> Execute<T>() where T:IAppModel;

        IQueryable<CustomerModel> Execute();

    }
}
