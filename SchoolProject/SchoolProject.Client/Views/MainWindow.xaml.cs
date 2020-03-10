using SchoolProject.Client.Models.Shop;
using SchoolProject.Client.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolProject.Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TopBar.MouseDown += (o, e)  => DragMove();
            CloseBtn.Click += (o, e)    => Close();
            MinBtn.Click += (o, e)      => WindowState = WindowState.Minimized;

            var categoryList = new CategoryList();
            CategoryList.Content = categoryList;

            categoryList.AddProductCategory(new ShopCategory()
            {
                Id = 1,
                Title = "Test Item",
            });
        }
    }
}
