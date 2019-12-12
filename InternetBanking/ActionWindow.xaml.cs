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
        public Func <string, string, bool> ReportSender;

        public TwilioApp TwilioApp { get; set; }
        public Client CurrentClient { get; set; }
        public MainWindow Window { get; set; }
        public ActionWindow(MainWindow window)
        {
            InitializeComponent();
            CurrentClient = new Client();
            Window = window;
            ReportSender = new Func<string, string, bool>(ShowMessage);
        }

        private void Withdrow_button(object sender, RoutedEventArgs e)
        {
            if (CurrentClient.Cash > 0 && CurrentClient.Cash > int.Parse(textBox_actionSum.Text))
            {
                CurrentClient.Cash -= int.Parse(textBox_actionSum.Text);
                string report = $"C вашего счета было снято {int.Parse(textBox_actionSum.Text)} остаток {CurrentClient.Cash}";
                ReportSender.BeginInvoke(CurrentClient.PhoneNumber, report, Result, null);
            }
            else
            {
                MessageBox.Show("Недостаточно средст на счету");
            }
        }

        private void Add_button(object sender, RoutedEventArgs e)
        {
            CurrentClient.Cash += int.Parse(textBox_actionSum.Text);
            string report = $"Ваш счет был пополнен на  {int.Parse(textBox_actionSum.Text)} баланс {CurrentClient.Cash}";
            ReportSender.BeginInvoke(CurrentClient.PhoneNumber, report, Result, null);
        }

        private void Result(IAsyncResult result)
        {
            var processResult = ReportSender.EndInvoke(result);
            if (processResult == true)
            {
                MessageBox.Show("Транзакция проведена успешно");
            }
            else
            {
                MessageBox.Show("Ошибка в проведении транзакции");
            }
        }

        private bool ShowMessage(string phoneNumber, string message)
        {
            var TwilioApp = new TwilioApp(phoneNumber, message);
            return true; 
        }
    }
}
