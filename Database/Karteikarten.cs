using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop.Database
{
    public class Karteikarten
    {
        public int KartenID { get; set; }
        public int ThemaID { get; set; }
        public int FrageID { get; set; }
        public int AntwortID { get; set; }
        public int IntervallID { get; set; }
        public DateTime LetzteAbfrage { get; set; }
    }
}
