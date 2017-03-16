using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
 //    [TestFixture]
 // public class ContactCreationTests
 // {
 //  private IWebDriver driver;
 // private StringBuilder verificationErrors;
 // private string baseURL;
 //  private bool acceptNextAlert = true;

//   [SetUp]
//      public void SetupTest()
//      {
//          driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
//           baseURL = "http://localhost/";
//           verificationErrors = new StringBuilder();
//   }

//       [TearDown]
//     public void TeardownTest()
//      {
//          try
//         {
//      driver.Quit();
//  }
//           catch (Exception)
//            {
// Ignore errors if unable to close the browser
//   }
//      Assert.AreEqual("", verificationErrors.ToString());
//   }

//       [Test]
//     public void ContactCreationTest()       
//     {
//         OpenHomePage();
//          Login(new AccountData("admin", "secret"));
//          CreateNewContact();
//       ContactData contact = new ContactData("Miau");
//           FillContactForm(contact);
//           SubmitContactCreation();

//  }


//      private void SubmitContactCreation()
//      {
//      driver.FindElement(By.Name("submit")).Click();
//  }


//     private void FillContactForm(ContactData contact)
//     {
//     driver.FindElement(By.Name("firstname")).Clear();
//      driver.FindElement(By.Name("firstname")).SendKeys(contact.Finame);
//   }

//      private void InitNewContactCreation()
//      {
//     driver.FindElement(By.Name("new")).Click();
// }

//     private void OpenHomePage()
//     {
//    //Открытие страницы
//   driver.Navigate().GoToUrl(baseURL + "addressbook/");
//  }

//   private void Login(AccountData account)
//  {
//  //Ввод логина
//   driver.FindElement(By.Name("user")).Clear();
//    driver.FindElement(By.Name("user")).SendKeys(account.Username);
//    driver.FindElement(By.Name("pass")).Clear();
//     driver.FindElement(By.Name("pass")).SendKeys(account.Password);
//   driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
//  }

//    private void CreateNewContact()
//    {
//     driver.FindElement(By.LinkText("add new")).Click();
//   }

//  private bool IsElementPresent(By by)
//     {
//        try
//       {
//driver.FindElement(by);
//            return true;
//}
//          catch (NoSuchElementException)
//         {
//             return false;
//}
//}

//  private bool IsAlertPresent()
//      {
//          try
//          {
//  driver.SwitchTo().Alert();
//              return true;
//}
//            catch (NoAlertPresentException)
//          {
//              return false;
//}
//}

// private string CloseAlertAndGetItsText()
//      {
//         try
//       {
// IAlert alert = driver.SwitchTo().Alert();
// string alertText = alert.Text;
//             if (acceptNextAlert)
//            {
// alert.Accept();
//}
//              else
//             {
// alert.Dismiss();
//                return alertText;
//}
//           finally
//          {
//  acceptNextAlert = true;
//}
//}
//}
}
