using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
namespace DevAndTest_Classes
{
    [TestFixture]
    class Task1
    {
        [Test]
        public void Test1()
        {
            var data = new List<object> { 1, 2, "a", "b" };
            var res = FilterOutIntegers(data);
            Assert.AreEqual(new List<int> { 1, 2 }, res);
        }
        [Test]
        public void Test2()
        {
            var data = new List<object> { 1, 2, "a", "b", "aasf", "1", "123", 231 };
            var res = FilterOutIntegers(data);
            Assert.AreEqual(new List<int> { 1, 2, 231 }, res);
        }
        public List<int> FilterOutIntegers(List<object> data)
        {
            return data.Where(item => item is Int32).Select(item => (int)item).ToList();
        }
    }
}
