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
using Microsoft.EntityFrameworkCore;

namespace Masterpol.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnerPage.xaml
    /// </summary>
    public partial class PartnerPage : Page
    {
        MainWindow Window { get; set; }
        List<Models.partner> Partners;
        public PartnerPage(MainWindow window)
        {
            this.Window = window;
            InitializeComponent();
            LoadPartners();
        }

        public void LoadPartners()
        {
            PartnersBlock.Children.Clear();
            Partners = Window.Database.partner.ToList();
            foreach (var partner in Partners)
            {
                Masterpol.Resources.PartnerUserControl PartnerCard = new Resources.PartnerUserControl(partner, Window);
                PartnersBlock.Children.Add(PartnerCard);
            }
        }
    }
}
