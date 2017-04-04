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

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                    {
                    Middlname = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30)
                });
            }

            return contacts;
        }
        


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
  //          ContactData contact = new ContactData("aaa","ccc");
  //          contact.Middlname = "bbb";
  //          contact.Nickname = "ddd";
  //          contact.Address = "ggg";
  //          contact.HomePhone = "hhhh";
 //           contact.Email = "eee";

            List<ContactData> oldcont = app.Contacts.GetContactList();

            app.Contacts.CreateCont(contact);

          
              Assert.AreEqual(oldcont.Count+1, app.Contacts.GetContactCount());

              List<ContactData> newcont = app.Contacts.GetContactList();
           // System.Console.Out.Write("=");

                     oldcont.Add(contact);
                       oldcont.Sort();
                      newcont.Sort();
                     Assert.AreEqual(oldcont, newcont);
        }

        [Test]
        public void BadContactCreationTest()
        {
            ContactData contact = new ContactData("a'a","");

            List<ContactData> oldcont = app.Contacts.GetContactList();

            app.Contacts.CreateCont(contact);

            Assert.AreEqual(oldcont.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newcont = app.Contacts.GetContactList();
            oldcont.Add(contact);
            oldcont.Sort();
            newcont.Sort();
            Assert.AreEqual(oldcont, newcont);
        }


     
    }
}
