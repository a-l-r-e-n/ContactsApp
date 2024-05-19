using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    internal class ProjectTests
    {
        [Test(Description = "Позитивный тест для сортировки контактов в проекте")]
        public void SortByName_SortingContacts_ListIsSorted()
        {
            // Setup
            var project = new Project();
            Contact[] contacts = new Contact[3];
            contacts[0] = new Contact("Петров", "Петр", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            contacts[1] = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            contacts[2] = new Contact("Сидоров", "Сергей", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            string[] expectedSernames = new string[contacts.Count()];
            expectedSernames[0] = contacts[1].Sername;
            expectedSernames[1] = contacts[0].Sername;
            expectedSernames[2] = contacts[2].Sername;

            // Act
            for (int i = 0; i < contacts.Count(); i++)
            {
                project.Contacts.Add(contacts[i]);
            }
            var sortedContacts = project.SortBySername();
            string[] actualSernames = new string[contacts.Count()];

            // Assert
            for (int i = 0; i < contacts.Count(); i++)
            {
                actualSernames[i] = sortedContacts[i].Sername;
                Assert.AreEqual(expectedSernames[i], actualSernames[i]);
            }
        }
        
        [Test(Description = "Позитивный тест поиска контакта по подстроке")]
        public void Search_FindContact_ReturnTrueValue()
        {
            // Setup
            var project = new Project();
            var contact1 = new Contact("Петров", "Петр", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var contact2 = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                new DateTime(2001,3,3), "qwe@gmail.com", "1111121");
            var expectedContact = contact2;
            var contact3 = new Contact("Сидоров", "Сергей", new PhoneNumber(79131231223),
                new DateTime(2000,1,1), "qwe@gmail.com", "1111121");

            // Act            
            project.Contacts.Add(contact1);
            project.Contacts.Add(contact2);
            project.Contacts.Add(contact3);
            var findedContacts = project.FindContact("Иван");
            var actualContact = findedContacts[0];

            // Assert
            Assert.AreEqual(expectedContact, actualContact);
        }
    }
}
