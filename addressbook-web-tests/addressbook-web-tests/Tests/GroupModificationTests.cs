using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //Проверить наличие групп если нет то создать
     //      app.Groups.Proverka();

           //Модификация группы
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            // Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
