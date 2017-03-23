using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kurs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] s = new string[] { "I","want","to","sleep","test" };

            for (int i = 0; i < s.Length; i++)
            {
                System.Console.Out.Write(s[i] + "\n");
            }
        }
    }
}
