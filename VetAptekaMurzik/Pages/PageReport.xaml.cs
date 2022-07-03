using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using PrintDialog = System.Windows.Controls.PrintDialog;

namespace VetAptekaMurzik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        /// <summary>
        /// Загрузка со страницей файла с шаблоном отчёта
        /// </summary>
        public PageReport()
        {
            InitializeComponent();
            InputTemplateReport();
        }

        /// <summary>
        /// Метод загрузки в RichTextBox файла с шаблоном отчёта
        /// </summary>
        private void InputTemplateReport()
        {
            string fileName = "../Resources/TemplateReport.txt";
            if (File.Exists(fileName))
            {
                var sr = new StreamReader(fileName, Encoding.UTF8);
                string text = sr.ReadToEnd();
                rtbReport.AppendText(text);
            }
        }

        /// <summary>
        /// Кнопка сохранения текста из RichTextBox'а в файл с выбранным расширением
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveReport_Click(object sender, RoutedEventArgs e)
        {
            string text = new TextRange(rtbReport.Document.ContentStart, rtbReport.Document.ContentEnd).Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|Pdf file (*.pdf)|*.pdf|Word file (*.doc)|*.doc|Csv file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, text);
                Manager.AccountFrame.Navigate(new PageProducts());
                InputTemplateReport();
            }
        }

        /// <summary>
        /// Кнопка печати текста из RichTextBox'а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintReport_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(rtbReport, "Вывод на печать!");
            }
        }
    }
}
