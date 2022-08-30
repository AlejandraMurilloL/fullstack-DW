using System;
using System.Collections.Generic;

namespace DW.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
