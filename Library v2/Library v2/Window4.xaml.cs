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
using System.Windows.Shapes;

namespace Library_v2
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        books_catalog _selctedbook = new books_catalog();
        libraryEntities1 _context = new libraryEntities1();
        public Window4()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            list.ItemsSource = _context.books_catalog.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("downloaded book succesfully");

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            _selctedbook = (books_catalog)list.SelectedItem;
            bookname.Text = _selctedbook.book_title;
        }
    }
}
