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

namespace Library
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        libraryEntities _context=new libraryEntities();
        public Window2()
        {
            InitializeComponent();
        }
        private void clear()
        {
            age.Text = " ";
            name.Text = " ";
            phonenum.Text = " ";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var member = new Member()
            {
                member_age = int.Parse(age.Text),
                member_name = name.Text,
                member_phonenumber = phonenum.Text,
            };
            _context.Members.Add(member);
            _context.SaveChanges();
            clear();
            

        }
    }
}
