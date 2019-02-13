using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.XDomainFactory
{
    public class DomainFactory : IDomainFactory
    {
        public IEntity<T> GetEntity<T>()
        {
            object objEntity = null;

            if (typeof(T) == typeof(IProduct))
            {
               objEntity =  new Product();
            }
            else if (typeof(T) == typeof(ICustomer))
            {
                objEntity = new Customer();
            }
            else
            {
                objEntity = null;    
            }

            return (IEntity<T>)objEntity;
        }


        

        

    }
}
