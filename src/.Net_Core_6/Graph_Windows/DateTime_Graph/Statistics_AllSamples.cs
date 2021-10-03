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
        //--------------------------- Statistics (All Samples)----------------------

        private void Mean_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Mean = ArrayStatistics.Mean(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Mean (Average): " + Mean + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Mean (Average) for All Samples. Try again.", 1);
                }
            });
        }

        private void StdDeviation_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double StdDeviation = ArrayStatistics.StandardDeviation(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Standard Deviation: " + StdDeviation + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Standard Deviation for All Samples. Try again.", 1);
                }
            });
        }

        private void Max_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Max = ArrayStatistics.Maximum(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Found Maximum Sample: " + Max + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not find Maximum Sample for All Samples. Try again.", 1);
                }
            });
        }

        private void Min_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Min = ArrayStatistics.Minimum(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Found Minimum Sample: " + Min + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not find Minimum Sample for All Samples. Try again.", 1);
                }
            });
        }

        private void AbsMax_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double AbsMax = ArrayStatistics.MaximumAbsolute(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Absolute Maximum: " + AbsMax + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Absolute Maximum for All Samples. Try again.", 1);
                }
            });
        }

        private void AbsMin_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double AbsMin = ArrayStatistics.MinimumAbsolute(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Absolute Minimum: " + AbsMin + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Absolute Minimum for All Samples. Try again.", 1);
                }
            });
        }

        private void RMS_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double RMS = ArrayStatistics.RootMeanSquare(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Root Mean Square: " + RMS + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Root Mean Square for All Samples. Try again.", 1);
                }
            });
        }

        private void Variance_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double Variance = ArrayStatistics.Variance(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Variance: " + Variance + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Variance for All Samples. Try again.", 1);
                }
            });
        }

        private void GeometricMean_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double GeometricMean = ArrayStatistics.GeometricMean(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Geometric Mean: " + GeometricMean + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Geometric Mean for All Samples. Try again.", 1);
                }
            });
        }

        private void HarmonicMean_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double HarmonicMean = ArrayStatistics.HarmonicMean(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Harmonic Mean: " + HarmonicMean + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Harmonic Mean for All Samples. Try again.", 1);
                }
            });
        }

        private void PopulationVariance_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double PopulationVariance = ArrayStatistics.PopulationVariance(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Population Variance: " + PopulationVariance + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Population Variance for All Samples. Try again.", 1);
                }
            });
        }

        private void PopulationStdDeviation_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    double PopulationStandardDeviation = ArrayStatistics.PopulationStandardDeviation(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Calculated Population Standard Deviation: " + PopulationStandardDeviation + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Population Standard Deviation for All Samples. Try again.", 1);
                }
            });
        }

        private void MeanStdDeviation_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    (double ArithmeticSampleMean, double UnbiasedPopulationStandardDeviation) = ArrayStatistics.MeanStandardDeviation(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Arithmetic Sample Mean: " + ArithmeticSampleMean + " " + Measurement_Unit + "  Unbiased Pop Std Deviation: " + UnbiasedPopulationStandardDeviation + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Mean Standard Deviation for All Samples. Try again.", 1);
                }
            });
        }

        private void MeanVariance_AllSamples_Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    int Measurement_Count_Copy = Measurement_Count;
                    double[] Measurement_Data_Copy = new double[Measurement_Count_Copy];
                    Array.Copy(Measurement_Data, Measurement_Data_Copy, Measurement_Count_Copy);
                    (double ArithmeticSampleMean, double UnbiasedPopulationVariance) = ArrayStatistics.MeanVariance(Measurement_Data_Copy);
                    Insert_Log("[All Samples (" + Measurement_Count_Copy + ")]" + "  Arithmetic Sample Mean: " + ArithmeticSampleMean + " " + Measurement_Unit + "  Unbiased Pop Variance: " + UnbiasedPopulationVariance + " " + Measurement_Unit, 3);
                    Measurement_Data_Copy = null;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Could not calculate Mean Variance for All Samples. Try again.", 1);
                }
            });
        }

        //--------------------------- Statistics (All Samples)----------------------
    }
}