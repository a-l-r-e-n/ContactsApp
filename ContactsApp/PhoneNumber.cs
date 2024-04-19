using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Номер телефона контакта.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private long _number;

        /// <summary>
        /// Количество символов в номере телефона.
        /// </summary>
        private const int _numberLength = 11;

        /// <summary>
        /// Возвращает или задаёт номер телефона контакта.
        /// </summary>
        public long Number 
        {   
            get 
            {
                return _number; 
            }
            set 
            {
                string numberString = value.ToString();
                if (numberString.Length != _numberLength)
                {
                    throw new ArgumentException($"The number must be {_numberLength} characters.");
                }

                if (numberString[0] != '7')
                {
                    throw new ArgumentException("The first digit is not 7");
                }
                _number = value; 
            } 
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="PhoneNumber">
        /// </summary>
        public PhoneNumber(long number)
        { 
            Number = number;
        }
    }
}
