﻿using Masterpol.Models;
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

namespace Masterpol.Windows
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public List<partner_products> PartnerProducts { get; set; }
        public MainWindow Window { get; set; }

        public HistoryWindow(partner selectedPartner, MainWindow window)
        {
            InitializeComponent();
            PartnerProducts = selectedPartner.partner_products.ToList();
            Window = window;
            DataContext = this;
        }
    }
}
