using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            string hostName = Dns.GetHostName();
            tbHostName.Text = hostName;
            IPHostEntry ipList = Dns.GetHostEntry(hostName);
            tbIpAdress.Text = "";
            foreach (var a in ipList.AddressList)
            {
                tbIpAdress.Text = tbIpAdress.Text + ((tbIpAdress.Text == "") ? "" : "; ") + a.ToString();
            }
        }

        private void GetIPAdress_Click(object sender, RoutedEventArgs e)
        {
            string hostName = tbHostName.Text;
            if (hostName == "")
            {
                MessageBox.Show("Введите имя хоста!");
                return;
            }
            try
            {
                IPHostEntry ipList = Dns.GetHostEntry(hostName);
                tbIpAdress.Text = "";
                foreach (var a in ipList.AddressList)
                {
                    tbIpAdress.Text = tbIpAdress.Text + ((tbIpAdress.Text == "") ? "" : "; ") + a.ToString();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Сообщение: " + exc.Message);
            }
        }

        private void GetHostName_Click(object sender, RoutedEventArgs e)
        {
            string ipAddress = tbIpAdress.Text;
            if (ipAddress == "")
            {
                MessageBox.Show("Введите IP-адрес!");
                return;
            }
            try
            {
                IPHostEntry ipList = Dns.GetHostEntry(ipAddress);
                tbHostName.Text = ipList.HostName;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Сообщение: " + exc.Message);
            }
        }
    }
}
