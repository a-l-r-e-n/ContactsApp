using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp
{
    /// <summary>
    /// Описывает проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов в проекте.
        /// </summary>
        public List<Contact> Contacts = new List<Contact>();

        /// <summary>
        /// Сортирует список по полному фамилии.
        /// </summary>
        /// <returns>Отсортированный список</returns>
        public List<Contact> SortBySername()
        {
            return Contacts.OrderBy(c => c.Sername).ToList();
        }

        /// <summary>
        /// Находит контакты у которых сегодня день рождения.
        /// </summary>
        /// <returns>Список именинников</returns>
        public List<Contact> FindBirthdayContact(DateTime today)
        {
            List<Contact> result = new List<Contact>();
            foreach (Contact contact in Contacts)
            {
                if ((contact.BirthDay.Month == today.Month) &&
                    (contact.BirthDay.Day == today.Day))
                {
                    result.Add(contact);
                }
            }
            return result;
        }
        
        /// <summary>
        /// Выполняет поиск по подстроке имени, номера или email'а.
        /// </summary>
        /// <param name="substring">Подстрока имени, номера или email'а</param>
        /// <returns>Список найденных контактов</returns>
        public List<Contact> FindContact(string substring)
        {
            if (substring == "")
            {
                return Contacts;
            }
            List<Contact> result = new List<Contact>();
            foreach (Contact contact in Contacts)
            {
                if (contact.Sername.Contains(substring) ||
                    contact.Name.Contains(substring))
                {
                    result.Add(contact);
                }
            }
            return result;
        }

    }
}
