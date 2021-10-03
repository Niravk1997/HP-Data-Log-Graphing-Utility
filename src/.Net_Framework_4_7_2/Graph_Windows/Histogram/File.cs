using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Histogram_Graph
{
    public partial class Histogram_Waveform : MetroWindow
    {
        private void Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Histogram Plot Data_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        for (int i = 0; i < Measurement_Count; i++)
                        {
                            datatotxt.WriteLine(Measurement_DateTime[i].ToString("yyyy-MM-dd h:mm:ss.fff tt") + "," + Measurement_Data[i]);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_Data_CSV_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Histogram Plot Data_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".csv",
                    Filter = "CSV Files (*.csv)|*.csv;*.csv" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        for (int i = 0; i < Measurement_Count; i++)
                        {
                            datatotxt.WriteLine(Measurement_DateTime[i].ToString("yyyy-MM-dd h:mm:ss.fff tt") + "," + Measurement_Data[i]);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_Graph_Image_Click(object sender, RoutedEventArgs e)
        {
            Save_Graph_to_Image();
        }

        private void Exit_Graph_Window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
