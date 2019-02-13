using ShoppingCore.Application.ApplicationModels;

namespace ShoppingCore.Application.Customers.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        void Execute(CustomerModel customerModel);
    }
}
