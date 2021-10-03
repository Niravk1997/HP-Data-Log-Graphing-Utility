using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using MathNet.Numerics.Statistics;
using Microsoft.Win32;
using ScottPlot;
using Math_Waveform_Graph;
using Histogram_Graph;
using MahApps.Metro.Controls;

namespace DateTime_Waveform_Graph
{
    public partial class DateTime_Math_Waveform : MetroWindow
    {
        //Inserts a message into the output log control
        private void Insert_Log(string Message, int Code)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            SolidColorBrush Color;
            this.Dispatcher.Invoke(DispatcherPriority.ContextIdle, new ThreadStart(delegate
            {
                if (Output_Log.Inlines.Count >= Auto_Clear_Output_Log_Count)
                {
                    Output_Log.Text = String.Empty;
                    Output_Log.Inlines.Clear();
                    Output_Log.Inlines.Add(new Run("[" + date + "]" + " " + "Output Log has been auto cleared. \n") { Foreground = Brushes.Green });
                }
            }));
            string Status = "";
            switch (Code)
            {
                case 0:
                    Status = "[Success]";
                    Color = Brushes.Green;
                    break;
                case 1:
                    Status = "[Error]";
                    Color = Brushes.Red;
                    break;
                case 2:
                    Status = "[Warning]";
                    Color = Brushes.Orange;
                    break;
                case 3:
                    Status = "[Statistics]";
                    Color = Brushes.DodgerBlue;
                    break;
                case 4:
                    Status = "[Math]";
                    Color = Brushes.BlueViolet;
                    break;
                case 5:
                    Status = "[Message]";
                    Color = Brushes.Black;
                    break;
                default:
                    Status = "";
                    Color = Brushes.Magenta;
                    break;
            }
            this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                Output_Log.Inlines.Add(new Run("[" + date + "]" + " " + Status + " " + Message + "\n") { Foreground = Color });
                if (Auto_Scroll.IsChecked == true)
                {
                    Output_Log_Scroll.ScrollToBottom();
                }
                Output_Log_Tab.IsSelected = true;
            }));
        }

        private void Auto_Scroll_Click(object sender, RoutedEventArgs e)
        {
            if (Auto_Scroll.IsChecked == true)
            {
                Insert_Log("Output Log Auto Scroll Enabled.", 0);
            }
            else
            {
                Insert_Log("Output Log Auto Scroll Disabled.", 0);
            }
        }

        private void Auto_Clear_20_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 20);
            Insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = true;
            Auto_Clear_40.IsChecked = false;
            Auto_Clear_80.IsChecked = false;
            Auto_Clear_100.IsChecked = false;
        }

        private void Auto_Clear_40_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 40);
            Insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = false;
            Auto_Clear_40.IsChecked = true;
            Auto_Clear_80.IsChecked = false;
            Auto_Clear_100.IsChecked = false;
        }

        private void Auto_Clear_80_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 80);
            Insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = false;
            Auto_Clear_40.IsChecked = false;
            Auto_Clear_80.IsChecked = true;
            Auto_Clear_100.IsChecked = false;
        }

        private void Auto_Clear_100_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 100);
            Insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = false;
            Auto_Clear_40.IsChecked = false;
            Auto_Clear_80.IsChecked = false;
            Auto_Clear_100.IsChecked = true;
        }

        private void Save_Log_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Graph Output Log_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        datatotxt.WriteLine(String.Join(String.Empty, Output_Log.Inlines.Select(line => line.ContentStart.GetTextInRun(LogicalDirection.Forward))).ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Graph Output Log to text file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Clear_Log_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(delegate
            {
                Output_Log.Text = String.Empty;
                Output_Log.Inlines.Clear();
            }));
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Insert_Log("Please email me if you encounter any bugs or need help.", 5);
            Insert_Log("Email: niravkp97@gmail.com", 5);
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            Insert_Log("Graphing Module 1.0.0", 5);
            Insert_Log("Created by Nirav Patel.", 5);
            Insert_Log("Email: niravkp97@gmail.com", 5);
        }
    }
}