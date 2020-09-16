namespace KarteikartenDesktop.UserInterface
{
    partial class Benutzereinstellung
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
            this.benutzernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.MaskedTextBox();
            this.testLoginButton = new System.Windows.Forms.Button();
            this.benutzernameLabel = new System.Windows.Forms.Label();
            this.passwortLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // benutzernameTextBox
            // 
            this.benutzernameTextBox.Location = new System.Drawing.Point(26, 27);
            this.benutzernameTextBox.Name = "benutzernameTextBox";
            this.benutzernameTextBox.Size = new System.Drawing.Size(214, 20);
            this.benutzernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(26, 77);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(214, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // testLoginButton
            // 
            this.testLoginButton.Location = new System.Drawing.Point(26, 103);
            this.testLoginButton.Name = "testLoginButton";
            this.testLoginButton.Size = new System.Drawing.Size(214, 23);
            this.testLoginButton.TabIndex = 2;
            this.testLoginButton.Text = "Test Login";
            this.testLoginButton.UseVisualStyleBackColor = true;
            this.testLoginButton.Click += new System.EventHandler(this.testLoginButton_Click);
            // 
            // benutzernameLabel
            // 
            this.benutzernameLabel.AutoSize = true;
            this.benutzernameLabel.Location = new System.Drawing.Point(23, 11);
            this.benutzernameLabel.Name = "benutzernameLabel";
            this.benutzernameLabel.Size = new System.Drawing.Size(78, 13);
            this.benutzernameLabel.TabIndex = 3;
            this.benutzernameLabel.Text = "Benutzername:";
            // 
            // passwortLabel
            // 
            this.passwortLabel.AutoSize = true;
            this.passwortLabel.Location = new System.Drawing.Point(23, 61);
            this.passwortLabel.Name = "passwortLabel";
            this.passwortLabel.Size = new System.Drawing.Size(53, 13);
            this.passwortLabel.TabIndex = 4;
            this.passwortLabel.Text = "Passwort:";
            // 
            // Benutzereinstellung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 137);
            this.Controls.Add(this.passwortLabel);
            this.Controls.Add(this.benutzernameLabel);
            this.Controls.Add(this.testLoginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.benutzernameTextBox);
            this.Name = "Benutzereinstellung";
            this.Text = "Benutzereinstellung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox benutzernameTextBox;
        private System.Windows.Forms.MaskedTextBox passwordTextBox;
        private System.Windows.Forms.Button testLoginButton;
        private System.Windows.Forms.Label benutzernameLabel;
        private System.Windows.Forms.Label passwortLabel;
    }
}