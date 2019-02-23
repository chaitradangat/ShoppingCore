using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.Customers.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        IAppModel Execute(CustomerModel customerModel);
    }
}