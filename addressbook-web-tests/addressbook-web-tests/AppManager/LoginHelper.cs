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
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsloggedIn())
            {
                if (IsloggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }



        public void Logout()
        {
            if (IsloggedIn())
            {

                driver.FindElement(By.LinkText("Logout")).Click();
            }
           
        }

        public bool IsloggedIn(AccountData account)
        {
            return IsloggedIn()
                && GetLoggedUserName() == account.Username;
                
            
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
                
        }

        public bool IsloggedIn()
        {
            return IsElementPresent(By.Name("logout"));
     
        }
    }

} 