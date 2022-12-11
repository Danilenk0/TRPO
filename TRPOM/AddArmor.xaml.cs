using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TRPOM
{
    /// <summary>
    /// Логика взаимодействия для AddArmor.xaml
    /// </summary>
    public partial class AddArmor : Window
    {
        public AddArmor()
        {
            InitializeComponent();
        }

        public static bool Fields(string Name, string Price, string IdCServices)
        {
            bool b = false;
            if ((Name != "") && (NCheck(Name) != -1))
            {

                bool d1 = int.TryParse(Price, out int result1);
                if ((d1 == true) && (Price != "") && (int.Parse(Price) > 15))
                {
                    
                    if (IdCServices != "")
                    {
                        b = true;
                    }
                    else { MessageBox.Show("Поле описание не должно быть пустым"); }
                }
                else { MessageBox.Show("В поле цена вводить только цифры"); }
            }
            else { MessageBox.Show("В поле имя не может быть цифр и длинна должна быть больше 0"); }

            return b;
        }
        public static int NCheck(string text)
        {
            int n = 0;
            if (text.IndexOf("1") == -1)
            {
                if (text.IndexOf("2") == -1)
                {
                    if (text.IndexOf("3") == -1)
                    {
                        if (text.IndexOf("4") == -1)
                        {
                            if (text.IndexOf("5") == -1)
                            {
                                if (text.IndexOf("6") == -1)
                                {
                                    if (text.IndexOf("7") == -1)
                                    {
                                        if (text.IndexOf("8") == -1)
                                        {
                                            if (text.IndexOf("9") == -1)
                                            {
                                                if (text.IndexOf("0") == -1)
                                                {
                                                    n = 0;
                                                }
                                                else { n = -1; }
                                            }
                                            else { n = -1; }
                                        }
                                        else { n = -1; }
                                    }
                                    else { n = -1; }
                                }
                                else { n = -1; }
                            }
                            else { n = -1; }
                        }
                        else { n = -1; }
                    }
                    else { n = -1; }
                }
                else { n = -1; }
            }
            else { n = -1; }


            return n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Fields(Name.Text, Price.Text, IdCServices.Text) == true)
            {
                workBD.Query($"Insert into armor (Price,Name,Description) values (N'{Price.Text}',N'{Name.Text}',N'{IdCServices.Text}')");
                Close();

            }

           
        }
    }
}
