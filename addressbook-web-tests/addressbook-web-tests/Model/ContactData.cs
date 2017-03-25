using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
  //      private string middlname;


        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }


        public string Firstname { get; set; }

      //  public string Middlname { get; set; }
    }
}
