using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Exel = Microsoft.Office.Interop.Excel;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++ )
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.xml");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
               File.ReadAllText(@"groups.json") );

        }

        public static IEnumerable<GroupData> GroupDataFromExelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Exel.Application app = new Exel.Application();
            Exel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Exel.Worksheet sheet = wb.ActiveSheet;
            Exel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i,1].value,
                    Footer = range.Cells[i, 2].value,
                    Header = range.Cells[i, 3].value
                });
            }
            wb.Close();
            app.Visible = false;
            return groups;

        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));

        }

        [Test, TestCaseSource("GroupDataFromExelFile")]

        public void GroupCreationTest(GroupData group)
        {
           

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
                       

            List<GroupData> newGroups = app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов
            //groups.Count //количество элементов в этом списке
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

      


        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();// контейнер или коллекция то есть объект который хранит набор других объектов
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }


    }
}
