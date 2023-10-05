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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> list = new List<double>();
        List<char> listChar = new List<char>();
        double rezult = 0;
        int item = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string RemoveEnd(string str, int len)
        {
            if (str.Length < len)
            {
                return string.Empty;
            }
            return str.Remove(str.Length - len);
        }
        private bool ElementFind(string s)
        {
            string[] array = new string[s.Length];
            bool Nofind = true;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == ',')
                {
                    Nofind = false;
                }
            }
            return Nofind;
        }
        private void textblockUp(Button b)
        {
            if (TextBlock1.Text == "" || TextBlock1.Text.LastIndexOf(",") == TextBlock1.Text.Length - 1) { }
            else
            {
                listChar.Add(Convert.ToChar(b.Content));
                list.Add(Convert.ToDouble(TextBlock1.Text));
                TextBlock1.Text = "";
                item++;
            }
        }
        private void btn_zap_Click(object sender, RoutedEventArgs e)
        {
            if(ElementFind(TextBlock1.Text))
            TextBlock1.Text += ",";
        }
        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            textblockUp(B);
        }
        private void btn_ch_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            TextBlock1.Text += B.Content.ToString();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            string text = TextBlock1.Text;
            text = RemoveEnd(text, 1);
            TextBlock1.Text = text;
        }

        private void btn_c_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            list.Clear();
            listChar.Clear();
            item = 0;
        }

        private void btn_rez_Click(object sender, RoutedEventArgs e)
        {
            list.Add(Convert.ToDouble(TextBlock1.Text));
            TextBlock1.Text = "";
            rezult = list[0];
            for(int i = 0; i < item; i++)
            {
                switch (listChar[i])
                {
                    case '+':
                        rezult = rezult + list[i + 1];
                        break;
                    case '-':
                        rezult = rezult - list[i + 1];
                        break;
                    case '/':
                        rezult = rezult / list[i + 1];
                        break;
                    case 'x':
                        rezult = rezult * list[i + 1];
                        break;
                    default:
                        break;
                }
            }
            TextBlock1.Text = rezult.ToString();
            item = 0;
            list.Clear();
            listChar.Clear();
        }
    }
}
