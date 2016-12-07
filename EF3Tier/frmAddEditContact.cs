using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace EF3Tier
{
    public partial class frmAddEditContact : Form
    {
        bool isNew = true;

        public frmAddEditContact(Contact contact)
        {
            InitializeComponent();

            if (contact == null)
            {
                contactBindingSource.DataSource = new Contact();
                isNew = true;
            }
            else
            {
                contactBindingSource.DataSource = contact;
                isNew = false;
            }
        }

        private void frmAddEditContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(txtContactName.Text))
                {
                    MessageBox.Show("Please enter name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtContactName.Focus();
                    e.Cancel = true;
                    return;
                }

                if (isNew)
                {
                    ContactService.Insert(contactBindingSource.Current as Contact);
                }
                else
                {
                    ContactService.Update(contactBindingSource.Current as Contact);
                }
            }
        }
    }
}
