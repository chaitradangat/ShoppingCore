using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Users;
using ShoppingCore.Persistence.EfCore.Interfaces;
using ShoppingCore.Application.Interfaces;


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCore.Persistence.EfCore.Users
{
    public class UserRepository : IRepository<User>
    {
        protected readonly IEfcoreDatabaseService _efcoredatabase;

        public UserRepository(IEfcoreDatabaseService efcoredatabase)
        {
            _efcoredatabase = efcoredatabase;
        }

        public IQueryable<User> List()
        {
            return _efcoredatabase.Users as IQueryable<User>;
        }

        public IEntity Find(int UserID)
        {
            return _efcoredatabase.Users.Find(UserID);
        }

        public void Add(User user)
        {
            _efcoredatabase.Users.Add(user);
        }

        public void Update(User user)
        {
            //optimize this code..
            var _user = _efcoredatabase.Users.Find(user.UserID);

            if (_user != null)
            {
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.AutheticationType = user.AutheticationType;
                _user.CustomerID = user.CustomerID;
                _user.IsAutheticated = user.IsAutheticated;
                _user.SellerID = user.SellerID;
                _user.UserRole = user.UserRole;
                _efcoredatabase.Users.Update(_user);
            }
            else
            {
                throw new Exception("Error Updating " + nameof(User) +" Entity");
            }
            
        }

        public void Delete(User user)
        {
            try
            {
                _efcoredatabase.Users.Remove(user);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
