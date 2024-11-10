using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace Library_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        libraryEntities _context =new libraryEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string x = "Admin";
            string y = "123";




             if (name.Text == x && passo.Text == y)
            {
              

                Window5 window5 = new Window5();
                window5.Show();
                this.Close();
                
               

            }
            

            string username = name.Text;
            string password = passo.Text;

            
            var usern = _context.Members.FirstOrDefault(u => u.user_name == username && u.password.ToString() == password);

             if (usern != null)
            {

                Window4 window4 = new Window4();
                window4.Show();
                this.Close();

                 
            }
            else
            {
               
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

      
    }
}
