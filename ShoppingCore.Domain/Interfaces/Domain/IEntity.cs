using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Common
{
    public interface IEntity<T>
    {
        //Id Commented so that each entity wil have a sensible name for Id
        //int Id { get; set; }
    }
}