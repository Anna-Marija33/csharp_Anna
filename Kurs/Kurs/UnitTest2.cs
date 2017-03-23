using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kurs
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            string[] s = new string[] { "I", "want", "to", "sleep", "test" };

            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");
            }
        }
    }
}
