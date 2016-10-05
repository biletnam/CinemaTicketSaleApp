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

namespace CineMaster.Forms
{
    public partial class TheatreForm : Form
    {
        public TheatreForm()
        {
            InitializeComponent();
            cmbTheatreList.DisplayMember = "MovieTheatreID";
            cmbTheatreList.DataSource = MovieTheatreOperation.GetTheatreList();
        }

        private void cmbTheatreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTheatreList.SelectedIndex > -1)
            {
                MovieTheatre theatre = (MovieTheatre)cmbTheatreList.SelectedItem;

                lblTheatreNumber.Text = theatre.MovieTheatreID.ToString();
                lblTheatreName.Text = theatre.MovieTheatreName;
                lblCapacity.Text = theatre.SeatingCapacity.ToString();
            }

            ClearForm.DisposePanels(this);

            if (cmbTheatreList.SelectedIndex == 0)
            {
                CreateTheatre.TheatreA(this);
            }
            else if (cmbTheatreList.SelectedIndex == 1)
            {;
                CreateTheatre.TheatreB(this);
            }
            if (cmbTheatreList.SelectedIndex == 2)
            {
                CreateTheatre.TheatreC(this);
            }
        }
    }
}
