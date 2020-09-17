using KarteikartenDesktop.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarteikartenDesktop {
    public partial class KartenAbfrage : Form {
        public KartenAbfrage(List<KarteikartenHelper> karten, DataBase database) {
            InitializeComponent();
            this.karten = karten;
            this.database = database;
        }


        List<KarteikartenHelper> karten = new List<KarteikartenHelper>();
        DataBase database;

        private void runderButton1_Click(object sender, EventArgs e) {
            panelLayover.Visible = true;
        }

        private void runderButton3_Click(object sender, EventArgs e) {
            panelLayover.Visible = false;
        }

        private void ZoomButtonAntwort_Click(object sender, EventArgs e) {
            picturePanel.Visible = true;
        }

        private void ZoomButtonFrage_Click(object sender, EventArgs e) {
            picturepanel2.Visible = true;
        }

        private void KartenAbfrage_MouseClick(object sender, MouseEventArgs e) {
            picturepanel2.Visible = false;
            picturePanel.Visible = false;
        }

        private void pictureBoxZoomAntwort_Click(object sender, EventArgs e) {

            picturePanel.Visible = false;
        }

        private void pictureBoxZoomFrage_Click(object sender, EventArgs e) {
            picturepanel2.Visible = false;
        }

        private void runderButtonZurück_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(this.runderButtonZurück, "Abfrage abbrechen und zurück zum Hauptmenü");
        }

        private void runderButton1_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(this.runderButton1, "Zur Antwort umdrehen");
        }

        private void runderButtonJa_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(this.runderButtonJa, "Gewusst");
        }

        private void runderButtonNein_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(this.runderButtonNein, "Nicht gewusst");
        }

        private void runderButtonQmark_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(this.runderButtonQmark, "Karte ist irrelevant");
        }

        private void runderButton3_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(this.runderButton3, "Zur Frage zurückdrehen");
        }

        private void KartenAbfrage_Load(object sender, EventArgs e)
        {
            generateAndShowCard();
        }

        private void generateAndShowCard() {
            if (this.karten.Count > 0) {
                var max = this.karten.Count - 1;
                var r = new Random();
                var pick = r.Next(0, max);

                this.karte = this.karten[pick];
                label3.Text = label2.Text = karte.KartenID.ToString();
                label5.Text = label1.Text = "Thema: " + karte.Thema;
                FragenLabel.Text = karte.Frage;
                antwortLabel.Text = karte.Antwort;

                pictureBoxFrage.Image = karte.FrageBitmap;
                pictureBoxZoomFrage.Image = karte.FrageBitmap;
                pictureBoxAntwort.Image = karte.AntwortBitmap;
                pictureBoxZoomAntwort.Image = karte.AntwortBitmap;

            } else {
                runderButtonZurück.PerformClick();
            }
        }

        private KarteikartenHelper karte;

        private void runderButtonJa_Click(object sender, EventArgs e)
        {
            if (this.karte != null)
            {
                var id = this.karten.FindIndex(x => x == this.karte);
                if (id > -1) {
                    this.karten.RemoveAt(id);
                }
                var karte = database.GetRecordCard(this.karte.KartenID);
                switch(karte.IntervallID) {
                    case 5: {
                            database.ChangeRecordCard(karte, intervallID: 2, letzteAbfrage: DateTime.Now);
                            break;
                        }
                    case 4: {
                            database.ChangeRecordCard(karte, intervallID: 4, letzteAbfrage: DateTime.Now);
                            break;
                        }
                    default: {
                            database.ChangeRecordCard(karte, intervallID: karte.IntervallID + 1, letzteAbfrage: DateTime.Now);
                            break;
                    }
                }


                // Panel "Antwort" invisible
                panelLayover.Visible = false;

                // Frage neusetzen
                generateAndShowCard();
            }
        }

        private void runderButtonNein_Click(object sender, EventArgs e)
        {
            if (this.karte != null)
            {
                var id = this.karten.FindIndex(x => x == this.karte);
                if (id > -1)
                {
                    this.karten.RemoveAt(id);
                }

                // Intervall um eins erhöhen!
                // Prüfen ob wir nicht in den unendlichen Intervall rennen
                database.SetAllIntervall();
                var intervall = database.AllIntervall;

                var karte = database.GetRecordCard(this.karte.KartenID);
                   
                database.ChangeRecordCard(karte, intervallID: 1, letzteAbfrage: DateTime.Now);
                           
                // Panel "Antwort" invisible
                panelLayover.Visible = false;

                // Frage neusetzen
                generateAndShowCard();
            }
        }

        private void runderButtonQmark_Click(object sender, EventArgs e)
        {
            if (this.karte != null)
            {
                var id = this.karten.FindIndex(x => x == this.karte);
                if (id > -1)
                {
                    this.karten.RemoveAt(id);
                }

                // Intervall um eins erhöhen!
                // Prüfen ob wir nicht in den unendlichen Intervall rennen
                database.SetAllIntervall();
                var intervall = database.AllIntervall;

                var karte = database.GetRecordCard(this.karte.KartenID);

                database.ChangeRecordCard(karte, intervallID: 5, letzteAbfrage: DateTime.Now);

                // Panel "Antwort" invisible
                panelLayover.Visible = false;

                // Frage neusetzen
                generateAndShowCard();
            }
        }
    }
}
