using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;




namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTests : AuthTestBase
    {
    [Test]
    public void ContactInformationTest()
    {
        ContactData  fromTable = app.Contacts.GetContacInformationFromTable(0);
        ContactData  fromForm = app.Contacts.GetContacInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }


        [Test]
        public void ContactKartInformation()
        {
            ContactData fromKart = app.Contacts.GetContactInformationFromKart(0);
            System.Console.Out.Write("firstname=");
            //      ContactData fromForm = app.Contacts.GetContacInformationFromEditForm(0);

            //      Assert.AreEqual(fromKart, fromForm);
            //       Assert.AreEqual(fromKart.Address, fromForm.Address);
            //      Assert.AreEqual(fromKart.AllPhones, fromForm.AllPhones);
            //      Assert.AreEqual(fromKart.AllEmails, fromForm.AllEmails);
        }




    }
}
