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
    /// <summary>
    /// Interaction logic for DateTime_Math_Waveform.xaml
    /// </summary>
    public partial class DateTime_Math_Waveform : MetroWindow
    {
        //Set Window Title, helps determine which instrument owns this Graph Window
        string Graph_Owner;

        //Needed to add the Plot to the graph
        ScottPlot.Plottable.SignalPlotXY Measurement_Plot;
        double[] Measurement_DateTime; //Date time data for the measurement data
        double[] Measurement_Data; //Waveform Array

        //Auto clear the output log after a specific amount of items inside the log has been reached.
        int Auto_Clear_Output_Log_Count = 40; //This integer variable is thread safe, interlocked.exchange is used.

        // A counter that is incremented when a measurement is processed. Show how many measuremnet is displayed on the GUI window.
        int Measurement_Count; //For testing set
        int Start_Sample;
        int End_Sample;

        string Measurement_Unit;

        public DateTime_Math_Waveform(string Graph_Owner, string Window_Title, double Value, int Start_Sample, int End_Sample, string Graph_Title, string Y_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, double[] Measurement_DateTime)
        {
            InitializeComponent();
            Graph_RightClick_Menu();

            this.Title = Graph_Owner + " " + Window_Title;
            this.Graph_Owner = Graph_Owner;

            if (Y_Axis_Label.Length > 3)
            {
                Measurement_Unit = Y_Axis_Label.Substring(0, 3);
            }
            else
            {
                Measurement_Unit = Y_Axis_Label;
            }

            this.Measurement_Data = Measurement_Data;
            this.Measurement_DateTime = Measurement_DateTime;
            this.Measurement_Count = Measurement_Count;
            this.Start_Sample = Start_Sample;
            this.End_Sample = End_Sample;

            try
            {
                Add_Measurement_Waveform(Y_Axis_Label, Red, Green, Blue);
                Start_SampleNumber_Label.Content = this.Start_Sample;
                End_SampleNumber_Label.Content = this.End_Sample;
                Sample_Average_Label.Content = (decimal)Math.Round(this.Measurement_Data.Mean(), 6);
                Max_Recorded_Sample_Label.Content = (decimal)this.Measurement_Data.Maximum();
                Min_Recorded_Sample_Label.Content = (decimal)this.Measurement_Data.Minimum();
                Total_Samples_Label.Content = this.Measurement_Count;
                Positive_Samples_Label.Content = this.Measurement_Data.Where(x => x >= 0).Count();
                Negative_Samples_Label.Content = this.Measurement_Data.Where(x => x < 0).Count();
                Sample_Average_Label_Unit.Content = Measurement_Unit;
                Max_Recorded_Sample_Label_Unit.Content = Measurement_Unit;
                Min_Recorded_Sample_Label_Unit.Content = Measurement_Unit;
                TimeSpan duration = (DateTime.FromOADate(Measurement_DateTime[Measurement_Count - 1])).Subtract(DateTime.FromOADate(Measurement_DateTime[0]));
                Time_Duration_Text.Content = duration.ToString("hh':'mm':'ss'.'fff");
                Hours_Duration_Text.Content = Math.Round(duration.TotalHours, 10) + " h";
                Minutes_Duration_Text.Content = Math.Round(duration.TotalMinutes, 10) + " m";
                Seconds_Duration_Text.Content = Math.Round(duration.TotalSeconds, 10) + " s";
                Graph.Plot.YLabel(Y_Axis_Label);
                Graph.Plot.XLabel("N Samples");
                Graph.Plot.Title(Graph_Title);
            }
            catch (Exception Ex)
            {
                Graph_Color_Menu.IsEnabled = false;
                Insert_Log(Ex.Message, 1);
                Insert_Log("Probably no data inside the Measurement Data Array", 1);
                Graph.Plot.AddAnnotation(Ex.Message, -10, -10);
                Graph.Plot.AddText("Failed to create an DateTime Math Waveform, try again.", 5, 0, size: 20, color: System.Drawing.Color.Red);
                Graph.Plot.AxisAuto();
                Graph.Render();
            }
        }

        private void Add_Measurement_Waveform(string Y_Axis_Label, int Red, int Green, int Blue)
        {
            Measurement_Plot = Graph.Plot.AddSignalXY(Measurement_DateTime, Measurement_Data, color: System.Drawing.Color.FromArgb(Red, Green, Blue), label: Y_Axis_Label);
            Graph.Plot.XAxis.DateTimeFormat(true);
            Graph.Render();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Measurement_Data = null;
                Measurement_DateTime = null;
                Measurement_Plot = null;
            }
            catch (Exception)
            {

            }
        }
    }
}
