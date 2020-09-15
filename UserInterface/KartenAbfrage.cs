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
        public KartenAbfrage() {
            InitializeComponent();
        }

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

        }
    }
}
