using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("aaa");
          // contact.Middlname = "bbb";
            contact.Lastname = "ccc";
          //  contact.Nickname = "ddd";
         //   contact.Address = "ggg";
         //   contact.Home = "hhhh";
         //   contact.Email = "eee";

            List<ContactData> oldcont = app.Contacts.GetContactList();

            app.Contacts.CreateCont(contact);
                    
            List<ContactData> newcont = app.Contacts.GetContactList();
           oldcont.Add(contact);
           // oldcont.Sort();
          //  newcont.Sort();
            Assert.AreEqual(oldcont, newcont);
        }

        [Test]
        public void BadContactCreationTest()
        {
            ContactData contact = new ContactData("a'a");

            List<ContactData> oldcont = app.Contacts.GetContactList();

            app.Contacts.CreateCont(contact);
            List<ContactData> newcont = app.Contacts.GetContactList();
            oldcont.Add(contact);
            oldcont.Sort();
            newcont.Sort();
            Assert.AreEqual(oldcont, newcont);
        }

        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");

            List<ContactData> oldcont = app.Contacts.GetContactList();

            app.Contacts.CreateCont(contact);

            List<ContactData> newcont = app.Contacts.GetContactList();

            oldcont.Add(contact);
            oldcont.Sort();
            newcont.Sort();
            Assert.AreEqual(oldcont, newcont);
        }
    }
}
