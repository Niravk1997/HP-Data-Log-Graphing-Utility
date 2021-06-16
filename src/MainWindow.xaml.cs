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

namespace Data_Log_Graphing_Utility
{
    public partial class MainWindow : Window
    {
        string FilePath = "";
        string FileName = "";

        List<DateTime> Measurement_DateTime = new List<DateTime>();
        List<double> Measurement_Data = new List<double>();

        List<string> Overload_Values = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            if (Thread.CurrentThread.CurrentCulture.Name != "en-US")
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            }
            insert_Log("Drag and Drop your data log file onto the Drag & Drop area.", 5);
            insert_Log("And then click the graph data button.", 5);
            insert_Log("Only text and csv files are allowed.", 5);
            get_Config_file();
        }

        private void get_Config_file()
        {
            try
            {
                string config_file_path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + "Overload.config";
                try
                {
                    using (var readFile = new StreamReader(config_file_path))
                    {
                        string line;
                        while ((line = readFile.ReadLine()) != null)
                        {
                            Overload_Values.Add(line.Trim());
                        }
                    }
                }
                catch (Exception)
                {
                    insert_Log("Failed to read the Overload.config file.", 1);
                }

            }
            catch (Exception)
            {
                insert_Log("Cannot load Overload.config file.", 1);
            }
        }

        private void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text/CSV files (*.txt, *.csv)|*.txt;*.csv",
                InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };
            if (openFileDialog.ShowDialog() == true)
            {
                bool fileExists = openFileDialog.CheckFileExists;
                bool filePathExists = openFileDialog.CheckPathExists;
                string fileExtension = System.IO.Path.GetExtension(openFileDialog.FileName);
                string filePath = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName;
                if (fileExists == true & filePathExists == true)
                {
                    if (fileExtension == ".txt" || fileExtension == ".csv" || fileExtension == ".CSV")
                    {
                        insert_Log("File Path: " + filePath, 5);
                        File_Path.Text = filePath;
                        FilePath = filePath;
                        try
                        {
                            Graph_Title_text.Text = fileName;
                            FileName = fileName;
                            fill_YAxis_label_input_field(fileName);
                        }
                        catch (Exception)
                        {
                            insert_Log("Cannot read data log file name. Please enter it manually.", 1);
                            Graph_Title_text.Text = string.Empty;
                        }
                    }
                    else
                    {
                        insert_Log("File is invalid. Must be a text file.", 1);
                    }
                }
                else
                {
                    insert_Log("File not found or file path not valid. Try again.", 1);
                }
            }
        }

        private void File_Border_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = System.IO.Path.GetFullPath(file[0]);
                string fileExtension = System.IO.Path.GetExtension(file[0]);
                string fileName = System.IO.Path.GetFileName(file[0]);
                if (fileExtension == ".txt" || fileExtension == ".csv" || fileExtension == ".CSV")
                {
                    insert_Log("File Path: " + filePath, 5);
                    File_Path.Text = filePath;
                    FilePath = filePath;
                    try
                    {
                        Graph_Title_text.Text = fileName;
                        FileName = fileName;
                        fill_YAxis_label_input_field(fileName);
                    }
                    catch (Exception)
                    {
                        insert_Log("Cannot read data log file name. Please enter it manually.", 1);
                        Graph_Title_text.Text = string.Empty;
                    }
                }
                else
                {
                    insert_Log("Invalid file type. Must be a .txt or .csv file.", 1);
                }

            }
        }

        private void fill_YAxis_label_input_field(string file_Name) 
        {
            string fileName = file_Name;
            if (fileName.Contains("VDC"))
            {
                Graph_Y_axisTitle_text.Text = "VDC Voltage";
            }
            else if (fileName.Contains("ADC"))
            {
                Graph_Y_axisTitle_text.Text = "ADC Current";
            }
            else if (fileName.Contains("VAC"))
            {
                Graph_Y_axisTitle_text.Text = "VAC Voltage";
            }
            else if (fileName.Contains("AAC"))
            {
                Graph_Y_axisTitle_text.Text = "AAC Current";
            }
            else if (fileName.Contains("2WireOhms"))
            {
                Graph_Y_axisTitle_text.Text = "Ω  2 Wire Ohms";
            }
            else if (fileName.Contains("4WireOhms"))
            {
                Graph_Y_axisTitle_text.Text = "Ω  4 Wire Ohms";
            }
            else if (fileName.Contains("FREQ"))
            {
                Graph_Y_axisTitle_text.Text = "Hz  Frequency";
            }
            else if (fileName.Contains("PER"))
            {
                Graph_Y_axisTitle_text.Text = "s  Seconds";
            }
            else if (fileName.Contains("DIODE"))
            {
                Graph_Y_axisTitle_text.Text = "VDC Voltage";
            }
            else if (fileName.Contains("CONTINUITY"))
            {
                Graph_Y_axisTitle_text.Text = "Ω  Ohms";
            }
            else if (fileName.Contains("DCV"))
            {
                Graph_Y_axisTitle_text.Text = "DCV Voltage";
            }
            else if (fileName.Contains("ACV"))
            {
                Graph_Y_axisTitle_text.Text = "ACV Voltage";
            }
            else 
            {
                Graph_Y_axisTitle_text.Text = "";
            }
        }

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
                                Measurement_DateTime.Add(DateTime.ParseExact(line_Parts[0], "yyyy-MM-dd h:mm:ss tt", null));
                                Measurement_Data.Add(0);
                                insert_Log("Overload value detected: " + line_Parts[0] + ", " + line_Parts[1], 2);
                            }
                        }
                        else 
                        {
                            Measurement_DateTime.Add(DateTime.ParseExact(line_Parts[0], "yyyy-MM-dd h:mm:ss tt", null));
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
                DateTime[] Measurement_DateTime = this.Measurement_DateTime.ToArray(); //Datetime data for the measurement data
                double[] Measurement_Data = this.Measurement_Data.ToArray(); //Waveform Array
                int count = Measurement_Data.Count();
                Create_Waveform_Window(FileName, "", 0, 0, count - 1, Graph_Title_text.Text, Graph_Y_axisTitle_text.Text, Value_Red, Value_Green, Value_Blue, Measurement_Data, count, Measurement_DateTime);
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

        private void insert_Log(string Message, int Code)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            SolidColorBrush Color;
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
                    Status = "";
                    Color = Brushes.Blue;
                    break;
                case 4:
                    Status = "";
                    Color = Brushes.Black;
                    break;
                case 5:
                    Status = "";
                    Color = Brushes.BlueViolet;
                    break;
                default:
                    Status = "Unknown";
                    Color = Brushes.Black;
                    break;
            }
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                Output_Log.Inlines.Add(new Run("[" + date + "]" + " " + Status + " " + Message + "\n") { Foreground = Color });
                Output_Log_Scroll.ScrollToBottom();
            }));
        }

        private void ClearOutputLog_Click(object sender, RoutedEventArgs e)
        {
            Output_Log.Text = String.Empty;
            Output_Log.Inlines.Clear();
        }

        private void App_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
