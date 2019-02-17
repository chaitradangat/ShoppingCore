using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Customers.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        IAppModel Execute(CustomerModel customerModel);
    }
}
