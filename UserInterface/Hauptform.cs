using KarteikartenDesktop.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarteikartenDesktop {
    public partial class Hauptform : Form {
        public Hauptform() {
            InitializeComponent();

            #region Testen von Export Karteikarten
            //database.CreateClass("FIA18A");
            //database.CreateSubject("IT3", 1);
            //database.CreateTopic("Programmierung", 1);

            //database.CreateQuestion("Warum sind Bananen krumm reloaded", new Bitmap(Image.FromFile(@"D:\vsico.png")));
            //database.CreateAnswer("Weil es so ist reloaded", null);

            //database.CreateRecordCard(1, 33, 33, 1, DateTime.Now);

            //database.SetAllAntwort();
            //var allquestions = database.AllAntwort;
            //var allKarteikarte = database.GetAllKarteikarten();
            //database.CreateUsersettings("sarah", "sarahsb", false, 1);
            //database.SetAllUsersettings();
            //var userSettings = database.AllUsersettings[0];
            //database.SetAllKlasse();
            //var allKlasse = database.AllKlasse;

            //database.SetAllIntervall();
            //var intervall = database.AllIntervall;
            //database.SetAllKarteikarten();
            //var karteikarten = database.AllKarteikarten;

            //database.SetAllAntwort();
            //database.SetAllFrage();

            //var allFragen = database.AllFrage;
            //var allAntworten = database.AllAntwort;

            //var recordCard = database.GetRecordCard(1);
            //database.ChangeRecordCard(recordCard, intervallID: 2, letzteAbfrage: DateTime.Now);
            //var test = database.GetRecordCard(1);


            //Request.ExportKarteikarte(allKarteikarte[allKarteikarte.Count - 1], userSettings, allKlasse);
            #endregion

            viewList.Add(dataGridView1);
            viewList.Add(dataGridView2);
            viewList.Add(dataGridView3);
            viewList.Add(dataGridView4);
            viewList.Add(dataGridView5);
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            panelGrids.Width = (int)(Hauptform.ActiveForm.Width * 47 / 64f);
            panelsideMenu.Width = Hauptform.ActiveForm.Width / 4;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            KartenErstellen erstellen = new KartenErstellen();
            this.Visible = false;
            if (erstellen.ShowDialog() == DialogResult.OK) {
                //-> Commit auf Datenbank, neue Karteikarte anlegen.
            }
            this.Visible = true;
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            KartenImport import = new KartenImport();
            if (import.ShowDialog() == DialogResult.OK) {
                //Erstellung von Karten und einfügen in DB anhand von Daten der jeweiligen im Web auswählten Karten
            }
        }

        private void buttonInt1_Click(object sender, EventArgs e) {
            panelInterval1.Visible = !panelInterval1.Visible;
        }

        private void buttonInt2_Click(object sender, EventArgs e) {
            panelInterval2.Visible = !panelInterval2.Visible;
        }

        private void buttonInt3_Click(object sender, EventArgs e) {
            panelInterval3.Visible = !panelInterval3.Visible;
        }

        private void buttonInt4_Click(object sender, EventArgs e) {
            panelInterval4.Visible = !panelInterval4.Visible;
        }

        private void buttonInt5_Click(object sender, EventArgs e) {
            panelInterval5.Visible = !panelInterval5.Visible;
        }

        private void buttonAbfrage_Click(object sender, EventArgs e) {
            this.Visible = false;
            KartenAbfrage abfrage = new KartenAbfrage();
            abfrage.ShowDialog();
            //überprüfung von Invallenänderung

            this.Visible = true;
        }
        private void buttonExport_Click(object sender, EventArgs e) {

            KartenExport export = new KartenExport(database);
            this.Visible = false;
            if (export.ShowDialog() == DialogResult.OK) {
                //-> Upload auf Web-DB der einzelnen angewählten Karten.
            }
            this.Visible = true;
        }

        private void handleHauptformClosing(object sender, FormClosingEventArgs e)
        {
            database.Connection.Close();
        }

        List<DataGridView> viewList = new List<DataGridView>();
        private DataBase database = new DataBase();

        private void Hauptform_VisibleChanged(object sender, EventArgs e) {
            var AktuelleKarteikarten = database.GetAllKarteikarten();
            foreach (var Karte in AktuelleKarteikarten) {

            }
        }
    }
}
