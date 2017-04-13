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
           app.Groups.Proverka();

           //Модификация группы
            GroupData newData = new GroupData("uuu");
            newData.Header = null;
            newData.Footer = null;

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData ForModify = oldGroups[0];

            app.Groups.Modify(ForModify, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
           
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
