using System.Windows;
using System.Windows.Controls;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAccount.xaml
    /// </summary>
    public partial class PageAccount : Page
    {
        /// <summary>
        /// Загрузка страницы вместе со страницей PageProducts
        /// </summary>
        public PageAccount()
        {
            InitializeComponent();
            Manager.AccountFrame = AccountFrame;
            AccountFrame.Navigate(new PageProducts());
        }

        /// <summary>
        /// Кнопка перехода на страницу с продуктами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            AccountFrame.Navigate(new PageProducts());
        }

        /// <summary>
        /// Кнопка перехода на страницу с категориями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            AccountFrame.Navigate(new PageCategory());
        }

        /// <summary>
        /// Кнопка перехода на страницу с диаграммами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagram_Click(object sender, RoutedEventArgs e)
        {
            AccountFrame.Navigate(new PageDiagram());
        }

        /// <summary>
        /// Кнопка перехода на страницу с составлением отчётов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            AccountFrame.Navigate(new PageReport());
        }
    }
}
