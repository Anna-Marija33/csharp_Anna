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
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("aga");
                app.Contacts.CreateCont(contact);
            }
            ContactData contacta = new ContactData("Igo-go-go");
            
            app.Contacts.ModifyCon(1, contacta);

        }
    }
}
