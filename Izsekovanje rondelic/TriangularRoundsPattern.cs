using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izsekovanje_rondelic
{
    public class TriangularRoundsPattern : IRoundsPattern
    {
        public Tape _Tape { get; set; }
        public Round _Round { get; set; }

        public TriangularRoundsPattern(Tape tape, Round round)
        {
            _Tape = tape;
            _Round = round;
        }

        public int CalcNoOfRounds()
        {
            int noOfRows = CalcNoOfRows();

            int noOfEvenRows = noOfRows / 2;
            int noOfOddRows = (noOfRows % 2) + noOfEvenRows;

            return (noOfEvenRows * CalcRoundsInEvenRows()) + (noOfOddRows * CalcRoundsInOddRows());
        }

        private int CalcRoundsInOddRows()
        {
            return (_Tape.NetLength + _Round.Distance) / (_Round.R * 2 + _Round.Distance);
        }

        private int CalcRoundsInEvenRows()
        {
            return (_Tape.NetLength - (_Round.R * 2) + (_Round.Distance / 2)) / (_Round.R * 2 + _Round.Distance);
        }

        private int CalcNoOfRows()
        {
            int b = CalcTriangular_B_leg();

            return ((_Tape.NetWidth + (b - (2 * _Round.R))) / b);
        }

        /*
         * Izračun katete pravokotnega trikotnika za rezultat odmika sodih vrstic.
         */
        private int CalcTriangular_B_leg()
        {
            double a;
            double b;
            double c;

            a = _Round.R + (_Round.Distance / 2);
            c = (2 * _Round.R) + _Round.Distance;
            b = Math.Sqrt(Math.Pow(c, 2) - Math.Pow(a, 2));

            return Convert.ToInt32(b);   // TODO: potrebno preveriti kaj naredimo z double!
        }

        public string PrintRoundLocations()
        {
            int noOfRoundsInOddRows = CalcRoundsInOddRows();
            int noOfRoundsInEvenRows = CalcRoundsInEvenRows();
            int noOfRows = CalcNoOfRows();

            int kateta = CalcTriangular_B_leg();
            string rounds = "";

            for (int a = 0; a < noOfRows; a++)
            {
                if ((a + 1) % 2 == 1)
                {
                    for (int b = 0; b < noOfRoundsInOddRows; b++)
                    {
                        // koordinate za X os
                        if (b == 0)
                            rounds += (_Tape.XDistance + _Round.R).ToString();
                        else
                            rounds += (_Tape.XDistance + _Round.R + (2 * _Round.R + _Round.Distance) * b).ToString();
                        rounds += ",";

                        // koordinate za Y os
                        if (a == 0)
                            rounds += (_Tape.YDistance + _Round.R);
                        else
                            rounds += (_Tape.YDistance + _Round.R + (kateta * a)).ToString();
                        rounds += "  ";
                    }
                }
                else
                {
                    for (int b = 0; b < noOfRoundsInEvenRows; b++)
                    {
                        rounds += "  ";
                        if (b == 0)
                            rounds += Convert.ToInt32(_Tape.XDistance + (2 * _Round.R) + (_Round.Distance / 2)).ToString();  // TODO kako zaokrožiti double?
                        else
                            rounds += Convert.ToInt32(_Tape.XDistance + _Round.R + ((2 * _Round.R) + (_Round.Distance / 2) * b)).ToString();
                        rounds += ",";

                        rounds += (_Tape.YDistance + _Round.R + kateta * a);
                        rounds += "  ";
                    }
                }
                rounds += Environment.NewLine + Environment.NewLine;
            }
            return rounds;
        }
    }
}
