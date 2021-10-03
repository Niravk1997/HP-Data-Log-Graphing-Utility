using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class Helpful_Functions
    {
        internal string Value_SI_Prefix(double Value, int Round_Value)
        {
            if (Value == double.NaN || Value == double.PositiveInfinity || Value == double.NegativeInfinity)
            {
                return "NaN ";
            }
            else if (Value == 0)
            {
                return Value.ToString() + " ";
            }
            else
            {
                char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
                char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

                int degree = (int)Math.Floor(Math.Log10(Math.Abs(Value)) / 3);
                double scaled_Value = Value * Math.Pow(1000, -degree);

                char? prefix = null;
                switch (Math.Sign(degree))
                {
                    case 1: prefix = incPrefixes[degree - 1]; break;
                    case -1: prefix = decPrefixes[-degree - 1]; break;
                }

                return Math.Round(scaled_Value, Round_Value).ToString() + " " + prefix;
            }
        }

        //converts a string into a number
        internal (bool, double) Text_Num(string text, bool allowNegative, bool isInteger)
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
