using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VetAptekaMurzik.Models;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCategory.xaml
    /// </summary>
    public partial class PageCategory : Page
    {
        /// <summary>
        /// Загрузка страницы вместе с данными о категории
        /// </summary>
        public PageCategory()
        {
            InitializeComponent();
            DGridCategory.ItemsSource = VetAptekaMurzikEntities.GetContext().Category.ToList();
        }

        /// <summary>
        /// Кнопка редактирования категории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var category = (sender as Button).DataContext as Category;
            Manager.AccountFrame.Navigate(new PageCategoryEdit(category));
        }
    }
}
