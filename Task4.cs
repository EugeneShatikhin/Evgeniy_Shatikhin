using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace DevAndTest_Classes
{
    class Task4
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, NumOfPairs(new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }, 5));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(4, NumOfPairs(new int[] { 1, 3, 6, 2, 7, 8, 4, 5 }, 9));
        }
        public int NumOfPairs(int[] nums, int target)
        {
            var numbers = nums.ToList();
            int pairs = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                pairs += numbers.Count(num => target - numbers[i] == num);
            }
            return pairs / 2;
        }
    }
}
