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
        /// <summary>
        /// Цвет отсутствия ошибок
        /// </summary>
        private Color _noErrorColor = Color.White;

        /// <summary>
        /// Цвет ошибки
        /// </summary>
        private Color _errorColor = Color.LightPink;

        /// <summary>
        /// Переменная для вывода ошибок при изменении значения фамилии контакта
        /// </summary>
        private string _sernameError;

        /// <summary>
        /// Переменная для вывода ошибок при изменении значения имени контакта
        /// </summary>
        private string _nameError;

        /// <summary>
        /// Переменная для вывода ошибок при изменении значения почты контакта
        /// </summary>
        private string _emailError;

        /// <summary>
        /// Переменная для вывода ошибок при изменении значения номера телефона контакта
        /// </summary>
        private string _phoneNumberError;

        /// <summary>
        /// Переменная для вывода ошибок при изменении значения даты рождения контакта
        /// </summary>
        private string _birthDayError;

        /// <summary>
        /// Переменная для вывода ошибок при изменении значения ссылки на ВК контакта
        /// </summary>
        private string _idVKError;

        private void ClearTextBoxes()
        {
            SernameTextBox.Text = "";
            SernameTextBox.BackColor = _noErrorColor;
            NameTextBox.Text = "";
            NameTextBox.BackColor = _noErrorColor;
            EmailTextBox.Text = "";
            EmailTextBox.BackColor = _noErrorColor;
            PhoneTextBox.Text = "";
            PhoneTextBox.BackColor = _noErrorColor;
            BirthdayDateTimePicker.Value = DateTime.Today;
            IdVkTextBox.Text = "";
            IdVkTextBox.BackColor = _noErrorColor;
        }

        /// <summary>
        /// Объект контакта, содержащий основную информацию о нём
        /// </summary>
        private Contact _contact = new Contact("EmptySername", "EmptyName",
            new PhoneNumber(79131232334), DateTime.Today, "qwe@gmail.com", "1111121");

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
        public ContactForm()
        {
            InitializeComponent();
            ClearTextBoxes();
        }


        /// <summary>
        /// Проверяет данные на наличие ошибок ввода
        /// </summary>
        /// <returns></returns>
        private bool CheckFormOnErrors()
        {
            StringBuilder message = new StringBuilder();

            if (_sernameError != "")
            {
                message.AppendLine(_sernameError);
            }
            if (_nameError != "")
            {
                message.AppendLine(_nameError);
            }
            if (_emailError != "")
            {
                message.AppendLine(_emailError);
            }
            //if (_phoneNumberError != "")
            //{
            //    message.AppendLine(_phoneNumberError);
            //}
            if (_idVKError != "")
            {
                message.AppendLine(_idVKError);
            }
            if (message.Length > 0)
            {
                MessageBox.Show(message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Обновляет информацию о контакте в полях на форме
        /// </summary>
        private void UpdateForm()
        {
            SernameTextBox.Text = _contact.Sername;
            NameTextBox.Text = _contact.Name;
            EmailTextBox.Text = _contact.Email;
            PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
            BirthdayDateTimePicker.Value = _contact.BirthDay;
            IdVkTextBox.Text = _contact.IdVK;
        }

        /// <summary>
        /// Обновляет данные контакта
        /// </summary>
        private void UpdateContact()
        {
            _contact.Name = NameTextBox.Text;
            _contact.Sername = SernameTextBox.Text;
            _contact.Email = EmailTextBox.Text;
            _contact.PhoneNumber = new PhoneNumber(Convert.ToInt64(PhoneTextBox.Text));
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
            if (CheckFormOnErrors() == true)
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

        /// <summary>
        /// Обрабатывает событие изменения значения поля с фамилией контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SernameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Sername = SernameTextBox.Text;
                SernameTextBox.BackColor = _noErrorColor;
                _sernameError = "";
            }
            catch (Exception exception)
            {
                SernameTextBox.BackColor = _errorColor;
                _sernameError = exception.Message;
            }
        }

        /// <summary>
        /// Обрабатывает событие изменения значения поля с именем контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = _noErrorColor;
                _nameError = "";
            }
            catch (Exception exception)
            {
                NameTextBox.BackColor = _errorColor;
                _nameError = exception.Message;
            }
        }
        
        /// <summary>
        /// Обрабатывает событие изменения значения поля с номером телефона контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.PhoneNumber = new PhoneNumber (Convert.ToInt64(PhoneTextBox.Text));
                PhoneTextBox.BackColor = _noErrorColor;
                _nameError = "";
            }
            catch (Exception exception)
            {
                PhoneTextBox.BackColor = _errorColor;
                _nameError = exception.Message;
            }
        }
        /// <summary>
        /// Обрабатывает событие изменения значения поля с почтой контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = _noErrorColor;
                _emailError = "";
            }
            catch (Exception exception)
            {
                EmailTextBox.BackColor = _errorColor;
                _emailError = exception.Message;
            }
        }

        /// <summary>
        /// Обрабатывает событие изменения значения поля с ссылкой на ВК контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.IdVK = IdVkTextBox.Text;
                IdVkTextBox.BackColor = _noErrorColor;
                _idVKError = "";
            }
            catch (Exception exception)
            {
                IdVkTextBox.BackColor = _errorColor;
                _idVKError = exception.Message;
            }
        }
        /// <summary>
        /// Обрабатывает событие изменения значения поля с датой рождения контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateOfBirthTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.BirthDay = BirthdayDateTimePicker.Value;
                _birthDayError = "";
            }
            catch (Exception exception)
            {
                _birthDayError = exception.Message;
            }
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            if (_contact.Sername != "EmptySername")
            {
                UpdateForm();
            }
        }
    }
}
