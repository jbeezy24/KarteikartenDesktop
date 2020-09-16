using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace KarteikartenDesktop {
    public partial class KartenImport : Form {
        public KartenImport(DataBase dataBase) {
            InitializeComponent();
            this.dataBase = dataBase;
        }
        private DataBase dataBase;

        private void buttonPaste_Click(object sender, EventArgs e) {
            textBox1.Text = Clipboard.GetText();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(textBox1.Text)) {
                if (Request.ImportKarteikarte(textBox1.Text, dataBase)) {
                    MessageBox.Show("Karten erfolgreich importiert!");
                }
                else
                    MessageBox.Show("Invalider Dowload-Code!");
            }
        }
    }
}
