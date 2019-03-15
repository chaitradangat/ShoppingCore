using ShoppingCore.Application.Interfaces;
using System;
using System.Collections.Generic;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class SellerModel : IAppModel
    {
        public int? SellerID { get; set; }

        public int UserID { get; set; }

        public string BusinessName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
