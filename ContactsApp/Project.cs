using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Описывает проект.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Возвращает или задаёт контакты.
        /// </summary>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Project"/>.
        /// </summary>
        public Project()
        {
            Contacts = new List<Contact>();
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Project"/> принимая список.
        /// </summary>
        public Project(List<Contact> contacts)
        {
            Contacts = contacts;
        }
    }
}
