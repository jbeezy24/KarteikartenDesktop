using KarteikartenDesktop.Database;
using KarteikartenDesktop.UserInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

            //Request.ImportKarteikarte("160018188151", database);
            //Request.ExportKarteikarte(allKarteikarte[allKarteikarte.Count - 1], userSettings, allKlasse);
            #endregion

            viewList.Add(dataGridView1);
            viewList.Add(dataGridView2);
            viewList.Add(dataGridView3);
            viewList.Add(dataGridView4);
            viewList.Add(dataGridView5);
            panelList.Add(panelInterval1);
            panelList.Add(panelInterval2);
            panelList.Add(panelInterval3);
            panelList.Add(panelInterval4);
            panelList.Add(panelInterval5);
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            panelGrids.Width = (int)(Hauptform.ActiveForm.Width * 47 / 64f);
            panelsideMenu.Width = Hauptform.ActiveForm.Width / 4;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            KartenErstellen erstellen = new KartenErstellen(database);
            this.Visible = false;
            if (erstellen.ShowDialog() == DialogResult.OK) {
                //-> Commit auf Datenbank, neue Karteikarte anlegen.
            }
            this.Visible = true;
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            KartenImport import = new KartenImport(database);
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
            List<KarteikartenHelper> listAbfrage = new List<KarteikartenHelper>();
            foreach (DataGridView view in viewList) {
                foreach (DataGridViewRow row in view.Rows) {
                    if (System.Convert.ToBoolean(row.Cells[0].Value) == true) {
                        var karte = database.GetAllKarteikarten().Where(x => x.KartenID == System.Convert.ToInt32(row.Cells[1].Value)).FirstOrDefault();
                        if (karte != null) {
                            listAbfrage.Add(karte);
                        }
                    }
                }
            }
            if (listAbfrage.Count > 0) {
                this.Visible = false;
                KartenAbfrage abfrage = new KartenAbfrage(listAbfrage, this.database);
                abfrage.ShowDialog();

                this.Visible = true;
            }
            else {
                MessageBox.Show("Wählen Sie Karteikarten zum Abfragen aus!", "Keine Karten ausgewählt", MessageBoxButtons.OK);
            }
        }
        private void buttonExport_Click(object sender, EventArgs e) {

            KartenExport export = new KartenExport(database);
            this.Visible = false;
            if (export.ShowDialog() == DialogResult.OK) {
                //-> Upload auf Web-DB der einzelnen angewählten Karten.
            }
            this.Visible = true;
        }

        private void handleHauptformClosing(object sender, FormClosingEventArgs e) {
            database.Connection.Close();
        }

        List<DataGridView> viewList = new List<DataGridView>();
        private DataBase database = new DataBase();
        List<Panel> panelList = new List<Panel>();

        private void Hauptform_VisibleChanged(object sender, EventArgs e) {
            List<KarteikartenHelper> karteikartenAbgelaufen = new List<KarteikartenHelper>();

            foreach (var view in viewList) {
                view.Rows.Clear();
            }
            var AktuelleKarteikarten = database.GetAllKarteikarten();
            foreach (var Karte in AktuelleKarteikarten) {
                var row = new DataGridViewRow();
                var cellcheck = new DataGridViewCheckBoxCell();
                var cellkartenid = new DataGridViewTextBoxCell();
                var celltopic = new DataGridViewTextBoxCell();
                var cellsubject = new DataGridViewTextBoxCell();

                celltopic.Value = Karte.Thema;
                cellsubject.Value = Karte.Fachname;
                cellkartenid.Value = Karte.KartenID;
                row.Cells.AddRange(new DataGridViewCell[] { cellcheck, cellkartenid, cellsubject, celltopic });
                switch (Karte.Intervall) {
                    case 1: {
                            dataGridView1.Rows.Add(row);
                            break;
                        }
                    case 3: {
                            dataGridView2.Rows.Add(row);
                            break;
                        }
                    case 7: {
                            dataGridView3.Rows.Add(row);
                            break;
                        }
                    case 30: {
                            dataGridView4.Rows.Add(row);
                            break;
                        }
                    case 9999: {
                            dataGridView5.Rows.Add(row);
                            break;
                        }
                }
                buttonInt1.Text = "Interval 1 (" + dataGridView1.Rows.Count + " Karten)";
                buttonInt2.Text = "Interval 2 (" + dataGridView2.Rows.Count + " Karten)";
                buttonInt3.Text = "Interval 3 (" + dataGridView3.Rows.Count + " Karten)";
                buttonInt4.Text = "Interval 4 (" + dataGridView4.Rows.Count + " Karten)";
                buttonInt5.Text = "Interval 5 (" + dataGridView5.Rows.Count + " Karten)";

                for (int i = 0; i < 5; i++) {
                    panelList[i].Size = new Size(Width, 22 * (1 + viewList[i].Rows.Count));
                }
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e) {
            foreach (DataGridView view in viewList) {
                foreach (DataGridViewRow row in view.Rows) {
                    row.Cells[0].Value = true;
                }
            }
        }

        private void buttonSelectNone_Click(object sender, EventArgs e) {
            foreach (DataGridView view in viewList) {
                foreach (DataGridViewRow row in view.Rows) {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            int deletionNumber = 0;
            foreach (DataGridView view in viewList) {
                foreach (DataGridViewRow row in view.Rows) {
                    if (System.Convert.ToBoolean(row.Cells[0].Value) == true) {
                        var karte = database.GetAllKarteikarten().Where(x => x.KartenID == System.Convert.ToInt32(row.Cells[1].Value)).FirstOrDefault();
                        if (karte != null) {
                            deletionNumber++;
                        }
                    }
                }
            }
            if (deletionNumber != 0) {
                if (MessageBox.Show("Möchten Sie alle " + deletionNumber + " angewählten Karteikarten löschen?", "Karteikarten löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                    foreach (DataGridView view in viewList) {
                        foreach (DataGridViewRow row in view.Rows) {
                            if (System.Convert.ToBoolean(row.Cells[0].Value) == true) {
                                database.RemoveRecordCard(System.Convert.ToInt32(row.Cells[1].Value));
                                view.Rows.Remove(row);
                            }
                        }
                    }
                }
            }
        }
        private void buttonOptions_Click(object sender, EventArgs e) {
            Benutzereinstellung benutzereinstellung = new Benutzereinstellung(database);
            benutzereinstellung.ShowDialog();
        }


        private bool checkEditButtonAviable() {
            int deletionNumber = 0;
            foreach (DataGridView view in viewList) {
                foreach (DataGridViewRow row in view.Rows) {
                    if (System.Convert.ToBoolean(row.Cells[0].Value) == true) {
                        singlecheckedcard = database.GetAllKarteikarten().Where(x => x.KartenID == System.Convert.ToInt32(row.Cells[1].Value)).FirstOrDefault();
                        if (singlecheckedcard != null) {
                            deletionNumber++;
                        }
                    }
                }
            }
            if (deletionNumber == 1) {
                return true;
            }
            else return false;
        }

        private KarteikartenHelper singlecheckedcard = new KarteikartenHelper();

        private void buttonKarteBearbeiten_Click(object sender, EventArgs e) {
			singlecheckedcard = new KarteikartenHelper();
            if (checkEditButtonAviable()) {
                KartenErstellen erstellen = new KartenErstellen(database, singlecheckedcard);
                this.Visible = false;
                if (erstellen.ShowDialog() == DialogResult.OK) {

                }
                this.Visible = true;
            } else MessageBox.Show("Bitte wählen Sie nur 1 Karteikarte aus!","Falsche Auswahl");
			
			
        private void Hauptform_Shown(object sender, EventArgs e)
        {
            List<KarteikartenHelper> karteikartenAbgelaufen = new List<KarteikartenHelper>();
            var AktuelleKarteikarten = database.GetAllKarteikarten();
            foreach (var Karte in AktuelleKarteikarten)
            {
                var timeNow = DateTime.Now;
                var dateTimeLate = Karte.LetzteAbfrage;
                var differenceDate = timeNow - dateTimeLate;

                if (differenceDate.Days > Karte.Intervall)
                {
                    karteikartenAbgelaufen.Add(Karte);
                }
            }         

            if (karteikartenAbgelaufen.Count > 0)
            {
                if (MessageBox.Show("Einige Karten sind vom Intervall abgelaufen. Möchten Sie diese aufrufen?", "Karteikarten", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Visible = false;
                    KartenAbfrage kartenAbfrage = new KartenAbfrage(karteikartenAbgelaufen, database);
                    kartenAbfrage.ShowDialog();
                    this.Visible = true;
                }
            }
        }
    }
}
