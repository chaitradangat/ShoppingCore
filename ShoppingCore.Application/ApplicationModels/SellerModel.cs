﻿using ShoppingCore.Application.Interfaces;
using System;
using System.Collections.Generic;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Application.ApplicationModels
{
    public class SellerModel : IAppModel
    {
        public int SellerID { get; set; }

        public int UserID { get; set; }

        public string BusinessName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<ProductModel> Products { get; set; }

        public IEntity MorphAppModel()
        {
            throw new NotImplementedException();
        }

        public IAppModel MorphDomainModel()
        {
            throw new NotImplementedException();
        }

        public IAppModel ConvertToAppModel()
        {
            throw new NotImplementedException();
        }

        public IEntity ConvertToDomainModel()
        {
            throw new NotImplementedException();
        }
    }
}
