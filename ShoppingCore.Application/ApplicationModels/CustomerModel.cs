﻿
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CustomerModel : IAppModel,ICustomer
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<AddressModel> Addresses { get; set; }

        
    }
}