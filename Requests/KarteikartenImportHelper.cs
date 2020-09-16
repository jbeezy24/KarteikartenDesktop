using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class KarteikartenImportHelper
    {
        public string Thema { get; set; }
        public string Fach { get; set; }
        public string Frage { get; set; }
        public string Antwort { get; set; }
        public Bitmap FrageBild { get; set; }
        public Bitmap AntwortBild { get; set; }
    }
}
