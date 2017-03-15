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
    public class ContactCreation: TestBase
    {
        [Test]
        public void ContactCreations()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new WebAddressbookTests.AccountData("admin", "secret"));
      //      app.


       }
    }
}
