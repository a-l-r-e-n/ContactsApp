﻿using System;
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
            UpdateListBox();

        }

        /// <summary>
        /// Обновляет список контактов на форме
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            _project.Contacts = _project.SortBySername();
            _displayContacts = _project.FindContact(FindTextBox.Text);
            foreach (var item in _displayContacts)
            {
                ContactsListBox.Items.Add(item.Sername);
            }

            //string birthdayPeople = "";
            //foreach (var item in _project.FindBirthdayContact(_todayData))
            //{
            //    birthdayPeople += item.FullName + ", ";
            //}
            //BirthdaySurnamesLabel.Text = birthdayPeople;
        }



        /// <summary>
        /// Добавляет контакт в проект.
        /// </summary>
        private void AddContact()
        {
            var contact = new ContactForm();
            DialogResult result = contact.ShowDialog();
            if (result == DialogResult.OK)
            {
                var updatedContact = contact.Contact;
                _project.Contacts.Add(updatedContact);
            }
            else
            {
                contact.Close();
            }
        }

        /// <summary>
        /// Удаляет выбранный контакт из проекта.
        /// </summary>
        /// <param name="index">Номер выбранного контакта</param>
        private void RemoveContact(int index)
        {
            if (index == -1)
            {
                return;
            }
            DialogResult result = MessageBox.Show($"Вы действительно хотите удалить " +
                $"{ContactsListBox.SelectedItem}?", "Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                foreach (var item in _project.Contacts)
                {
                    if (item == _displayContacts[index])
                    {
                        _project.Contacts.Remove(item);
                        break;
                    }
                }
            }
            ClearSelectedContact();
        }

        /// <summary>
        /// Редактирует выбранный контакт.
        /// </summary>
        /// <param name="index"></param>
        private void EditContact(int index)
        {
            var contactEditForm = new ContactForm();
            var editContact = _displayContacts[index].Clone();
            contactEditForm.Contact = (Contact)editContact;

            DialogResult result = contactEditForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                _project.Contacts.Remove(_displayContacts[index]);
                _project.Contacts.Add(contactEditForm.Contact);
                UpdateSelectedContact(index);
            }
            ContactsListBox.SetSelected(index, true);
        }

        /// <summary>
        /// Очищает информацию о контакте.
        /// </summary>
        private void ClearSelectedContact()
        {
            SernameTextBox.Text = null;
            NameTextBox.Text = null;
            EmailTextBox.Text = null;
            PhoneTextBox.Text = null;
            BirthdayDateTimePicker.Value = DateTime.Today;
            IdVkTextBox.Text = null;
        }

        /// <summary>
        /// Обновляет информацию о контакте на форме.
        /// </summary>
        /// <param name="index"></param>
        private void UpdateSelectedContact(int index)
        {
            Contact contact = _displayContacts[index];
            SernameTextBox.Text = contact.Sername;
            NameTextBox.Text = contact.Name;
            EmailTextBox.Text = contact.Email;
            PhoneTextBox.Text = contact.PhoneNumber.ToString();
            BirthdayDateTimePicker.Value = contact.BirthDay;
            IdVkTextBox.Text = contact.IdVK;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addContactPictureBox_Click(object sender, EventArgs e)
        {

            AddContact();
            UpdateListBox();
            _projectManager.SaveProject(_project);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки редактирования контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editContactPictureBox_Click(object sender, EventArgs e)
        {
            int index = ContactsListBox.SelectedIndex;
            EditContact(index);
            UpdateListBox();
            ContactsListBox.SetSelected(index, true);
            _projectManager.SaveProject(_project);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteContactPictureBox_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
            _projectManager.SaveProject(_project);
        }

        /// <summary>
        /// Обрабатывает событие закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _projectManager.SaveProject(_project);
            DialogResult result = MessageBox.Show($"Do you really want to exit?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Выполняет поиск контакта по подстроке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        /// <summary>
        /// Обрабатывает событие выбора контакта из списка на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                ClearSelectedContact();
            }
            else
            {
                UpdateSelectedContact(ContactsListBox.SelectedIndex);
            }
        }
    }
}
