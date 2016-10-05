namespace CineMaster.Forms
{
    partial class SessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSessionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMovies = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTheatres = new System.Windows.Forms.ComboBox();
            this.btnAddSession = new System.Windows.Forms.Button();
            this.btnUpdateSession = new System.Windows.Forms.Button();
            this.lstSessions = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstTickets = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seans Tarih\r\n        ve\r\n      Saati";
            // 
            // dtpSessionDate
            // 
            this.dtpSessionDate.CustomFormat = "dd.MM.yy - HH:mm:ss";
            this.dtpSessionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSessionDate.Location = new System.Drawing.Point(118, 45);
            this.dtpSessionDate.Name = "dtpSessionDate";
            this.dtpSessionDate.Size = new System.Drawing.Size(233, 20);
            this.dtpSessionDate.TabIndex = 1;
            // 
            // cmbMovies
            // 
            this.cmbMovies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovies.FormattingEnabled = true;
            this.cmbMovies.Location = new System.Drawing.Point(118, 196);
            this.cmbMovies.Name = "cmbMovies";
            this.cmbMovies.Size = new System.Drawing.Size(233, 21);
            this.cmbMovies.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(81, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Film";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(72, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Salon";
            // 
            // cmbTheatres
            // 
            this.cmbTheatres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheatres.FormattingEnabled = true;
            this.cmbTheatres.Location = new System.Drawing.Point(118, 112);
            this.cmbTheatres.Name = "cmbTheatres";
            this.cmbTheatres.Size = new System.Drawing.Size(233, 21);
            this.cmbTheatres.TabIndex = 6;
            // 
            // btnAddSession
            // 
            this.btnAddSession.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddSession.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAddSession.Location = new System.Drawing.Point(251, 466);
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.Size = new System.Drawing.Size(100, 50);
            this.btnAddSession.TabIndex = 7;
            this.btnAddSession.Text = "SEANS OLUŞTUR";
            this.btnAddSession.UseVisualStyleBackColor = true;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // btnUpdateSession
            // 
            this.btnUpdateSession.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateSession.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnUpdateSession.Location = new System.Drawing.Point(145, 466);
            this.btnUpdateSession.Name = "btnUpdateSession";
            this.btnUpdateSession.Size = new System.Drawing.Size(100, 50);
            this.btnUpdateSession.TabIndex = 8;
            this.btnUpdateSession.Text = "SEANS BİLGİLERİNİ GÜNCELLE";
            this.btnUpdateSession.UseVisualStyleBackColor = true;
            this.btnUpdateSession.Click += new System.EventHandler(this.btnUpdateSession_Click);
            // 
            // lstSessions
            // 
            this.lstSessions.FormattingEnabled = true;
            this.lstSessions.Location = new System.Drawing.Point(357, 31);
            this.lstSessions.Name = "lstSessions";
            this.lstSessions.Size = new System.Drawing.Size(299, 485);
            this.lstSessions.TabIndex = 9;
            this.lstSessions.SelectedIndexChanged += new System.EventHandler(this.lstSessions_SelectedIndexChanged);
            this.lstSessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSessions_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(709, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 5;
            // 
            // lstTickets
            // 
            this.lstTickets.FormattingEnabled = true;
            this.lstTickets.Location = new System.Drawing.Point(662, 31);
            this.lstTickets.Name = "lstTickets";
            this.lstTickets.Size = new System.Drawing.Size(461, 290);
            this.lstTickets.TabIndex = 10;
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1135, 556);
            this.Controls.Add(this.lstTickets);
            this.Controls.Add(this.lstSessions);
            this.Controls.Add(this.btnUpdateSession);
            this.Controls.Add(this.btnAddSession);
            this.Controls.Add(this.cmbTheatres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMovies);
            this.Controls.Add(this.dtpSessionDate);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SessionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seans Bilgileri";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.ComboBox cmbMovies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTheatres;
        private System.Windows.Forms.Button btnAddSession;
        private System.Windows.Forms.Button btnUpdateSession;
        private System.Windows.Forms.ListBox lstSessions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstTickets;
    }
}