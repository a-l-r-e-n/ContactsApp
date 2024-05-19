using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    public class ContactTests
    {
        [Test(Description = "тест геттера Surname")]
        public void Test_Surname_Get_CorrectValue()
        {
            //Setup - Подготовка объекта к тестированию
            Contact contact = new Contact("Фамилия", "Имя", new PhoneNumber(79138569696),
               DateTime.Today, "qwe@gmail.com", "1111121");
            contact.Sername = "Смирнов"; //Исходные данные - setup
                                         //Выполнение тестируемого метода и сравнение с ожидаемым значением
            if (contact.Sername == "Смирнов")
            {
                // Test Description + Test Result
                Console.WriteLine("Тест Surname возврата корректной фамилии: пройден");
            }
            else
            {
                Console.WriteLine("Тест Surname возврата корректной фамилии: провален");
            }
        }

        [Test(Description = "Позитивный тест геттера Surname")]
        public void FullName_SetCorrectValue_ValueIsSetted()
        {
            // Setup
            Contact contact = new Contact("Фамилия","Имя", new PhoneNumber(79138569696),
               DateTime.Today, "qwe@gmail.com","1111121");
            var expected = "Иванов";
            contact.Sername = expected;

            // Act
            var actual = contact.Sername;

            // Assert
            Assert.AreEqual(expected, actual, "Значение фио установлено неправильно");
        }
    }
}
