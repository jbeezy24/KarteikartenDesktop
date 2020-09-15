using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class KarteikartenHelper
    {
        public int KartenID { get; set; }
        public string Thema { get; set; }
        public string Frage { get; set; }
        public Bitmap FrageBitmap { get; set; }
        public int FrageBitmapID { get; set; }
        public string Antwort { get; set; }
        public Bitmap AntwortBitmap { get; set; }
        public int AntwortBitmapID { get; set; }
        public int Intervall { get; set; }
        public DateTime LetzteAbfrage { get; set; }
        public string Fachname { get; set; }
        public int ThemaID { get; set; }
    }
}
