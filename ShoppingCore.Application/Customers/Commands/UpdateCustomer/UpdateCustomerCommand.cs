using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;

using System;
using System.Collections.Generic;
using System.Text;


namespace ShoppingCore.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        protected readonly IDatabaseService _database;

        public UpdateCustomerCommand(IDatabaseService database)
        {
            _database = database;
        }

        public IAppModel Execute(CustomerModel customerModel)
        {
            //assign the entity
            customerModel._entity = _database.Customers.Find(customerModel.CustomerID);

            customerModel.ConvertToDomainModel();

            _database.Customers.Update(customerModel._entity);

            _database.Save();

            return customerModel;
        }

    }
}
