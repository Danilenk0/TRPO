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
    /// Логика взаимодействия для AddList.xaml
    /// </summary>
    public partial class AddList : Window
    {
        public AddList()
        {
            InitializeComponent();
        }
        public static bool Fields(string Name, string Price, string IdCServices)
        {
            bool b = false;
            if (int.Parse(Name)>0)
            {
                if (Price != "")
                {
                    if (int.Parse(IdCServices)>1)
                    {
                        b = true;
                    }
                    else { MessageBox.Show("Срок аренды указывается только цифрами в днях, должен быть не меньше чем 1"); }
                }
                else { MessageBox.Show("в поле название не должно быть пусто"); }
            }
            else { MessageBox.Show("В поле номер должны быть цифры больше 0"); }
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
                workBD.Query($"Insert into list (Name,IdClients,Much) values (N'{Price.Text}',N'{Name.Text}',N'{int.Parse(IdCServices.Text)}')");
                Close();
            }

           
        }
    }
}
