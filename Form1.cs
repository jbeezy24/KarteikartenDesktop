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

namespace KarteikartenDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase();

            var day1 = dataBase.GetIntervall(1);
            var days3 = dataBase.GetIntervall(2);
            var days7 = dataBase.GetIntervall(3);
            var days30 = dataBase.GetIntervall(4);

            dataBase.RemoveIntervall(4);
            var days30Removed = dataBase.GetIntervall(4); // sollte 0 zurückgeben
        }
    }
}
