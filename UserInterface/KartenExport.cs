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
    }

}
