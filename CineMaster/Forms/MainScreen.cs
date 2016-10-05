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
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            LoginForm loginForm = new LoginForm();
            DialogResult result = loginForm.ShowDialog();
            if(!loginForm.isManager)
            {
                btnEmployee.Enabled = false;
            }

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new EmployeeForm();
            empForm.Owner = this;
            empForm.ShowDialog();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            tmrDateTime.Start();
        }

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = "Tarih: " + DateTime.Now.ToShortDateString() + "\nSaat: " + DateTime.Now.ToLongTimeString();
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            MovieForm movieForm = new MovieForm();
            movieForm.Owner = this;
            movieForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Çıkış yapmak istediğinze emin misiniz?", "CineMaster Sinemaları", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void btnSession_Click(object sender, EventArgs e)
        {
            SessionForm sessionForm = new SessionForm();
            sessionForm.Owner = this;
            sessionForm.Show();
        }

        private void btnTheatre_Click(object sender, EventArgs e)
        {
            TheatreForm theatreForm = new TheatreForm();
            theatreForm.Owner = this;
            theatreForm.Show();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            TicketForm ticketForm = new TicketForm();
            ticketForm.Owner = this;
            ticketForm.Show();
        }
    }
}
