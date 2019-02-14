using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Interfaces
{
    public interface IAppModel
    {
        IEntity MorphAppModel();
    }
}
