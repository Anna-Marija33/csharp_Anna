using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;




namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            this.driver = driver;
        }

        public ContactHelper CreateNewContact()
        {//Создание новго контакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {//заполнение формы данными
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Finame);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {//Подтверждение
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {// выбор контакта
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index +"]")).Click(); //Переведено на параметр
            return this;
        }

        public ContactHelper RemoveContact()
        {// удаление контакта
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept(); //закрытие диалогового окна
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }





        }
    }
