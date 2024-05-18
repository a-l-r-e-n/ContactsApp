using ContactsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Объект контакта, содержащий основную информацию о нём
        /// </summary>
        private Contact _contact = new Contact("EmptySername", "EmptyName",
            new PhoneNumber(79131232334), DateTime.Today, "qwe@gmail.com", "1111121");


        private void ContactForm_Load(object sender, EventArgs e)
        {
            if (_contact.Sername != "EmptySername")
            {
                UpdateForm();
            }
        }

        /// <summary>
        /// Обновляет информацию о контакте в полях на форме
        /// </summary>
        private void UpdateForm()
        {
            SernameTextBox.Text = _contact.Sername;
            NameTextBox.Text = _contact.Name;
            EmailTextBox.Text = _contact.Email;
            //PhoneTextBox.Text = _contact.PhoneNumber;
            BirthdayDateTimePicker.Value = _contact.BirthDay;
            IdVkTextBox.Text = _contact.IdVK;
        }

        
        /// <summary>
        /// Возвращает или задаёт данные о контакте
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
            }
        }

        /// <summary>
        /// Обновляет данные контакта
        /// </summary>
        private void UpdateContact()
        {
            _contact.Name = NameTextBox.Text;
            _contact.Sername = SernameTextBox.Text;
            _contact.Email = EmailTextBox.Text;
            //_contact.PhoneNumber = PhoneTextBox.Text;
            _contact.BirthDay = BirthdayDateTimePicker.Value;
            _contact.IdVK = IdVkTextBox.Text;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки ОК на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            //if (CheckFormOnErrors() == true)
            {
                UpdateContact();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки отмены на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
