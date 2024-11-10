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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        libraryEntities _context = new libraryEntities();
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public string UserPhone { get; set; }

        public Window3()
        {
            InitializeComponent();
        }


        public void SetMemberData(string name, int age, string phone)
        {
            UserName = name;
            UserAge = age;
            UserPhone = phone;


        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new Member
            {
                member_age = UserAge,
                member_phonenumber = UserPhone,
                name = UserName,
                user_name = user_name.Text,
                password = int.Parse(password.Text),


            };
            _context.Members.Add(user);
            _context.SaveChanges();


            if (password.Text == confirme_password.Text)
            {

                MessageBox.Show("CREADTED ACCOUNT SUCCEFULLY");

               await Task.Delay(5000);

                Window4 window4 = new Window4();
                window4.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("check confirm password ");

            }
        }
    }
}
