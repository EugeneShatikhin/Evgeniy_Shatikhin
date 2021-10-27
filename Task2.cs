using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
namespace DevAndTest_Classes
{
    [TestFixture]
    class Task2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("A", first_non_repeating_letter("SssTttttAS"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("T", first_non_repeating_letter("sTreSS"));
        }
        public string first_non_repeating_letter(string data)
        {
            string loweredData = data.ToLower();
            List<char> chars = loweredData.Select(ch => ch).Distinct().ToList(); // get all characters in string
            foreach (var item in chars)
            {
                if (loweredData.Count(ch => ch == item) == 1) 
                {
                    int Index;
                    if (data.IndexOf(item) == -1) Index = data.IndexOf(item.ToString().ToUpper()); // character is actually uppercase
                    else Index = data.IndexOf(item); // character is actually lowercase
                    return data[Index].ToString();
                }
            }   
            return "";
        }
    } 
}
