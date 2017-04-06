using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allStroka;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;

        }


        public ContactData()
        {
           
        }


        public string Firstname { get; set; }
        public string Middlname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Tittle { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string FaxPhone { get; set; }
        public string Email { get; set; }
        public string Em2 { get; set; }
        public string Em3 { get; set; }
        public string HomePage { get; set; }
        public string Address2 { get; set; }
        public string Id { get; set; }
        public string Home { get; set; }
        public string Notes { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)+CleanUp(Home)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }


        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Em2) + CleanUp(Em3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        [JsonIgnore]

        public string AllStroka
        {
            get
            {
                if (allStroka != null)
                {
                    return allStroka;
                }
                else
                {
                    allStroka = (Preobr(Firstname + " " + Middlname + " " + Lastname) + Preobr(Nickname.Trim()) + Preobr(Tittle) + Preobr(Company) + Preobr(Address)
                        + "\r\n" + Preobr("H: " + HomePhone) + Preobr("M: " + MobilePhone) + Preobr("W: " + WorkPhone) + Preobr("F: " + FaxPhone) + "\r\n" + Preobr(Email)
                        + Preobr(Em2) + Preobr(Em3) + Preobr("Homepage:" + "\r\n" + HomePage) + "\r\n" + "\r\n" + Preobr(Address2) + "\r\n"
                        + Preobr("P: " + Home) + "\r\n" + Preobr(Notes));
                   
                    while (allStroka.LastIndexOf("\r\n") == allStroka.Length-2)/// отрезать с хвоста переводы строк если там пустые строки шли
                        {
                        allStroka = allStroka.Remove(allStroka.Length - 2);
           
                       }

                    return allStroka;
                 }
            }
            set
            {
                allStroka = value;
            }
        }


        private string Preobr(string kusok)
        {
            kusok = kusok.Trim();
            kusok = kusok.Replace("  ", " ");  //Заменить два пробела на один если миддлнейм пустой был


            if ((kusok.Substring(kusok.IndexOf(":") + 1)).Trim()== "") // это если телефон пустой то надписи тоже стереть
           {
                return "";
            }

            if (kusok != "") // а если не пустая строка добавить перевод каретки
            {
                kusok = kusok + "\r\n";
            }
                        
            return kusok;
        }


        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           //return .Replace("-", "").Replace("(","").Replace(")", "")+"\r\n";
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

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

            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            //return "Firstname=" + Firstname;
            return "Firstname=" + Firstname+"Lastname="+Lastname;

        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
             string aaaa = other.Firstname + other.Lastname;
             string bbbb = Firstname + Lastname;


            //return Firstname.CompareTo(other.Firstname)
           
            return  bbbb.CompareTo(aaaa);
        }

    }
}
