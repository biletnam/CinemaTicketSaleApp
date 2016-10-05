using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineMaster.Helper;
using CineMaster.Models;
using CineMaster.Enums;
using System.Configuration;
using System.Data.SqlClient;

namespace CineMaster.Forms
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();

            cmbTitle.Items.Add(Title.Müdür);
            cmbTitle.Items.Add(Title.Biletçi);
            RefreshListBox();

            ClearForms();
        }

        private void RefreshListBox()
        {
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = EmployeeDataTransaction.GetEmployeeList();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != string.Empty && txtLastName.Text != string.Empty && maskNationalityNumber.Text != string.Empty && (rdbFemale.Checked || rdbMale.Checked) && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty && ((DateTime.Today.Year - dtpDateOfBirth.Value.Year)>18))
            {
                Employee employee = new Employee();
                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.NationalityNumber = maskNationalityNumber.Text;
                employee.Gender = rdbMale.Checked == true ? Gender.Erkek : Gender.Kadın;
                employee.DateOfBirth = dtpDateOfBirth.Value;
                employee.PhoneNumber = maskPhoneNumber.Text;
                employee.Username = txtUsername.Text;
                employee.Password = txtPassword.Text;
                employee.Title = cmbTitle.SelectedIndex == 0 ? Title.Müdür : Title.Biletçi;
                foreach (Employee emp in EmployeeDataTransaction.GetEmployeeList())
                {
                    if (emp.Username == txtUsername.Text)
                    {
                        MessageBox.Show("Bu kullanıcı adına sahip bir çalışan vardır.\nLütfen farklı bir kullanıcı adı giriniz...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (emp.NationalityNumber == maskNationalityNumber.Text)
                    {
                        MessageBox.Show("Bu TC Kimlik numarasına sahip çalışan daha önce sisteme eklenmiştir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                EmployeeDataTransaction.AddEmployee(employee);

                RefreshListBox();

                MessageBox.Show("Çalışan kaydı başarıyla gerçekleştirildi","BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForms();
            }
            else
            {
                MessageBox.Show("Lütfen çalışan kaydı için gereken bilgileri eksiksiz ve doğru bir şekilde doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedIndex > -1)
            {
                Employee employee = (Employee)lstEmployees.SelectedItem;

                EmployeeDataTransaction.DeleteEmployee(employee.EmployeeID);

                RefreshListBox();
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = (Employee)lstEmployees.SelectedItem;
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.NationalityNumber = maskNationalityNumber.Text;
            employee.Gender = rdbMale.Checked == true ? Gender.Erkek : Gender.Kadın;
            employee.DateOfBirth = dtpDateOfBirth.Value;
            employee.PhoneNumber = maskPhoneNumber.Text;
            employee.Username = txtUsername.Text;
            employee.Password = txtPassword.Text;
            employee.Title = cmbTitle.SelectedIndex == 0 ? Title.Müdür : Title.Biletçi;

            EmployeeDataTransaction.UpdateEmployee(employee);
            EmployeeDataTransaction.GetEmployeeList();
            RefreshListBox();

            ClearForms();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedIndex == -1)
            {
                ClearForms();
            }

            else if (lstEmployees.SelectedIndex > -1)
            {
                Employee employee = (Employee)lstEmployees.SelectedItem;
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                maskNationalityNumber.Text = employee.NationalityNumber;
                rdbMale.Checked = employee.Gender == Gender.Erkek ? true : false;
                rdbFemale.Checked = employee.Gender == Gender.Kadın ? true : false;
                dtpDateOfBirth.Value = employee.DateOfBirth;
                maskPhoneNumber.Text = employee.PhoneNumber;
                txtUsername.Text = employee.Username;
                txtPassword.Text = employee.Password;
                cmbTitle.SelectedItem = employee.Title;
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            ClearForms();
        }

        private void ClearForms()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            maskNationalityNumber.Clear();
            maskPhoneNumber.Clear();
            dtpDateOfBirth.Value = DateTime.Today;
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            cmbTitle.SelectedIndex = -1;
            lstEmployees.SelectedIndex = -1;
        }

        private void lstEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ClearForms();
            }
        }
    }
}
