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
    public partial class KartenErstellen : Form {
        public KartenErstellen(DataBase db) {
            bearbeiteteKarte = new KarteikartenHelper();
            InitializeComponent();
            this.database = db;

            this.Text = "Karte Erstellen";
            db.SetAllFach();
            fachlist = db.AllFach;

            foreach (var fach in fachlist) {
                comboBox1.Items.Add(fach.Name);
            }
        }

        public KartenErstellen(DataBase db, KarteikartenHelper karte) {
            InitializeComponent();
            bearbeiteteKarte = karte;
            this.Text = "Karte Bearbeiten";
            this.database = db;

            db.SetAllFach();
            fachlist = db.AllFach;

            foreach (var fach in fachlist) {
                comboBox1.Items.Add(fach.Name);
            }

            //Laden der Daten aus Karte
            comboBox1.Text = karte.Fachname;
            comboBox1.Enabled = false;
            textBox1.Text = karte.Thema;
            richTextBox1.Text = karte.Frage;
            richTextBox2.Text = karte.Antwort;
            frageBild = karte.FrageBitmap;
            antwortBild = karte.AntwortBitmap;
        }

        KarteikartenHelper bearbeiteteKarte = new KarteikartenHelper();
        Bitmap frageBild;
        Bitmap antwortBild;

        List<Fach> fachlist = new List<Fach>();        
        DataBase database;



        private void buttonOK_Click(object sender, EventArgs e) {
            database.SetAllThema();
            var thema = database.AllThema.Where(x => x.Name.ToLower() == textBox1.Text.ToLower()).FirstOrDefault();

            database.SetAllFach();
            var fach = database.AllFach.Where(x => x.Name.ToLower() == comboBox1.SelectedItem.ToString().ToLower()).FirstOrDefault();

            if (thema == null) {
                database.CreateTopic(textBox1.Text, fach.FachID);
                database.SetAllThema();
                thema = database.AllThema.Where(x => x.Name.ToLower() == textBox1.Text.ToLower()).FirstOrDefault();
            }
            if (this.Text == "Karte Erstellen") {
            database.CreateQuestion(richTextBox1.Text, frageBild);
            database.CreateAnswer(richTextBox2.Text, antwortBild);

            database.SetAllFrage();
            database.SetAllAntwort();

            var frage = database.AllFrage[database.AllFrage.Count - 1];
            var antwort = database.AllAntwort[database.AllAntwort.Count - 1];

            database.CreateRecordCard(thema.ThemaID, frage.FrageID, antwort.AntwortID, 1, DateTime.Now);
            } else {

                var karte = database.GetRecordCard(bearbeiteteKarte.KartenID);
                database.ChangeRecordCard(karte, thema.ThemaID, richTextBox1.Text, richTextBox2.Text, frageBild, antwortBild);
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Bild auswählen zum Upload";
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    frageBild = new Bitmap(Image.FromFile(dialog.FileName));
                }
                catch (Exception ex) {
                    Logger.WriteLogfile(ex.Message);
                    throw;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Bild auswählen zum Upload";
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    antwortBild = new Bitmap(Image.FromFile(dialog.FileName));
                }
                catch (Exception ex) {
                    Logger.WriteLogfile(ex.Message);
                    throw;
                }
            }
        }

        private void runderButton2_MouseDown(object sender, MouseEventArgs e) {
            panel1.Visible = true;
            pictureBox1.Image = antwortBild;
        }

        private void runderButton2_MouseUp(object sender, MouseEventArgs e) {
            panel1.Visible = false;
        }

        private void runderButton1_MouseDown(object sender, MouseEventArgs e) {
            panel1.Visible = true;
            pictureBox1.Image = frageBild;
        }

        private void runderButton1_MouseUp(object sender, MouseEventArgs e) {
            panel1.Visible = false;
        }

        private void runderButton4_Click(object sender, EventArgs e) {
            frageBild = null;
        }

        private void runderButton3_Click(object sender, EventArgs e) {
            antwortBild = null;
        }
    }
}
