using System;

namespace Warehouse.Products.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Sku { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}