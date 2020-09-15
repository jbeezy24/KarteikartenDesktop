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

            DataBase dataBase = new DataBase();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            panelGrids.Width = Hauptform.ActiveForm.Width * 5 / 8;
            panelsideMenu.Width = Hauptform.ActiveForm.Width / 4;
        }

        private void button3_Click(object sender, EventArgs e) {
            KartenErstellen erstellen = new KartenErstellen();

            if (erstellen.ShowDialog() == DialogResult.OK) {
                //-> Commit auf Datenbank, neue Karteikarte anlegen.
            }
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            KartenImport import = new KartenImport();
            if(import.ShowDialog() == DialogResult.OK) {
                //Erstellung von Karten anhand von Daten der 
            }
        }

        private void buttonAbfrage_Click(object sender, EventArgs e) {

        }
    }
}
