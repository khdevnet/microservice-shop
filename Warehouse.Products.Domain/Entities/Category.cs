using System;
using System.Collections.Generic;

namespace Warehouse.Products.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public Guid ParentId { get; set; }

        public Category Parent { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Category> SubCategeris { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}