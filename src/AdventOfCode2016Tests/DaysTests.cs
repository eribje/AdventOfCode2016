using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2016.Days;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class DaysTests
    {
        [TestMethod]
        public void Day1_Part1_R2L3()
        {
            var result = Day1.SolvePart1("R2, L3");

            Assert.AreEqual(5, result);                        
        }

        [TestMethod]
        public void Day1_Part1_R5L5R5R3()
        {
            var result = Day1.SolvePart1("R5,L5,R5,R3");

            Assert.AreEqual(12, result);            
        }

        [TestMethod]
        public void Day2_Part1_ULL()
        {
            var result = Day2.SolvePart1("ULL");
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void Day2_Part1_UUUUD()
        {
            var result = Day2.SolvePart1("UUUUD");
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void Day2_Part2()
        {
            var result = Day2.SolvePart2("ULL" + Environment.NewLine + "RRDDD" + Environment.NewLine + "LURDL" + Environment.NewLine + "UUUUD");
            Assert.AreEqual("5DB3", result);
        }
        // Tests
        //Day9.Solve("A(1x5)BC");
        //Day9.Solve("(3x3)XYZ");
        //Day9.Solve("(6x1)(1x3)A");
        //Day9.Solve("X(8x2)(3x3)ABCY");
    }
}
