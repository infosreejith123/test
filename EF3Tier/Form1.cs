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
using Model;

namespace EF3Tier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ContactService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditContact(null))
            {
                if (contactBindingSource.Current == null)
                {
                    return;
                }

                if (frm.DialogResult == DialogResult.OK)
                {
                    dataGridView.DataSource = ContactService.GetAll();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditContact(contactBindingSource.Current as Contact))
            {
                if (contactBindingSource.Current == null)
                {
                    return;
                }

                if (frm.DialogResult == DialogResult.OK)
                {
                    dataGridView.DataSource = ContactService.GetAll();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (contactBindingSource.Current==null)
            {
                return;
            }

            if (MessageBox.Show("Are you sure want to delete?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ContactService.Delete(contactBindingSource.Current as Contact);
            }
        }
    }
}
