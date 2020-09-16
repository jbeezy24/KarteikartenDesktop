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
        public KartenAbfrage(List<KarteikartenHelper> karten) {
            InitializeComponent();
            this.karten = karten;
        }


        List<KarteikartenHelper> karten = new List<KarteikartenHelper>();

        private void KartenAbfrage_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void runderButton1_Click(object sender, EventArgs e) {
            panelLayover.Visible = true;
        }

        private void runderButton3_Click(object sender, EventArgs e) {
            panelLayover.Visible = false;
        }

        private void pictureBoxAntwort_MouseMove(object sender, MouseEventArgs e) {

        }

        private void pictureBoxFrage_MouseMove(object sender, MouseEventArgs e) {
            ZoomButtonAntwort.Visible = true;
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
            // die erste Karte anzeigen
            var max = this.karten.Count - 1;
            var r = new Random();
            var pick = r.Next(0, max);

            var karte = this.karten[pick];
            label3.Text = karte.KartenID.ToString();
            label5.Text = "Thema: " + karte.Thema;

        }
    }
}
