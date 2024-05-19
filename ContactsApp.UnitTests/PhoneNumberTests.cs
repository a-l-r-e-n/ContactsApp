using NUnit.Framework;
using System;


namespace ContactsApp.UnitTests
{

    [TestFixture]
    public class PhoneNumberTests
    {
        private PhoneNumber CreateClearPhoneNumber()
        {
            return new PhoneNumber(70000000000);
        }

        [Test(Description = "Позитивный тест геттера Номера телефона")]
        public void TestNumberGet_CorrectValue()
        {
            // Setup
            var expected = 78005553535;

            var phoneNumber = CreateClearPhoneNumber();
            phoneNumber.Number = expected;

            // Act
            var actual = phoneNumber.Number;

            // Assert
            Assert.AreEqual(expected, actual, "Возвращается неправильное значение Номера телефона");
        }

        [TestCase(88005553535, "Должно возникать исключение, если Номер не начинается с цифры 7",
            TestName = "Присвоение неправильного Номера, начинающегося не с цифры 7")]
        [TestCase(780055535353, "Должно возникать исключение, если Номер содержит больше 11 символов",
            TestName = "Присвоение неправильного Номера длиннее 11 символов.")]
        public void TestNumberSet_ArgumentException(long wrongNumber, string message)
        {
            var phoneNumber = CreateClearPhoneNumber();
            Assert.Throws<ArgumentException>(
                () => { phoneNumber.Number = wrongNumber; },
                message);
        }

        [Test(Description = "Позитивный тест сеттера Номера телефона")]
        public void TestNumberSet_CorrectValue()
        {
            var number = 78005553535;

            var phoneNumber = CreateClearPhoneNumber();
            Assert.DoesNotThrow(
                () => { phoneNumber.Number = number; },
                "Значение Номера установлено неправильно");
        }

        [Test(Description = "Позитивный тест конструктора")]
        public void TestConstructorPhoneNumber_CorrectValue()
        {
            var number = 78005553535;
            Assert.DoesNotThrow(
                () => { var phoneNumber = new PhoneNumber(number); },
                "Номер присвоен неверно");
        }
    }
}
