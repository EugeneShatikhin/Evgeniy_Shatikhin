using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace DevAndTest_Classes
{
    [TestFixture]
    class Extra1
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(21, NextBigger(12));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(2071, NextBigger(2017));
        }
        public int NextBigger(int num)
        {
            List<int> digits = num.ToString().Select(ch => int.Parse(ch.ToString())).Reverse().ToList();
            // digits in reversed order
            int sum = 0, exp = 1;
            bool found = false;
            for (int i = 0; i < digits.Count-1; i++)
            {
                if(digits[i] > digits[i+1] && !found)
                {
                    int temp = digits[i + 1];
                    digits[i + 1] = digits[i];
                    digits[i] = temp;
                    found = true;
                }
                sum += digits[i] * exp;
                exp *= 10;
            }
            sum += digits[digits.Count - 1] * exp;
            if (!found) return -1;
            return sum;
        }
    }
}
