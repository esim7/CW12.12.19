using Domain;
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

namespace InternetBanking
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public MainWindow Window { get; set; }
        //public Context MyContext { get; set; }
        public Registration(MainWindow window)
        {
            InitializeComponent();
            Window = window;
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox_Password_reg.Password == passwordBox_Password_Copy.Password && textBox_Login_reg.Text != null && textBox_phone.Text != null)
            {
                Client client = new Client();
                client.Login = textBox_Login_reg.Text;
                client.Password = passwordBox_Password_reg.Password;
                client.PhoneNumber = textBox_phone.Text;
                //MyContext.Clients.Add(client);
                Window.Clients.Add(client);
                MessageBox.Show("Вы успешно зарегистрированны");
                Window.frame.Navigate(new Login(Window));
            }
        }

        private void cancel_reg_Click(object sender, RoutedEventArgs e)
        {
            Window.frame.Navigate(new Login(Window));
        }
    }
}
