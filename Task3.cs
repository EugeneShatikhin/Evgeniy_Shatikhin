using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace DevAndTest_Classes
{
    class Task3
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(6, DigitalRoot(132189));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(2, DigitalRoot(493193));
        }
        public int DigitalRoot(int num)
        {
            var query = num.ToString().Select(ch => int.Parse(ch.ToString()));
            int sum = 0;
            foreach (var digit in query) sum += digit;
            if (sum > 9) return DigitalRoot(sum);
            return sum;
        }
    }
}
