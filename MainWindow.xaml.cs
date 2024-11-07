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

namespace Masterpol
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Models.Database Database = new Models.Database();
        internal Pages.PartnerPage PartnerPage;
        public MainWindow()
        {
            PartnerPage = new Pages.PartnerPage(this);
            InitializeComponent();
            MainFrame.Navigate(PartnerPage);
        }

        private void AddPartner_Click(object sender, RoutedEventArgs e)
        {
            Windows.EditWindow editWindow = new Windows.EditWindow(this);
            editWindow.Show();
        }


    }
}
