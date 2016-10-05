using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineMaster.Models;
using CineMaster.Helper;

namespace CineMaster.Forms
{
    public partial class SessionForm : Form
    {
        public SessionForm()
        {
            InitializeComponent();
            RefreshMovies();
            cmbTheatres.ValueMember = "MovieTheatreID";
            cmbTheatres.DisplayMember = "Name";
            cmbTheatres.DataSource = MovieTheatreOperation.GetTheatreList();
            RefreshSessionListBox();
            ClearForm.Clear(this);
        }

        private void RefreshMovies()
        {
            cmbMovies.DataSource = null;
            cmbMovies.DisplayMember = "Name";
            cmbMovies.ValueMember = "ID";
            cmbMovies.DataSource = MovieDataTransaction.GetActualMovies();
        }

        private void RefreshSessionListBox()
        {
            lstSessions.DataSource = null;
            lstSessions.DataSource = SessionDataTransaction.GetAllSessions();
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            if (dtpSessionDate.Value >= DateTime.Today && cmbMovies.SelectedIndex > -1 && cmbTheatres.SelectedIndex > -1)
            {
                Session session = new Session();
                session.Date = dtpSessionDate.Value.Date;
                session.Time = dtpSessionDate.Value.TimeOfDay;
                session.Movie = (Movie)cmbMovies.SelectedItem;
                session.MovieTheatre = (MovieTheatre)cmbTheatres.SelectedItem;
                if (SessionDataTransaction.AddSession(session))
                {
                    MessageBox.Show("Seans ekleme işlemi başarılı...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefreshSessionListBox();
                ClearForm.Clear(this);
            }
        }

        private void btnUpdateSession_Click(object sender, EventArgs e)
        {
            if (lstSessions.SelectedIndex > -1)
            {
                if (dtpSessionDate.Value >= DateTime.Today && cmbMovies.SelectedIndex > -1 && cmbTheatres.SelectedIndex > -1)
                {
                    Session session = (Session)lstSessions.SelectedItem;
                    session.Date = dtpSessionDate.Value.Date;
                    session.Time = dtpSessionDate.Value.TimeOfDay;
                    session.Movie = (Movie)cmbMovies.SelectedItem;
                    session.MovieTheatre = (MovieTheatre)cmbTheatres.SelectedItem;
                    SessionDataTransaction.UpdateSession(session);
                    MessageBox.Show("İlgili seansı güncellediniz...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshSessionListBox();
                }
            }
        }

        private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSessions.SelectedIndex == -1)
            {
                ClearForm.Clear(this);
            }

            else if (lstSessions.SelectedIndex > -1)
            {
                Session session = (Session)lstSessions.SelectedItem;
                dtpSessionDate.Value = session.Date + session.Time;
                cmbMovies.SelectedValue = session.Movie.ID;
                cmbTheatres.SelectedValue = session.MovieTheatre.MovieTheatreID;

                lstTickets.DataSource = null;
                lstTickets.DataSource = TicketDataTransaction.GetTicketDetail(session);
            }
        }

        private void lstSessions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ClearForm.Clear(this);
            }
        }
    }
}
