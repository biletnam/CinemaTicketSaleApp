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

namespace CineMaster.Forms
{
    public partial class TicketForm : Form
    {
        int _selectedSeatNumber = -1;

        public TicketForm()
        {
            InitializeComponent();

            cmbSession.DataSource = SessionDataTransaction.GetAvailableSessions();

            cmbSeller.DataSource = EmployeeDataTransaction.GetTicketSellers();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearForm.DisposePanels(this);

            if (cmbSession.SelectedIndex > -1)
            {
                Session session = (Session)cmbSession.SelectedItem;

                if (session.MovieTheatre.MovieTheatreID == 1)
                {
                    CreateTheatreA();
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel)
                        {
                            foreach (Control control in ctrl.Controls)
                            {
                                if (control is Button)
                                {
                                    foreach (Ticket ticket in TicketDataTransaction.GetTicketList(session))
                                    {
                                        if ((short)control.Tag == ticket.SeatNumber)
                                        {
                                            control.BackgroundImage = Image.FromFile(@"fullSeat.png");
                                            control.BackgroundImageLayout = ImageLayout.Stretch;
                                            control.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (session.MovieTheatre.MovieTheatreID == 2)
                {
                    CreateTheatreB();
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel)
                        {
                            foreach (Control control in ctrl.Controls)
                            {
                                if (control is Button)
                                {
                                    foreach (Ticket ticket in TicketDataTransaction.GetTicketList(session))
                                    {
                                        if ((short)control.Tag == ticket.SeatNumber)
                                        {
                                            control.BackgroundImage = Image.FromFile(@"fullSeat.png");
                                            control.BackgroundImageLayout = ImageLayout.Stretch;
                                            control.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (session.MovieTheatre.MovieTheatreID == 3)
                {
                    CreateTheatreC();
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel)
                        {
                            foreach (Control control in ctrl.Controls)
                            {
                                if (control is Button)
                                {
                                    foreach (Ticket ticket in TicketDataTransaction.GetTicketList(session))
                                    {
                                        if ((short)control.Tag == ticket.SeatNumber)
                                        {
                                            control.BackgroundImage = Image.FromFile(@"fullSeat.png");
                                            control.BackgroundImageLayout = ImageLayout.Stretch;
                                            control.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CreateTheatreA()
        {
            Panel pnlTheatreA = new Panel();
            pnlTheatreA.Name = "pnlTheatreB";
            pnlTheatreA.Location = new Point(375, 20);
            pnlTheatreA.Size = new Size(500, 450);
            pnlTheatreA.BackColor = Color.DarkGray;
            pnlTheatreA.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pnlTheatreA);

            PictureBox pcbCurtain = new PictureBox();
            pcbCurtain.Name = "pcbCurtain";
            pcbCurtain.Location = new Point(100, 0);
            pcbCurtain.Size = new Size(300, 50);
            pcbCurtain.BackgroundImage = Image.FromFile(@"curtain.jpg");
            pcbCurtain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreA.Controls.Add(pcbCurtain);

            PictureBox pcbDoor = new PictureBox();
            pcbDoor.Name = "pcbDoor";
            pcbDoor.Location = new Point(470, 215);
            pcbDoor.Size = new Size(20, 50);
            pcbDoor.BackgroundImage = Image.FromFile(@"door.png");
            pcbDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreA.Controls.Add(pcbDoor);

            PictureBox pcbLeftDoor = new PictureBox();
            pcbLeftDoor.Name = "pcbLeftDoor";
            pcbLeftDoor.Location = new Point(0, 215);
            pcbLeftDoor.Size = new Size(20, 50);
            pcbLeftDoor.BackgroundImage = Image.FromFile(@"doorleft.png");
            pcbLeftDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreA.Controls.Add(pcbLeftDoor);

            short counter = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i == 4) || (j == 3) || (i == 0 && j == 0) || (i == 0 && j == 8) || (i == 8 && j == 8) || (i == 8 && j == 0))
                    {
                        continue;
                    }
                    Button button = new Button();
                    button.Name = "button" + counter;
                    button.Text = counter.ToString();
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    button.Tag = counter;
                    button.Size = new Size(35, 35);
                    button.Left = ((j * 40) + 70);
                    button.Top = ((i * 40) + 60);
                    button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.TabStop = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    button.MouseDown += Button_MouseDown;

                    pnlTheatreA.Controls.Add(button);

                    counter++;
                }
            }
        }
        private void CreateTheatreB()
        {
            Panel pnlTheatreB = new Panel();
            pnlTheatreB.Name = "pnlTheatreB";
            pnlTheatreB.Location = new Point(375, 20);
            pnlTheatreB.Size = new Size(500, 480);
            pnlTheatreB.BackColor = Color.DarkGray;
            pnlTheatreB.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pnlTheatreB);

            PictureBox pcbCurtain = new PictureBox();
            pcbCurtain.Name = "pcbCurtain";
            pcbCurtain.Location = new Point(100, 0);
            pcbCurtain.Size = new Size(300, 50);
            pcbCurtain.BackgroundImage = Image.FromFile(@"curtain.jpg");
            pcbCurtain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreB.Controls.Add(pcbCurtain);

            PictureBox pcbDoor = new PictureBox();
            pcbDoor.Name = "pcbDoor";
            pcbDoor.Location = new Point(470, 250);
            pcbDoor.Size = new Size(20, 50);
            pcbDoor.BackgroundImage = Image.FromFile(@"door.png");
            pcbDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreB.Controls.Add(pcbDoor);

            PictureBox pcbLeftDoor = new PictureBox();
            pcbLeftDoor.Name = "pcbLeftDoor";
            pcbLeftDoor.Location = new Point(0, 250);
            pcbLeftDoor.Size = new Size(20, 50);
            pcbLeftDoor.BackgroundImage = Image.FromFile(@"doorleft.png");
            pcbLeftDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreB.Controls.Add(pcbLeftDoor);

            short counter = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i == 5) || (j == 2) || (i == 0 && j == 9))
                    {
                        continue;
                    }
                    Button button = new Button();
                    button.Name = "button" + counter;
                    button.Text = counter.ToString();
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    button.Tag = counter;
                    button.Size = new Size(35, 35);
                    button.Left = ((j * 40) + 50);
                    button.Top = ((i * 40) + 60);
                    button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.TabStop = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    button.MouseDown += Button_MouseDown;

                    pnlTheatreB.Controls.Add(button);

                    counter++;
                }
            }
        }
        private void CreateTheatreC()
        {
            Panel pnlTheatreC = new Panel();
            pnlTheatreC.Name = "pnlTheatreC";
            pnlTheatreC.Location = new Point(375, 20);
            pnlTheatreC.Size = new Size(500, 530);
            pnlTheatreC.BackColor = Color.DarkGray;
            pnlTheatreC.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pnlTheatreC);

            PictureBox pcbCurtain = new PictureBox();
            pcbCurtain.Name = "pcbCurtain";
            pcbCurtain.Location = new Point(100, 0);
            pcbCurtain.Size = new Size(300, 50);
            pcbCurtain.BackgroundImage = Image.FromFile(@"curtain.jpg");
            pcbCurtain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreC.Controls.Add(pcbCurtain);

            PictureBox pcbDoor = new PictureBox();
            pcbDoor.Name = "pcbDoor";
            pcbDoor.Location = new Point(470, 330);
            pcbDoor.Size = new Size(20, 50);
            pcbDoor.BackgroundImage = Image.FromFile(@"door.png");
            pcbDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreC.Controls.Add(pcbDoor);

            PictureBox pcbLeftDoor = new PictureBox();
            pcbLeftDoor.Name = "pcbLeftDoor";
            pcbLeftDoor.Location = new Point(0, 330);
            pcbLeftDoor.Size = new Size(20, 50);
            pcbLeftDoor.BackgroundImage = Image.FromFile(@"doorleft.png");
            pcbLeftDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreC.Controls.Add(pcbLeftDoor);

            short counter = 1;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if ((i == 7) || (j == 4))
                    {
                        continue;
                    }
                    Button button = new Button();
                    button.Name = "button" + counter;
                    button.Text = counter.ToString();
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    button.Tag = counter;
                    button.Size = new Size(37, 35);
                    button.Left = ((j * 40) + 30);
                    button.Top = ((i * 40) + 60);
                    button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.TabStop = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    button.MouseDown += Button_MouseDown;

                    pnlTheatreC.Controls.Add(button);

                    counter++;
                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            short clickedSeatNumber = (short)button.Tag;
            if (_selectedSeatNumber == -1 && e.Button == MouseButtons.Left)
            {
                button.BackgroundImage = Image.FromFile(@"fullSeat.png");
                _selectedSeatNumber = clickedSeatNumber;
                lblSeatNumber.Text = _selectedSeatNumber.ToString();
            }
            else if (e.Button == MouseButtons.Right && clickedSeatNumber == _selectedSeatNumber)
            {
                button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                _selectedSeatNumber = -1;
                lblSeatNumber.Text = string.Empty;
            }
        }

        private void btnSaleTicket_Click(object sender, EventArgs e)
        {
            if (cmbSession.SelectedIndex > -1 && cmbSeller.SelectedIndex > -1 && (rdbNormal.Checked || rdbStudent.Checked) && (lblSeatNumber.Text != string.Empty))
            {
                Ticket ticket = new Ticket();
                Session session = (Session)cmbSession.SelectedItem;
                ticket.AudienceType = rdbStudent.Checked == true ? AudienceType.Öğrenci : AudienceType.Tam;
                ticket.Session = (Session)cmbSession.SelectedItem;
                ticket.Seller = (Employee)cmbSeller.SelectedItem;
                ticket.SeatNumber = (byte)_selectedSeatNumber;
                ticket.Price = rdbStudent.Checked == true ? (byte)10 : (byte)15;

                TicketDataTransaction.AddTicket(ticket);

                session.TicketList.Add(ticket);

                MessageBox.Show("Bilet satış işlemi başarıyla gerçekleştirildi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bilet satışı için gereken bilgileri eksiksiz şekilde doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rdbStudent_CheckedChanged(object sender, EventArgs e)
        {
            lblPrice.Text = "10 ₺";
        }

        private void rdbNormal_CheckedChanged(object sender, EventArgs e)
        {
            lblPrice.Text = "15 ₺";
        }
    }
}
