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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            PhoneNumber phoneNumber = new PhoneNumber(79131232334);
            Contact contact = new Contact("Иванов","Иван",phoneNumber,DateTime.Now,"почта","вк");
                       
        }
    }
}
