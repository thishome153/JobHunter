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
using System.Windows.Threading;
using xb9d8bb5e6df032aa;
namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для MatrixCanvas.xaml
    /// </summary>
    public partial class MatrixCanvas : Window
    {
        bool StopFlag;
            TestLogic tl;
            TestLogicData td;
            Member CapturePosition;
       public const int megabyte = 1048576;

        public MatrixCanvas()
        {
            InitializeComponent();
            tl = new TestLogic();
            td = new TestLogicData();
            CapturePosition = new Member();
            CapturePosition.i = 0;
            CapturePosition.j = 0;
        }

        public void DrawCursoR(System.Windows.Controls.Canvas canvas, Member cursor, System.Windows.Media.SolidColorBrush color, SolidColorBrush bckclr)
        {
            System.Windows.Shapes.Rectangle rct = new Rectangle();
            rct.Stroke = Brushes.LightSlateGray; rct.Width = 25; rct.Height = 25;
            rct.Fill = bckclr;
            rct.StrokeThickness = 1;
            Canvas.SetLeft(rct, cursor.j * 28+5); Canvas.SetTop(rct, cursor.i * 28+5);
            canvas.Children.Add(rct);

            TextBlock CursorText = new TextBlock();
            CursorText.Text = cursor.Value.ToString();
            CursorText.Foreground = color;
            Canvas.SetLeft(CursorText, cursor.j * 28+9); Canvas.SetTop(CursorText, cursor.i * 28+9);
            canvas.Children.Add(CursorText);
        }

        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
            System.Threading.Thread.Sleep(10);

        }

        public object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;

            return null;
        }

/*
        private void ListNumTxtObjects(xb9d8bb5e6df032aa.Matrix matr)
        {
           grid.Columns.Clear();

            for (int j = 0; j < matr.maxj + 1; j++)
            {
                DataGridTextColumn tc = new DataGridTextColumn();
                tc.Binding = new Binding(String.Format("[{0}]", j));
                grid.Columns.Add(tc);
            }


            grid.ItemsSource = tl.Matrix.AsBindingList_();
        }
        */
        private void DrawMatrix(Canvas canvas, xb9d8bb5e6df032aa.Matrix matrix)
        {
            for (int i = 0; i <= 19; i++)
             for (int j = 0; j <= 19; j++)
                    DrawCursoR(canvas, matrix.items[i, j], Brushes.Black, Brushes.White);
        }

        private void FindMaximum()
        {
            StopFlag = false;
            CursoR mult = tl.FindMult(td.table);
            label1.Content = ""; textBox2.Clear();
            textBox2.Text += "\n Таблица 20х20 ";
            textBox2.Text += "\n";

            textBox2.Text += "\n [" + mult.i.ToString() + "," + mult.j.ToString() + "]= " + mult.Value.ToString();
            foreach (Member nb in mult.Neighbors)
                textBox2.Text += "\n [" + nb.i.ToString() + "," + nb.j.ToString() + "]= " + nb.Value.ToString()+"\t\t";
            textBox2.Text += "\n  Наибольшее произведение : " + mult.GetMult().ToString();

            DrawMatrix(canvas1, this.tl.Matrix);
            DrawCursoR(canvas1, mult, Brushes.Yellow, Brushes.LightGray); // maximum cursor
            foreach (Member m in mult.Neighbors)
            {
                DrawCursoR(canvas1, m, Brushes.Red, Brushes.LightGray);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StopFlag = false;
            label1.Content = "";
            DrawMatrix(canvas1, this.tl.Matrix);

            while (! StopFlag)    {
                for (int i = CapturePosition.i; i <= 19; i++)
                {
                    for (int j = CapturePosition.j; j <= 19; j++)
                    {
                      DrawCursoR(canvas1, tl.Matrix.items[i, j], Brushes.Green, Brushes.LightGray); // current  cursor
                      foreach (Member m in tl.Matrix.items[i, j].Neighbors)
                        {
                            DrawCursoR(canvas1, m, Brushes.Red, Brushes.LightGray);
                        }
                        // кто-то память leaks..
                        DateTime mark = DateTime.Now.AddMilliseconds(250);
                          while (DateTime.Now < mark)
                            DoEvents();
                        
                          label1.Content = i.ToString() + ", " + j.ToString() + "  < "+
                                            tl.Matrix.items[i, j].Value.ToString() + "*" +
                                            tl.Matrix.items[i, j].Neighbors[0].Value.ToString() + "*" +
                                            tl.Matrix.items[i, j].Neighbors[1].Value.ToString() + "*" +
                                            tl.Matrix.items[i, j].Neighbors[2].Value.ToString() + "= " +
                                            tl.Matrix.items[i, j].GetMult().ToString()+">";
                          if (StopFlag)
                          {
                              CapturePosition.i = i;
                              CapturePosition.j = j;
                              goto break_;
                          }

                        DrawCursoR(canvas1, tl.Matrix.items[i, j], Brushes.Black, Brushes.White);
                        foreach (Member m in tl.Matrix.items[i, j].Neighbors)
                        {
                            DrawCursoR(canvas1, m, Brushes.Black, Brushes.White);
                        }
                        System.Diagnostics.Process prcs = System.Diagnostics.Process.GetCurrentProcess();
                        statusBar1.Items[0] = "Working set  " +(prcs.WorkingSet64 / megabyte).ToString() + " Mb";
                    }
                    CapturePosition.j = 0;
                    
                }
            }
            break_:   

            ;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (StopFlag == true) { CapturePosition.i = 0; 
                CapturePosition.j = 0;
                FindMaximum();
            }
            StopFlag = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FindMaximum();
        }
        /*
                private void grid_MouseUp(object sender, MouseButtonEventArgs e)
                {


                     for (int i = 0; i <= 19; i++)
                       for (int j = 0; j <= 19; j++)
                          DrawCursoR(canvas1, tl.Matrix.items[i, j], Brushes.Black, Brushes.White);

                     CursoR test = grid.SelectedItem as CursoR;
                     label1.Content = "[" + test.i.ToString() + ", " + test.j.ToString() + "] = " + test.Value.ToString();
                     DrawCursoR(canvas1, test, Brushes.Yellow, Brushes.LightGray); // current cursor
                     foreach (Member m in test.Neigbors)
                     {
                         DrawCursoR(canvas1, m, Brushes.Red, Brushes.LightGray);
                     }
                }
         * * */
    }
 
}
