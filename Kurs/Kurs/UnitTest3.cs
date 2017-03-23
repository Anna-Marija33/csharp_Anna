using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace Kurs
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod3()
        {
            IWebDriver driver = null;
            int attempt = 0;

            while (driver.FindElements(By.Id("Test")).Count == 0 && attempt < 60)   // Поиск элемента пока не найдено ноль
            {
                System.Threading.Thread.Sleep(1000);  // Ждем 1000 мс
                attempt = attempt + 1; // как вариант attempt++
            }

            //...
        }
    }
}
