using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SchoolProject.Client.Models.Shop;

namespace SchoolProject.Client.Database
{
    public class DatabaseHandler
    {
        private const string ConnectionString = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=school";

        private MySqlConnection Connection;
        
        public DatabaseHandler()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        public List<ShopCategory> GetShopCategories()
        {
            var categoryList = new List<ShopCategory>();

            var query = "SELECT * FROM `category`";
            using (var command = new MySqlCommand(query, Connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var shopCategory = new ShopCategory
                    {
                        Id      = reader.GetUInt32("id"),
                        Title   = reader.GetString("name")
                    };
                    categoryList.Add(shopCategory);
                }
                reader.Close();
            }

            return categoryList;
        }

        public List<ShopProduct> GetShopProducts()
        {
            var productList = new List<ShopProduct>();

            var query = "SELECT * FROM `products`";
            using (var command = new MySqlCommand(query, Connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new ShopProduct
                    {
                        Id          = reader.GetUInt32("id"),
                        Title       = reader.GetString("name"),
                        Description = reader.GetString("description"),
                        Price       = reader.GetDouble("price"),
                        Quantity    = reader.GetByte("quantityInStock")
                    };
                    productList.Add(product);
                }
                reader.Close();
            }

            return productList;
        }

        public uint GetCategoryForProduct(uint productId)
        {
            var query = "SELECT * FROM `product_category` WHERE `productId` = @productId";

            using (var command = new MySqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@productId", productId);
                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                    return 0;
                else
                {
                    reader.Read();
                    return reader.GetUInt32("categoryId");
                }
            }
        }
    }
}
