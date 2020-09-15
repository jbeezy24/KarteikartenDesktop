namespace KarteikartenDesktop {
    partial class KartenAbfrage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KartenAbfrage));
            this.panelFrage = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.FragenLabel = new System.Windows.Forms.Label();
            this.pictureBoxFrage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAntwort = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.antwortLabel = new System.Windows.Forms.Label();
            this.pictureBoxAntwort = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelLayover = new System.Windows.Forms.Panel();
            this.runderButtonJa = new KarteikartenDesktop.UserInterface.RunderButton();
            this.runderButtonNein = new KarteikartenDesktop.UserInterface.RunderButton();
            this.runderButtonQmark = new KarteikartenDesktop.UserInterface.RunderButton();
            this.runderButton3 = new KarteikartenDesktop.UserInterface.RunderButton();
            this.runderButtonZurück = new KarteikartenDesktop.UserInterface.RunderButton();
            this.runderButton1 = new KarteikartenDesktop.UserInterface.RunderButton();
            this.panelFrage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrage)).BeginInit();
            this.panelAntwort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAntwort)).BeginInit();
            this.panelLayover.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFrage
            // 
            this.panelFrage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelFrage.Controls.Add(this.label2);
            this.panelFrage.Controls.Add(this.FragenLabel);
            this.panelFrage.Controls.Add(this.pictureBoxFrage);
            this.panelFrage.Controls.Add(this.label1);
            this.panelFrage.Location = new System.Drawing.Point(69, 12);
            this.panelFrage.Name = "panelFrage";
            this.panelFrage.Size = new System.Drawing.Size(650, 282);
            this.panelFrage.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "<KartenID>";
            // 
            // FragenLabel
            // 
            this.FragenLabel.BackColor = System.Drawing.Color.Transparent;
            this.FragenLabel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FragenLabel.Location = new System.Drawing.Point(20, 37);
            this.FragenLabel.Name = "FragenLabel";
            this.FragenLabel.Size = new System.Drawing.Size(418, 227);
            this.FragenLabel.TabIndex = 1;
            this.FragenLabel.Text = resources.GetString("FragenLabel.Text");
            this.FragenLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxFrage
            // 
            this.pictureBoxFrage.Location = new System.Drawing.Point(447, 37);
            this.pictureBoxFrage.Name = "pictureBoxFrage";
            this.pictureBoxFrage.Size = new System.Drawing.Size(187, 227);
            this.pictureBoxFrage.TabIndex = 2;
            this.pictureBoxFrage.TabStop = false;
            this.pictureBoxFrage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFrage_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "THEMA: <hier Thema>";
            // 
            // panelAntwort
            // 
            this.panelAntwort.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelAntwort.Controls.Add(this.label3);
            this.panelAntwort.Controls.Add(this.antwortLabel);
            this.panelAntwort.Controls.Add(this.pictureBoxAntwort);
            this.panelAntwort.Controls.Add(this.label5);
            this.panelAntwort.Location = new System.Drawing.Point(17, 12);
            this.panelAntwort.Name = "panelAntwort";
            this.panelAntwort.Size = new System.Drawing.Size(653, 282);
            this.panelAntwort.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "<KartenID>";
            // 
            // antwortLabel
            // 
            this.antwortLabel.BackColor = System.Drawing.Color.Transparent;
            this.antwortLabel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antwortLabel.Location = new System.Drawing.Point(23, 37);
            this.antwortLabel.Name = "antwortLabel";
            this.antwortLabel.Size = new System.Drawing.Size(418, 227);
            this.antwortLabel.TabIndex = 1;
            this.antwortLabel.Text = resources.GetString("antwortLabel.Text");
            this.antwortLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxAntwort
            // 
            this.pictureBoxAntwort.Location = new System.Drawing.Point(447, 37);
            this.pictureBoxAntwort.Name = "pictureBoxAntwort";
            this.pictureBoxAntwort.Size = new System.Drawing.Size(187, 227);
            this.pictureBoxAntwort.TabIndex = 2;
            this.pictureBoxAntwort.TabStop = false;
            this.pictureBoxAntwort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAntwort_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(476, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "THEMA: <hier Thema>";
            // 
            // panelLayover
            // 
            this.panelLayover.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelLayover.Controls.Add(this.runderButtonJa);
            this.panelLayover.Controls.Add(this.runderButtonNein);
            this.panelLayover.Controls.Add(this.runderButtonQmark);
            this.panelLayover.Controls.Add(this.panelAntwort);
            this.panelLayover.Controls.Add(this.runderButton3);
            this.panelLayover.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLayover.Location = new System.Drawing.Point(52, 0);
            this.panelLayover.Name = "panelLayover";
            this.panelLayover.Size = new System.Drawing.Size(732, 411);
            this.panelLayover.TabIndex = 3;
            this.panelLayover.Visible = false;
            // 
            // runderButtonJa
            // 
            this.runderButtonJa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runderButtonJa.BackColor = System.Drawing.Color.LimeGreen;
            this.runderButtonJa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runderButtonJa.FlatAppearance.BorderSize = 0;
            this.runderButtonJa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runderButtonJa.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runderButtonJa.Location = new System.Drawing.Point(73, 300);
            this.runderButtonJa.Margin = new System.Windows.Forms.Padding(0);
            this.runderButtonJa.Name = "runderButtonJa";
            this.runderButtonJa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.runderButtonJa.Size = new System.Drawing.Size(105, 105);
            this.runderButtonJa.TabIndex = 5;
            this.runderButtonJa.Text = "✅";
            this.runderButtonJa.UseVisualStyleBackColor = false;
            // 
            // runderButtonNein
            // 
            this.runderButtonNein.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runderButtonNein.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(6)))), ((int)(((byte)(12)))));
            this.runderButtonNein.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runderButtonNein.FlatAppearance.BorderSize = 0;
            this.runderButtonNein.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runderButtonNein.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runderButtonNein.Location = new System.Drawing.Point(215, 300);
            this.runderButtonNein.Margin = new System.Windows.Forms.Padding(0);
            this.runderButtonNein.Name = "runderButtonNein";
            this.runderButtonNein.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.runderButtonNein.Size = new System.Drawing.Size(105, 105);
            this.runderButtonNein.TabIndex = 4;
            this.runderButtonNein.Text = "✖️";
            this.runderButtonNein.UseVisualStyleBackColor = false;
            // 
            // runderButtonQmark
            // 
            this.runderButtonQmark.BackColor = System.Drawing.Color.DodgerBlue;
            this.runderButtonQmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runderButtonQmark.FlatAppearance.BorderSize = 0;
            this.runderButtonQmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runderButtonQmark.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runderButtonQmark.Location = new System.Drawing.Point(355, 300);
            this.runderButtonQmark.Margin = new System.Windows.Forms.Padding(0);
            this.runderButtonQmark.Name = "runderButtonQmark";
            this.runderButtonQmark.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.runderButtonQmark.Size = new System.Drawing.Size(105, 105);
            this.runderButtonQmark.TabIndex = 3;
            this.runderButtonQmark.Text = "❓";
            this.runderButtonQmark.UseVisualStyleBackColor = false;
            // 
            // runderButton3
            // 
            this.runderButton3.BackColor = System.Drawing.Color.GreenYellow;
            this.runderButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runderButton3.FlatAppearance.BorderSize = 0;
            this.runderButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runderButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runderButton3.Location = new System.Drawing.Point(496, 300);
            this.runderButton3.Margin = new System.Windows.Forms.Padding(0);
            this.runderButton3.Name = "runderButton3";
            this.runderButton3.Size = new System.Drawing.Size(105, 105);
            this.runderButton3.TabIndex = 1;
            this.runderButton3.Text = "↩️";
            this.runderButton3.UseVisualStyleBackColor = false;
            this.runderButton3.Click += new System.EventHandler(this.runderButton3_Click);
            // 
            // runderButtonZurück
            // 
            this.runderButtonZurück.BackColor = System.Drawing.Color.LightGray;
            this.runderButtonZurück.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runderButtonZurück.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.runderButtonZurück.FlatAppearance.BorderSize = 0;
            this.runderButtonZurück.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runderButtonZurück.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runderButtonZurück.Location = new System.Drawing.Point(9, 12);
            this.runderButtonZurück.Margin = new System.Windows.Forms.Padding(0);
            this.runderButtonZurück.Name = "runderButtonZurück";
            this.runderButtonZurück.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.runderButtonZurück.Size = new System.Drawing.Size(40, 40);
            this.runderButtonZurück.TabIndex = 2;
            this.runderButtonZurück.Text = "🔙";
            this.runderButtonZurück.UseVisualStyleBackColor = false;
            // 
            // runderButton1
            // 
            this.runderButton1.BackColor = System.Drawing.Color.GreenYellow;
            this.runderButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runderButton1.FlatAppearance.BorderSize = 0;
            this.runderButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runderButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runderButton1.Location = new System.Drawing.Point(336, 297);
            this.runderButton1.Margin = new System.Windows.Forms.Padding(0);
            this.runderButton1.Name = "runderButton1";
            this.runderButton1.Size = new System.Drawing.Size(105, 105);
            this.runderButton1.TabIndex = 0;
            this.runderButton1.Text = "↩️";
            this.runderButton1.UseVisualStyleBackColor = false;
            this.runderButton1.Click += new System.EventHandler(this.runderButton1_Click);
            // 
            // KartenAbfrage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.panelLayover);
            this.Controls.Add(this.runderButtonZurück);
            this.Controls.Add(this.panelFrage);
            this.Controls.Add(this.runderButton1);
            this.Name = "KartenAbfrage";
            this.Text = "KartenAbfrage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KartenAbfrage_FormClosing);
            this.panelFrage.ResumeLayout(false);
            this.panelFrage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrage)).EndInit();
            this.panelAntwort.ResumeLayout(false);
            this.panelAntwort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAntwort)).EndInit();
            this.panelLayover.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserInterface.RunderButton runderButton1;
        private System.Windows.Forms.Panel panelFrage;
        private System.Windows.Forms.Label FragenLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxFrage;
        private UserInterface.RunderButton runderButtonZurück;
        private UserInterface.RunderButton runderButton3;
        private System.Windows.Forms.Panel panelAntwort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label antwortLabel;
        private System.Windows.Forms.PictureBox pictureBoxAntwort;
        private System.Windows.Forms.Label label5;
        private UserInterface.RunderButton runderButtonQmark;
        private UserInterface.RunderButton runderButtonNein;
        private UserInterface.RunderButton runderButtonJa;
        private System.Windows.Forms.Panel panelLayover;
    }
}