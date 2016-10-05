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
using System.IO;
using System.Drawing.Imaging;

namespace CineMaster.Forms
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();

            List<MovieGenre> genreList = MovieGenreOperation.GetMovieGenres();

            foreach (MovieGenre genre in genreList)
            {
                chkMovieGenre.Items.Add(genre);
            }

            RefreshListBox();

            ClearForm.Clear(this);
        }

        private void RefreshListBox()
        {
            lstMovies.DataSource = null;
            lstMovies.DataSource = MovieDataTransaction.GetAllMovies();
        }

        private void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearForm.Clear(this);

            if (lstMovies.SelectedIndex > -1)
            {
                Movie movie = (Movie)lstMovies.SelectedItem;
                MovieDataTransaction.GetMovieDetailsById(movie);
                txtMovieName.Text = movie.Name;

                for (int i = 0; i < chkMovieGenre.Items.Count; i++)
                {
                    for (int j = 0; j < movie.Genres.Count; j++)
                    {
                        if (movie.Genres[j].ID == ((MovieGenre)chkMovieGenre.Items[i]).ID)
                        {
                            chkMovieGenre.SetItemChecked(i, true);
                        }
                    }
                }
                dtpReleaseDate.Value = movie.ReleaseDate;
                numDuration.Value = movie.Duration;
                txtDescription.Text = movie.Description;

                if (movie.Poster != null)
                {
                    ImageConverter imgConvert = new ImageConverter();
                    Image image = (Image)imgConvert.ConvertFrom(movie.Poster);
                    pcbPoster.Image = image;
                }
            }
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            if (txtMovieName.Text != string.Empty && chkMovieGenre.CheckedItems.Count > 0 && numDuration.Value > 0)
            {
                Movie movie = new Movie();
                movie.Name = txtMovieName.Text;
                List<MovieGenre> genreList = new List<MovieGenre>();
                for (int i = 0; i < chkMovieGenre.Items.Count; i++)
                {
                    if (chkMovieGenre.GetItemChecked(i))
                    {
                        genreList.Add((MovieGenre)chkMovieGenre.Items[i]);
                    }
                }
                movie.Genres = genreList;
                movie.ReleaseDate = dtpReleaseDate.Value;
                movie.Duration = (short)numDuration.Value;
                movie.Description = txtDescription.Text;
                MemoryStream ms = new MemoryStream();
                pcbPoster.Image.Save(ms, ImageFormat.Jpeg);
                byte[] toDatabase = ms.ToArray();
                ms.Close();
                ms.Dispose();
                movie.Poster = toDatabase;

                MovieDataTransaction.AddMovie(movie);

                RefreshListBox();

                MessageBox.Show("Film ekleme işlemi başarıyla gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm.Clear(this);
            }
            else
            {
                MessageBox.Show("Lütfen film eklemek için gereken bilgileri eksiksiz şekilde doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddPoster_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pcbPoster.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            if (lstMovies.SelectedIndex > -1)
            {
                if (txtMovieName.Text != string.Empty && chkMovieGenre.CheckedItems.Count > 0 && numDuration.Value > 0)
                {
                    Movie movie = (Movie)lstMovies.SelectedItem;
                    movie.Name = txtMovieName.Text;
                    List<MovieGenre> genreList = new List<MovieGenre>();
                    for (int i = 0; i < chkMovieGenre.Items.Count; i++)
                    {
                        if (chkMovieGenre.GetItemChecked(i))
                        {
                            genreList.Add((MovieGenre)chkMovieGenre.Items[i]);
                        }
                    }
                    movie.Genres = genreList;
                    movie.ReleaseDate = dtpReleaseDate.Value;
                    movie.Duration = (short)numDuration.Value;
                    movie.Description = txtDescription.Text;
                    MemoryStream ms = new MemoryStream();
                    pcbPoster.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] toDatabase = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    movie.Poster = toDatabase;
                    MovieDataTransaction.UpdateMovie(movie);

                    RefreshListBox();
                }
            }
        }

        private void lstMovies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ClearForm.Clear(this);
            }
        }
    }
}
