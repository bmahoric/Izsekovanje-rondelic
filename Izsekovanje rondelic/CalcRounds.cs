using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Izsekovanje_rondelic
{
    class CalcRounds
    {
        public int r { get; set; }
        public int distance { get; set; }

        public int GetNoOfRounds(Tape trak)
        {
            int noOfRoundsInOddCols = CalcRoundsInRows(trak, true);
            int noOfRoundsInEvenCols = CalcRoundsInRows(trak, false);
            int noOfRows = CalcNoOfRows(trak);

            int noOfEvenRows = noOfRows / 2;
            int noOfOddRows = (noOfRows % 2) + noOfEvenRows; 

            return (noOfEvenRows * noOfRoundsInEvenCols) + (noOfOddRows * noOfRoundsInOddCols);
        }

        public string[,] GetRoundLocations(Tape trak)
        {
            int noOfRoundsInOddCols = CalcRoundsInRows(trak, true);
            int noOfRoundsInEvenCols = CalcRoundsInRows(trak, false);
            int noOfRows = CalcNoOfRows(trak);

            int noOfEvenCols = noOfRows / 2;
            int noOfOddCols = (noOfRows % 2) + noOfEvenCols;

            int noOfCols = noOfEvenCols + noOfOddCols;
            int b = CalcYDistanceOfEvenRows();

            string[,] rounds = new string[noOfCols,noOfRows];

            for (int x=0;x<noOfCols;x++)
            {
                for (int y=0;y<noOfRows;y++)
                {
                    // TODO: odstraniti distanco za kroge prvega stolpca oz. vrstice
                    if (x>0 & y>0)
                        rounds[x,y] = (trak.xDistance + (r * (x + 1) + distance)).ToString()+" "+(trak.yDistance + r + (b * (y + 1))).ToString();
                    else if (x==0 & y>0)
                        rounds[x, y] = (trak.xDistance + (r * (x + 1))).ToString()+" "+(trak.yDistance + r + (b * (y + 1))).ToString();
                    else if (y==0 & x>0)
                        rounds[x, y] = (trak.xDistance + (r * (x + 1) + distance)).ToString()+" "+(trak.yDistance + r).ToString();
                    else
                        rounds[x, y] = (trak.xDistance + (r * (x + 1))).ToString()+" "+(trak.yDistance + r).ToString();
                }
            }

            return rounds;
        }

        /*
         * Prešteje število rondelic v vrsticah - sodih oz. lihih
         */
        private int CalcRoundsInRows(Tape trak, bool isOdd)
        {
            int noOfCols;

            if (isOdd)
                return noOfCols = (trak.NetLength()+distance) / (r * 2 + distance);
            else
                return noOfCols = (trak.NetLength() - (r * 2) + (distance / 2)) / (r * 2 + distance);
        }

        private int CalcNoOfRows(Tape trak)
        {
            int noOfRows;
            int b = CalcYDistanceOfEvenRows();

            noOfRows = ((trak.NetWidth() + (b - (2 * r))) / b);

            return noOfRows;
        }

        /*
         * Izračun katete pravokotnega trikotnika za rezultat odmika sodih vrstic.
         */
        private int CalcYDistanceOfEvenRows()
        {
            double a;
            double b;
            double c;

            a = r + (distance / 2);
            c = (2 * r) + distance;
            b = Math.Sqrt(Math.Pow(c, 2) - Math.Pow(a, 2));

            return Convert.ToInt32(b);   // TODO: potrebno preveriti kaj naredimo z double!
        }
    }
}
