using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class ExportRequestJson
    {
        public string Benutzername { get; set; }
        public Klasse Klasse { get; set; }
        public string Code { get; set; }
    }
}
