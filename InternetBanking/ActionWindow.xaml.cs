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
    /// Interaction logic for ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Page
    {
        public delegate void SmsReport(string message);
        public event SmsReport Notification;

        public string PhoneNumber { get; set; }
        public string Report { get; set; }

        public TwilioApp TwilioApp { get; set; }
        public Client CurrentClient { get; set; }
        public MainWindow Window { get; set; }
        public ActionWindow(MainWindow window)
        {
            InitializeComponent();
            CurrentClient = new Client();
            TwilioApp = new TwilioApp();
            Window = window;
            Notification += ShowMessage;
            PhoneNumber = CurrentClient.PhoneNumber;
        }

        private void Withdrow_button(object sender, RoutedEventArgs e)
        {
            if (CurrentClient.Cash > 0 && CurrentClient.Cash > int.Parse(textBox_actionSum.Text))
            {
                CurrentClient.Cash -= int.Parse(textBox_actionSum.Text);
                Notification?.Invoke($"C вашего счета было снято {int.Parse(textBox_actionSum.Text)} остаток {CurrentClient.Cash}");
            }
            else
            {
                MessageBox.Show("Недостаточно средст на счету");

            }
        }

        private void add_button(object sender, RoutedEventArgs e)
        {
            CurrentClient.Cash += int.Parse(textBox_actionSum.Text);
            Notification?.Invoke($"Ваш счет был пополнен на  {int.Parse(textBox_actionSum.Text)} баланс {CurrentClient.Cash}");
        }

        private void ShowMessage(string message)
        {
            TwilioApp.SendeReport(CurrentClient.PhoneNumber, message);
        }
    }
}
