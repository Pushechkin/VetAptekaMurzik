using System;
using System.Windows;

namespace VetAptekaMurzik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Загрузка главного окна со страницей авторизации
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new Pages.Auhorization());

        }

        /// <summary>
        /// Кнопка "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {   
            Manager.MainFrame.GoBack();
        }

        /// <summary>
        /// Метод скрывающий кнопку "Назад" когда при нажатие на нее ты не сможешь вернуться на прошлую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
