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
        [Test]
        public void Test3()
        {
            Assert.AreEqual(6, NumOfPairs(new int[] { 3, 3, 3, 3 }, 6));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(3, NumOfPairs(new int[] { -2, -2, -2 }, -4));
        }
        public int NumOfPairs(int[] nums, int target)
        {
            var numbers = nums.ToList();
            int pairs = 0;
            int length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                pairs += numbers.Count(num => num + numbers[0] == target);
                if(numbers[0] * 2 == target) pairs -= 1; // we don't want to count num+num as pair
                numbers.RemoveAt(0);
            }
            return pairs;
        }
    }
}
