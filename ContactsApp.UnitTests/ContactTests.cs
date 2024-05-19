using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    public class ContactTests
    {
        // Тесты ФИО
        [TestCase("", "Должно возникать исключение, если Фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве Фамилии.")]
        [TestCase("СмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирнов", 
            "Должно возникать" + "исключение, если фамилия больше 100 символов",
            TestName = "Присвоение неправильной Фамилии больше 100 символов.")]
        public void Sername_SetIncorrectValue_ThrowException(string wrongSername, string message)
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                contact.Sername = wrongSername;
            }, message);
        }

        [Test(Description = "Присвоение корректного значения в поле Фамилия")]
        public void Sername_SetCorrectValue_ValueIsSetted()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223), 
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "Иванов";
            contact.Sername = expected;

            // Act
            var actual = contact.Sername;

            // Assert
            Assert.AreEqual(expected, actual, "Значение Фамилии установлено неправильно");
        }

        [Test(Description = "Позитивный тест геттера Фамилия")]
        public void Sername_GetValue_ReturnsValue()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223), 
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "Иванов";
            contact.Sername = expected;

            // Act
            var actual = contact.Sername;

            // Assert
            Assert.AreEqual(expected, actual, "Возвращается неправильное значение Фамилии");
        }

        // Тесты Имени
        [TestCase("", "Должно возникать исключение, если Имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве Имени.")]
        [TestCase("СмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирнов", 
            "Должно возникать" + "исключение, если Имя больше 100 символов",
            TestName = "Присвоение неправильного Имени больше 100 символов.")]
        public void Name_SetIncorrectValue_ThrowException(string wrongName, string message)
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                contact.Name = wrongName;
            }, message);
        }

        [Test(Description = "Присвоение корректного значения в поле Имя")]
        public void Name_SetCorrectValue_ValueIsSetted()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "Иван";
            contact.Name = expected;

            // Act
            var actual = contact.Name;

            // Assert
            Assert.AreEqual(expected, actual, "Значение Имени установлено неправильно");
        }

        [Test(Description = "Позитивный тест геттера Имя")]
        public void Name_GetValue_ReturnsValue()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "Иван";
            contact.Name = expected;

            // Act
            var actual = contact.Name;

            // Assert
            Assert.AreEqual(expected, actual, "Возвращается неправильное значение Имени");
        }

        // Тесты email
        [TestCase("", "Должно возникать исключение, если email - пустая строка",
            TestName = "Присвоение пустой строки в качестве email.")]
        [TestCase("СмирновСмирновСмирновСмирновСмирновСмирновСмирнов" +
            "СмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирнов@bk.ru",
            "Должно возникать исключение, если фамилия болльше 100 символов",
            TestName = "Присвоение неправильного email больше 100 символов.")]
        public void Email_SetIncorrectValue_ThrowException(string wrongEmail, string message)
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223), 
                DateTime.Today, "qwe@gmail.com", "1111121");

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                contact.Email = wrongEmail;
            }, message);
        }

        [Test(Description = "Присвоение корректного значения в поле email")]
        public void Email_SetCorrectValue_ValueIsSetted()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "Ivan123@mail.ru";
            contact.Email = expected;
            // Act
            var actual = contact.Email;

            // Assert
            Assert.AreEqual(expected, actual, "Значение email установлено неправильно");
        }

        [Test(Description = "Позитивный тест геттера email")]
        public void Email_GetValue_ReturnsValue()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "Ivan123@mail.ru";
            contact.Email = expected;

            // Act
            var actual = contact.Email;

            // Assert
            Assert.AreEqual(expected, actual, "Возвращается неправильное значение email");
        }

        // Тесты даты рождения
        [Test(Description = "Негативный тест сеттера даты")]
        public void DateOfBirth_SetIncorrectValueEarlyData_ThrowException()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");

            // Act
            var expected = new DateTime(1000, 1, 1);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                contact.BirthDay = expected;
            }, "Должно возникать исключение, если дата раньше 1900г.");
        }

        [Test(Description = "Негативный тест сеттера даты")]
        public void DateOfBirth_SetIncorrectValueLateDate_ThrowException()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");

            // Act
            var expected = new DateTime(2048, 1, 1);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                contact.BirthDay = expected;
            }, "Должно возникать исключение, если дата позже текущей.");
        }

        [Test(Description = "Позитивный тест сеттера даты")]
        public void DateOfBirth_SetCorrectValue_ValueIsSetted()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = DateTime.Today;
            contact.BirthDay = expected;

            // Act
            var actual = contact.BirthDay;

            // Assert
            Assert.AreEqual(expected, actual, "Значение email установлено неправильно");
        }

        [Test(Description = "Позитивный тест геттера даты")]
        public void DateOfBirth_GetValue_ReturnsValue()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = DateTime.Today;
            contact.BirthDay = expected;

            // Act
            var actual = contact.BirthDay;

            // Assert
            Assert.AreEqual(expected, actual, "Возвращается неправильное значение email");
        }

        // Тесты idVK
        [TestCase("", "Должно возникать исключение, если полное IdVK - пустая строка",
            TestName = "Присвоение пустой строки в качестве IdVK")]
        [TestCase("01234567890123456789012345678901234567890123456789a",
            "Должно возникать исключение, если IdVK длиннее 50 символов",
            TestName = "Присвоение неправильного IdVK более 50 символов")]
        public void IdVk_SetUncorrectValue_ArgumentException(string wrongIdVK, string message)
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                contact.IdVK = wrongIdVK;
            }, message);
        }

        [Test(Description = "Позитивный тест сеттера IdVK")]
        public void IdVK_SetCorrectValue_ValueIsSetted()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "123456";
            contact.IdVK = expected;

            // Act
            var actual = contact.IdVK;

            // Assert
            Assert.AreEqual(expected, actual, "Значение IdVK установлено неправильно");
        }

        [Test(Description = "Позитивный тест геттера IdVK")]
        public void IdVK_GetValue_ReturnsValue()
        {
            // Setup
            Contact contact = new Contact("Иванов", "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            var expected = "123456";
            contact.IdVK = expected;

            // Act
            var actual = contact.IdVK;

            // Assert
            Assert.AreEqual(expected, actual, "Возвращается неправильное значение IdVK");
        }

        [Test(Description = "Позитивный тест конструктора с параметрами")]
        public void Constructor_SetCorrectParameters_ReturnsCorrectValues()
        {
            // Setup
            var correctSername = "Иванов";
            var expectedSername = correctSername;
            var correctName = "Иван";
            var expectedName = correctName;
            var correctEmail = "Ivan123@mail.com";
            var expectedEmail = correctEmail;
            var correctPhoneNumber = new PhoneNumber(79131231223);
            var expectedPhoneNumber = correctPhoneNumber;
            var correctBirthDay = DateTime.Today;
            var expectedBirthDay = correctBirthDay;
            var correctVkId = "1234567890";
            var expectedVkId = correctVkId;
            Contact contact = new Contact(correctSername,correctName, correctPhoneNumber,
                correctBirthDay, correctEmail,  correctVkId);

            // Act
            var actualSername = contact.Sername;
            var actualName = contact.Name;
            var actualEmail = contact.Email;
            var actualPhoneNumber = contact.PhoneNumber;
            var actualBirthDay = contact.BirthDay;
            var actualIdVk = contact.IdVK;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedSername, actualSername);
                    Assert.AreEqual(expectedName, actualName);
                    Assert.AreEqual(expectedEmail, actualEmail);
                    Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber);
                    Assert.AreEqual(expectedBirthDay, actualBirthDay);
                    Assert.AreEqual(expectedVkId, actualIdVk);
                }
                );
        }

        [Test(Description = "Негативный тест конструктора с параметрами")]
        public void Constructor_SetInvalidParameter_ArgumentException()
        {
            // Setup
            var wrongSername = "СмирновСмирновСмирновСмирновСмирновСмирновСмирнов" +
            "СмирновСмирновСмирновСмирновСмирновСмирновСмирновСмирнов";
            var message = "Должно возникать исключение, если имя содержит больше 100 символов";

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                new Contact(wrongSername, "Иван", new PhoneNumber(79131231223),
                DateTime.Today, "qwe@gmail.com", "1111121");
            },
            message);
        }
    }
}
