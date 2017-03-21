using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("grrr");
                group.Header = "";
                group.Footer = "";

                app.Groups.Create(group);
            }

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);

        }
    }
}
