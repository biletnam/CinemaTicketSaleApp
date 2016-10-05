namespace CineMaster.Forms
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAddPoster = new System.Windows.Forms.Button();
            this.chkMovieGenre = new System.Windows.Forms.CheckedListBox();
            this.pcbPoster = new System.Windows.Forms.PictureBox();
            this.btnUpdateMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMovies = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAddPoster
            // 
            this.btnAddPoster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddPoster.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAddPoster.Location = new System.Drawing.Point(496, 261);
            this.btnAddPoster.Name = "btnAddPoster";
            this.btnAddPoster.Size = new System.Drawing.Size(100, 40);
            this.btnAddPoster.TabIndex = 4;
            this.btnAddPoster.Text = "AFİŞ EKLE";
            this.btnAddPoster.UseVisualStyleBackColor = true;
            this.btnAddPoster.Click += new System.EventHandler(this.btnAddPoster_Click);
            // 
            // chkMovieGenre
            // 
            this.chkMovieGenre.FormattingEnabled = true;
            this.chkMovieGenre.Location = new System.Drawing.Point(104, 64);
            this.chkMovieGenre.Name = "chkMovieGenre";
            this.chkMovieGenre.Size = new System.Drawing.Size(107, 169);
            this.chkMovieGenre.TabIndex = 1;
            // 
            // pcbPoster
            // 
            this.pcbPoster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbPoster.Location = new System.Drawing.Point(395, 28);
            this.pcbPoster.Name = "pcbPoster";
            this.pcbPoster.Size = new System.Drawing.Size(201, 223);
            this.pcbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPoster.TabIndex = 19;
            this.pcbPoster.TabStop = false;
            // 
            // btnUpdateMovie
            // 
            this.btnUpdateMovie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateMovie.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnUpdateMovie.Location = new System.Drawing.Point(167, 476);
            this.btnUpdateMovie.Name = "btnUpdateMovie";
            this.btnUpdateMovie.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateMovie.TabIndex = 6;
            this.btnUpdateMovie.Text = "GÜNCELLE";
            this.btnUpdateMovie.UseVisualStyleBackColor = true;
            this.btnUpdateMovie.Click += new System.EventHandler(this.btnUpdateMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddMovie.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAddMovie.Location = new System.Drawing.Point(273, 476);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(100, 40);
            this.btnAddMovie.TabIndex = 5;
            this.btnAddMovie.Text = "EKLE";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(104, 287);
            this.numDuration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(273, 20);
            this.numDuration.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 323);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(273, 136);
            this.txtDescription.TabIndex = 3;
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(104, 28);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(273, 20);
            this.txtMovieName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(34, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Kısa Bilgi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(51, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Süresi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(63, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "İsmi";
            // 
            // lstMovies
            // 
            this.lstMovies.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.Location = new System.Drawing.Point(628, 0);
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.Size = new System.Drawing.Size(228, 538);
            this.lstMovies.TabIndex = 7;
            this.lstMovies.SelectedIndexChanged += new System.EventHandler(this.lstMovies_SelectedIndexChanged);
            this.lstMovies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstMovies_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(60, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Türü";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(13, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vizyon Tarihi";
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReleaseDate.Location = new System.Drawing.Point(104, 252);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(273, 20);
            this.dtpReleaseDate.TabIndex = 21;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(856, 538);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstMovies);
            this.Controls.Add(this.btnAddPoster);
            this.Controls.Add(this.chkMovieGenre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbPoster);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateMovie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.txtMovieName);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.txtDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MovieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CineMaster Film Yönetim Modülü";
            ((System.ComponentModel.ISupportInitialize)(this.pcbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Button btnUpdateMovie;
        private System.Windows.Forms.PictureBox pcbPoster;
        private System.Windows.Forms.CheckedListBox chkMovieGenre;
        private System.Windows.Forms.Button btnAddPoster;
        private System.Windows.Forms.ListBox lstMovies;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
    }
}