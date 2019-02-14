﻿using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Application.ApplicationModels;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.XDomainFactory;


namespace ShoppingCore.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDatabaseService _database;
        private readonly IDomainFactory _factory;

        public CreateCustomerCommand(IDatabaseService database,IDomainFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CustomerModel customerModel,IUser user = null)
        {
            var customer = customerModel.MorphAppModel(user);

            _database.Customers.Add(customer);

            _database.Save();

        }

        


    }
}
