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
        private void Calculate_Histogram_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {

            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = Histogram_Color_Check();
            (bool isBuckets, double Buckets) = Text_Num(Buckets_TextBox_Histogram_NSamples.Text, false, true);
            (bool isBarWidth, double BarWidth) = Text_Num(BarWidth_TextBox_Histogram_NSamples.Text, false, false);
            (bool isBarThickness, double BarThickness) = Text_Num(BarBorder_TextBox_Histogram_NSamples.Text, false, false);
            if (isValidGraphColor == true & isBuckets == true & isBarWidth == true & isBarThickness)
            {
                if (Buckets > 0)
                {
                    bool Curve = false;
                    if (MeanCurve_CheckBox_Histogram_NSamples.IsChecked == true)
                    {
                        Curve = true;
                    }
                    else
                    {
                        Curve = false;
                    };
                    string Graph_Title = GraphTitle_TextBox_Histogram_NSamples.Text;
                    string X_Axis_Label = XAxisTitle_TextBox_Histogram_NSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            DateTime[] Measurement_Data_DateTime = new DateTime[Measurement_Count_Copy];
                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_DateTime[i] = DateTime.FromOADate(Measurement_DateTime[i]);
                            }

                            Create_Histogram_Window("Histogram Waveform [" + 0 + ", " + Measurement_Count_Copy + "]", 0, Measurement_Count_Copy, Graph_Title, X_Axis_Label, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime, (int)Buckets, BarWidth, (float)BarThickness, Curve);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Histogram Waveform. Try again.", 1);
                        }
                    });
                }
                else 
                {
                    Insert_Log("Histogram [All Samples]: Buckets Value is invalid. Must be a positive integer number.", 1);
                }
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Red_Histogram_TextBox.Text = string.Empty;
                    Green_Histogram_TextBox.Text = string.Empty;
                    Blue_Histogram_TextBox.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Color values are invalid. Set new values between 0 and 255 and try again.", 1);
                }
                if (isBuckets == false)
                {
                    Buckets_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Buckets Value is invalid. Must be a positive integer number.", 1);
                }
                if (isBarWidth == false)
                {
                    BarWidth_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Bar Width is invalid. Must be a positive number.", 1);
                }
                if (isBarThickness == false)
                {
                    BarBorder_TextBox_Histogram_NSamples.Text = string.Empty;
                    Insert_Log("Histogram [All Samples]: Bar Border thickness is invalid. Must be a positive number.", 1);
                }
            }
        }

        private void Histogram_Color_Set_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, int Value_Red, int Value_Green, int Value_Blue) = Histogram_Color_Check();
            if (isValid == true)
            {
                GraphColor_Histogram.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
            }
        }

        private (bool, int, int, int) Histogram_Color_Check()
        {
            (bool isValid_Red, double Value_Red) = Text_Num(Red_Histogram_TextBox.Text, false, true);
            (bool isValid_Green, double Value_Green) = Text_Num(Green_Histogram_TextBox.Text, false, true);
            (bool isValid_Blue, double Value_Blue) = Text_Num(Blue_Histogram_TextBox.Text, false, true);
            if ((isValid_Red == true) & (isValid_Green == true) & (isValid_Blue == true))
            {
                if ((Value_Red <= 255) & (Value_Green <= 255) & (Value_Blue <= 255))
                {
                    return (true, (int)Value_Red, (int)Value_Green, (int)Value_Blue);
                }
                else
                {
                    if (Value_Red > 255)
                    {
                        Red_Histogram_TextBox.Text = string.Empty;
                    }
                    if (Value_Green > 255)
                    {
                        Green_Histogram_TextBox.Text = string.Empty;
                    }
                    if (Value_Blue > 255)
                    {
                        Blue_Histogram_TextBox.Text = string.Empty;
                    }
                    Insert_Log("Histogram Graph Color values must be positive integers and must be between 0 and 255.", 1);
                    return (false, 0, 0, 0);
                }
            }
            else
            {
                if (isValid_Red == false)
                {
                    Red_Histogram_TextBox.Text = string.Empty;
                }
                if (isValid_Green == false)
                {
                    Green_Histogram_TextBox.Text = string.Empty;
                }
                if (isValid_Blue == false)
                {
                    Blue_Histogram_TextBox.Text = string.Empty;
                }
                Insert_Log("Histogram Graph Color values must be positive integers and must be between 0 and 255.", 1);
                return (false, 0, 0, 0);
            }
        }

        private void Histogram_Color_RandomizeButton_Click(object sender, RoutedEventArgs e)
        {
            Random RGB_Value = new Random();
            int Value_Red = RGB_Value.Next(0, 255);
            int Value_Green = RGB_Value.Next(0, 255);
            int Value_Blue = RGB_Value.Next(0, 255);
            Red_Histogram_TextBox.Text = Value_Red.ToString();
            Green_Histogram_TextBox.Text = Value_Green.ToString();
            Blue_Histogram_TextBox.Text = Value_Blue.ToString();
            GraphColor_Histogram.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
        }
    }
}