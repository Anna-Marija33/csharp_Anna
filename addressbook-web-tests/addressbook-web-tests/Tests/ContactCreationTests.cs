using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Exel = Microsoft.Office.Interop.Excel;

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



        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
               File.ReadAllText(@"contacts.json"));

        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }



        public static IEnumerable<ContactData> ContactDataFromCsvFile()
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


        public static IEnumerable<ContactData> ContactDataFromExelFile()
        {
            List<ContactData> groups = new List<ContactData>();
            Exel.Application app = new Exel.Application();
            Exel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Exel.Worksheet sheet = wb.ActiveSheet;
            Exel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].value,
                    Lastname = range.Cells[i, 2].value,
                    Middlname = range.Cells[i, 3].value,
                    Nickname = range.Cells[i, 3].value
                });
            }
            wb.Close();
            app.Visible = false;
            return groups;

        }


        [Test, TestCaseSource("ContactDataFromExelFile")]
        public void ContactCreationTest(ContactData contact)
        {
  

            List<ContactData> oldcont = ContactData.GetAll(); 

            app.Contacts.CreateCont(contact);

          
              Assert.AreEqual(oldcont.Count+1, app.Contacts.GetContactCount());

              List<ContactData> newcont = ContactData.GetAll(); 
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
