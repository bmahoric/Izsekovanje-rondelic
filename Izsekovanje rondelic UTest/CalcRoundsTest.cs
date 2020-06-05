using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Izsekovanje_rondelic;
using System.Runtime.InteropServices;

namespace Izsekovanje_rondelic_UTest
{
    [TestClass]
    public class CalcRoundsTest
    {
        [TestMethod]
        public void Test_GetNoOfRounds1()
        {
            Tape trak = new Tape(100, 40, 1, 1);
            Round rondelica = new Round(5, 4);
            IRoundsPattern calc = new TriangularRoundsPattern(trak, rondelica);
            int calcResult = calc.CalcNoOfRounds();

            Assert.AreEqual(20, calcResult);
        }

        [TestMethod]
        public void Test_GetNoOfRounds2()
        {
            Tape trak = new Tape(100, 15, 1, 1);
            Round rondelica = new Round(8, 2);
            IRoundsPattern calc = new TriangularRoundsPattern(trak, rondelica);
            int calcResult = calc.CalcNoOfRounds();

            Assert.AreEqual(7, calcResult);
        }
    }
}
