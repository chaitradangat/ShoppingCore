using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.Customers.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        void Execute(CustomerModel customerModel,IUser user);
    }
}