using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Customers.Queries.GetAllCustomers
{
    public interface IGetAllCustomers
    {
        IEnumerable<IAppModel> Execute();

        IEnumerable<T> Execute<T>() where T:IAppModel;

    }
}
