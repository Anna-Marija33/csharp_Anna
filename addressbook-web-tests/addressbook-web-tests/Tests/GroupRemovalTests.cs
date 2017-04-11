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
             app.Groups.Proverka();



            List<GroupData> oldGroups = GroupData.GetAll();//app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов
            GroupData ToBeRemoved = oldGroups[0];

            //удалить группу
            app.Groups.Remove(ToBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();//app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов

     //       ToBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, ToBeRemoved.Id);
            }

        }

 
      
    }
}
