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
        private void Force_Auto_Axis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.AxisAuto();
            Graph.Render();
            Insert_Log("Graph's Force Auto-Axis method called.", 0);
        }

        private void Title_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Title(Title_Set_Text.Text);
            Graph.Render();
            Insert_Log("Graph's Title Label changed to " + Title_Set_Text.Text, 0);
            Title_Set_Text.Text = string.Empty;
        }

        private void X_Axis_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Label(X_Axis_Set_Text.Text);
            Graph.Render();
            Insert_Log("Graph's X-Axis Label changed to " + X_Axis_Set_Text.Text, 0);
            X_Axis_Set_Text.Text = string.Empty;
        }

        private void Y_Axis_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Label(Y_Axis_Set_Text.Text);
            Graph.Render();
            Insert_Log("Graph's Y-Axis Label changed to " + Y_Axis_Set_Text.Text, 0);
            Y_Axis_Set_Text.Text = string.Empty;
        }

        private void X_Axis_Show_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Show.IsChecked == true)
            {
                Graph.Plot.XAxis.Ticks(true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.Ticks(false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been disabled.", 0);
            }
        }

        private void X_Axis_Default_Tick_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Default_Tick.IsChecked == true)
            {
                Graph.Plot.XAxis.ManualTickSpacing(0);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been set to default.", 0);
            }
        }

        private void X_Axis_Custom_Set_Tick_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(X_Axis_Custom_Set_Tick.Text, false, true);
            if (isValid == true)
            {
                X_Axis_Default_Tick.IsChecked = false;
                Graph.Plot.XAxis.ManualTickSpacing(Value);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been set to " + Value, 0);
                X_Axis_Custom_Set_Tick.Text = string.Empty;
            }
            else
            {
                X_Axis_Custom_Set_Tick.Text = string.Empty;
                Insert_Log("Graph's X-Axis Custom Tick value must be a number. No text or other characters are allowed.", 1);
            }

        }

        private void X_Axis_Tick_Rotation_0_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(rotation: 0);
            Graph.Render();
            Insert_Log("Graph's X-Axis Ticks rotated to 0�", 0);
            X_Axis_Tick_Rotation_0.IsChecked = true;
            X_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void X_Axis_Tick_Rotation_45_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(rotation: 45);
            Graph.Render();
            Insert_Log("Graph's X-Axis Ticks rotated to 45�", 0);
            X_Axis_Tick_Rotation_0.IsChecked = false;
            X_Axis_Tick_Rotation_45.IsChecked = true;
        }

        private void X_Axis_Minor_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Minor_Grid.IsChecked == true)
            {
                Graph.Plot.XAxis.MinorGrid(true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Minor Grid is enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.MinorGrid(false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Minor Grid is disabled.", 0);
            }
        }

        private void X_Axis_Multiplier_Notation_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Multiplier_Notation.IsChecked == true)
            {
                Graph.Plot.XAxis.TickLabelNotation(multiplier: true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Multiplier Notation is Enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.TickLabelNotation(multiplier: false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Multiplier Notation is Disabled.", 0);
            }
        }

        private void X_Axis_Tick_Ruler_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Tick_Ruler_Mode.IsChecked == true)
            {
                Graph.Plot.XAxis.RulerMode(true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ruler Mode is Enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.RulerMode(false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ruler Mode is Disabled.", 0);
            }
        }

        private void Y_Axis_Show_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Show.IsChecked == true)
            {
                Graph.Plot.YAxis.Ticks(true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.Ticks(false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been disabled.", 0);
            }
        }

        private void Y_Axis_Default_Tick_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Default_Tick.IsChecked == true)
            {
                Graph.Plot.YAxis.ManualTickSpacing(0);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been set to default.", 0);
            }
        }

        private void Y_Axis_Custom_Set_Tick_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Text_Num(Y_Axis_Custom_Set_Tick.Text, false, true);
            if (isValid == true)
            {
                Y_Axis_Default_Tick.IsChecked = false;
                Graph.Plot.YAxis.ManualTickSpacing(Value);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been set to " + Value, 0);
                Y_Axis_Custom_Set_Tick.Text = string.Empty;
            }
            else
            {
                Y_Axis_Custom_Set_Tick.Text = string.Empty;
                Insert_Log("Graph's Y-Axis Custom Tick value must be a number. No text or other characters are allowed.", 1);
            }
        }

        private void Y_Axis_Tick_Rotation_0_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.TickLabelStyle(rotation: 0);
            Graph.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 0�", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = true;
            Y_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void Y_Axis_Tick_Rotation_45_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.TickLabelStyle(rotation: 45);
            Graph.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 45�", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = false;
            Y_Axis_Tick_Rotation_45.IsChecked = true;
        }

        private void Y_Axis_Minor_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Minor_Grid.IsChecked == true)
            {
                Graph.Plot.YAxis.MinorGrid(true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Minor Grid is enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.MinorGrid(false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Minor Grid is disabled.", 0);
            }
        }

        private void Y_Axis_Multiplier_Notation_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Multiplier_Notation.IsChecked == true)
            {
                Graph.Plot.YAxis.TickLabelNotation(multiplier: true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Multiplier Notation is Enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.TickLabelNotation(multiplier: false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Multiplier Notation is Disabled.", 0);
            }
        }

        private void Y_Axis_Tick_Ruler_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Tick_Ruler_Mode.IsChecked == true)
            {
                Graph.Plot.YAxis.RulerMode(true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ruler Mode is Enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.RulerMode(false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ruler Mode is Disabled.", 0);
            }
        }

        //Font Size
        private void Font_Size_12_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 12);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 12);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 12.", 0);
            Font_12.IsChecked = true;
            Font_14.IsChecked = false;
            Font_16.IsChecked = false;
            Font_18.IsChecked = false;
        }

        private void Font_Size_14_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 14);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 14);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 14.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = true;
            Font_16.IsChecked = false;
            Font_18.IsChecked = false;
        }

        private void Font_Size_16_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 16);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 16);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 16.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = false;
            Font_16.IsChecked = true;
            Font_18.IsChecked = false;
        }

        private void Font_Size_18_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 18);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 18);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 18.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = false;
            Font_16.IsChecked = false;
            Font_18.IsChecked = true;
        }

        private void Graph_Vertical_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Graph_Vertical_Grid.IsChecked == true)
            {
                Graph.Plot.XAxis.Grid(true);
                Graph.Render();
                Insert_Log("Graph's Vertical Grid is Enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.Grid(false);
                Graph.Render();
                Insert_Log("Graph's Vertical Grid is Disabled.", 0);
            }
        }

        private void Graph_Horizontal_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Graph_Horizontal_Grid.IsChecked == true)
            {
                Graph.Plot.YAxis.Grid(true);
                Graph.Render();
                Insert_Log("Graph's Horizontal Grid is Enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.Grid(false);
                Graph.Render();
                Insert_Log("Graph's Horizontal Grid is Disabled.", 0);
            }
        }

        private void Grid_Style_Default_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.Solid);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Default.", 0);
            Grid_Style_Default.IsChecked = true;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.Dot);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Dotted.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = true;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dashed_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.Dash);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Dashed.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = true;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dot_Dash_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.DashDot);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Dot Dashed.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = true;
        }

        private void Show_legend_Click(object sender, RoutedEventArgs e)
        {
            if (Show_legend.IsChecked == true)
            {
                Graph.Plot.Legend(true);
                Graph.Render();
                Insert_Log("Graph's Legend is Enabled.", 0);
            }
            else
            {
                Graph.Plot.Legend(false);
                Graph.Render();
                Insert_Log("Graph's Legend is Disabled.", 0);
            }
        }

        private void Legend_TopLeft_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.UpperLeft);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Top Left Side.", 0);
            Legend_TopLeft.IsChecked = true;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_TopRight_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.UpperRight);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Top Right Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = true;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_BottomLeft_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.LowerLeft);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Bottom Left Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = true;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_BottomRight_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.LowerRight);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Bottom Left Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = true;
        }
    }
}