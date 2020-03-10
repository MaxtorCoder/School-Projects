using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Client.Models.Shop
{
    using ProductDictionary = ConcurrentDictionary<uint, ShopProduct>;
    public class ShopCategory
    {
        public uint Id { get; set; }
        public string Title { get; set; }

        private ProductDictionary Products = new ProductDictionary();

        public ProductDictionary GetProducts() => Products;
        public void AddProduct(ShopProduct product) => Products.TryAdd(product.Id, product);
    }
}
