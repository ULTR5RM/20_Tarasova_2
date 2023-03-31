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
using _20_Tarasova_2.Entity;

namespace _20_Tarasova_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities m = new Entities();
        Entities n = Helper.getContext();
        public MainWindow()
        {
            InitializeComponent();
        }
        public string[] SortingList { get; set; } =
        {
            "Без сортировки",
            "Сортировка по возрастанию",
            
        };

        public string[] FilterList { get; set; } =
        {
            "Все",
            "09.02.07 Информационные системы и программирование"

        };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from Teachers in m.Teachers select new { Teachers.IdTeachers, Teachers.LastName, Teachers.FirstName, Teachers.Patronymic, Teachers.IdStatusTeachers, Teachers.IdRole, Teachers.IdSpeciality };
            UsersGrid.ItemsSource = query.ToList();

            //UsersGrid.ItemsSource =  APPconnect.Model1.Teachers.ToList();
        }

        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            var result = Entities.GetContext().Teachers.ToList();

            switch (cmbSorting.SelectedIndex)
            {
                case 1:
                    result = result.OrderBy(p => p.IdSpeciality).ToList();
                    break;
                case 2:
                    result = result.OrderByDescending(p => p.IdSpeciality).ToList();
                    break;
            }

            switch (cmbFilter.SelectedIndex)
            {
                case 1:
                    result = result.Where(p => p.IdSpeciality >= 0 && p.IdSpeciality < 15).ToList();
                    break;
           
                case 2:
                    result = result.Where(p => p.IdSpeciality>= 1).ToList();
                    break;
            }
            result = result.Where(p => p.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            UsersGrid.ItemsSource = result;

            txtResultAmount.Text = result.Count.ToString();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
