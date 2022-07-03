using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using VetAptekaMurzik.Models;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCategoryEdit.xaml
    /// </summary>
    public partial class PageCategoryEdit : Page
    {
        /// <summary>
        /// Присваивание переменной данных БД
        /// </summary>
        private Category _currentCategory = new Category();

        /// <summary>
        /// Загрузка страницы с присваиванием значений
        /// </summary>
        /// <param name="currentCategory"></param>
        public PageCategoryEdit(Category currentCategory)
        {
            InitializeComponent();
            if (currentCategory != null)
            {
                _currentCategory = currentCategory;
            }

            DataContext = _currentCategory;
        }

        /// <summary>
        /// Кнопка сохранения редактирования категории с проверкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategoryEdit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            int num;
            bool isNum = int.TryParse(tbPercent.Text, out num);

            if (tbPercent.Text != "" && isNum)
            {
                if (Convert.ToInt32(tbPercent.Text) < 1 || Convert.ToInt32(tbPercent.Text) > 100)
                    errors.AppendLine("Процент может быть лишь в диапазоне от 1 до 100");
            }
            else 
            {
                errors.AppendLine("Введите числовое значение процента");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                VetAptekaMurzikEntities.GetContext().SaveChanges();
                Manager.AccountFrame.Navigate(new PageCategory());
                MessageBox.Show("Процент успешно изменен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
