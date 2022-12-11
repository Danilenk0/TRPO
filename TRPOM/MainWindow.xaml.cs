using System;
using System.Collections.Generic;
using System.Data;
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
using Xceed.Document.NET;
using Xceed.Words.NET;
using Image = Xceed.Document.NET.Image;
using Paragraph = Xceed.Document.NET.Paragraph;

namespace TRPOM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Word.Visibility = Visibility.Collapsed;
            Excel.Visibility = Visibility.Collapsed;
            CL1.Visibility = Visibility.Visible;
            BR2.Visibility = Visibility.Collapsed;
            DBN.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Visible;

            workBD.Select(DB1, "Select Id,FirstName,LastName,SecondName,Age,PassportNum From clients");
            DB1.Visibility = Visibility.Visible;
            DB2.Visibility = Visibility.Collapsed;
            DB3.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Word.Visibility = Visibility.Collapsed;
            Excel.Visibility = Visibility.Collapsed;
            CL1.Visibility = Visibility.Collapsed;
            BR2.Visibility = Visibility.Visible;
            DBN.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Visible;

            workBD.Select(DB2, "Select Id,Name,Price,Description From armor");
            DB1.Visibility = Visibility.Collapsed;
            DB2.Visibility = Visibility.Visible;
            DB3.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Word.Visibility = Visibility.Visible;
            Excel.Visibility = Visibility.Visible;
            CL1.Visibility = Visibility.Collapsed;
            BR2.Visibility = Visibility.Collapsed;
            DBN.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;

            workBD.Select(DB3, "Select IdClients,Name,Much From list");
            DB1.Visibility = Visibility.Collapsed;
            DB2.Visibility = Visibility.Collapsed;
            DB3.Visibility = Visibility.Visible;
        }

       

        private void Search_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            workBD.Select(DB1, $"Select Id,FirstName,LastName,SecondName,Age,PassportNum From clients Where (FirstName LIKE N'{Search.Text}%') OR (LastName LIKE N'{Search.Text}%') OR (SecondName LIKE N'{Search.Text}%') OR (Age LIKE N'{Search.Text}%') OR (PassportNum LIKE N'{Search.Text}%')");
            workBD.Select(DB2, $"Select Id,Name,Price,Description From armor Where (Id LIKE N'{Search.Text}%') OR (Name LIKE N'{Search.Text}%') OR (Price LIKE N'{Search.Text}%') OR (Description LIKE N'{Search.Text}%')");
            workBD.Select(DB3, $"Select IdClient,Name,Much From list Where (IdClient LIKE N'{Search.Text}%') OR (Name LIKE N'{Search.Text}%') OR (Much LIKE N'{Search.Text}%')");

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DB1.SelectedItem != null)
            {
                workBD.Query($"Delete From clients Where Id=N'{((DataRowView)DB1.SelectedItem).Row[0]}'");
                workBD.Select(DB1, $"Select Id,FirstName,LastName,SecondName,Age,PassportNum From clients Where (FirstName LIKE N'{Search.Text}%') OR (LastName LIKE N'{Search.Text}%') OR (SecondName LIKE N'{Search.Text}%') OR (Age LIKE N'{Search.Text}%') OR (PassportNum LIKE N'{Search.Text}%')");
            }
            if (DB2.SelectedItem != null)
            {
                workBD.Query($"Delete From armor Where Id=N'{((DataRowView)DB2.SelectedItem).Row[0]}'");
                workBD.Select(DB2, $"Select Id,Name,Price,Description From armor Where (Id LIKE N'{Search.Text}%') OR (Name LIKE N'{Search.Text}%') OR (Price LIKE N'{Search.Text}%') OR (Description LIKE N'{Search.Text}%')");
            }
            if (DB3.SelectedItem != null)
            {
                workBD.Query($"Delete From list Where IdClients=N'{((DataRowView)DB3.SelectedItem).Row[0]}'");
                workBD.Select(DB3, $"Select IdClients,Name,Much From list Where (IdClients LIKE N'{Search.Text}%') OR (Name LIKE N'{Search.Text}%') OR (Much LIKE N'{Search.Text}%')");
            }
        }

        private void CL1_Click(object sender, RoutedEventArgs e)
        {
            AddClient win1 = new AddClient();
            win1.ShowDialog();
        }

        private void BR2_Click(object sender, RoutedEventArgs e)
        {
            AddArmor win1 = new AddArmor();
            win1.ShowDialog();
        }

        private void DBN_Click(object sender, RoutedEventArgs e)
        {
            AddList win1 = new AddList();
            win1.ShowDialog();
        }

        private void Word_Click(object sender, RoutedEventArgs e)
        {
            if (DB3.SelectedItem != null)
            {
                string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "example.docx";
                string pathImage = AppDomain.CurrentDomain.BaseDirectory + "1.png";

                // создаём документ
                DocX document = DocX.Create(pathDocument);
                document.InsertParagraph("Гостиница «Старый город»                          Форма 3-Г").
                         // устанавливаем шрифт
                         Font("Courier New").
                         // устанавливаем размер шрифта
                         FontSize(12).
                         // устанавливаем цвет

                         // делаем текст жирным
                         Italic().
                         // устанавливаем интервал между символами

                         // выравниваем текст по центру
                         Alignment = Alignment.left;
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph("Город: Гомель                                               Утв. Приказом Минфин. ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph($"Клиент_____________{((DataRowView)DB3.SelectedItem).Row[0]}______{((DataRowView)DB3.SelectedItem).Row[1]}_____________{((DataRowView)DB3.SelectedItem).Row[2]}________").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;

                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;

                // загрузка изображения
                Image image = document.AddImage(pathImage);

                // создание параграфа
                Paragraph paragraph = document.InsertParagraph();
                // вставка изображения в параграф
                paragraph.AppendPicture(image.CreatePicture());
                // выравнивание параграфа по центру
                paragraph.Alignment = Alignment.center;
                paragraph.FontSize(10);

                // сохраняем документ
                document.Save();
            }
            else { MessageBox.Show("Выберите элемент из первой таблицы"); }
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            int count_row = DB3.Items.Count;
            int count_col = DB3.Columns.Count;


            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Open(String.Format(@"{0}\qqq" + ".xlsx", Environment.CurrentDirectory));
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            var Excelcells = ExcelWorkSheet.get_Range("B4", "D" + (2 + count_row).ToString());
            Excelcells.Borders.ColorIndex = 0;
            Excelcells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            Excelcells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            Excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            DataTable dataTable = workBD.Select("Select IdClients,Name,Much From list");


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    DataColumn column = dataTable.Columns[j];
                    /* ExcelApp.Cells[3 + i, 1 + j] = column.ColumnName[j];*/
                    ExcelApp.Cells[4 + i, 2 + j] = dataRow[column].ToString();
                }

            }

            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
