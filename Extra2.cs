using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace DevAndTest_Classes
{
    [TestFixture]
    class Extra2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(2149583361, GetInt32FromIPv4("128.32.10.1"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(32, GetInt32FromIPv4("0.0.0.32"));
        }
        public UInt32 GetInt32FromIPv4(string ip)
        {
            var octets = ip.Split('.').Reverse();
            string sresult = "";
            foreach(var octet in octets)
            {
                string binary = Convert.ToString(int.Parse(octet), 2);
                if (binary.Length < 8) binary = binary.Insert(0, string.Concat(Enumerable.Repeat('0', 8 - binary.Length)));
                sresult = sresult.Insert(0, binary);
            }
            return Convert.ToUInt32(sresult, 2);
        }
    }
}
