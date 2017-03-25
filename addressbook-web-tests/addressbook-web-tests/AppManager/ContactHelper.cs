using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;





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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
           
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                string firstname = cells[2].Text;      
                contacts.Add(new ContactData(firstname));
               
                
            }

            return contacts;
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
                ContactData contact = new ContactData("ugu");
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
          //  Type(By.Name("middlename"), contact.Middlname);
           Type(By.Name("lastname"), contact.Lastname);
         //   Type(By.Name("nickname"), contact.Nickname);
         //   Type(By.Name("address"), contact.Address);
         //   Type(By.Name("home"), contact.Home);
         //   Type(By.Name("email"), contact.Email);

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {//Подтверждение
            driver.FindElement(By.Name("submit")).Click();
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
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[" + index + "]")).Click();
            return this;
        }

    }
}
