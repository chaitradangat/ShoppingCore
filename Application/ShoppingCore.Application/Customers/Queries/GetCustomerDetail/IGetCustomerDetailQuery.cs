﻿using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCore.Application.Customers.Queries.GetCustomerDetail
{
    public interface IGetCustomerDetailQuery
    {
        //IAppModel Execute(int CustomerID); #removed

        //this property will be later generalized to CustomerModel or better IAppModel
        //IQueryable<Customer> Execute();

        IQueryable<CustomerModel> Execute();
    }
}
