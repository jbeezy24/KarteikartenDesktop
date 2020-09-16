﻿using KarteikartenDesktop.Database;
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
            //dataBase.CreateClass("FIA18A");
            //dataBase.CreateSubject("IT3", 1);
            //dataBase.CreateTopic("Programmierung", 1);

            //dataBase.CreateQuestion("Warum sind Bananen krumm?", new Bitmap(Image.FromFile(@"D:\vsico.png")));
            //dataBase.CreateAnswer("Weil es so ist", null);

            //dataBase.CreateRecordCard(1, 11, 11, 1, DateTime.Now);

            //dataBase.CreateUsersettings("sarah", "sarahb", true, 1);
            //var allKarteikarte = dataBase.GetAllKarteikarten();
            //dataBase.SetAllUsersettings();
            //var userSettings = dataBase.AllUsersettings[0];
            //dataBase.SetAllKlasse();
            //var allKlasse = dataBase.AllKlasse;

            //Request.ExportKarteikarte(allKarteikarte[0], userSettings, allKlasse);
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
            this.Visible = true;
        }

        private void handleHauptformClosing(object sender, FormClosingEventArgs e)
        {
            database.Connection.Close();
        }
        private void buttonExport_Click(object sender, EventArgs e) {

            KartenExport export = new KartenExport();
            this.Visible = false;
            if (export.ShowDialog() == DialogResult.OK) {
                //-> Upload auf Web-DB der einzelnen angewählten Karten.
            }
            this.Visible = true;
        }

        List<DataGridView> viewList = new List<DataGridView>();
        private DataBase database = new DataBase();

    }
}
