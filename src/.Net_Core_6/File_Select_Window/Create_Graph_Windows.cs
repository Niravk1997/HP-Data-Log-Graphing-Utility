using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
using DateTime_Waveform_Graph;
using Math_Waveform_Graph;
using Histogram_Graph;
using MahApps.Metro.Controls;
namespace Data_Log_Graphing_Utility
{
    public partial class File_Select : MetroWindow
    {
        private void Graph_Add_Data_Click(object sender, RoutedEventArgs e)
        {
            Input_Grid.IsEnabled = false;
            if (insertGraphData(FilePath) == true)
            {
                insert_Log("Data has been successfully processed. Graphing now, please wait.", 0);
                Graph_Data();
            }
            else
            {
                Measurement_DateTime.Clear();
                Measurement_Data.Clear();
            }
            Input_Grid.IsEnabled = true;
        }

        private bool insertGraphData(string path)
        {
            Measurement_DateTime.Clear();
            Measurement_Data.Clear();
            string[] line_Parts;
            try
            {
                using (var readFile = new StreamReader(path))
                {
                    string line;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        line_Parts = line.Split(',');

                        bool Overload_Value = Overload_Values.Any(line_Parts[1].Contains);
                        if (Overload_Value == true)
                        {
                            if (Ignore_Overload_option.IsChecked == true)
                            {
                                insert_Log("Not Added. Overload value detected: " + line_Parts[0] + ", " + line_Parts[1], 2);
                            }
                            else
                            {
                                Measurement_DateTime.Add(DateTime.ParseExact(line_Parts[0], "yyyy-MM-dd h:mm:ss.fff tt", null));
                                Measurement_Data.Add(0);
                                insert_Log("Overload value detected: " + line_Parts[0] + ", " + line_Parts[1], 2);
                            }
                        }
                        else
                        {
                            Measurement_DateTime.Add(DateTime.ParseExact(line_Parts[0], "yyyy-MM-dd h:mm:ss.fff tt", null));
                            Measurement_Data.Add(double.Parse(line_Parts[1]));
                        }
                    }
                    return true;
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("File read failed. Try again.", 1);
                Measurement_DateTime.Clear();
                Measurement_Data.Clear();
                return false;
            }
        }

        private void Graph_Data()
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Check();
            if (isValidGraphColor == true)
            {
                double[] Measurement_Data = this.Measurement_Data.ToArray(); //Waveform Array
                int count = Measurement_Data.Count();
                if (Is_DateTime_Checked.IsChecked == true)
                {
                    double[] Measurement_Data_DateTime = new double[count];
                    for (int i = 0; i < count; i++)
                    {
                        Measurement_Data_DateTime[i] = this.Measurement_DateTime[i].ToOADate();
                    }
                    Create_Waveform_Window(FileName, "", 0, 0, count - 1, Graph_Title_text.Text, Graph_Y_axisTitle_text.Text, Value_Red, Value_Green, Value_Blue, Measurement_Data, count, Measurement_Data_DateTime);
                    Measurement_Data_DateTime = null;
                }
                else
                {
                    DateTime[] Measurement_DateTime = this.Measurement_DateTime.ToArray(); //Datetime data for the measurement data
                    Create_Waveform_Window(FileName, "", 0, 0, count - 1, Graph_Title_text.Text, Graph_Y_axisTitle_text.Text, Value_Red, Value_Green, Value_Blue, Measurement_Data, count, Measurement_DateTime);
                }
                this.Measurement_DateTime.Clear();
                this.Measurement_Data.Clear();
                if (Clear_input_fields.IsChecked == true)
                {
                    File_Path.Text = string.Empty;
                    Graph_Title_text.Text = string.Empty;
                    Graph_Y_axisTitle_text.Text = string.Empty;
                }
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    insert_Log("Cannot create Waveform. Check your Graph Color values.", 1);
                    Measurement_DateTime.Clear();
                    Measurement_Data.Clear();
                }
            }
        }

        private void Create_Waveform_Window(string FileName, string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, DateTime[] Measurement_DateTime)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_Waveform Calculate_Waveform = new Math_Waveform(FileName, Window_Title, Value, Start_Sample, End_Sample, Graph_Title, Y_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count, Measurement_DateTime);
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
                insert_Log(Ex.Message, 1);
                insert_Log("Waveform Window creation failed.", 1);
                this.Measurement_DateTime.Clear();
                this.Measurement_Data.Clear();
            }
        }

        //Creates DateTime Math Waveform Windows
        private void Create_Waveform_Window(string FileName, string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, double[] Measurement_DateTime)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    DateTime_Math_Waveform Calculate_Waveform = new DateTime_Math_Waveform(FileName, Window_Title, Value, Start_Sample, End_Sample, Graph_Title, Y_Axis_Label, Red, Green, Blue, Measurement_Data, Measurement_Count, Measurement_DateTime);
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
                insert_Log(Ex.Message, 1);
                insert_Log("DateTime Math Waveform Window creation failed.", 1);
                this.Measurement_DateTime.Clear();
                this.Measurement_Data.Clear();
            }
        }

        private void GraphColor_SetButton_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Check();
            if (isValid == true)
            {
                GraphColor_Preview.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
            }
        }

        private (bool, int, int, int) GraphColor_Check()
        {
            (bool isValid_Red, double Value_Red) = Text_Num(Red_GraphColor_TextBox.Text, false, true);
            (bool isValid_Green, double Value_Green) = Text_Num(Green_GraphColor_TextBox.Text, false, true);
            (bool isValid_Blue, double Value_Blue) = Text_Num(Blue_GraphColor_TextBox.Text, false, true);
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
                        Red_GraphColor_TextBox.Text = string.Empty;
                    }
                    if (Value_Green > 255)
                    {
                        Green_GraphColor_TextBox.Text = string.Empty;
                    }
                    if (Value_Blue > 255)
                    {
                        Blue_GraphColor_TextBox.Text = string.Empty;
                    }
                    insert_Log("Math (N Samples) Graph Color values must be positive integers and must be between 0 and 255.", 1);
                    return (false, 0, 0, 0);
                }
            }
            else
            {
                if (isValid_Red == false)
                {
                    Red_GraphColor_TextBox.Text = string.Empty;
                }
                if (isValid_Green == false)
                {
                    Green_GraphColor_TextBox.Text = string.Empty;
                }
                if (isValid_Blue == false)
                {
                    Blue_GraphColor_TextBox.Text = string.Empty;
                }
                insert_Log("Math (N Samples) Graph Color values must be positive integers and must be between 0 and 255.", 1);
                return (false, 0, 0, 0);
            }

        }

        private void GraphColor_RandomizeButton_Click(object sender, RoutedEventArgs e)
        {
            Random RGB_Value = new Random();
            int Value_Red = RGB_Value.Next(0, 255);
            int Value_Green = RGB_Value.Next(0, 255);
            int Value_Blue = RGB_Value.Next(0, 255);
            Red_GraphColor_TextBox.Text = Value_Red.ToString();
            Green_GraphColor_TextBox.Text = Value_Green.ToString();
            Blue_GraphColor_TextBox.Text = Value_Blue.ToString();
            GraphColor_Preview.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
        }
    }
}
