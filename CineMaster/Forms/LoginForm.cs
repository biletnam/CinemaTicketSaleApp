using CineMaster.Models;
using CineMaster.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMaster.Forms
{
    public partial class LoginForm : Form
    {
        EmployeeForm empForm;
        public bool isManager = false;
        public LoginForm()
        {
            InitializeComponent();

            empForm = new EmployeeForm();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginCase = false;

            foreach (Employee employee in EmployeeDataTransaction.GetEmployeeList())
            {
                if(txtUsername.Text == employee.Username && txtPassword.Text == employee.Password)
                {
                    if(employee.Title == Enums.Title.Müdür)
                    {
                        isManager = true;
                    }
                    else if(employee.Title == Enums.Title.Biletçi)
                    {
                        isManager = false;
                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    loginCase = true;
                }
            }

            if(!loginCase)
            {
                MessageBox.Show("Hatalı kullanıcı adı ve şifre girişi!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm.Clear(this);
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            foreach (Employee emp in EmployeeDataTransaction.GetEmployeeList())
            {
                if (txtUsername.Text == emp.Username)
                {
                    MessageBox.Show("Şifreniz: " + emp.Password, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                //else
                //{
                //    MessageBox.Show("Sistemde böyle bir kullanıcı adı bulunmamaktadır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
    }
}
