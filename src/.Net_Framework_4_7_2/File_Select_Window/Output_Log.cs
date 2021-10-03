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
    }
}
