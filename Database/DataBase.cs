using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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

                SQLiteCommand mycommand = new SQLiteCommand(databaseConnection);
                mycommand.CommandText = "PRAGMA foreign_keys=ON";
                mycommand.ExecuteNonQuery();

                this.connection = databaseConnection;

                // Erstellen der Tabelle Bild mit entsprechenden Eigenschaften
                removeTable("Bild");
                removeTable("Intervall");
                removeTable("Frage");
                removeTable("Antwort");
                removeTable("Klasse");
                removeTable("Fach");
                removeTable("Thema");
                removeTable("UserSettings");
                removeTable("Karteikarten");
                createTable("Bild", "BildID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, BildDaten BLOB");
                createTable("Intervall", "IntervallID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Dauer INTEGER");
                createTable("Frage", "FrageID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Text VARCHAR(1000), BildID INTEGER, FOREIGN KEY (BildID) REFERENCES Bild(BildID)");
                createTable("Antwort", "AntwortID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Text VARCHAR(2000), BildID INTEGER, FOREIGN KEY (BildID) REFERENCES Bild(BildID)");
                createTable("Klasse", "KlasseID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(64)");
                createTable("Fach", "FachID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(64), KlasseID INTEGER, FOREIGN KEY (KlasseID) REFERENCES Klasse(KlasseID)");
                createTable("Thema", "ThemaID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(64), FachID INTEGER, FOREIGN KEY (FachID) REFERENCES Fach(FachID)");
                createTable("UserSettings", "SettingsID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Benutzername VARCHAR(64), Passwort VARCHAR(600), AutoLogin TINYINT, KlasseID INTEGER, FOREIGN KEY (KlasseID) REFERENCES Klasse(KlasseID)");
                createTable("Karteikarten", "KartenID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ThemaID INTEGER, FrageID INTEGER, AntwortID INTEGER, IntervallID INTEGER, LetzteAbfrage DATETIME," +
                    "FOREIGN KEY (ThemaID) REFERENCES Thema(ThemaID), FOREIGN KEY (FrageID) REFERENCES Frage(FrageID), FOREIGN KEY (AntwortID) REFERENCES Antwort(AntwortID), FOREIGN KEY (IntervallID) REFERENCES Intervall(IntervallID)");

                this.connection.Close();
            } else
            {
                SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=karteikarten.sqlite;Version=3;");
                databaseConnection.Open();

                SQLiteCommand mycommand = new SQLiteCommand(databaseConnection);
                mycommand.CommandText = "PRAGMA foreign_keys=ON";
                mycommand.ExecuteNonQuery();

                this.connection = databaseConnection;

                this.connection.Close();
            }
        }

        public void SavePicture(Bitmap picture)
        {
            byte[] pic = ImageToByte(picture, System.Drawing.Imaging.ImageFormat.Jpeg);

            SQLiteCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = string.Format("INSERT INTO Bild (BildDaten) VALUES (@0);");
            SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
            param.Value = pic;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        public void ChangePicture(Bitmap picture, int pictureID)
        {
            byte[] pic = ImageToByte(picture, System.Drawing.Imaging.ImageFormat.Jpeg);

            SQLiteCommand command = this.connection.CreateCommand();
            command.CommandText = string.Format("UPDATE Bild SET BildDaten=(@0) WHERE BildID='" + pictureID + "';");
            SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.Binary);
            parameter.Value = pic;
            command.Parameters.Add(parameter);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        public void RemovePicture(int pictureID) {
            SQLiteCommand command = this.connection.CreateCommand();
            command.CommandText = string.Format("DELETE FROM Bild WHERE BildID='" + pictureID + "';");

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        public Bitmap GetPicture(int pictureID)
        {
            string query = "SELECT BildDaten FROM Bild WHERE BildID='" + pictureID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        byte[] a = (System.Byte[])dataReader["BildDaten"];
                        return new Bitmap(byteToImage(a));
                    }
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { }

            return null;
        }

        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(memoryStream, format);
                byte[] imageBytes = memoryStream.ToArray();
                return imageBytes;
            }
        }

        private Image byteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(memoryStream);
            return image;
        }

        private void createTable(string tableName, string parameterString)
        {
            if (this.connection != null)
            {
                try
                {
                    string sql = "create table " + tableName + " (" + parameterString + ")";
                    SQLiteCommand command = new SQLiteCommand(sql, this.connection);
                    command.ExecuteNonQuery();
                } catch (Exception ex) { 
                    
                }
            }
        }

        private void removeTable(string tableName)
        {
            try
            {
                string sql = "drop table " + tableName;
                SQLiteCommand command = new SQLiteCommand(sql, this.connection);
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        private SQLiteConnection connection;
    }
}
