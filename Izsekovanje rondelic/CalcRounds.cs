using System;

namespace Izsekovanje_rondelic
{
    class CalcRounds
    {
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
            int kateta = CalcYDistanceOfEvenRows(trak);
            string rounds = "";

            for (int a=0; a<noOfRows; a++)
            {
                if ((a+1) % 2 == 1)
                {
                    for (int b=0; b<noOfRoundsInOddRows; b++)
                    {
                        // kordinate za X os
                        if (b == 0)
                            rounds += (trak.xDistance + trak.r).ToString();
                        else
                            rounds += (trak.xDistance + trak.r + (2 * trak.r + trak.distance) * b).ToString();
                        rounds += ",";

                        // doda koordinate za Y os
                        if (a == 0)
                            rounds += (trak.yDistance + trak.r);
                        else
                            rounds += (trak.yDistance + trak.r + (kateta * a)).ToString();
                        rounds += "  ";
                    }
                }
                else
                {
                    for (int b=0; b<noOfRoundsInEvenRows; b++)
                    {
                        rounds += "  ";
                        if (b == 0)
                            rounds += Convert.ToInt32(trak.xDistance + (2 * trak.r) + (trak.distance / 2)).ToString();  // TODO kako zaokrožiti double?
                        else
                            rounds += Convert.ToInt32(trak.xDistance + trak.r + ((2 * trak.r) + (trak.distance / 2) * b)).ToString();
                        rounds += ",";

                        rounds += (trak.yDistance + trak.r + kateta * a);
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
                return noOfRounds = (trak.NetLength()+trak.distance) / (trak.r * 2 + trak.distance);
            else
                return noOfRounds = (trak.NetLength() - (trak.r * 2) + (trak.distance / 2)) / (trak.r * 2 + trak.distance);
        }

        private int CalcNoOfRows(Tape trak)
        {
            int noOfRows;
            int b = CalcYDistanceOfEvenRows(trak);

            noOfRows = ((trak.NetWidth() + (b - (2 * trak.r))) / b);

            return noOfRows;
        }

        /*
         * Izračun katete pravokotnega trikotnika za rezultat odmika sodih vrstic.
         */
        private int CalcYDistanceOfEvenRows(Tape trak)
        {
            double a;
            double b;
            double c;

            a = trak.r + (trak.distance / 2);
            c = (2 * trak.r) + trak.distance;
            b = Math.Sqrt(Math.Pow(c, 2) - Math.Pow(a, 2));

            return Convert.ToInt32(b);   // TODO: potrebno preveriti kaj naredimo z double!
        }
    }
}
