using KarteikartenDesktop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class ExportRequestJson
    {
        public List<Karteikarten> KarteikartenList { get; set; }
        public List<Antwort> AntwortenList { get; set; }
        public List<Frage> FrageList { get; set; }
        public List<Fach> FachList { get; set; }
        public List<Thema> ThemaList { get; set; }
        public List<Bild> BildList { get; set; }
        public List<Klasse> KlasseList { get; set; }
        public List<UserSettings> UserSettingsList { get; set; }
    }
}
