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

            int gorc = Convert.ToInt32(args[0]);
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
           
           

            if (gorc == 1)
            {
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
            else
            {
                if (gorc == 2)
                {
                    List<ContactData> contacts = new List<ContactData>();
                    for (int i = 0; i < count; i++)
                    {
                        contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                        {
                            Middlname = TestBase.GenerateRandomString(10),
                            Nickname = TestBase.GenerateRandomString(10)
                        });
                    }

                    if (format == "exel")
                    {
                        writeContactsToExelFile(contacts, filename);
                    }
                    else
                    {
                        StreamWriter writerc = new StreamWriter(filename);
                        if (format == "csv")
                        {
                            writeContactsToCsvFile(contacts, writerc);
                        }
                        else if (format == "xml")
                        {
                           // System.Console.Out.Write("filename =" + filename+ "  format="+format);
                            writeContactsToXmlFile(contacts, writerc);
                        }
                        else if (format == "json")
                        {
                            writeContactsToJsonFile(contacts, writerc);
                        }
                        else
                        {
                            System.Console.Out.Write("Unrecognised format" + format);
                        }
                        writerc.Close();
                    }
                    
                }
                //else
                //{
               //     System.Console.Out.Write("Неправильный параметр типа данных = " + gorc);
                //}

            }
        
         }



        static void writeContactsToExelFile(List<ContactData> contacts, string filename)
        {
            Exel.Application app = new Exel.Application();
            app.Visible = true;
            Exel.Workbook wb = app.Workbooks.Add();
            Exel.Worksheet sheet = wb.ActiveSheet;
            
            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Lastname;
                sheet.Cells[row, 3] = contact.Middlname;
                sheet.Cells[row, 4] = contact.Nickname;
                
                row++;
            }

            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
        }

        
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3}",
               contact.Firstname, contact.Lastname, contact.Middlname, contact.Nickname));
            }
        }


        
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        
         static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
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
