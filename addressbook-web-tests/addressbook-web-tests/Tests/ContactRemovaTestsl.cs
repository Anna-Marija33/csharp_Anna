using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Removal(1);
            //app.Navigator.OpenHomePage();
            //app.Auth.Login(new AccountData("admin", "secret"));
            //app.Contacts
            //    .SelectContact(1)
            //    .RemoveContact();
        }
        

    }
}
