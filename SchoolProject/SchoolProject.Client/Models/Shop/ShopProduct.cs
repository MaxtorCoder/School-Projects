using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Client.Models.Shop
{
    public class ShopProduct
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte Quantity { get; set; }
    }
}
