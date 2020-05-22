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
            Tape trak = new Tape(100, 40, 1, 1, 5, 4);
            CalcRounds calc = new CalcRounds();
            int calcResult = calc.GetNoOfRounds(trak);

            Assert.AreEqual(20, calcResult);
        }

        [TestMethod]
        public void Test_GetNoOfRounds2()
        {
            Tape trak = new Tape(100, 15, 1, 1, 6, 1);
            CalcRounds calc = new CalcRounds();
            int calcResult = calc.GetNoOfRounds(trak);

            Assert.AreEqual(7, calcResult);
        }
    }
}
