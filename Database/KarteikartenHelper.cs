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
        public string Thema { get => thema; set => thema = value; }
        public string Frage { get => frage; set => frage = value; }
        public Bitmap FrageBitmap { get; set; }
        public int? FrageBitmapID { get; set; }
        public string Antwort { get => antwort; set => antwort = value; }
        public Bitmap AntwortBitmap { get; set; }
        public int? AntwortBitmapID { get; set; }
        public int Intervall { get; set; }
        public DateTime LetzteAbfrage { get; set; }
        public string Fachname { get => fachname; set => fachname = value; }
        public int ThemaID { get; set; }
        public int FrageID { get; set; }
        public int FachID { get; set; }
        public int AntwortID { get; set; }

        private string thema = string.Empty;
        private string frage = string.Empty;
        private string antwort = string.Empty;
        private string fachname = string.Empty;
    }
}
