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
    }
}
