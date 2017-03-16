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

        public ContactHelper(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void CreateNewContact()
        {//Создание новго контакта
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillContactForm(ContactData contact)
        {//заполнение формы данными
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Finame);
        }

        public void SubmitContactCreation()
        {//Подтверждение
            driver.FindElement(By.Name("submit")).Click();           
        }

        public void SelectContact(int index)
        {// выбор контакта
            driver.FindElement(By.Id(""+index+"")).Click();
        }

        public void RemoveContact()
        {// удаление контакта
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
          //  Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));

        }
    }
}
