using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }


        public string Firstname { get; set; }

       // public string Middlname { get; set; }
       public string Lastname { get; set; }
       // public string Nickname { get; set; }
       // public string Address { get; set; }
       // public string Home { get; set; }
      //  public string Email { get; set; }
        //public string Id { get; set; }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname;
        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname);
        }

    }
}
