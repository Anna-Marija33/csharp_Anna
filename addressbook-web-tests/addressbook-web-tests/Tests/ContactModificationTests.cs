using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        
        [Test]
        public void ContactModificationTest()
        {
            // выяснить есть ли запись если нету то создать
           app.Contacts.Analis();
           
            ///модифицировать запись
            ContactData contacta = new ContactData("DA");
            contacta.Lastname = null;
            contacta.Middlname = null;
            contacta.Lastname = null;
            contacta.Nickname = null;
            contacta.Address = null;
            contacta.Home = null;
            contacta.Email = null;

            List<ContactData> oldcont = app.Contacts.GetContactList();

            app.Contacts.ModifyCon(0, contacta);

           // Assert.AreEqual(oldcont.Count, app.Contacts.GetContactCount());

            List<ContactData> newcont = app.Contacts.GetContactList();
            oldcont[0].Firstname = contacta.Firstname;
        //    oldcont[0].Lastname = contacta.Lastname;
            oldcont.Sort();
            newcont.Sort();
            Assert.AreEqual(oldcont, newcont);
        }
    }
}
