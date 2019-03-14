using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Application.Interfaces;


namespace ShoppingCore.Application.Users.Queries.GetUser
{
    public interface IGetUserQuery
    {
        IAppModel Execute(string UserName, string Password);

        IAppModel Execute(int UserID);

        IAppModel Execute();
    }
}