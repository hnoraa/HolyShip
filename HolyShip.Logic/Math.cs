using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public static class Math
    {
        public static double RandomDouble(double min, double max)
        {
            Random rnd = new Random();
            var next = rnd.NextDouble();
            return min + (next * (max - min));
        }

        public static string GetRandomDirection()
        {
            Random rnd = new Random();
            return ((Enums.Direction)rnd.Next(0, 3)).ToString();
        }
    }
}
