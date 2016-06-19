using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Numerics.Tests
{
    [TestClass]
    public class RangeTest
    {
        [TestMethod]
        public void WhenRangesAreSplit_WithValidValues_ValidNumberOfRangesIsReturned()
        {
            const int testNumberToRange = 100;
            Assert.AreEqual(25, new Range(testNumberToRange).Split(25).Count());
            Assert.AreEqual(5, new Range(testNumberToRange).Split(5).Count());
            Assert.AreEqual(2, new Range(testNumberToRange).Split(2).Count());
        }

        [TestMethod]
        public void WhenOddRangesAreSplit_WithEvenRangeCounts_ValidNumberOfRangesIsReturned()
        {
            Assert.AreEqual(2, new Range(5).Split(2).Count());
            Assert.AreEqual(4, new Range(9).Split(4).Count());
        }

        [TestMethod]
        public void WhenEvenRangesAreSplit_WithOddRangeCounts_ValidNumberOfRangesIsReturned()
        {
            Assert.AreEqual(3, new Range(10).Split(3).Count());
            Assert.AreEqual(3, new Range(4).Split(3).Count());
        }

        [TestMethod]
        public void WhenOddRangesAreSplit_WithEvenRangeCounts_TheRemainderIsAddedToTheLeadingRanges()
        {
            Assert.AreEqual(3, new Range(5).Split(2).First().Length);
        }

        [TestMethod]
        public void WhenEnumeratingRanges_TheEnumerationYeidsAppropriately()
        {
            const int count = 5;
            var runningSum = new Range(count).AsEnumerable().Count();
            Assert.AreEqual(count, runningSum);
        }
    }
}