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
using System.Windows.Shapes;
using xb9d8bb5e6df032aa;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для MatrixVisualizer.xaml
    /// </summary>
    public partial class MatrixVisualizer : Window
    {
        TestLogic tl;

        public MatrixVisualizer()
        {
            InitializeComponent();
             tl = new TestLogic();
        }

        private void letsGO_2()
        {
            textBox2.Clear();
            TestLogicData td = new TestLogicData();
            CursoR mult = tl.FindMult(td.table);
            textBox2.Text += "\n Таблица 20х20 ";
            textBox2.Text += "\n";
            ListNumTxtObjects(tl.Matrix);
            textBox2.Text += "\n [" + mult.i.ToString() + "," + mult.j.ToString() + "]= " + mult.Value.ToString();
            foreach (Member nb in mult.Neighbors)
                textBox2.Text += "\n [" + nb.i.ToString() + "," + nb.j.ToString() + "]= " + nb.Value.ToString();
            textBox2.Text += "\n  Наибольшее произведение : " + mult.GetMult().ToString();

            

        }

        private void ListNumTxtObjects(xb9d8bb5e6df032aa.Matrix matr)
        {
            grid.Columns.Clear();
                
                    for (int j = 0; j < matr.maxj+1; j++)
                    {
                        DataGridTextColumn tc = new DataGridTextColumn();
                        tc.Binding = new Binding(String.Format("[{0}]", j));
                        grid.Columns.Add(tc);
                    }
            grid.ItemsSource = tl.Matrix.AsBindingList();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            letsGO_2();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        class MyTable
        {
            public MyTable(int Id, string Vocalist, string Album, int Year)
            {
                this.Id = Id;
                this.Vocalist = Vocalist;
                this.Album = Album;
                this.Year = Year;
            }
            public int Id { get; set; }
            public string Vocalist { get; set; }
            public string Album { get; set; }
            public int Year { get; set; }
        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            List<MyTable> result = new List<MyTable>(3);
            result.Add(new MyTable(1, "Майкл Джексон", "Thriller", 1982));
            result.Add(new MyTable(2, "AC/DC", "Back in Black", 1980));
            result.Add(new MyTable(3, "Bee Gees", "Saturday Night Fever", 1977));
            result.Add(new MyTable(4, "Pink Floyd", "The Dark Side of the Moon", 1973));
            grid.ItemsSource = result;
        }
    }
}
