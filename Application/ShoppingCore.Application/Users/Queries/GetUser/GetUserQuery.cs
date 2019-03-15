using System;
using System.Collections.Generic;
using System.Linq;

using ShoppingCore.Utilities.Encryption;
using ShoppingCore.Application.ApplicationModelsMapper;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;




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
            return
            _persistence.Users.List().MapUserModel()
                .Where(u => u.UserName == UserName && u.Password == new Encryption().EncryptString(Password))
                .SingleOrDefault();
        }

        public IAppModel Execute(int UserID)
        {
            return _persistence.Users.Find(UserID).MapEntityToAppModel();
        }

        public IAppModel Execute()
        {
            //dunno what this moethod is doing here :/
            throw new NotImplementedException();
        }

        
    }
}
