using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace DevAndTest_Classes
{
    [TestFixture]
    class Task5
    {
        [Test]
        public void Test1()
        {
            string s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string exp = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            Assert.AreEqual(exp, DensRequest(s));
        }
        [Test]
        public void Test2()
        {
            string s = "Elmer:Preston;Duncan:Clem;Monica:Preston;Courtney:Pauley;Craig:Preston;Patrick:Clem;Baxter:Preston;Gene:Clem";
            string exp = "(CLEM, DUNCAN)(CLEM, GENE)(CLEM, PATRICK)(PAULEY, COURTNEY)(PRESTON, BAXTER)(PRESTON, CRAIG)(PRESTON, ELMER)(PRESTON, MONICA)";
            Assert.AreEqual(exp, DensRequest(s));
        }
        public struct Person
        {
            public Person(string f, string l)
            {
                this.firstName = f;
                this.lastName = l;
            }
            public string firstName;
            public string lastName;
        }
        public string DensRequest(string s)
        {
            s = s.ToUpper();
            var People = new List<Person>();
            string[] people = s.Split(';');
            foreach (var person in people)
            {
                string[] fullname = person.Split(':');
                People.Add(new Person(fullname[0], fullname[1]));
            }
            People = People.OrderBy(person => person.lastName).ThenBy(person => person.firstName).ToList();
            string res = "";
            foreach (var person in People)
            {
                res += "(" + person.lastName + ", " + person.firstName + ")";
            }
            return res;
        }
    }
}
