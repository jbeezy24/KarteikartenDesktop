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
        public KartenImport() {
            InitializeComponent();
        }

        private void buttonPaste_Click(object sender, EventArgs e) {
            textBox1.Text = Clipboard.GetText();
        }
    }
}
