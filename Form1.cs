﻿using KarteikartenDesktop.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
    }
}
