using System;
using System.Text;
using System.IO;
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



        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Middlname = parts[2],
                    Nickname = parts[3]
                });
            }
            return contacts;
        }




        [Test, TestCaseSource("ContactDataFromFile")]
        public void ContactCreationTest(ContactData contact)
        {
  

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
