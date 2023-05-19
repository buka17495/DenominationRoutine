using DenominationRoutine;
using NUnit.Framework;

namespace DenominationRoutineTests
{
    public class DenominationTests
    {
        [TestCase(30, 1)]
        [TestCase(50, 2)]
        [TestCase(60, 2)]
        [TestCase(80, 2)]
        [TestCase(140, 4)]
        [TestCase(230, 9)]
        [TestCase(370, 20)]
        [TestCase(610, 49)]
        [TestCase(980, 110)]
        //example
        [TestCase(100, 4)]
        public void DenominateTests(int sum, int expectedCount)
        {
            var count = Program.Denominate(sum);

            Assert.AreEqual(expectedCount, count);
        }
    }
}