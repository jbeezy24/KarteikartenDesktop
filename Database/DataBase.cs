using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            string folderPath = StaticVariables.EnvironmentPath() + @"\database\";
            string databasePath = StaticVariables.EnvironmentPath() + @"\database\" + "karteikarten.sqlite";
            if (!File.Exists(databasePath))
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                SQLiteConnection.CreateFile(databasePath);

                SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=karteikarten.sqlite;Version=3;");
                databaseConnection.Open();
                databaseConnection.Close();
            }
        }
    }
}
