using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Контакт.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Максимальное количество символов для полей Имя, Фамилия, Почта.
        /// </summary>
        private const int _maxTextLength = 50;

        /// <summary>
        /// Максимальное количество символов для поля idVK.
        /// </summary>
        private const int _maxIdLength = 15;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _sername;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// День рождения.
        /// </summary>
        private DateTime _birthDay;

        /// <summary>
        /// Электронная почта.
        /// </summary>
        private string _email;

        /// <summary>
        /// id "ВКонтакте".
        /// </summary>
        private string _idVK;

        /// <summary>
        /// Возвращает или задаёт фамилию контакта.
        /// </summary>
        public string Sername
        {
            get
            {
                return _sername;
            }

            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Enter the sername.");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException("The sername is too long ( MAX {_maxTextLength} characters).");
                }

                char[] sername = value.ToCharArray();
                sername[0] = char.ToUpper(sername[0]);
                _sername = new string(sername);
            }
        }

        /// <summary>
        /// Возвращает или задаёт имя контакта.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Enter the name.");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException("The name is too long ( MAX {_maxTextLength} characters).");
                }

                char[] name = value.ToCharArray();
                name[0] = char.ToUpper(name[0]);
                _name = new string(name);
            }
        }

        /// <summary>
        /// Возвращает или задаёт адрес электронной почты контакта.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException($"Enter the email!");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException($"The email is too long ( MAX {_maxTextLength} characters).");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт ID "ВКонтакте" контакта.
        /// </summary>
        public string IdVK
        {
            get
            {
                return _idVK;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException($"Enter the id!");
                }
                if (value.Length > _maxIdLength)
                {
                    throw new ArgumentException($"The id is too long ( MAX {_maxIdLength} characters).");
                }
                _idVK = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт дату рождения контакта.
        /// </summary>
        public DateTime BirthDay
        {
            get
            {
                return _birthDay;
            }

            set
            {
                if (value > new DateTime(1900, 1, 1) && (value < DateTime.Now))
                {
                    _birthDay = value;
                }
                else
                {
                    throw new ArgumentException($"Uncorrect date value.");
                }
            }
        }

        /// <summary>
        /// Возвращает или задаёт номер телефона контакта.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact">
        /// </summary>
        /// <param name="sername">фамилия контакта</param>
        /// <param name="name">имя контакта</param>
        /// <param name="email">электронная почта</param>
        /// <param name="phoneNumber">номер телефона</param>
        /// <param name="birthDay">дата рождения</param>
        /// <param name="idVK">ссылка на ВК</param>
        public Contact(string sername, string name, PhoneNumber phoneNumber,
            DateTime birthDay, string email, string idVK)
        {
            Sername = sername;
            Name = name;
            BirthDay = birthDay;
            PhoneNumber = phoneNumber;
            Email = email;
            IdVK = idVK;
        }

        /// <summary>
        /// /// Клонирование данного объекта.
        /// </summary>
        public object Clone()
        {
            return new Contact(_sername, _name, new PhoneNumber(PhoneNumber.Number), _birthDay, _email, _idVK);
        }
    }
}
