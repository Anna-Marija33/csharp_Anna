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
    public class ContactRemovalTests: AuthTestBase
    {
        
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("aga");
                app.Contacts.CreateCont(contact);
            }

            app.Contacts.Removal(1);
           
        }

       


    }
}
