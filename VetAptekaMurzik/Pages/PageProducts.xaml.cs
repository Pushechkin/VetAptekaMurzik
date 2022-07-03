using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VetAptekaMurzik.Models;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        /// <summary>
        /// Загрузка страницы вместе с данными о продуктах
        /// </summary>
        public PageProducts()
        {
            InitializeComponent();
            DGridProducts.ItemsSource = VetAptekaMurzikEntities.GetContext().Product.ToList();
        }

        /// <summary>
        /// Кнопка редактирования продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            Manager.AccountFrame.Navigate(new PageProductsAddEdit(product));
        }

        /// <summary>
        /// Запуск метода для выбора товара только определенной категории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBoxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        /// <summary>
        /// Запуск метода для поиска определенных товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        /// <summary>
        /// Метод позволяющий искать товары по имени и категории
        /// </summary>
        public void Update()
        {
            var products = VetAptekaMurzikEntities.GetContext().Product.ToList();

            switch (CBoxCategories.SelectedIndex)
            {
                case 0:
                    products = products.ToList();
                    break;
                case 1:
                    products = products.Where(p => Convert.ToString(p.id_category).Contains("A")).ToList();
                    break;
                case 2:
                    products = products.Where(p => Convert.ToString(p.id_category).Contains("B")).ToList(); break;
                case 3:
                    products = products.Where(p => Convert.ToString(p.id_category).Contains("C")).ToList(); break;
            }

            products = products.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower())).ToList();

            DGridProducts.ItemsSource = products;
        }

        /// <summary>
        /// Кнопка добавления товара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.AccountFrame.Navigate(new PageProductsAddEdit(null));
        }

        /// <summary>
        /// Кнопка удаления товара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DGridProducts.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    VetAptekaMurzikEntities.GetContext().Product.RemoveRange(productForRemoving);
                    VetAptekaMurzikEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridProducts.ItemsSource = VetAptekaMurzikEntities.GetContext().Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
