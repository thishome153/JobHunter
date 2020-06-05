using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xb9d8bb5e6df032aa;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.textBox1.Text = TestValues.encodedString;
            this.textBox1.TextWrapping = TextWrapping.Wrap;
            this.textBox2.TextWrapping = TextWrapping.Wrap;
            button1.ToolTip = "ключ 0x0070eafb";
        }


        private void letsGO()
        {
            ushort us = (ushort)TestValues.Key;  //after cast  =  0xeafb   (16bit)   = 60155
            int lenString = TestValues.length;   //1644
            textBox2.Clear();
            textBox2.Text = x1110bdd110cdcea4._xaacba899487bce8c(TestValues.encodedString, TestValues.Key);
            textBox2.Text += string.Concat("\n\n");
            textBox2.Text += string.Join("\n",(xb9d8bb5e6df032aa.SharpeyKnowledge.Main_with_dict()));
            SharpeyKnowledge oint = new SharpeyKnowledge();
            List<int> digits = new List<int>(){0,1,2,3,4,5,6,7,8,9};
            oint.Method1( digits);
            digits.Add(1);
            int salary = 65536;
            oint.Method2( salary);
            salary += 1;
        }
        
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            letsGO();
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = string.Concat(new string[5] {"\n Head hunter job candidate app",
                                                         "\n ....... decoder + matrix.......",
                                                         "\n",
                                                          "\n @2020  home153@mail.ru",
                                                          "\n"});
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            MatrixVisualizer vz = new MatrixVisualizer();
            vz.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MatrixCanvas vz = new MatrixCanvas();
            vz.ShowDialog();
        }
    }
}
