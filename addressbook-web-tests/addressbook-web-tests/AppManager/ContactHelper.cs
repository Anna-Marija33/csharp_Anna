using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;








namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper CreateCont(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            CreateNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper ModifyCon(int p, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(p);
            FillContactForm(contact);
            SubmitContactModification(p);
            return this;
        }

       

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                     string firstname = cells[2].Text;
                     string lastname = cells[1].Text;
                    // string id = cells[1].Text;
                    //contactCache.Add(new ContactData(firstname));
                    //contactCache.Add(new ContactData(firstname) {Id=id }); 
                    contactCache.Add(new ContactData(firstname, lastname) { Id = element.FindElement(By.TagName("input")).GetAttribute("id") });
                    //contactCache.Add(new ContactData (element.Text) { Id = element.FindElement(By.TagName("input")).GetAttribute("id") });
                }
            }
            
            return new List < ContactData >(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.OpenHomePage();
            return driver.FindElements(By.Name("entry")).Count;
         }

        public ContactHelper Removal(int p)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(p);
            RemoveContact();
            return this;
        }

        public void Analis()
        {
            if (!Nalichie())
            {
                ContactData contact = new ContactData("ugu","aga");
                CreateCont(contact);
            }
        }

        public bool Nalichie()
        {
            return IsElementPresent(By.Name("selected[]"));
         }

       

        public ContactHelper CreateNewContact()
        {//Создание нового контакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {//заполнение формы данными
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlname);
           Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
           Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("email"), contact.Email);

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {//Подтверждение
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {// выбор контакта
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) +"]")).Click(); //Переведено на параметр
            return this;
        }

        public ContactHelper RemoveContact()
        {// удаление контакта
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
           driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper InitContactModificationn(int index)
        {
            driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"))[7].
                FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper InitContactModificationnn(int index)
        {
            driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"))[6].
                FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[" + (index + 1) + "]")).Click();
            contactCache = null;
            return this;
        }

        public ContactData GetContacInformationFromTable(int index)  
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
               
            };

        }



        public ContactData GetContactInformationFromKart(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationnn(0);
            ContactData aaa = new  ContactData("aaa", "ccc");

            //string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            // string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            //string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            //System.Console.Out.Write("firstname="+firstName);
            //  string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            //  string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            //  string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            //  string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            //  string home = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            return aaa;
           // return new ContactData(firstName, lastName);
          //  {
         //       Address = address,
         //       HomePhone = homePhone,
         //       MobilePhone = mobilePhone,
         //       WorkPhone = workPhone,
         //       Home = home
         //   };
        }

        public ContactData  GetContacInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationn(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string tittle = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email  = driver.FindElement(By.Name("email")).GetAttribute("value");
            string em2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string em3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string home = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Middlname = middlName,
                 Nickname = nickName,
                 Tittle = tittle,
                 Company = company,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                FaxPhone = faxPhone,
                HomePage = homePage,
                Address2 = address2,
                Home = home,
                Email = email,
                Em2 = em2,
                Em3 = em3

            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value); 
        }

    }
}
