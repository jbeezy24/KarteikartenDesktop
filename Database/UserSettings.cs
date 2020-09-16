using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class UserSettings
    {
        public int SettingsID { get; set; }
        public string Benutzername { get; set; }
        public string Passwort { get; set; }
        public bool AutoLogin { get; set; }
    }
}
