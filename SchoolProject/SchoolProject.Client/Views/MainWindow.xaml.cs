using SchoolProject.Client.Database;
using SchoolProject.Client.Views.UserControls;
using System.Windows;

namespace SchoolProject.Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CategoryList categoryList = new CategoryList();

        public MainWindow()
        {
            PrepareDatabase();

            InitializeComponent();

            TopBar.MouseDown += (o, e)  => DragMove();
            CloseBtn.Click += (o, e)    => Close();
            MinBtn.Click += (o, e)      => WindowState = WindowState.Minimized;

            CategoryList.Content = categoryList;
            categoryList.List.SelectedIndex = 0;
        }

        private void PrepareDatabase()
        {
            var database = new DatabaseHandler();

            foreach (var category in database.GetShopCategories())
                categoryList.AddProductCategory(category);

            foreach (var product in database.GetShopProducts())
            {
                var categoryId = database.GetCategoryForProduct(product.Id);
                categoryList.GetShopCategory(categoryId).AddProduct(product);
            }
        }
    }
}
