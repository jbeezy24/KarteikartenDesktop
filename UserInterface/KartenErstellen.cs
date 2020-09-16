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
            InitializeComponent();
            this.database = db;

            db.SetAllFach();
            fachlist = db.AllFach;

            foreach (var fach in fachlist) {
                comboBox1.Items.Add(fach.Name);
            }
        }

        Image frageBild;
        Image antwortBild;

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


            database.CreateQuestion(richTextBox1.Text, new Bitmap(frageBild));
            database.CreateAnswer(richTextBox2.Text, new Bitmap(antwortBild));

            database.SetAllFrage();
            database.SetAllAntwort();

            var frage = database.AllFrage[database.AllFrage.Count - 1];
            var antwort = database.AllAntwort[database.AllAntwort.Count - 1];

            database.CreateRecordCard(thema.ThemaID, frage.FrageID, antwort.AntwortID, 1, DateTime.Now);
        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Bild auswählen zum Upload";
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    frageBild = Image.FromFile(dialog.FileName);
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
                    antwortBild = Image.FromFile(dialog.FileName);
                }
                catch (Exception ex) {
                    Logger.WriteLogfile(ex.Message);
                    throw;
                }
            }
        }
    }
}
