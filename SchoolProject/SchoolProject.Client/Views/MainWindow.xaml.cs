using System;
using System.Threading;
using System.Windows;
using SchoolProject.Client.Database;

namespace SchoolProject.Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            PrepareDatabase();

            InitializeComponent();

            TopBar.MouseDown += (o, e)  => DragMove();
            CloseBtn.Click += (o, e)    => Close();
            MinBtn.Click += (o, e)      => WindowState = WindowState.Minimized;
        }

        private void PrepareDatabase()
        {

        }
    }
}
