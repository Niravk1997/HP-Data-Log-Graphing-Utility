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
        string FilePath = "";
        string FileName = "";

        List<DateTime> Measurement_DateTime = new List<DateTime>();
        List<double> Measurement_Data = new List<double>();

        List<string> Overload_Values = new List<string>();

        public File_Select()
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

        private void App_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
