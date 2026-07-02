using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverterLib
{
    static public class Converter
    {
        static public double CelsiusToFahrenheit(double degreesCelsius)
        {
            return (degreesCelsius * 9 / 5) + 32;
        }

        static public double FahrenheitToCelsius(double degreesFahrenheit)
        {
            return (degreesFahrenheit - 32) * 5 / 9;
        }
    }
}
