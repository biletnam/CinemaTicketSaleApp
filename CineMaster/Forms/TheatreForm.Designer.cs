namespace CineMaster.Forms
{
    partial class TheatreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheatreForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTheatreNumber = new System.Windows.Forms.Label();
            this.lblTheatreName = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.cmbTheatreList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(50, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salon Numarası -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(86, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Salon Adı - ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(38, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Koltuk Kapasitesi - ";
            // 
            // lblTheatreNumber
            // 
            this.lblTheatreNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTheatreNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTheatreNumber.Location = new System.Drawing.Point(184, 147);
            this.lblTheatreNumber.Name = "lblTheatreNumber";
            this.lblTheatreNumber.Size = new System.Drawing.Size(148, 23);
            this.lblTheatreNumber.TabIndex = 3;
            // 
            // lblTheatreName
            // 
            this.lblTheatreName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTheatreName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTheatreName.Location = new System.Drawing.Point(184, 203);
            this.lblTheatreName.Name = "lblTheatreName";
            this.lblTheatreName.Size = new System.Drawing.Size(148, 23);
            this.lblTheatreName.TabIndex = 4;
            // 
            // lblCapacity
            // 
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCapacity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCapacity.Location = new System.Drawing.Point(184, 259);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(148, 23);
            this.lblCapacity.TabIndex = 5;
            // 
            // cmbTheatreList
            // 
            this.cmbTheatreList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheatreList.FormattingEnabled = true;
            this.cmbTheatreList.Location = new System.Drawing.Point(187, 45);
            this.cmbTheatreList.Name = "cmbTheatreList";
            this.cmbTheatreList.Size = new System.Drawing.Size(145, 21);
            this.cmbTheatreList.TabIndex = 6;
            this.cmbTheatreList.SelectedIndexChanged += new System.EventHandler(this.cmbTheatreList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(107, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "SALON";
            // 
            // TheatreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(893, 570);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTheatreList);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblTheatreName);
            this.Controls.Add(this.lblTheatreNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TheatreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salonlar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTheatreNumber;
        private System.Windows.Forms.Label lblTheatreName;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.ComboBox cmbTheatreList;
        private System.Windows.Forms.Label label4;
    }
}