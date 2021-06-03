using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lastSelected = -10;
        Boolean forward = true;

        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;


        }
        public void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            int columnIndex = uxGrid.Columns.IndexOf(headerClicked.Column);

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();

            if (lastSelected == columnIndex)
                forward = !forward;
            else
                forward = true;

            if (columnIndex >= 0)
            {
                if (forward)
                {
                    if (columnIndex == 0)
                    {
                        view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                        //MessageBox.Show("Name sorted forward");
                    }
                    else
                    {
                        view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
                        //MessageBox.Show("Password sorted forward");
                    }
                }
                else
                {
                    if (columnIndex == 0)
                    {
                        view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
                        //MessageBox.Show("Name sorted backwards");
                    }
                    else
                    {
                        view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Descending));
                        //MessageBox.Show("Password sorted backwards");
                    }
                }
                lastSelected = columnIndex;
            }
        }
    }
}
