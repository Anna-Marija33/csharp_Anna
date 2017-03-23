using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GRoupRemovalTests: AuthTestBase
    {
      
        [Test]
        public void GRoupRemovalTest()
        {

            //Проверить наличие групп если нет то создать
           // app.Groups.Proverka();

            List<GroupData> oldGroups = app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов
            
            //удалить группу
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

        }

 
      
    }
}
