using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Users
{
    public partial class Form1 : Form
    {
        portaltable stmodel = new portaltable();
        public Form1()
        {
            InitializeComponent();
            populateDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            populateDataGridView();
        }
        private void populateDataGridView()
        {
            portalEntities db = new portalEntities();
            dataGridView1.DataSource = db.portaltables.ToList<portaltable>();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            portalEntities portal = new portalEntities();
            stmodel.Username = txtboxUsername.Text;
            stmodel.Email = txtboxEmailAddress.Text;
            stmodel.Name = txtboxName.Text;
            stmodel.FamilyName = txtboxFamilyName.Text;
            stmodel.Phone = txtboxPhone.Text;
            stmodel.Mobile = txtboxMobile.Text;
            stmodel.BirthDate = txtboxBirthDate.Text;
            stmodel.BirthPlace = txtboxBirthPlace.Text;
            if (stmodel.ID == 0)
            {
                portal.portaltables.Attach(stmodel);
            }
            else
                portal.Entry(stmodel).State = System.Data.Entity.EntityState.Modified;
            portal.SaveChanges();
            MessageBox.Show("Data Edited successfully.");
            populateDataGridView();
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            portalEntities db = new portalEntities();
            var entry = db.Entry(stmodel);
            if (entry.State == System.Data.Entity.EntityState.Detached)
                db.portaltables.Attach(stmodel);
            db.portaltables.Remove(stmodel);
            db.SaveChanges();
            populateDataGridView();

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            portalEntities portal = new portalEntities();

            stmodel.Username = txtboxUsername.Text;
            stmodel.Email = txtboxEmailAddress.Text;
            stmodel.Name = txtboxName.Text;
            stmodel.FamilyName = txtboxFamilyName.Text;
            stmodel.Phone = txtboxPhone.Text;
            stmodel.Mobile = txtboxMobile.Text;
            stmodel.BirthDate = txtboxBirthDate.Text;
            stmodel.BirthPlace = txtboxBirthPlace.Text;
            if (stmodel.ID == 0)
            {
                portal.portaltables.Add(stmodel);
            }
            else

                portal.Entry(stmodel).State = System.Data.Entity.EntityState.Modified;
            portal.SaveChanges();
            MessageBox.Show("Data Registered successfully.");

            populateDataGridView();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                stmodel.ID = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                portalEntities db = new portalEntities();
                stmodel = db.portaltables.Where(x => x.ID == stmodel.ID).FirstOrDefault();
                txtboxUsername.Text = stmodel.Username;
                txtboxEmailAddress.Text = stmodel.Email;
                txtboxName.Text = stmodel.Name;
                txtboxFamilyName.Text = stmodel.FamilyName;
                txtboxPhone.Text = stmodel.Phone;
                txtboxMobile.Text = stmodel.Mobile;
                txtboxBirthDate.Text = stmodel.BirthDate;
                txtboxBirthPlace.Text = stmodel.BirthPlace;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtboxUsername.Text = string.Empty;
            txtboxEmailAddress.Text = string.Empty;
            txtboxName.Text = string.Empty;
            txtboxFamilyName.Text = string.Empty;
            txtboxPhone.Text = string.Empty;
            txtboxMobile.Text = string.Empty;
            txtboxBirthDate.Text = string.Empty;
            txtboxBirthPlace.Text = string.Empty;
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            portalEntities db = new portalEntities();
            dataGridView1.DataSource = db.portaltables.Where(x=> x.Username.Contains(txtboxSearch.Text)).ToList();

        }
    }
}

 