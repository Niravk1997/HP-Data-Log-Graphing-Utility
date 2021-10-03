using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DateTime_Waveform_Graph
{
    public partial class DateTime_Math_Waveform : MetroWindow
    {
        private static readonly char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
        private static readonly char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

        private void set_YAXIS_Precision_Format_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Y_Axis_Precision_Set_Text.Text, false, true);
            if (isValid)
            {
                if (Value > 0)
                {
                    Graph.Plot.YAxis.TickLabelFormat("F" + (int)Value, dateTimeFormat: false);
                    Graph.Refresh();
                }
                else
                {
                    Insert_Log("Precision Value must be a positive integer greater than 0.", 2);
                }
            }
            else
            {
                Insert_Log("Precision Value must be a positive integer greater than 0.", 2);
            }
        }

        private void set_YAXIS_Default_Format_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.TickLabelFormat("g", dateTimeFormat: false);
            Graph.Refresh();
        }

        private void set_YAXIS_MetricPrefix_Format_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.TickLabelFormat(Value_SI_Prefix);
            Graph.Refresh();
        }

        private static string Value_SI_Prefix(double position)
        {
            if (position == 0)
            {
                return position.ToString();
            }
            else
            {
                int degree = (int)Math.Floor(Math.Log10(Math.Abs(position)) / 3);
                double scaled_Value = Math.Round(position * Math.Pow(1000, -degree), 8);

                char? prefix = null;
                switch (Math.Sign(degree))
                {
                    case 1: prefix = incPrefixes[degree - 1]; break;
                    case -1: prefix = decPrefixes[-degree - 1]; break;
                }
                return scaled_Value + "" + prefix;
            }
        }
    }
}
