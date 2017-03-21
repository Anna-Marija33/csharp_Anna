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

            // выяснить есть ли запись если нету то создать
            app.Contacts.Analis();

            //удалить запись
            app.Contacts.Removal(1);
           
        }

       


    }
}
