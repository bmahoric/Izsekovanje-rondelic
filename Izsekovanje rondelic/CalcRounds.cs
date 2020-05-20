using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Izsekovanje_rondelic
{
    class CalcRounds
    {
        public int r { get; set; }
        public int distance { get; set; }
        private int noOfRoundsInOddRows { get; set; }
        private int noOfRoundsInEvenRows { get; set; }
        private int noOfRows { get; set; }
        
        public int GetNoOfRounds(Tape trak)
        {
            noOfRoundsInOddRows = CalcRoundsInCols(trak, true);
            noOfRoundsInEvenRows = CalcRoundsInCols(trak, false);
            noOfRows = CalcNoOfRows(trak);

            int noOfEvenRows = noOfRows / 2;
            int noOfOddRows = (noOfRows % 2) + noOfEvenRows; 

            return (noOfEvenRows * noOfRoundsInEvenRows) + (noOfOddRows * noOfRoundsInOddRows);
        }

        public string PrintRoundLocations(Tape trak)
        {
            noOfRoundsInOddRows = CalcRoundsInCols(trak, true);
            noOfRoundsInEvenRows = CalcRoundsInCols(trak, false);
            noOfRows = CalcNoOfRows(trak);

            int noOfEvenRows = noOfRows / 2;
            int noOfOddRows = (noOfRows % 2) + noOfEvenRows;
            int kateta = CalcYDistanceOfEvenRows();
            string rounds = "";

            for (int a=0; a<noOfRows; a++)
            {
                if ((a+1) % 2 == 1)
                {
                    for (int b=0; b<noOfRoundsInOddRows; b++)
                    {
                        // kordinate za X os
                        if (b == 0)
                            rounds += (trak.xDistance + r).ToString();
                        else
                            rounds += (trak.xDistance + r + (2 * r + distance) * b).ToString();
                        rounds += ",";

                        // doda koordinate za Y os
                        if (a == 0)
                            rounds += (trak.yDistance + r);
                        else
                            rounds += (trak.yDistance + r + (kateta * a)).ToString();
                        rounds += "  ";
                    }
                }
                else
                {
                    for (int b=0; b<noOfRoundsInEvenRows; b++)
                    {
                        rounds += "  ";
                        if (b == 0)
                            rounds += Convert.ToInt32(trak.xDistance + (2 * r) + (distance / 2)).ToString();  // TODO kako zaokrožiti double?
                        else
                            rounds += Convert.ToInt32(trak.xDistance + r + ((2 * r) + (distance / 2) * b)).ToString();
                        rounds += ",";

                        rounds += (trak.yDistance + r + kateta * a);
                        rounds += "  ";
                    }
                }
                rounds += Environment.NewLine + Environment.NewLine;
            }
            return rounds;
        }

        /*
         * Prešteje število rondelic v vrsticah - sodih oz. lihih
         */
        private int CalcRoundsInCols(Tape trak, bool isOdd)
        {
            int noOfRounds;

            if (isOdd)
                return noOfRounds = (trak.NetLength()+distance) / (r * 2 + distance);
            else
                return noOfRounds = (trak.NetLength() - (r * 2) + (distance / 2)) / (r * 2 + distance);
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
