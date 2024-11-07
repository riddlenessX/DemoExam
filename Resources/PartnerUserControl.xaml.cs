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

namespace Masterpol.Resources
{
    /// <summary>
    /// Логика взаимодействия для PartnerUserControl.xaml
    /// </summary>

    public partial class PartnerUserControl : UserControl
    {
        public string PartnerType { get; set; }
        public string PhoneNumber { get; set; }
        public string PartnerName { get; set; }
        public int? Rating { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string DirectorName { get; set; }
        public Models.partner Partner { get; set; }
        public int TotalSales { get; set; }
        public MainWindow Window;

        public PartnerUserControl(Models.partner partner, MainWindow window)
        {
            this.Partner = partner;
            DataContext = this;
            PartnerType = partner.partner_type.name;
            PartnerName = partner.name;
            PhoneNumber = $"+7 {partner.contact_number}";
            Rating = partner.rating;
            DirectorName = $"{partner.director.last_name} {partner.director.first_name} {partner.director.middle_name}";
            TotalSales = partner.CalculateTotalSales();
            DiscountPercentage = CalculateDiscount();
            this.Window = window;
            InitializeComponent();
        }

        public int CalculateDiscount()
        {
            if (TotalSales >= 300000)
            {
                return 15;
            }
            else if (TotalSales >= 50000)
            {
                return 10;
            }
            else if (TotalSales >= 10000)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Windows.EditWindow editWindow = new Windows.EditWindow(Partner, this.Window);
            editWindow.Show();
        }

        private void ShowHistoryButton(object sender, RoutedEventArgs e)
        {
            Windows.HistoryWindow historyWindow = new Windows.HistoryWindow(Partner, this.Window);
            historyWindow.Show();
        }
    }
}
