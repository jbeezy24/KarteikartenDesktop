namespace KarteikartenDesktop {
    partial class Hauptform {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panelsideMenu = new System.Windows.Forms.Panel();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAbfrage = new System.Windows.Forms.Button();
            this.panelGrids = new System.Windows.Forms.Panel();
            this.panelInterval5 = new System.Windows.Forms.Panel();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.buttonInt5 = new System.Windows.Forms.Button();
            this.panelInterval4 = new System.Windows.Forms.Panel();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.buttonInt4 = new System.Windows.Forms.Button();
            this.panelInterval3 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.buttonInt3 = new System.Windows.Forms.Button();
            this.panelInterval2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.buttonInt2 = new System.Windows.Forms.Button();
            this.panelInterval1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonInt1 = new System.Windows.Forms.Button();
            this.panelsideMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelGrids.SuspendLayout();
            this.panelInterval5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.panelInterval4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.panelInterval3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panelInterval2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelInterval1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelsideMenu
            // 
            this.panelsideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelsideMenu.BackColor = System.Drawing.Color.LightCyan;
            this.panelsideMenu.Controls.Add(this.buttonImport);
            this.panelsideMenu.Controls.Add(this.buttonExport);
            this.panelsideMenu.Controls.Add(this.buttonAdd);
            this.panelsideMenu.Controls.Add(this.buttonOptions);
            this.panelsideMenu.Controls.Add(this.panel1);
            this.panelsideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelsideMenu.Name = "panelsideMenu";
            this.panelsideMenu.Size = new System.Drawing.Size(200, 411);
            this.panelsideMenu.TabIndex = 0;
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImport.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonImport.Location = new System.Drawing.Point(0, 162);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(200, 30);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "Karten Importieren";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.Location = new System.Drawing.Point(0, 126);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(200, 30);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Karten Exportieren";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.Location = new System.Drawing.Point(0, 90);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(200, 30);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Karten Erstellen";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOptions.BackColor = System.Drawing.Color.Transparent;
            this.buttonOptions.ForeColor = System.Drawing.Color.Transparent;
            this.buttonOptions.Image = global::KarteikartenDesktop.Properties.Resources.settingscog_87317_1_;
            this.buttonOptions.Location = new System.Drawing.Point(3, 348);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(60, 60);
            this.buttonOptions.TabIndex = 1;
            this.buttonOptions.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 84);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonAbfrage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 30);
            this.panel2.TabIndex = 1;
            // 
            // buttonAbfrage
            // 
            this.buttonAbfrage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbfrage.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonAbfrage.Location = new System.Drawing.Point(703, 4);
            this.buttonAbfrage.Name = "buttonAbfrage";
            this.buttonAbfrage.Size = new System.Drawing.Size(78, 23);
            this.buttonAbfrage.TabIndex = 0;
            this.buttonAbfrage.Text = "Abfragen";
            this.buttonAbfrage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbfrage.UseVisualStyleBackColor = true;
            this.buttonAbfrage.Click += new System.EventHandler(this.buttonAbfrage_Click);
            // 
            // panelGrids
            // 
            this.panelGrids.AutoScroll = true;
            this.panelGrids.Controls.Add(this.panelInterval5);
            this.panelGrids.Controls.Add(this.buttonInt5);
            this.panelGrids.Controls.Add(this.panelInterval4);
            this.panelGrids.Controls.Add(this.buttonInt4);
            this.panelGrids.Controls.Add(this.panelInterval3);
            this.panelGrids.Controls.Add(this.buttonInt3);
            this.panelGrids.Controls.Add(this.panelInterval2);
            this.panelGrids.Controls.Add(this.buttonInt2);
            this.panelGrids.Controls.Add(this.panelInterval1);
            this.panelGrids.Controls.Add(this.buttonInt1);
            this.panelGrids.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelGrids.Location = new System.Drawing.Point(199, 30);
            this.panelGrids.Name = "panelGrids";
            this.panelGrids.Size = new System.Drawing.Size(585, 381);
            this.panelGrids.TabIndex = 2;
            // 
            // panelInterval5
            // 
            this.panelInterval5.Controls.Add(this.dataGridView5);
            this.panelInterval5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterval5.Location = new System.Drawing.Point(0, 542);
            this.panelInterval5.Name = "panelInterval5";
            this.panelInterval5.Size = new System.Drawing.Size(568, 88);
            this.panelInterval5.TabIndex = 10;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(0, 0);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(568, 88);
            this.dataGridView5.TabIndex = 0;
            // 
            // buttonInt5
            // 
            this.buttonInt5.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInt5.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInt5.Location = new System.Drawing.Point(0, 504);
            this.buttonInt5.Name = "buttonInt5";
            this.buttonInt5.Size = new System.Drawing.Size(568, 38);
            this.buttonInt5.TabIndex = 8;
            this.buttonInt5.Text = "Interval ? (x Karten)";
            this.buttonInt5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonInt5.UseVisualStyleBackColor = true;
            this.buttonInt5.Click += new System.EventHandler(this.buttonInt5_Click);
            // 
            // panelInterval4
            // 
            this.panelInterval4.Controls.Add(this.dataGridView4);
            this.panelInterval4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterval4.Location = new System.Drawing.Point(0, 416);
            this.panelInterval4.Name = "panelInterval4";
            this.panelInterval4.Size = new System.Drawing.Size(568, 88);
            this.panelInterval4.TabIndex = 7;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(568, 88);
            this.dataGridView4.TabIndex = 0;
            // 
            // buttonInt4
            // 
            this.buttonInt4.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInt4.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInt4.Location = new System.Drawing.Point(0, 378);
            this.buttonInt4.Name = "buttonInt4";
            this.buttonInt4.Size = new System.Drawing.Size(568, 38);
            this.buttonInt4.TabIndex = 6;
            this.buttonInt4.Text = "Interval 4 (x Karten)";
            this.buttonInt4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonInt4.UseVisualStyleBackColor = true;
            this.buttonInt4.Click += new System.EventHandler(this.buttonInt4_Click);
            // 
            // panelInterval3
            // 
            this.panelInterval3.Controls.Add(this.dataGridView3);
            this.panelInterval3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterval3.Location = new System.Drawing.Point(0, 290);
            this.panelInterval3.Name = "panelInterval3";
            this.panelInterval3.Size = new System.Drawing.Size(568, 88);
            this.panelInterval3.TabIndex = 5;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(568, 88);
            this.dataGridView3.TabIndex = 0;
            // 
            // buttonInt3
            // 
            this.buttonInt3.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInt3.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInt3.Location = new System.Drawing.Point(0, 252);
            this.buttonInt3.Name = "buttonInt3";
            this.buttonInt3.Size = new System.Drawing.Size(568, 38);
            this.buttonInt3.TabIndex = 4;
            this.buttonInt3.Text = "Interval 3 (x Karten)";
            this.buttonInt3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonInt3.UseVisualStyleBackColor = true;
            this.buttonInt3.Click += new System.EventHandler(this.buttonInt3_Click);
            // 
            // panelInterval2
            // 
            this.panelInterval2.Controls.Add(this.dataGridView2);
            this.panelInterval2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterval2.Location = new System.Drawing.Point(0, 164);
            this.panelInterval2.Name = "panelInterval2";
            this.panelInterval2.Size = new System.Drawing.Size(568, 88);
            this.panelInterval2.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(568, 88);
            this.dataGridView2.TabIndex = 0;
            // 
            // buttonInt2
            // 
            this.buttonInt2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInt2.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInt2.Location = new System.Drawing.Point(0, 126);
            this.buttonInt2.Name = "buttonInt2";
            this.buttonInt2.Size = new System.Drawing.Size(568, 38);
            this.buttonInt2.TabIndex = 2;
            this.buttonInt2.Text = "Interval 2 (x Karten)";
            this.buttonInt2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonInt2.UseVisualStyleBackColor = true;
            this.buttonInt2.Click += new System.EventHandler(this.buttonInt2_Click);
            // 
            // panelInterval1
            // 
            this.panelInterval1.Controls.Add(this.dataGridView1);
            this.panelInterval1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInterval1.Location = new System.Drawing.Point(0, 38);
            this.panelInterval1.Name = "panelInterval1";
            this.panelInterval1.Size = new System.Drawing.Size(568, 88);
            this.panelInterval1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(568, 88);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonInt1
            // 
            this.buttonInt1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInt1.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInt1.Location = new System.Drawing.Point(0, 0);
            this.buttonInt1.Name = "buttonInt1";
            this.buttonInt1.Size = new System.Drawing.Size(568, 38);
            this.buttonInt1.TabIndex = 0;
            this.buttonInt1.Text = "Interval 1 (x Karten)";
            this.buttonInt1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonInt1.UseVisualStyleBackColor = true;
            this.buttonInt1.Click += new System.EventHandler(this.buttonInt1_Click);
            // 
            // Hauptform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.panelGrids);
            this.Controls.Add(this.panelsideMenu);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(200, 112);
            this.Name = "Hauptform";
            this.Text = "KarteiLernSystem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.handleHauptformClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panelsideMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelGrids.ResumeLayout(false);
            this.panelInterval5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.panelInterval4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.panelInterval3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panelInterval2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelInterval1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelsideMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAbfrage;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelGrids;
        private System.Windows.Forms.Button buttonInt4;
        private System.Windows.Forms.Panel panelInterval3;
        private System.Windows.Forms.Button buttonInt3;
        private System.Windows.Forms.Panel panelInterval2;
        private System.Windows.Forms.Button buttonInt2;
        private System.Windows.Forms.Panel panelInterval1;
        private System.Windows.Forms.Button buttonInt1;
        private System.Windows.Forms.Panel panelInterval4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelInterval5;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Button buttonInt5;
    }
}

