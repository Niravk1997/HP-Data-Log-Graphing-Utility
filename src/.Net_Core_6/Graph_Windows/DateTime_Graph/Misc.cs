
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

        //--------------------------MISC------------------------------//
        private void Clear_All_Text_onPlot_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Clear(typeof(ScottPlot.Plottable.Text));
        }

        private void PlaceTextGraph_Clear_Click(object sender, RoutedEventArgs e)
        {
            Place_Text.Text = string.Empty;
        }

        private void PlaceTextGraphColor_Randomize_Click(object sender, RoutedEventArgs e)
        {
            Random RGB_Value = new Random();
            int Value_Red = RGB_Value.Next(0, 255);
            int Value_Green = RGB_Value.Next(0, 255);
            int Value_Blue = RGB_Value.Next(0, 255);
            PlaceTextRed_GraphColor_TextBox.Text = Value_Red.ToString();
            PlaceTextGreen_GraphColor_TextBox.Text = Value_Green.ToString();
            PlaceTextBlue_GraphColor_TextBox.Text = Value_Blue.ToString();
            PlaceText_GraphColor_Preview.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
        }

        private void PlaceTextGraphColor_SetButton_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, int Value_Red, int Value_Green, int Value_Blue) = PlaceTextGraphColor_Check();
            if (isValid == true)
            {
                PlaceText_GraphColor_Preview.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
            }
        }

        private (bool, int, int, int) PlaceTextGraphColor_Check()
        {
            (bool isValid_Red, double Value_Red) = Text_Num(PlaceTextRed_GraphColor_TextBox.Text, false, true);
            (bool isValid_Green, double Value_Green) = Text_Num(PlaceTextGreen_GraphColor_TextBox.Text, false, true);
            (bool isValid_Blue, double Value_Blue) = Text_Num(PlaceTextBlue_GraphColor_TextBox.Text, false, true);
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
                        PlaceTextRed_GraphColor_TextBox.Text = string.Empty;
                    }
                    if (Value_Green > 255)
                    {
                        PlaceTextGreen_GraphColor_TextBox.Text = string.Empty;
                    }
                    if (Value_Blue > 255)
                    {
                        PlaceTextBlue_GraphColor_TextBox.Text = string.Empty;
                    }
                    Insert_Log("Place Text Graph Color values must be positive integers and must be between 0 and 255.", 1);
                    return (false, 0, 0, 0);
                }
            }
            else
            {
                if (isValid_Red == false)
                {
                    PlaceTextRed_GraphColor_TextBox.Text = string.Empty;
                }
                if (isValid_Green == false)
                {
                    PlaceTextGreen_GraphColor_TextBox.Text = string.Empty;
                }
                if (isValid_Blue == false)
                {
                    PlaceTextBlue_GraphColor_TextBox.Text = string.Empty;
                }
                Insert_Log("Place Text Graph Color values must be positive integers and must be between 0 and 255.", 1);
                return (false, 0, 0, 0);
            }

        }

        //---------------------------------------------------------------
    }
}
