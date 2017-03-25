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
            ContactData contacta = new ContactData("Igo-go-go");    
                 
            app.Contacts.ModifyCon(0, contacta);

        }
    }
}
