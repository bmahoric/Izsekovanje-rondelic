using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izsekovanje_rondelic
{
    public class TriangularCalcHelper
    {
        private readonly Round _round;

        public TriangularCalcHelper(Round round)
        {
            _round = round;
        }

        /*
         * Izračun katete pravokotnega trikotnika za rezultat odmika sodih vrstic.
         */
        public int CalcB_leg()
        {
            double a;
            double b;
            double c;

            a = _round.R + (_round.Distance / 2);
            c = (2 * _round.R) + _round.Distance;
            b = Math.Sqrt(Math.Pow(c, 2) - Math.Pow(a, 2));

            return Convert.ToInt32(b);   // TODO: potrebno preveriti kaj naredimo z double!
        }
    }
}
