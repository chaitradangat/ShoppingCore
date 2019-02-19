using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Users;
using ShoppingCore.Independent.Persistence.EfCore.Interfaces;
using ShoppingCore.Independent.Persistence.Interfaces;


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCore.Independent.Persistence.EfCore.Users
{
    public class Users : IRepository<User>
    {
        protected readonly IEfcoreDatabaseService _efcoredatabase;

        public Users(IEfcoreDatabaseService efcoredatabase)
        {
            _efcoredatabase = efcoredatabase;
        }

        public IQueryable<User> List()
        {
            return _efcoredatabase.Users.AsQueryable();
        }

        public IEntity Find(int UserID)
        {
            return _efcoredatabase.Users.Find(UserID);
        }

        public void Add(User u)
        {
            _efcoredatabase.Users.Add(u);
        }

        public void Update(User u)
        {
            var user = _efcoredatabase.Users.Find(u.UserID);
            user.UserName = u.UserName;
            user.Password = u.Password;
            user.AutheticationType = u.AutheticationType;
            user.CustomerID = u.CustomerID;
            user.IsAutheticated = u.IsAutheticated;
            user.SellerID = u.SellerID;
            user.UserRole = u.UserRole;
        }

        public void Delete(User u)
        {
            _efcoredatabase.Users.Remove(u);
        }
    }
}
