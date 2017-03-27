﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


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

            
            List<ContactData> oldcont = app.Contacts.GetContactList();
            //удалить запись
            app.Contacts.Removal(0);
            Assert.AreEqual(oldcont.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newcont = app.Contacts.GetContactList();
            

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
