using SchoolProject.Client.Models.Shop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolProject.Client.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CategoryList.xaml
    /// </summary>
    
    using ProductDictionary = ConcurrentDictionary<uint, ShopProduct>;

    public partial class CategoryList : UserControl
    {
        private Dictionary<uint, ShopCategory> Categories = new Dictionary<uint, ShopCategory>();

        public CategoryList()
        {
            InitializeComponent();
        }

        public ShopCategory GetShopCategory(uint categoryId) => Categories[categoryId];
        public ProductDictionary GetProducts(uint categoryId) => Categories[categoryId].GetProducts();
        public void AddProductCategory(ShopCategory category)
        {
            Categories.Add(category.Id, category);
            List.Items.Add(category);
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = (List.SelectedItem as ShopCategory) ?? (List.Items[0] as ShopCategory);
            Console.WriteLine($"Selected : {selectedCategory?.Title}");

            ProductView.Items.Clear();
            foreach (var product in selectedCategory.GetProducts().Values)
                ProductView.Items.Add(product);
        }
    }
}
