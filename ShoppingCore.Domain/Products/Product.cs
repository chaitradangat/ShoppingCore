using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;


namespace ShoppingCore.Domain.Products
{
   public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProductCategoryId { get; set; }

        public Units Units {get;set;}

        public float Quantity { get; set; }
        public float Price { get; set; }

        public int LocationId { get; set; }
    }
}
