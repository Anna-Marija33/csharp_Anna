using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: ContactTestBase
    {
        
        [Test]
        public void ContactModificationTest()
        {
            // выяснить есть ли запись если нету то создать
           app.Contacts.Analis();
           
            ///модифицировать запись
            ContactData contacta = new ContactData("aga","ugu");
   
            contacta.Middlname = null;       
            contacta.Nickname = null;
            contacta.Address = null;
            contacta.HomePhone = null;
            contacta.Email = null;

            List<ContactData> oldcont = ContactData.GetAll();
            ContactData ForModify = oldcont[0];

          
           // System.Console.Out.WriteLine("lastname=" + contacta.Lastname);

            app.Contacts.ModifyCon(ForModify, contacta);

            

            Assert.AreEqual(oldcont.Count, app.Contacts.GetContactCount());

            List<ContactData> newcont = ContactData.GetAll();
            oldcont[0].Firstname = contacta.Firstname;
            oldcont[0].Lastname = contacta.Lastname;

            oldcont.Sort();
            newcont.Sort();
            Assert.AreEqual(oldcont, newcont);

            foreach (ContactData contact in newcont)
            {
               // System.Console.Out.WriteLine("index=" + ForModify.Id+ " indexbeg=" + contact.Id);
                if (contact.Id == ForModify.Id)
                    {
                  //  System.Console.Out.WriteLine("ravno   index=" + ForModify.Id + " indexbeg=" + contact.Id);
                    Assert.AreEqual(contacta.Firstname,contact.Firstname);
                     }
            }
        }
    }
}
