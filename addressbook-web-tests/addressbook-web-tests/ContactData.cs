using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string finame;
       

        public ContactData(string finame)
        {
            this.finame = finame;
        }


        public string Finame
        {
            get
            {
                return finame;
            }
            set
            {
                finame = value;
            }
        }

       
    }
}
