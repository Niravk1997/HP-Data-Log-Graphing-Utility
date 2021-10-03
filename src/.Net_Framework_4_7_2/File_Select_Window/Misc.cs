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
        //converts a string into a number
        private (bool, double) Text_Num(string text, bool allowNegative, bool isInteger)
        {
            if (isInteger == true)
            {
                bool isValid = int.TryParse(text, out int value);
                if (isValid == true)
                {
                    if (allowNegative == false)
                    {
                        if (value < 0)
                        {
                            return (false, 0);
                        }
                        else
                        {
                            return (true, value);
                        }
                    }
                    else
                    {
                        return (true, value);
                    }
                }
                else
                {
                    return (false, 0);
                }
            }
            else
            {
                bool isValid = double.TryParse(text, out double value);
                if (isValid == true)
                {
                    if (allowNegative == false)
                    {
                        if (value < 0)
                        {
                            return (false, 0);
                        }
                        else
                        {
                            return (true, value);
                        }
                    }
                    else
                    {
                        return (true, value);
                    }
                }
                else
                {
                    return (false, 0);
                }
            }
        }
    }
}
