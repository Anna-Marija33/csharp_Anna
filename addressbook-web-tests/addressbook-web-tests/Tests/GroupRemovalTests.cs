using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GRoupRemovalTests: AuthTestBase
    {
      
        [Test]
        public void GRoupRemovalTest()
        {
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("grrr");
                group.Header = "";
                group.Footer = "";

                app.Groups.Create(group);
            }

            app.Groups.Remove(1);
 
        }

 
      
    }
}
