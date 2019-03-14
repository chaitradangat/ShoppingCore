using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IPersistence<IEntity> _persistence;

        public GetUserQuery(IPersistence<IEntity> persistence)
        {
            _persistence = persistence;
        }

        public IAppModel Execute(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public IAppModel Execute(int UserID)
        {
            throw new NotImplementedException();
        }

        public IAppModel Execute()
        {
            throw new NotImplementedException();
        }

        
    }
}
