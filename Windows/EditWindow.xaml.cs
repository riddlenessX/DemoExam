using Masterpol.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Masterpol.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : System.Windows.Window
    {
        public partner Partner { get; set; }
        public List<partner_type> PartnerTypes { get; set; }
        public MainWindow Window;

        public EditWindow(partner partner, MainWindow window)
        {
            InitializeComponent();

            this.Window = window;
            DataContext = this;
            Partner = partner;
            PartnerTypes = window.Database.partner_type.ToList();
        }

        public EditWindow(MainWindow window)
        {
            InitializeComponent();

            this.Window = window;
            DataContext = this;
            // Устанавливаем объект партнера и список типов партнера в качестве контекста данных
            PartnerTypes = window.Database.partner_type.ToList();
            Partner = new Models.partner();
            Partner.director = new Models.director();
            Partner.partner_type = PartnerTypes[0];
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверяем, добавлен ли партнер в базу данных
                if (Partner.id == 0) // Если ID равен 0, считаем, что это новый партнер
                {
                    Window.Database.partner.Add(Partner);
                }
                else
                {
                    // Если партнер уже существует, отмечаем его как измененный
                    Window.Database.Entry(Partner).State = EntityState.Modified;
                }

                // Сохраняем изменения в базе данных
                Window.Database.SaveChanges();


                // Закрываем окно с успешным результатом
                MessageBox.Show("Данные успешно сохранены.", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                Window.PartnerPage.LoadPartners();
                Close();
            }
            catch (Exception ex)
            {
                // Обрабатываем ошибку
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
