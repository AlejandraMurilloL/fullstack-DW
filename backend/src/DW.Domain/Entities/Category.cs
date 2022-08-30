﻿using System;
using System.Collections.Generic;

namespace DW.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string Category1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}