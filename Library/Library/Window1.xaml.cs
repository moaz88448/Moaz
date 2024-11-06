using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        books_catalog _selectedbook=new books_catalog();
        public libraryEntities _context=new libraryEntities();

        public Window1()
        {
            InitializeComponent();
            Load();
        }
       
        public void Load()
        {
            list.ItemsSource=_context.books_catalog.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var book = new books_catalog
            {
                book_id=int.Parse(Id.Text),
                book_author=authore.Text,
                book_subject=subject.Text,
                book_title=title.Text,
                book_ISBN=ISBN.Text,


            };
            _context.books_catalog.Add(book);
            _context.SaveChanges();
            Load();
            clear();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _selectedbook.book_id = int.Parse(Id.Text);
            _selectedbook.book_author = authore.Text;
            _selectedbook.book_subject = subject.Text;
            _selectedbook.book_title=title.Text;
            _selectedbook.book_ISBN = ISBN.Text;
            _context.SaveChanges();
            Load();
            clear();



        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedbook=(books_catalog)list.SelectedItem;
            Id.Text = _selectedbook.book_id.ToString();
            title.Text=_selectedbook.book_title;
            ISBN.Text = _selectedbook.book_ISBN;
            authore.Text=_selectedbook.book_author;
            subject.Text=_selectedbook.book_subject;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            _context.books_catalog.Remove(_selectedbook);
            _context.SaveChanges();
           
            clear();
          
        }
        

        private void clear()
        {
            Id.Text = " ";
            authore.Text = " ";
            subject.Text = " ";
            title.Text = " ";
            ISBN.Text = " ";


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow window =new MainWindow();
            window.Show();
            this.Close();
        }

        private void Load_click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
