using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using VetAptekaMurzik.Models;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProductsAddEdit.xaml
    /// </summary>
    public partial class PageProductsAddEdit : Page
    {
        /// <summary>
        /// Присваивание переменной данных БД
        /// </summary>
        private Product _currentProduct = new Product();

        /// <summary>
        /// Загрузка страницы с присваиванием значений
        /// </summary>
        /// <param name="currentProduct"></param>
        public PageProductsAddEdit(Product currentProduct)
        {
            InitializeComponent();
            if (currentProduct != null)
            {
                _currentProduct = currentProduct;
            }

            DataContext = _currentProduct;
        }

        /// <summary>
        /// Кнопка добавления/редактирования товаров с проверкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductsAddEdit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            int num;
            bool isNumPrice = int.TryParse(tbPrice.Text, out num);
            bool isNumQuantity = int.TryParse(tbQuantity.Text, out num);
            bool isNumStorage = int.TryParse(tbQuantity.Text, out num);

            if (tbName.Text != "")
            {
                if (tbPrice.Text != "" && isNumPrice)
                {
                    if (tbQuantity.Text != "" && isNumQuantity)
                    {
                        if (tbId_storage.Text != "" && isNumStorage)
                        {
                            if (string.IsNullOrWhiteSpace(tbName.Text))
                                errors.AppendLine("Укажите название товара");
                            if (Convert.ToInt32(tbPrice.Text) < 1 || Convert.ToInt32(tbPrice.Text) > 10000)
                                errors.AppendLine("Стоимость товара может быть лишь в диапазоне от 1 до 10000");
                            if (Convert.ToInt32(tbQuantity.Text) < 0 || Convert.ToInt32(tbQuantity.Text) > 1000)
                                errors.AppendLine("Количество товара может быть лишь в диапазоне от 1 до 1000");
                            if (string.IsNullOrWhiteSpace(tbId_storage.Text))
                                errors.AppendLine("Укажите склад");
                        }
                        else
                        {
                            errors.AppendLine("Введите числовое значение номера склада");
                        }
                    }
                    else
                    {
                        errors.AppendLine("Введите числовое значение количества");
                    }
                }
                else
                {
                    errors.AppendLine("Введите числовое значение цены");
                }
            }
            else
            {
                errors.AppendLine("Введите название игрушки");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            try
            {
                if (_currentProduct.id_product == 0)
                {
                    VetAptekaMurzikEntities.GetContext().Product.Add(_currentProduct);
                    VetAptekaMurzikEntities.GetContext().SaveChanges();
                    Manager.AccountFrame.Navigate(new PageProducts());
                    MessageBox.Show("Продукт успешно добавлен!");
                }
                else
                {
                    VetAptekaMurzikEntities.GetContext().SaveChanges();
                    Manager.AccountFrame.Navigate(new PageProducts());
                    MessageBox.Show("Продукт успешно изменен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
