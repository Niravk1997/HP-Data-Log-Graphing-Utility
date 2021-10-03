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
        //--------------------------- Math (All Samples)----------------------

        private void Addition_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Addition_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Addition_AllSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] + Value;
                            }
                            Create_Waveform_Window("Addition DateTime Math Waveform [All Samples]: Samples + " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Addition (All Samples) (Samples + Value) DateTime Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value + Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Addition DateTime Math Waveform [All Samples]: " + Value + " + Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Addition (All Samples) (Value + Samples) DateTime Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Addition_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Addition (All Samples) DateTime Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Addition (All Samples) DateTime Math Waveform.", 1);
                }
            }
        }

        private void Subtraction_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Subtraction_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Subtraction_AllSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] - Value;
                            }
                            Create_Waveform_Window("Subtraction DateTime Math Waveform [All Samples]: Samples - " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Subtraction (All Samples) (Samples - Value) DateTime Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value - Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Subtraction DateTime Math Waveform [All Samples]: " + Value + " - Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Subtraction (All Samples) (Value - Samples) DateTime Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Subtraction_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Subtraction (All Samples) DateTime Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Subtraction (All Samples) DateTime Math Waveform.", 1);
                }
            }
        }

        private void Multiplication_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Mutiplication_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Multiplication_AllSamples_Samples_Value.IsSelected == true)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Measurement_Data_Copy[i] * Value;
                            }
                            Create_Waveform_Window("Multiplication DateTime Math Waveform [All Samples]: Samples * " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Multiplication (All Samples) (Samples * Value) DateTime Math Waveform. Try again.", 1);
                        }
                    });
                }
                else
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Value * Measurement_Data_Copy[i];
                            }
                            Create_Waveform_Window("Multiplication DateTime Math Waveform [All Samples]: " + Value + " * Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create Multiplication (All Samples) (Value * Samples) DateTime Math Waveform. Try again.", 1);
                        }
                    });
                }
            }
            else
            {
                if (isValid == false)
                {
                    Mutiplication_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Multiplication (All Samples) DateTime Math Waveform. Value's input field must only have numbers.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Multiplication (All Samples) DateTime Math Waveform.", 1);
                }
            }
        }

        private void Division_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Division_TextBox_Math_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Value != 0)
                {
                    if (Division_AllSamples_Samples_Value.IsSelected == true)
                    {
                        string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                        string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                        Task.Run(() =>
                        {
                            try
                            {
                                int Measurement_Count_Copy = Measurement_Count;
                                double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                                double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                                for (int i = 0; i < Measurement_Count_Copy; i++)
                                {
                                    Measurement_Data_Copy[i] = Measurement_Data_Copy[i] / Value;
                                }
                                Create_Waveform_Window("Division DateTime Math Waveform [All Samples]: Samples / " + Value, Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                                Measurement_Data_Copy = null;
                                Measurement_Data_DateTime = null;
                            }
                            catch (Exception Ex)
                            {
                                Insert_Log(Ex.Message, 1);
                                Insert_Log("Cannot create Division (All Samples) (Samples / Value) DateTime Math Waveform. Try again.", 1);
                            }
                        });
                    }
                    else
                    {
                        string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                        string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                        Task.Run(() =>
                        {
                            try
                            {
                                int Measurement_Count_Copy = Measurement_Count;
                                double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                                double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                                Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                                for (int i = 0; i < Measurement_Count_Copy; i++)
                                {
                                    Measurement_Data_Copy[i] = Value / Measurement_Data_Copy[i];
                                    if (double.IsInfinity(Measurement_Data_Copy[i]) == true) //Check is answer is infinite, if yes then set it to 0
                                    {
                                        Measurement_Data_Copy[i] = 0;
                                    }
                                }
                                Create_Waveform_Window("Division DateTime Math Waveform [All Samples]: " + Value + " / Samples", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                                Measurement_Data_Copy = null;
                                Measurement_Data_DateTime = null;
                            }
                            catch (Exception Ex)
                            {
                                Insert_Log(Ex.Message, 1);
                                Insert_Log("Cannot create Division (All Samples) (Value / Samples) DateTime Math Waveform. Try again.", 1);
                            }
                        });
                    }
                }
                else
                {
                    Insert_Log("Cannot create Division (All Samples) (Value / Samples) DateTime Math Waveform." + " Cannot divide by " + Value, 1);
                }
            }
            else
            {
                if (isValid == false)
                {
                    Division_TextBox_Math_AllSamples.Text = String.Empty;
                    Insert_Log("Cannot create Division (All Samples) DateTime Math Waveform. Value's input field must only have numbers, no text.", 1);
                }
                else
                {
                    Insert_Log("Cannot create Division (All Samples) DateTime Math Waveform.", 1);
                }
            }
        }

        private void Percentage_Error_Button_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Percentage_Error_TextBox_AllSamples.Text, true, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true & isValidGraphColor == true)
            {
                if (Value != 0)
                {
                    string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                    string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                    Task.Run(() =>
                    {
                        try
                        {
                            int Measurement_Count_Copy = Measurement_Count;
                            double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                            double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                            Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                            for (int i = 0; i < Measurement_Count_Copy; i++)
                            {
                                Measurement_Data_Copy[i] = Math.Abs((Measurement_Data_Copy[i] - Value) / Value) * 100;
                            }
                            Create_Waveform_Window("% Error DateTime Math Waveform [All Samples]: |(Samples - " + Value + ") / " + Value + "| x 100", Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                            Measurement_Data_Copy = null;
                            Measurement_Data_DateTime = null;
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                            Insert_Log("Cannot create % Error DateTime Math Waveform (All Samples). Try again.", 1);
                        }
                    });
                }
                else
                {
                    Insert_Log("Cannot create % Error DateTime Math Waveform (All Samples): Value must not be " + Value, 1);
                }
            }
            else
            {
                if (isValid == false)
                {
                    Insert_Log("Cannot create % Error DateTime Math Waveform (All Samples). Value must be a real number.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create % Error DateTime Math Waveform (All Samples). Graph Color values are not valid.", 1);
                }
            }
        }

        private void DB_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid_DB_1_Value, double DB_1_Value) = Text_Num(DB_1_Math_AllSamples.Text, true, false);
            (bool isValid_DB_2_Value, double DB_2_Value) = Text_Num(DB_2_Math_AllSamples.Text, false, false);
            (bool isValid_DB_3_Value, double DB_3_Value) = Text_Num(DB_3_Math_AllSamples.Text, false, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid_DB_1_Value == true & isValid_DB_2_Value == true & isValid_DB_3_Value == true & isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = (DB_1_Value) * (Math.Log(((Math.Abs(Measurement_Data_Copy[i])) / DB_3_Value), DB_2_Value));
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("DB (All Samples DateTime Math Waveform): " + DB_1_Value + " x log" + DB_2_Value + " (Samples / " + DB_3_Value + ")", DB_3_Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create DB (All Samples) DateTime Math Waveform. Try again.", 1);
                    }
                });
            }
            else
            {
                if ((isValid_DB_1_Value == false) || (isValid_DB_2_Value == false) || (isValid_DB_3_Value == false))
                {
                    Insert_Log("Cannot create DB (All Samples) DateTime Math Waveform. The base and the argument of the logarithm must be positive. Check your inputted values.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create DB (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void DBM_Button_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid_DBM_1_Value, double DBM_1_Value) = Text_Num(DBM_1_Math_AllSamples.Text, true, false);
            (bool isValid_DBM_2_Value, double DBM_2_Value) = Text_Num(DBM_2_Math_AllSamples.Text, false, false);
            (bool isValid_DBM_3_Value, double DBM_3_Value) = Text_Num(DBM_3_Math_AllSamples.Text, false, false);
            (bool isValid_DBM_4_Value, double DBM_4_Value) = Text_Num(DBM_4_Math_AllSamples.Text, false, false);
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid_DBM_1_Value == true & isValid_DBM_2_Value == true & isValid_DBM_3_Value == true & isValid_DBM_4_Value == true & isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = (DBM_1_Value) * (Math.Log(((((Math.Pow(Measurement_Data_Copy[i], 2)) / DBM_3_Value)) / DBM_4_Value), DBM_2_Value));
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("DBM (All Samples DateTime Math Waveform): " + DBM_1_Value + " x log" + DBM_2_Value + " ((Samples^2 / " + DBM_3_Value + ") / " + DBM_4_Value + ")", DBM_3_Value, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create DBM (All Samples) DateTime Math Waveform. Try again.", 1);
                    }
                });
            }
            else
            {
                if ((isValid_DBM_1_Value == false) || (isValid_DBM_2_Value == false) || (isValid_DBM_3_Value == false) || (isValid_DBM_4_Value == false))
                {
                    Insert_Log("Cannot create DBM (All Samples) DateTime Math Waveform. The base and the argument of the logarithm must be positive. Check your inputted values.", 1);
                }
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create DBM (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Value_Power_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            (bool isValid, double Value) = Text_Num(Value_Power_AllSample_Text.Text, true, false);
            if (isValidGraphColor == true & isValid == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Pow(Value, Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("(Value)^(Samples) DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create (Value)^(Samples) (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create (Value)^(Samples) (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
                if (isValid == false)
                {
                    Insert_Log("Cannot create (Value)^(Samples) (All Samples) DateTime Math Waveform. Check your Value.", 1);
                }
            }
        }

        private void AllSample_Power_Value_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            (bool isValid, double Value) = Text_Num(AllSample_Power_Value_Text.Text, true, false);
            if (isValidGraphColor == true & isValid == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Pow(Measurement_Data_Copy[i], Value);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("(Samples)^(Value) DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create (Samples)^(Value) (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create (Samples)^(Value) (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
                if (isValid == false)
                {
                    Insert_Log("Cannot create (Samples)^(Value) (All Samples) DateTime Math Waveform. Check your Value.", 1);
                }
            }
        }

        private void Log_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Log10(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Logarithm DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Logarithm (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Logarithm (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Ln_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Log(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Natural Logarithm DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Natural Logarithm (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Natural Logarithm (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Square_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Sqrt(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Square Root DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Square Root (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Square Root (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Abs_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            Measurement_Data_Copy[i] = Math.Abs(Measurement_Data_Copy[i]);
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Absolute Value DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Absolute Value (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Absolute Value (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Sine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Sine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Sin(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Sin(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Sine DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Sine (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Sine (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Cosine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Cosine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Cos(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Cos(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Cosine DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Cosine (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Cosine (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Tangent_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Tangent_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Tan(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Tan(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Tangent DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Tangent (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Tangent (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Inverse_Sine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Inverse_Sine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Asin(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Asin(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Inverse Sine DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Sine (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Sine (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Inverse_Cosine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Inverse_Cosine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Acos(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Acos(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Inverse Cosine DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Cosine (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Cosine (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Inverse_Tangent_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Inverse_Tangent_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Atan(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Atan(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Inverse Tangent DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Inverse Tangent (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Inverse Tangent (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Hyperbolic_Sine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Hyperbolic_Sine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Sinh(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Sinh(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Hyperbolic Sine DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Sine (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Sine (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Hyperbolic_Cosine_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Hyperbolic_Cosine_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Cosh(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Cosh(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Hyperbolic Cosine DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Cosine (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Cosine (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void Hyperbolic_Tangent_AllSample_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValidGraphColor, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValidGraphColor == true)
            {
                string Graph_Title = GraphTitle_TextBox_Math_AllSamples.Text;
                string Y_Axis_Title = YAxis_TextBox_Math_AllSamples.Text;
                bool inDegrees = Hyperbolic_Tangent_AllSample_Degrees.IsSelected;
                Task.Run(() =>
                {
                    try
                    {
                        int Measurement_Count_Copy = Measurement_Count;
                        double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);

                        double[] Measurement_Data_DateTime = new double[Measurement_Count_Copy];
                        Array.Copy(Measurement_DateTime, Measurement_Data_DateTime, Measurement_Count_Copy);

                        for (int i = 0; i < Measurement_Count_Copy; i++)
                        {
                            if (inDegrees == true)
                            {
                                Measurement_Data_Copy[i] = (Math.Tanh(Measurement_Data_Copy[i]) * (180 / Math.PI));
                            }
                            else
                            {
                                Measurement_Data_Copy[i] = Math.Tanh(Measurement_Data_Copy[i]);
                            }
                            if (double.IsNaN(Measurement_Data_Copy[i]) || double.IsInfinity(Measurement_Data_Copy[i]))
                            {
                                Measurement_Data_Copy[i] = 0;
                            }
                        }
                        Create_Waveform_Window("Hyperbolic Tangent DateTime Math Waveform [All Samples]", 0, 0, Measurement_Count_Copy - 1, Graph_Title, Y_Axis_Title, Value_Red, Value_Green, Value_Blue, Measurement_Data_Copy, Measurement_Count_Copy, Measurement_Data_DateTime);
                        Measurement_Data_Copy = null;
                        Measurement_Data_DateTime = null;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Cannot create Hyperbolic Tangent (All Samples) DateTime Math Waveform, try again.", 1);
                    }
                });
            }
            else
            {
                if (isValidGraphColor == false)
                {
                    Insert_Log("Cannot create Hyperbolic Tangent (All Samples) DateTime Math Waveform. Check your Graph Color values.", 1);
                }
            }
        }

        private void GraphColor_SetButton_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, int Value_Red, int Value_Green, int Value_Blue) = GraphColor_Math_AllSamples_Check();
            if (isValid == true)
            {
                GraphColor_Preview_Math_AllSamples.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
            }
        }

        private (bool, int, int, int) GraphColor_Math_AllSamples_Check()
        {
            (bool isValid_Red, double Value_Red) = Text_Num(Red_GraphColor_TextBox_Math_AllSamples.Text, false, true);
            (bool isValid_Green, double Value_Green) = Text_Num(Green_GraphColor_TextBox_Math_AllSamples.Text, false, true);
            (bool isValid_Blue, double Value_Blue) = Text_Num(Blue_GraphColor_TextBox_Math_AllSamples.Text, false, true);
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
                        Red_GraphColor_TextBox_Math_AllSamples.Text = string.Empty;
                    }
                    if (Value_Green > 255)
                    {
                        Green_GraphColor_TextBox_Math_AllSamples.Text = string.Empty;
                    }
                    if (Value_Blue > 255)
                    {
                        Blue_GraphColor_TextBox_Math_AllSamples.Text = string.Empty;
                    }
                    Insert_Log("Math (All Samples) Graph Color values must be positive integers and must be between 0 and 255.", 1);
                    return (false, 0, 0, 0);
                }
            }
            else
            {
                if (isValid_Red == false)
                {
                    Red_GraphColor_TextBox_Math_AllSamples.Text = string.Empty;
                }
                if (isValid_Green == false)
                {
                    Green_GraphColor_TextBox_Math_AllSamples.Text = string.Empty;
                }
                if (isValid_Blue == false)
                {
                    Blue_GraphColor_TextBox_Math_AllSamples.Text = string.Empty;
                }
                Insert_Log("Math (All Samples) Graph Color values must be positive integers and must be between 0 and 255.", 1);
                return (false, 0, 0, 0);
            }

        }

        private void GraphColor_RandomizeButton_Math_AllSamples_Click(object sender, RoutedEventArgs e)
        {
            Random RGB_Value = new Random();
            int Value_Red = RGB_Value.Next(0, 255);
            int Value_Green = RGB_Value.Next(0, 255);
            int Value_Blue = RGB_Value.Next(0, 255);
            Red_GraphColor_TextBox_Math_AllSamples.Text = Value_Red.ToString();
            Green_GraphColor_TextBox_Math_AllSamples.Text = Value_Green.ToString();
            Blue_GraphColor_TextBox_Math_AllSamples.Text = Value_Blue.ToString();
            GraphColor_Preview_Math_AllSamples.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue)));
        }

        //--------------------------- Math (All Samples)----------------------
    }
}