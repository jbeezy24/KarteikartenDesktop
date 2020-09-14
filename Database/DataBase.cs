using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class DataBase
    {
        public DataBase()
        {
            // Prüfen ob Ordner + Datei bereits existiert
            string databasePath = StaticVariables.EnvironmentPath() + @"\database\" + "karteikarten.sqlite";
            if (!File.Exists(databasePath))
            {
                
            }
        }
    }
}
