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
        //converts a string into a number
        private (bool, double) Text_Num(string text, bool allowNegative, bool isInteger)
        {
            if (isInteger == true)
            {
                bool isValid = int.TryParse(text, out int value);
                if (isValid == true)
                {
                    if (allowNegative == false)
                    {
                        if (value < 0)
                        {
                            return (false, 0);
                        }
                        else
                        {
                            return (true, value);
                        }
                    }
                    else
                    {
                        return (true, value);
                    }
                }
                else
                {
                    return (false, 0);
                }
            }
            else
            {
                bool isValid = double.TryParse(text, out double value);
                if (isValid == true)
                {
                    if (allowNegative == false)
                    {
                        if (value < 0)
                        {
                            return (false, 0);
                        }
                        else
                        {
                            return (true, value);
                        }
                    }
                    else
                    {
                        return (true, value);
                    }
                }
                else
                {
                    return (false, 0);
                }
            }
        }

        private (bool, int, int) TimeDifference_Range()
        {
            (bool isValid_Start, double Start_Value) = Text_Num(Start_TimeDifference_NSamples_TextBox.Text, false, true);
            (bool isValid_End, double End_Value) = Text_Num(End_TimeDifference_NSamples_TextBox.Text, false, true);
            if (isValid_Start == true & isValid_End == true)
            {
                if (Start_Value < End_Value)
                {
                    if (End_Value < Measurement_Count)
                    {
                        return (true, (int)Start_Value, (int)End_Value);
                    }
                    else
                    {
                        Insert_Log("Time Difference End Value must be less than or equal to Total N Samples Captured.", 1);
                        return (false, 0, 0);
                    }
                }
                else
                {
                    Insert_Log("Time Difference Start Value must be less than End Value.", 1);
                    return (false, 0, 0);
                }
            }
            else
            {
                if (isValid_Start == false)
                {
                    Insert_Log("Time Difference Start Value is invalid. Value must be an positive integer.", 1);
                    Start_Histogram_NSamples_TextBox.Text = String.Empty;
                }
                if (isValid_End == false)
                {
                    Insert_Log("Time Difference End Value is invalid. Value must be an positive integer.", 1);
                    End_Histogram_NSamples_TextBox.Text = String.Empty;
                }
                return (false, 0, 0);
            }
        }

        private void Calculate_TimeDifference_NSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool IsValidRange, int StartValue, int EndValue) = TimeDifference_Range();
            if (IsValidRange == true)
            {
                try
                {
                    if (TimeDifference_S_N.IsSelected == true)
                    {
                        TimeSpan duration = DateTime.Parse(Measurement_DateTime[EndValue].ToString()).Subtract(DateTime.Parse(Measurement_DateTime[StartValue].ToString()));
                        Insert_Log("[Start Sample: " + Measurement_DateTime[StartValue].ToString() + ", " + (decimal)Measurement_Data[StartValue] + Measurement_Unit + ", End Sample: " + Measurement_DateTime[EndValue].ToString() + ", " + (decimal)Measurement_Data[EndValue] + Measurement_Unit + "]", 0);
                        Insert_Log("∆ Time Difference between [Start Sample: " + StartValue + ", End Sample: " + EndValue + "] is " + duration.TotalSeconds + " Seconds", 0);
                    }
                    else if (TimeDifference_M_N.IsSelected == true)
                    {
                        TimeSpan duration = DateTime.Parse(Measurement_DateTime[EndValue].ToString()).Subtract(DateTime.Parse(Measurement_DateTime[StartValue].ToString()));
                        Insert_Log("[Start Sample: " + Measurement_DateTime[StartValue].ToString() + ", " + (decimal)Measurement_Data[StartValue] + Measurement_Unit + ", End Sample: " + Measurement_DateTime[EndValue].ToString() + ", " + (decimal)Measurement_Data[EndValue] + Measurement_Unit + "]", 0);
                        Insert_Log("∆ Time Difference between [Start Sample: " + StartValue + ", End Sample: " + EndValue + "] is " + duration.TotalMinutes + " Minutes", 0);
                    }
                    else if (TimeDifference_H_N.IsSelected == true)
                    {
                        TimeSpan duration = DateTime.Parse(Measurement_DateTime[EndValue].ToString()).Subtract(DateTime.Parse(Measurement_DateTime[StartValue].ToString()));
                        Insert_Log("[Start Sample: " + Measurement_DateTime[StartValue].ToString() + ", " + (decimal)Measurement_Data[StartValue] + Measurement_Unit + ", End Sample: " + Measurement_DateTime[EndValue].ToString() + ", " + (decimal)Measurement_Data[EndValue] + Measurement_Unit + "]", 0);
                        Insert_Log("∆ Time Difference between [Start Sample: " + StartValue + ", End Sample: " + EndValue + "] is " + duration.TotalHours + " Hours", 0);
                    }
                }
                catch (Exception)
                {
                    Insert_Log("Time Difference [N Samples]: Calculation failed. Try again.", 1);
                }
            }
        }

        private void Calculate_TimeDifference_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TimeDifference_S_All.IsSelected == true)
                {
                    TimeSpan duration = DateTime.Parse(Measurement_DateTime[(Measurement_Count - 1)].ToString()).Subtract(DateTime.Parse(Measurement_DateTime[0].ToString()));
                    Insert_Log("[Start Sample: " + Measurement_DateTime[0].ToString() + ", " + (decimal)Measurement_Data[0] + Measurement_Unit + ", End Sample: " + Measurement_DateTime[(Measurement_Count - 1)].ToString() + ", " + (decimal)Measurement_Data[(Measurement_Count - 1)] + Measurement_Unit + "]", 0);
                    Insert_Log("∆ Time Difference between [Start Sample: " + 0 + ", End Sample: " + (Measurement_Count - 1) + "] is " + duration.TotalSeconds + " Seconds", 0);
                }
                else if (TimeDifference_M_All.IsSelected == true)
                {
                    TimeSpan duration = DateTime.Parse(Measurement_DateTime[(Measurement_Count - 1)].ToString()).Subtract(DateTime.Parse(Measurement_DateTime[0].ToString()));
                    Insert_Log("[Start Sample: " + Measurement_DateTime[0].ToString() + ", " + (decimal)Measurement_Data[0] + Measurement_Unit + ", End Sample: " + Measurement_DateTime[(Measurement_Count - 1)].ToString() + ", " + (decimal)Measurement_Data[(Measurement_Count - 1)] + Measurement_Unit + "]", 0);
                    Insert_Log("∆ Time Difference between [Start Sample: " + 0 + ", End Sample: " + (Measurement_Count - 1) + "] is " + duration.TotalMinutes + " Minutes", 0);
                }
                else if (TimeDifference_H_All.IsSelected == true)
                {
                    TimeSpan duration = DateTime.Parse(Measurement_DateTime[(Measurement_Count - 1)].ToString()).Subtract(DateTime.Parse(Measurement_DateTime[0].ToString()));
                    Insert_Log("[Start Sample: " + Measurement_DateTime[0].ToString() + ", " + (decimal)Measurement_Data[0] + Measurement_Unit + ", End Sample: " + Measurement_DateTime[(Measurement_Count - 1)].ToString() + ", " + (decimal)Measurement_Data[(Measurement_Count - 1)] + Measurement_Unit + "]", 0);
                    Insert_Log("∆ Time Difference between [Start Sample: " + 0 + ", End Sample: " + (Measurement_Count - 1) + "] is " + duration.TotalHours + " Hours", 0);
                }
            }
            catch (Exception)
            {
                Insert_Log("Time Difference [All Samples]: Calculation failed. Try again.", 1);
            }
        }
    }
}
