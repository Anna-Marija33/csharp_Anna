using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

//using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
//using System.Text.RegularExpressions;



namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        
        [Test]
        public void ContactRemovalTest()
        {

            // выяснить есть ли запись если нету то создать
            app.Contacts.Analis();


            // List<ContactData> oldcont = app.Contacts.GetContactList();
            List<ContactData> oldcont = ContactData.GetAll();
            ContactData ToBeRemoved = oldcont[0];

            //System.Console.Out.WriteLine("kolOldcont=" + oldcont.Count);

            //удалить запись
            app.Contacts.Removal(ToBeRemoved);

            
            System.Threading.Thread.Sleep(1000); //Не проходила проверка поколичеству я предположила что считать начинает раньше чем успевает удалиться запись, поэтому сделала паузу в одну секунду
            //несколько тупо, но я не сообразила появления какого элемента надо ожидать

           // System.Console.Out.WriteLine("kol2="+ app.Contacts.GetContactCount());

                   Assert.AreEqual(oldcont.Count - 1, app.Contacts.GetContactCount());

            // List<ContactData> newcont = app.Contacts.GetContactList();
            List<ContactData> newcont = ContactData.GetAll();

           ContactData ForRemoving = oldcont[0];
             oldcont.RemoveAt(0);

             Assert.AreEqual(oldcont, newcont);

            foreach (ContactData contact in newcont)
             {
                 Assert.AreNotEqual(contact.Id, ForRemoving.Id);
            }

        }



    }
}
