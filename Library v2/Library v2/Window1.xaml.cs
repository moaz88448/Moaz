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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        books_catalog _selctedbook = new books_catalog();
        libraryEntities _context = new libraryEntities();

        public Window1()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            list.ItemsSource = _context.books_catalog.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var books = new books_catalog
            {
                book_id = int.Parse(id.Text),
                book_author = author.Text,
                book_ISBN = ISBN.Text,
                book_subject = subject.Text,
                book_title = title.Text
            };
            _context.books_catalog.Add(books);
            _context.SaveChanges();
            Load();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _selctedbook.book_id = int.Parse(id.Text);
            _selctedbook.book_author = author.Text;
            _selctedbook.book_subject = subject.Text;
            _selctedbook.book_title = title.Text;
            _selctedbook.book_ISBN = ISBN.Text;
            _context.SaveChanges();
            Load();

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (list.SelectedItem is books_catalog selectedBook)
            {
                _selctedbook = list.SelectedItem as books_catalog;
                id.Text = _selctedbook.book_id.ToString();
                author.Text = _selctedbook.book_author;
                title.Text = _selctedbook.book_title;
                ISBN.Text = _selctedbook.book_ISBN;
                subject.Text = _selctedbook.book_subject;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _context.books_catalog.Remove(_selctedbook);
            _context.SaveChanges();
            Load();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window5 window5 =new Window5();
            window5.Show();
            this.Close();
        }
    }
}
