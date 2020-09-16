using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class ExportObject
    {
        public Thema_Import Thema { get; set; }
        public List<Karteikarten_Import> Karteikarten { get; set; }
    }
}
