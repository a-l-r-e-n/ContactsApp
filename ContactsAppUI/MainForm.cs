using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Основное окно приложения.
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// Объект проекта.
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Объект менеджера проекта.
        /// </summary>
        private ProjectManager _projectManager = new ProjectManager();

        /// <summary>
        /// Список отображаемых на форме контактов.
        /// </summary>
        private List<Contact> _displayContacts;

        private DateTime _todayData = DateTime.Today;


        public MainForm()
        {
            InitializeComponent();
            _project = _projectManager.LoadProject();

            PhoneNumber phoneNumber = new PhoneNumber(79131232334);
            Contact contact = new Contact("Иванов", "Иван", phoneNumber, DateTime.Now, "почта", "вк");

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void addContactPictureBox_Click(object sender, EventArgs e)
        {
            var contact = new ContactForm();
            
        }

        private void editContactPictureBox_Click(object sender, EventArgs e)
        {
            var contact = new ContactForm();
        }

        private void deleteContactPictureBox_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}
