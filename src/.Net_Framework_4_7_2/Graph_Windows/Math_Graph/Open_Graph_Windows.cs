using System;
using System.Collections.Concurrent;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MathNet.Numerics.Statistics;
using Microsoft.Win32;
using ScottPlot;
using DateTime_Waveform_Graph;
using Histogram_Graph;
using MahApps.Metro.Controls;

namespace Math_Waveform_Graph
{
    public partial class Math_Waveform : MetroWindow
    {
        private void Create_Waveform_Window(string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, DateTime[] Measurement_DateTime)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_Waveform Calculate_Waveform = new Math_Waveform(Graph_Owner, Window_Title, Value, Start_Sample, End_Sample, Graph_Title, Y_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count, Measurement_DateTime);
                    Calculate_Waveform.Show();
                    Calculate_Waveform.Closed += (sender2, e2) => Calculate_Waveform.Dispatcher.InvokeShutdown();
                    Dispatcher.Run();
                }));
                Waveform_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.SetApartmentState(ApartmentState.STA);
                Waveform_Thread.IsBackground = true;
                Waveform_Thread.Start();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Math Waveform Window creation failed.", 1);
            }
        }

        private void Create_Histogram_Window(string Window_Title, int Start_Sample, int End_Sample, string Graph_Title, string X_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, DateTime[] Measurement_DateTime, int Buckets, double BarWidth, float BarBorder, bool Curve)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Histogram_Waveform Histogram_Waveform = new Histogram_Waveform(Graph_Owner, Window_Title, Start_Sample, End_Sample, Graph_Title, X_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count, Measurement_DateTime, Buckets, BarWidth, BarBorder, Curve);
                    Histogram_Waveform.Show();
                    Histogram_Waveform.Closed += (sender2, e2) => Histogram_Waveform.Dispatcher.InvokeShutdown();
                    Dispatcher.Run();

                }));
                Waveform_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.SetApartmentState(ApartmentState.STA);
                Waveform_Thread.IsBackground = true;
                Waveform_Thread.Start();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Histogram Window creation failed.", 1);
            }
        }

        //Creates DateTime Math Waveform Windows
        private void Create_Waveform_Window(string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, double[] Measurement_DateTime)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    DateTime_Math_Waveform Calculate_Waveform = new DateTime_Math_Waveform(Graph_Owner, Window_Title, Value, Start_Sample, End_Sample, Graph_Title, Y_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count, Measurement_DateTime);
                    Calculate_Waveform.Show();
                    Calculate_Waveform.Closed += (sender2, e2) => Calculate_Waveform.Dispatcher.InvokeShutdown();
                    Dispatcher.Run();
                }));
                Waveform_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.SetApartmentState(ApartmentState.STA);
                Waveform_Thread.IsBackground = true;
                Waveform_Thread.Start();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("DateTime Math Waveform Window creation failed.", 1);
            }
        }

        private void Plot_Data_in_MathWaveform_DateTime_Button_Click(object sender, RoutedEventArgs e)
        {
            string Window_Title = this.Title.Replace("HP 34401A", "");
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                    double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];

                    for (int i = 0; i < Measurement_Count_Copy; i++)
                    {
                        Measurement_Data_DateTime[i] = this.Measurement_DateTime[i].ToOADate();
                    }

                    Create_Waveform_Window(Window_Title, 0, 0, Measurement_Count_Copy - 1, "", Measurement_Unit, 30, 144, 255, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                    Measurement_Data_Copy = null;
                    Measurement_Data_DateTime = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Cannot create Math Waveform (Date Time X-Axis), try again.", 1);
                }
            });
        }
    }
}
