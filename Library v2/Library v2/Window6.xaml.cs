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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        libraryEntities _context = new libraryEntities();
        Member _selecteduser = new Member();
        public Window6()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            list.ItemsSource = _context.Members.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            var user = new Member
            {
                member_age = int.Parse(age.Text),
                name = name.Text,
                member_phonenumber = phone.Text,
                user_name = user_name.Text,
                password = int.Parse(pass.Text)
            };
            _context.Members.Add(user);
            _context.SaveChanges();
            Load();


        }

        private void update_Click_1(object sender, RoutedEventArgs e)
        {
            _selecteduser.name = name.Text;
            _selecteduser.member_age = int.Parse(age.Text);
            _selecteduser.member_phonenumber = phone.Text;
            _selecteduser.user_name= user_name.Text;
            _selecteduser.password=int.Parse(pass.Text);
          
            _context.SaveChanges();
            Load();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem is Member member)
            {
                _selecteduser = (Member)list.SelectedItem;
                name.Text = _selecteduser.name;
                age.Text = _selecteduser.member_age.ToString();
                phone.Text = _selecteduser.member_phonenumber.ToString();
                pass.Text = _selecteduser.password.ToString();
                user_name.Text = _selecteduser.user_name;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selecteduser != null)
            {
                
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    
                    _context.Members.Remove(_selecteduser);
                    _context.SaveChanges();
                    Load();
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            this.Close();
        }
    }
}
