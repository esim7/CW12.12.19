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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public MainWindow Window { get; set; }
        //public ActionWindow ActionWindow { get; set; }
        public Login(MainWindow window)
        {
            InitializeComponent();
            Window = window;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            foreach(var client in Window.Clients)
            {
                if(client.Login == textBox_Login.Text && client.Password == passwordBox_Password.Password)
                {
                    ActionWindow actionWindow = new ActionWindow(Window);
                    Window.frame.Navigate(actionWindow);
                    actionWindow.CurrentClient = client;

                }
                else 
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            Window.frame.Navigate(new Registration(Window));
        }
    }
}
