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
    public class GroupHelper : HelperBase
    {
       
       public GroupHelper(ApplicationManager manager) : base(manager)
      {
        //this.driver = driver;
      }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage(); 
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();  //готовим пустой список
            //теперь нужно заполнить список данными
            manager.Navigator.GoToGroupsPage(); //переход на нужную страницу
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //означает что нас интересуют элеменгты с тэгом спан класс гроуп
            //Теперь мы должны эти элементы, это объекты типа айвебэлемент, превратит в нужные нам элементы типа групдейт
            foreach (IWebElement element in elements) // для каждого элемента такой то коллекции нужно выполнить ннечто
            {
                // GroupData group = new GroupData(element.Text); // создали объект
                // groups.Add(group);  //поместили
                // То же без промежуточного элемента
                groups.Add(new GroupData(element.Text)); //Итого: читаем элементы с вебстраницы, преобразовываем их в нужные нам объекты типа гроупдейт
            }

            return groups;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public void Proverka()
        {
            if (!NalichieGR())
            {
                GroupData group = new GroupData("grrr");
                group.Header = "";
                group.Footer = "";

                Create(group);
            }
        }

        public bool NalichieGR()
        {
            return IsElementPresent(By.Name("selected[]"));
        }


        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            //Создание новой группы
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            //Заполнение формы данными
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
           
            return this;
        }

     

        public GroupHelper ReturnToGroupsPage()
        {
            //Возврат  на страницу групп
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            //Подтверждение
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }



        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
