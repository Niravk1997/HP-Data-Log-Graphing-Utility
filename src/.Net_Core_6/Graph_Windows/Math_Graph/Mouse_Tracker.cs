using System;
using System.Collections.Concurrent;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MathNet.Numerics.Statistics;
using Microsoft.Win32;
using ScottPlot;
using DateTime_Waveform_Graph;
using Histogram_Graph;
using MahApps.Metro.Controls;

namespace Math_Waveform_Graph
{
    public partial class Math_Waveform : MetroWindow
    {
        private ScottPlot.Plottable.Crosshair Mouse_Tracker;
        private ScottPlot.Plottable.Text MouseCoordinates;
        private bool ShowMouseTracker = false;
        private bool ShowMouseCoordinates = false;

        private void Show_Tracker_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Tracker.IsChecked == true)
            {
                Mouse_Tracker = Graph.Plot.AddCrosshair(0, 0);
                Mouse_Tracker.VerticalLine.PositionFormatter = x => $"{x:F4}";
                Mouse_Tracker.HorizontalLine.PositionFormatter = x => $"{x:F0}";
                Tracker_Color_Selector(2);
                Tracker_Style_Selector(1);
                ShowMouseTracker = true;
                Show_XY_Coordinates_Tracker.IsChecked = true;
                Enable_XY_Coordinates_Tracker();
                Tracker_Mouse_Status_Bar.Fill = Brushes.Green;
                Insert_Log("Mouser Tracker has been enabled. Auto Axis is disabled.", 0);
            }
            else
            {
                ShowMouseTracker = false;
                Graph.Plot.Remove(plottable: Mouse_Tracker);
                if (ShowMouseCoordinates == true)
                {
                    ShowMouseCoordinates = false;
                    Show_XY_Coordinates_Tracker.IsChecked = false;
                    Graph.Plot.Remove(plottable: MouseCoordinates);
                }
                Tracker_Mouse_Status_Bar.Fill = Brushes.Red;
                Insert_Log("Mouser Tracker has been disabled. Auto Axis is enabled.", 0);
            }
            Graph.Render();
        }

        private void Show_XY_Coordinates_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Enable_XY_Coordinates_Tracker();
        }

        private void Enable_XY_Coordinates_Tracker()
        {
            if (Show_XY_Coordinates_Tracker.IsChecked == true & ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                MouseCoordinates = Graph.Plot.AddText("null, null", X_MouseCoordinate, Y_MouseCoordinate, color: Mouse_Tracker.HorizontalLine.Color);
                MouseCoordinates.Alignment = Alignment.UpperRight;
                MouseCoordinates.FontSize = 16;
                ShowMouseCoordinates = true;
            }
            else
            {
                ShowMouseCoordinates = false;
                Show_XY_Coordinates_Tracker.IsChecked = false;
                Graph.Plot.Remove(plottable: MouseCoordinates);
            }
            Graph.Render();
        }

        private void Graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                int xIndex = (int)X_MouseCoordinate;
                bool xIndex_Valid = (xIndex >= 0 && xIndex < Measurement_Count);

                Mouse_Tracker.X = X_MouseCoordinate;
                Mouse_Tracker.Y = Y_MouseCoordinate;

                if (ShowMouseCoordinates == true)
                {
                    if (xIndex_Valid)
                    {
                        MouseCoordinates.Label = xIndex + ", " + ((decimal)(Measurement_Data[xIndex])).ToString() + Measurement_Unit;
                    }
                    else
                    {
                        MouseCoordinates.Label = xIndex + ", " + "null";
                    }
                    MouseCoordinates.X = X_MouseCoordinate;
                    MouseCoordinates.Y = Y_MouseCoordinate;
                }

                if (xIndex_Valid)
                {
                    Sample_Label.Content = ((decimal)(Measurement_Data[xIndex]));
                    Sample_Label_Unit.Content = Measurement_Unit;
                    Sample_Number_Label.Content = xIndex;
                }
                else
                {
                    Sample_Label.Content = "null";
                    Sample_Label_Unit.Content = "";
                    Sample_Number_Label.Content = "null";
                }

                Graph.Render();
            }
        }

        private void Set_Tracker_Color(string Color, string ColorName, int ColorNum)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker.Color = System.Drawing.ColorTranslator.FromHtml(Color);

                if (ShowMouseCoordinates == true)
                {
                    MouseCoordinates.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                }
                Graph.Render();
                Insert_Log("Mouse Tracker Color set to " + ColorName + ".", 0);
                Tracker_Color_Selector(ColorNum);
            }
            else
            {
                Tracker_Color_Selector(9);
                Insert_Log("Cannot change Mouse Tracker Color. Mouse Tracker is not enabled.", 1);
            }
        }

        private void Green_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF00FF17", "Green", 0);
        }

        private void Blue_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF00C0FF", "Blue", 1);
        }

        private void Red_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFF0000", "Red", 2);
        }

        private void Yellow_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFFFF00", "Yellow", 3);
        }

        private void Orange_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFF8C00", "Orange", 4);
        }

        private void Black_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF000000", "Black", 5);
        }

        private void Pink_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFF1493", "Pink", 6);
        }

        private void Violet_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF9400D3", "Violet", 7);
        }

        private void White_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFFFFFF", "White", 8);
        }

        private void Tracker_Color_Selector(int Tracker_Color)
        {
            if (Tracker_Color == 0)
            {
                Green_Tracker.IsChecked = true;
            }
            else
            {
                Green_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 1)
            {
                Blue_Tracker.IsChecked = true;
            }
            else
            {
                Blue_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 2)
            {
                Red_Tracker.IsChecked = true;
            }
            else
            {
                Red_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 3)
            {
                Yellow_Tracker.IsChecked = true;
            }
            else
            {
                Yellow_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 4)
            {
                Orange_Tracker.IsChecked = true;
            }
            else
            {
                Orange_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 5)
            {
                Black_Tracker.IsChecked = true;
            }
            else
            {
                Black_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 6)
            {
                Pink_Tracker.IsChecked = true;
            }
            else
            {
                Pink_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 7)
            {
                Violet_Tracker.IsChecked = true;
            }
            else
            {
                Violet_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 8)
            {
                White_Tracker.IsChecked = true;
            }
            else
            {
                White_Tracker.IsChecked = false;
            }
        }

        private void Tracker_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker.LineStyle = LineStyle.Dot;
                Insert_Log("Mouse Tracker Style set to Dotted.", 0);
                Tracker_Style_Selector(0);
                Graph.Render();
            }
            else
            {
                Insert_Log("Cannot set Mouse Tracker Style. Mouse Tracker not enabled.", 2);
            }
        }

        private void Tracker_Style_Dot_Dash_Click(object sender, RoutedEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker.LineStyle = LineStyle.DashDot;
                Insert_Log("Mouse Tracker Style set to Dot Dash.", 0);
                Tracker_Style_Selector(1);
                Graph.Render();
            }
            else
            {
                Insert_Log("Cannot set Mouse Tracker Style. Mouse Tracker not enabled.", 2);
            }
        }

        private void Tracker_Style_Solid_Click(object sender, RoutedEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker.LineStyle = LineStyle.Solid;
                Insert_Log("Mouse Tracker Style set to Solid.", 0);
                Tracker_Style_Selector(2);
                Graph.Render();
            }
            else
            {
                Insert_Log("Cannot set Mouse Tracker Style. Mouse Tracker not enabled.", 2);
            }
        }

        private void Tracker_Style_Selector(int Style)
        {
            if (Style == 0)
            {
                Tracker_Style_Dotted.IsChecked = true;
            }
            else
            {
                Tracker_Style_Dotted.IsChecked = false;
            }
            if (Style == 1)
            {
                Tracker_Style_Dot_Dash.IsChecked = true;
            }
            else
            {
                Tracker_Style_Dot_Dash.IsChecked = false;
            }
            if (Style == 2)
            {
                Tracker_Style_Solid.IsChecked = true;
            }
            else
            {
                Tracker_Style_Solid.IsChecked = false;
            }
        }
    }
}