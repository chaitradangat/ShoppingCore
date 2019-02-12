using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.XDomainFactory
{
    public class DomainFactory
    {
        public IEntity GetEntity(Type type)
        {
            if (type == typeof(IProduct))
            {
                return new Product();
            }
            else
            {
                return null;
            }
        }


        

        

    }
}
