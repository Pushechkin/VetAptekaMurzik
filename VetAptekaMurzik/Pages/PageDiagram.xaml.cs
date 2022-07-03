using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using VetAptekaMurzik.Models;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDiagram.xaml
    /// </summary>
    public partial class PageDiagram : Page
    {

        /// <summary>
        /// Загрузка страницы с присваиванием значений
        /// </summary>
        public PageDiagram()
        {
            InitializeComponent();
            ChartPayments.ChartAreas.Add(new ChartArea("Main"));

            var currentSeries = new Series("Payments")
            {
                IsValueShownAsLabel = true
            };
            ChartPayments.Series.Add(currentSeries);

            UpdateChart();
        }

        /// <summary>
        /// Цикл, где выбирается начало даты и конец даты и подсчитывается количество услуг в этом диапазоне, обрабатывание данных диаграммы
        /// </summary>
        private void UpdateChart()
        {
            Series currentSeries = ChartPayments.Series.FirstOrDefault();
            currentSeries.ChartType = SeriesChartType.Pie;
            currentSeries.Points.Clear();

            var writeDB = VetAptekaMurzikEntities.GetContext().ExpenditureInvoice.Where(p => p.Data >= dpStart.SelectedDate
                && p.Data <= dpEnd.SelectedDate).ToList();
            var writes = writeDB.GroupBy(p => p.id_product).Select(group =>
            new
            {
                Serv = group.Key,
                CountServ = group.Count()
            }).ToList();

            foreach (var write in writes)
            {
                currentSeries.Points.AddXY(write.Serv.ToString(), write.CountServ);
            }


        }

        /// <summary>
        /// Запуск функции UpdateChart() при изменении значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpStart_CalendarClosed(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateChart();
        }

        /// <summary>
        /// Запуск функции UpdateChart() при изменении значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpEnd_CalendarClosed(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateChart();
        }
    }
}
