using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GRoupRemovalTests: AuthTestBase
    {
      
        [Test]
        public void GRoupRemovalTest()
        {
            app.Groups.Remove(1);
 
        }

 
      
    }
}
