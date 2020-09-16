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
    public partial class KartenExport : Form {
        public KartenExport(DataBase db) {
            InitializeComponent();
            this.db = db;
            db.SetAllFach();
            fachlist = db.AllFach;

            foreach (var fach in fachlist) {
                comboBox1.Items.Add(fach.Name);
            }
        }

        private DataBase db;
        private List<Fach> fachlist;

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                row.Cells[0].Value = checkBox1.Checked;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            dataGridView1.Rows.Clear();
            var fachKarten = db.GetAllKarteikarten().Where(x => x.Fachname == comboBox1.SelectedItem.ToString()).ToList();
            foreach (var Karte in fachKarten) {
                var row = new DataGridViewRow();
                var cellcheck = new DataGridViewCheckBoxCell();
                var cellkartenid = new DataGridViewTextBoxCell();
                var celltopic = new DataGridViewTextBoxCell();
                var cellquestion = new DataGridViewTextBoxCell();

                celltopic.Value = Karte.Thema;
                cellquestion.Value = Karte.Frage;
                cellkartenid.Value = Karte.KartenID;
                row.Cells.AddRange(new DataGridViewCell[] { cellcheck,cellkartenid,celltopic,cellquestion});
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e) {
            List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                if(System.Convert.ToBoolean(row.Cells[0].Value) == true) {
                    var karte = db.GetAllKarteikarten().Where(x => x.KartenID == System.Convert.ToInt32(row.Cells[1].Value)).FirstOrDefault();
                    if (karte != null) {
                        Request.ExportKarteikarte(karte, db.GetUsersettings(1));
                    }
                }
            }           
        }
    }
}
