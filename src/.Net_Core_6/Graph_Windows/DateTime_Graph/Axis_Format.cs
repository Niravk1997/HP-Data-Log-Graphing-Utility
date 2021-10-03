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
        //---------------------Date Time Format------------------------------

        private void DateTime_HH_mm_ss_fff_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nHH:mm:ss.fff", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(1);
        }

        private void DateTime_H_mm_ss_fff_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nH:mm:ss.fff", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(2);
        }

        private void DateTime_HH_mm_ss_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nHH:mm:ss", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(3);
        }

        private void DateTime_HH_mm_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nHH:mm", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(4);
        }

        private void DateTime_H_mm_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nH:mm", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(5);
        }

        private void DateTime_hh_mm_ss_fff_tt_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nhh:mm:ss.fff tt", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(6);
        }

        private void DateTime_h_mm_ss_fff_tt_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nh:mm:ss.fff tt", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(7);
        }

        private void DateTime_hh_mm_ss_tt_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nhh:mm:ss tt", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(8);
        }

        private void DateTime_hh_mm_tt_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nhh:mm tt", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(9);
        }

        private void DateTime_h_mm_tt_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelFormat("MM/dd/yyyy\nh:mm tt", dateTimeFormat: true);
            Graph.Render();
            DateTime_Format_Selected(10);
        }

        private void DateTime_Format_Selected(int Selected)
        {
            if (Selected == 1)
            {
                DateTime_HH_mm_ss_fff.IsChecked = true;
            }
            else
            {
                DateTime_HH_mm_ss_fff.IsChecked = false;
            }
            if (Selected == 2)
            {
                DateTime_H_mm_ss_fff.IsChecked = true;
            }
            else
            {
                DateTime_H_mm_ss_fff.IsChecked = false;
            }
            if (Selected == 3)
            {
                DateTime_HH_mm_ss.IsChecked = true;
            }
            else
            {
                DateTime_HH_mm_ss.IsChecked = false;
            }
            if (Selected == 4)
            {
                DateTime_HH_mm.IsChecked = true;
            }
            else
            {
                DateTime_HH_mm.IsChecked = false;
            }
            if (Selected == 5)
            {
                DateTime_H_mm.IsChecked = true;
            }
            else
            {
                DateTime_H_mm.IsChecked = false;
            }
            if (Selected == 6)
            {
                DateTime_hh_mm_ss_fff_tt.IsChecked = true;
            }
            else
            {
                DateTime_hh_mm_ss_fff_tt.IsChecked = false;
            }
            if (Selected == 7)
            {
                DateTime_h_mm_ss_fff_tt.IsChecked = true;
            }
            else
            {
                DateTime_h_mm_ss_fff_tt.IsChecked = false;
            }
            if (Selected == 8)
            {
                DateTime_hh_mm_ss_tt.IsChecked = true;
            }
            else
            {
                DateTime_hh_mm_ss_tt.IsChecked = false;
            }
            if (Selected == 9)
            {
                DateTime_hh_mm_tt.IsChecked = true;
            }
            else
            {
                DateTime_hh_mm_tt.IsChecked = false;
            }
            if (Selected == 10)
            {
                DateTime_h_mm_tt.IsChecked = true;
            }
            else
            {
                DateTime_h_mm_tt.IsChecked = false;
            }

        }

        //--------------------------------------------------------------------
    }
}
