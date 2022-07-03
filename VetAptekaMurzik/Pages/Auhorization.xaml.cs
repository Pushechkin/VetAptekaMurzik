using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VetAptekaMurzik.Models;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auhorization.xaml
    /// </summary>
    public partial class Auhorization : Page
    {
        /// <summary>
        /// Загрузка страницы
        /// </summary>
        public Auhorization()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Вход через БД с записыванием кто и когда заходил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (psbPassword.Password != "" && tbLogin.Text != "")
            {
                VetAptekaMurzikEntities vapmEntities = new VetAptekaMurzikEntities();
                var users = VetAptekaMurzikEntities.GetContext().User.ToList();
                var usersLogin = users.Where(p => p.Login.Equals(tbLogin.Text)).ToList();
                foreach (User userss in users)
                {
                    if (usersLogin.Count == 1)
                    {
                        if (usersLogin[0].Password.Equals(psbPassword.Password))
                        {
                            DateTime local = DateTime.Now;
                            Visit visits = new Visit
                            {
                                id_user = userss.id_user,
                                Data = local
                            };

                            vapmEntities.Visit.Add(visits);
                            vapmEntities.SaveChanges();

                            Manager.MainFrame.Navigate(new PageAccount());
                        }
                        else
                        {
                            MessageBox.Show("Указан неправильный пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Указан неправильный логин!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Действие кнопки когда она не нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPass_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            psbPassword.Password = tbPassword.Text;
            tbPassword.Visibility = Visibility.Hidden;
            psbPassword.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Действие кнопки когда она нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPass_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbPassword.Text = psbPassword.Password;
            tbPassword.Visibility = Visibility.Visible;
            psbPassword.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Кнопка справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpravka_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Логин = «User». Пароль = «12345»", "Данные для входа", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
