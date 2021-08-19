using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataReader.ReadData();
            Console.ReadLine();
        }
    }
}
