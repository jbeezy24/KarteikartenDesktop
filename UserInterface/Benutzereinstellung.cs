using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarteikartenDesktop.UserInterface
{
    public partial class Benutzereinstellung : Form
    {
        public Benutzereinstellung(DataBase database)
        {
            InitializeComponent();
            this.database = database;

            database.SetAllUsersettings();
            var userSettings = database.AllUsersettings[0];
            benutzernameTextBox.Text = userSettings.Benutzername;
            passwordTextBox.Text = userSettings.Passwort;
        }

        private DataBase database;

        private void testLoginButton_Click(object sender, EventArgs e)
        {
            database.SetAllUsersettings();
            if (database.AllUsersettings.Count > 0)
            {
                for (int i = 0; i < database.AllUsersettings.Count; i++)
                {
                    database.RemoveUsersettings(database.AllUsersettings[i].SettingsID);
                }
            }

            database.CreateUsersettings(benutzernameTextBox.Text, passwordTextBox.Text, false, 1);
            database.SetAllUsersettings();

            var returnExport = Request.ExportKarteikarte(new KarteikartenHelper(), database.AllUsersettings[database.AllUsersettings.Count - 1]);
            if (!returnExport.Contains("Authentifizierung fehlgeschlagen"))
            {
                MessageBox.Show("Benutzerdaten sind gültig!");
            } else
            {
                MessageBox.Show("Ungültige Benutzerdaten, bitte vergewissern Sie sich, dass Ihre Benutzerdaten richtig sind!");
            }
        }
    }
}
