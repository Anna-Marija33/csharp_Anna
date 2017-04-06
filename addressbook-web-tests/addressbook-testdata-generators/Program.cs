using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Exel = Microsoft.Office.Interop.Excel;

namespace addressbook_testdata_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.Out.Write("Hello, World!");
            int count = Convert.ToInt32(args[0]);
            //StreamWriter writer = new StreamWriter(args[1]);
            string filename = args[1];
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });

               
            }
            if (format == "exel")
            {
                writeGroupsToExelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognised format" + format);
                }

                writer.Close();
            }
     
        }


        static void writeGroupsToExelFile(List<GroupData> groups, string filename)
        {
            Exel.Application app = new Exel.Application();
            app.Visible = true;
            Exel.Workbook wb = app.Workbooks.Add();
            Exel.Worksheet sheet = wb.ActiveSheet;
            //sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
        }


        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
               group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {

            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
