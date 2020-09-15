using KarteikartenDesktop.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                createTable("Frage", "FrageID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Text VARCHAR(500), BildID INTEGER, FOREIGN KEY (BildID) REFERENCES Bild(BildID)");
                createTable("Antwort", "AntwortID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Text VARCHAR(2000), BildID INTEGER, FOREIGN KEY (BildID) REFERENCES Bild(BildID)");
                createTable("Klasse", "KlasseID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(64)");
                createTable("Fach", "FachID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(64), KlasseID INTEGER, FOREIGN KEY (KlasseID) REFERENCES Klasse(KlasseID)");
                createTable("Thema", "ThemaID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(64), FachID INTEGER, FOREIGN KEY (FachID) REFERENCES Fach(FachID)");
                createTable("UserSettings", "SettingsID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Benutzername VARCHAR(64), Passwort VARCHAR(600), AutoLogin INTEGER, KlasseID INTEGER, FOREIGN KEY (KlasseID) REFERENCES Klasse(KlasseID)");
                createTable("Karteikarten", "KartenID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ThemaID INTEGER, FrageID INTEGER, AntwortID INTEGER, IntervallID INTEGER, LetzteAbfrage DATETIME," +
                    "FOREIGN KEY (ThemaID) REFERENCES Thema(ThemaID), FOREIGN KEY (FrageID) REFERENCES Frage(FrageID), FOREIGN KEY (AntwortID) REFERENCES Antwort(AntwortID), FOREIGN KEY (IntervallID) REFERENCES Intervall(IntervallID)");

                CreateIntervall(1);
                CreateIntervall(3);
                CreateIntervall(7);
                CreateIntervall(30);
                CreateIntervall(9999);

               // this.connection.Close();
            } else
            {
                SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=karteikarten.sqlite;Version=3;");
                databaseConnection.Open();

                SQLiteCommand mycommand = new SQLiteCommand(databaseConnection);
                mycommand.CommandText = "PRAGMA foreign_keys=ON";
                mycommand.ExecuteNonQuery();

                this.connection = databaseConnection;

                // this.connection.Close();
            }
        }

        #region Karteikarten erstellen / bearbeiten / löschen / ausgeben
        public void CreateRecordCard(int themaID, int frageID, int antwortID, int intervallID, DateTime letzteAbfrage)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("INSERT INTO Karteikarten (ThemaID, FrageID, AntwortID, IntervallID, LetzteAbfrage) VALUES (@0, @1, @2, @3, @4);");
                SQLiteParameter parameterTopic = new SQLiteParameter("@0", DbType.Int32);
                SQLiteParameter parameterQuestion = new SQLiteParameter("@1", DbType.Int32);
                SQLiteParameter parameterAnswer = new SQLiteParameter("@2", DbType.Int32);
                SQLiteParameter parameterIntervall = new SQLiteParameter("@3", DbType.Int32);
                SQLiteParameter parameterLastRequest = new SQLiteParameter("@4", DbType.DateTime);

                parameterTopic.Value = themaID;
                parameterQuestion.Value = frageID;
                parameterAnswer.Value = antwortID;
                parameterIntervall.Value = intervallID;
                parameterLastRequest.Value = letzteAbfrage;

                command.Parameters.Add(parameterTopic);
                command.Parameters.Add(parameterQuestion);
                command.Parameters.Add(parameterAnswer);
                command.Parameters.Add(parameterIntervall);
                command.Parameters.Add(parameterLastRequest);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateRecordCard: " + ex.Message);
            }
        }

        public Karteikarten GetRecordCard(int recordCardID)
        {
            Karteikarten recordCard = new Karteikarten();
            string query = "SELECT * FROM Karteikarten WHERE KartenID='" + recordCardID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var topicID = dataReader["ThemaID"];
                        var questionID = dataReader["FrageID"];
                        var answerID = dataReader["AntwortID"];
                        var intervallID = dataReader["IntervallID"];
                        var lastRequest = dataReader["LetzteAbfrage"];

                        recordCard.ThemaID = Convert.ToInt32(topicID);
                        recordCard.FrageID = Convert.ToInt32(questionID);
                        recordCard.AntwortID = Convert.ToInt32(answerID);
                        recordCard.IntervallID = Convert.ToInt32(intervallID);
                        recordCard.LetzteAbfrage = Convert.ToDateTime(lastRequest);

                        return recordCard;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetRecordCard 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetRecordCard 2: " + ex.Message);
            }

            return recordCard;
        }

        public void ChangeRecordCard(int recordCardID, int? themaID = null, int? frageID = null, int? antwortID = null)
        {
            try
            {
                string sqlQuery = "UPDATE Karteikarten SET ";

                if (themaID != null)
                {
                    sqlQuery += "ThemaID='" + themaID + "'";
                }

                if (frageID != null)
                {
                    sqlQuery += ", FrageID='" + frageID + "'";
                }

                if (antwortID != null)
                {
                    sqlQuery += ", AntwortID='" + antwortID + "'";
                }

                sqlQuery += " WHERE KartenID='" + recordCardID + "';";

                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = sqlQuery;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("ChangeRecordCard: " + ex.Message);
            }
        }

        public void RemoveRecordCard(int recordCardID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Karteikarten WHERE KartenID='" + recordCardID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveRecordCard: " + ex.Message);
            }
        }
        #endregion

        #region Benutzereinstellungen erstellen / bearbeiten / löschen / ausgeben
        public void CreateUsersettings(string username, string password, bool autologin, int classID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("INSERT INTO UserSettings (Benutzername, Passwort, AutoLogin, KlasseID) VALUES (@0, @1, @2, @3);");
                SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                parameter.Value = username;
                command.Parameters.Add(parameter);
                SQLiteParameter parameterPassword = new SQLiteParameter("@1", System.Data.DbType.String);
                parameterPassword.Value = password;
                command.Parameters.Add(parameterPassword);
                SQLiteParameter parameterAutoLogin = new SQLiteParameter("@2", DbType.Int32);
                parameterAutoLogin.Value = autologin == true ? 1 : 0;
                command.Parameters.Add(parameterAutoLogin);
                SQLiteParameter parameterClassID = new SQLiteParameter("@3", DbType.Int32);
                parameterClassID.Value = classID;
                command.Parameters.Add(parameterClassID);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateUsersettings: " + ex.Message);
            }
        }

        public UserSettings GetUsersettings(int settingsID)
        {
            UserSettings userSettings = new UserSettings();
            string query = "SELECT * FROM UserSettings WHERE SettingsID='" + settingsID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var username = dataReader["Benutzername"];
                        var password = dataReader["Passwort"];
                        var autoLogin = dataReader["AutoLogin"];
                        var classID = dataReader["KlasseID"];

                        userSettings.Benutzername = username.ToString();
                        userSettings.Passwort = password.ToString();
                        userSettings.AutoLogin = Convert.ToInt32(autoLogin) == 1 ? true : false;
                        userSettings.KlasseID = Convert.ToInt32(classID);
                        return userSettings;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetUsersettings 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetUsersettings 2: " + ex.Message);
            }

            return userSettings;
        }

        public void ChangeUsersettings(int settingsID, string username = null, string password = null, bool? autoLogin = null, int? classID = null)
        {
            try
            {
                string sqlQuery = "UPDATE UserSettings SET ";

                if (!string.IsNullOrEmpty(username))
                {
                    sqlQuery += "Benutzername='"+ username + "'";
                }

                if (!string.IsNullOrEmpty(password))
                {
                    sqlQuery += ", Passwort='" + password + "'";
                }

                if (autoLogin != null)
                {
                    int number = autoLogin == true ? 1 : 0;
                    sqlQuery += ", AutoLogin='" + number +"'";
                }

                if (classID != null)
                {
                    sqlQuery += ", KlasseID='" + classID + "'";
                }

                sqlQuery += " WHERE SettingsID='" + settingsID + "';";

                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = sqlQuery;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("ChangeUsersettings: " + ex.Message);
            }
        }

        public void RemoveUsersettings(int settingsID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM UserSettings WHERE SettingsID='" + settingsID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveUsersettings: " + ex.Message);
            }
        }

        #endregion

        #region Thema erstellen / löschen / ausgeben
        public void CreateTopic(string name, int fachID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("INSERT INTO Thema (Name, FachID) VALUES (@0, @1);");
                SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                parameter.Value = name;
                command.Parameters.Add(parameter);
                SQLiteParameter parameterSubject = new SQLiteParameter("@1", System.Data.DbType.Int32);
                parameterSubject.Value = fachID;
                command.Parameters.Add(parameterSubject);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateTopic: " + ex.Message);
            }
        }

        public Thema GetTopic(int themaID)
        {
            Thema thema = new Thema();
            string query = "SELECT Name FROM Thema WHERE ThemaID='" + themaID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var name = dataReader["Name"];
                        var subjectID = dataReader["FachID"];
                        thema.ThemaID = themaID;
                        thema.Name = name.ToString();
                        thema.FachID = Convert.ToInt32(subjectID);

                        return thema;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetTopic 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetTopic 2: " + ex.Message);
            }

            return thema;
        }

        public void RemoveTopic(int themaID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Thema WHERE ThemaID='" + themaID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveTopic: " + ex.Message);
            }
        }
        #endregion

        #region Fach erstellen / löschen / ausgeben
        public void CreateSubject(string name, int classID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("INSERT INTO Fach (Name, KlasseID) VALUES (@0, @1);");
                SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                parameter.Value = name;
                command.Parameters.Add(parameter);
                SQLiteParameter parameterSubject = new SQLiteParameter("@1", System.Data.DbType.Int32);
                parameterSubject.Value = classID;
                command.Parameters.Add(parameterSubject);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateSubject: " + ex.Message);
            }
        }

        public Fach GetSubject(int fachID)
        {
            Fach fach = new Fach();
            string query = "SELECT Name FROM Fach WHERE FachID='" + fachID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var name = dataReader["Name"];
                        var klasseID = dataReader["KlasseID"];

                        fach.Name = name.ToString();
                        fach.FachID = fachID;
                        fach.KlasseID = Convert.ToInt32(klasseID);
                        return fach;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetSubject 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetSubject 2: " + ex.Message);
            }

            return fach;
        }

        public void RemoveSubject(int fachID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Fach WHERE FachID='" + fachID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveSubject: " + ex.Message);
            }
        }
        #endregion

        #region Klasse erstellen / löschen / ausgeben
        public void CreateClass(string name)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("INSERT INTO Klasse (Name) VALUES (@0);");
                SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                parameter.Value = name;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateClass: " + ex.Message);
            }
        }

        public Klasse GetClass(int classID)
        {
            Klasse klasse = new Klasse();
            string query = "SELECT Name FROM Klasse WHERE KlasseID='" + classID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var className = dataReader["Name"];
                        klasse.Name = className.ToString();
                        klasse.KlasseID = classID;
                        return klasse;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetClass 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetClass 2: " + ex.Message);
            }

            return klasse;
        }

        public void RemoveClass(int classID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Klasse WHERE KlasseID='" + classID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveClass: " + ex.Message);
            }
        }

        #endregion

        #region Antwort erstellen / bearbeiten / löschen / ausgeben
        public void CreateAnswer(string text, Bitmap picture = null)
        {
            try
            {
                if (picture == null)
                {
                    CreateAnswer(text, 0);
                }
                else
                {
                    SavePicture(picture);

                    // letzten Eintrag von Tabelle Bild bekommen, da dort unser neuestes Bild ist
                    var latestPictureID = GetLatestPictureBildID();

                    if (latestPictureID > 0)
                    {
                        CreateAnswer(text, latestPictureID);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateAnswer 1: " + ex.Message);
            }
        }

        public void CreateAnswer(string text, int bildID = 0)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();

                if (bildID == 0)
                {
                    command.CommandText = string.Format("INSERT INTO Antwort (Text) VALUES (@0);");
                    SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                    parameter.Value = text;
                    command.Parameters.Add(parameter);
                }
                else
                {
                    command.CommandText = string.Format("INSERT INTO Antwort (Text, BildID) VALUES (@0, @1);");
                    SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                    SQLiteParameter parameterBildID = new SQLiteParameter("@1", System.Data.DbType.Int32);
                    parameter.Value = text;
                    parameterBildID.Value = bildID;
                    command.Parameters.Add(parameter);
                    command.Parameters.Add(parameterBildID);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateAnswer 2: " + ex.Message);
            }
        }

        public string GetAnswer(int antwortID)
        {
            string query = "SELECT Text FROM Antwort WHERE AntwortID='" + antwortID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var a = dataReader["Text"];
                        return Convert.ToString(a);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetAnswer 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetAnswer 2: " + ex.Message);
            }

            return string.Empty;
        }

        public Bitmap GetAnswerPicture(int antwortID)
        {
            string query = "SELECT BildDaten FROM Bild INNER JOIN Antwort ON Antwort.BildID=Bild.BildID WHERE Antwort.AntwortID='" + antwortID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        byte[] a = (System.Byte[])dataReader["BildDaten"];
                        return new Bitmap(ByteToImage(a));
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetAnswerPicture 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetAnswerPicture 2: " + ex.Message);
            }

            return null;
        }

        public void ChangeAnswer(int antwortID, string text)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("Update Antwort SET Text='" + text + "' WHERE AntwortID='" + antwortID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("ChangeAnswer1: " + ex.Message);
            }
        }

        public void ChangeAnswer(int antwortID, Bitmap picture)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                SavePicture(picture);
                var latestPictureID = GetLatestPictureBildID();

                if (latestPictureID > 0)
                {
                    command.CommandText = string.Format("Update Antwort SET BildID='" + latestPictureID + "' WHERE AntwortID='" + antwortID + "';");
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("ChangeAnswer2: " + ex.Message);
            }
        }

        public void RemoveAnswer(int antwortID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Antwort WHERE AntwortID='" + antwortID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveAnswer: " + ex.Message);
            }
        }
        #endregion

        #region Frage erstellen / bearbeiten / löschen / ausgeben
        public void CreateQuestion(string text, Bitmap picture = null)
        {
            try
            {
                if (picture == null)
                {
                    CreateQuestion(text, 0);
                }
                else
                {
                    SavePicture(picture);

                    // letzten Eintrag von Tabelle Bild bekommen, da dort unser neuestes Bild ist
                    var latestPictureID = GetLatestPictureBildID();

                    if (latestPictureID > 0)
                    {
                        CreateQuestion(text, latestPictureID);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateQuestion1: " + ex.Message);
            }
        }

        public void CreateQuestion(string text, int bildID = 0)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();

                if (bildID == 0)
                {
                    command.CommandText = string.Format("INSERT INTO Frage (Text) VALUES (@0);");
                    SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                    parameter.Value = text;
                    command.Parameters.Add(parameter);
                } else
                {
                    command.CommandText = string.Format("INSERT INTO Frage (Text, BildID) VALUES (@0, @1);");
                    SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.String);
                    SQLiteParameter parameterBildID = new SQLiteParameter("@1", System.Data.DbType.Int32);
                    parameter.Value = text;
                    parameterBildID.Value = bildID;
                    command.Parameters.Add(parameter);
                    command.Parameters.Add(parameterBildID);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("CreateQuestion2 : " + ex.Message);
            }
        }

        public string GetQuestion(int frageID)
        {
            string query = "SELECT Text FROM Frage WHERE FrageID='" + frageID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var a = dataReader["Text"];
                        return Convert.ToString(a);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetQuestion 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetQuestion 2: " + ex.Message);
            }

            return string.Empty;
        }

        public Bitmap GetQuestionPicture(int frageID)
        {
            string query = "SELECT BildDaten FROM Bild INNER JOIN Frage ON Frage.BildID=Bild.BildID WHERE Frage.FrageID='" + frageID + "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        byte[] a = (System.Byte[])dataReader["BildDaten"];
                        return new Bitmap(ByteToImage(a));
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetQuestionPicture 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetQuestionPicture 2: " + ex.Message);
            }

            return null;
        }

        public void ChangeQuestion(int frageID, string text)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("Update Frage SET Text='" + text + "' WHERE FrageID='" + frageID + "';");
                command.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Logger.WriteLogfile("ChangeQuestion1: " + ex.Message);
            }
        }

        public void ChangeQuestion(int frageID, Bitmap picture)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                SavePicture(picture);
                var latestPictureID = GetLatestPictureBildID();

                if (latestPictureID > 0)
                {
                    command.CommandText = string.Format("Update Frage SET BildID='" + latestPictureID + "' WHERE FrageID='" + frageID + "';");
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                Logger.WriteLogfile("ChangeQuestion2: " + ex.Message);
            }
        }

        public void RemoveQuestion(int frageID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Frage WHERE FrageID='" + frageID + "';");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveQuestion: " + ex.Message);
            }
        }
        #endregion

        #region Intervalltabelle erstellen / auslesen / löschen
        public void CreateIntervall(int duration)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("INSERT INTO Intervall (Dauer) VALUES (@0);");
                SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.Int32);
                parameter.Value = duration;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Logger.WriteLogfile("CreateIntervall: " + ex.Message);
            }
        }

        public Intervall GetIntervall(int intervallID)
        {
            Intervall intervall = new Intervall();
            string query = "SELECT Dauer FROM Intervall WHERE IntervallID='" + intervallID+ "';";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var dauer = dataReader["Dauer"];
                        intervall.IntervallID = intervallID;
                        intervall.Dauer = Convert.ToInt32(dauer);
                        return intervall;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetIntervall 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetIntervall 2: " + ex.Message);
            }

            return intervall;
        }

        public void RemoveIntervall(int intervallID)
        {
            try
            {
                SQLiteCommand command = this.connection.CreateCommand();
                command.CommandText = string.Format("DELETE FROM Intervall WHERE IntervallID='" + intervallID + "';");
                command.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Logger.WriteLogfile("RemoveIntervall: " + ex.Message);
            }
        }
        #endregion

        #region Bildtabelle bearbeiten / hinzufügen / entfernen / auslesen
        public void SavePicture(Bitmap picture)
        {
            byte[] pic = ImageToByte(picture, System.Drawing.Imaging.ImageFormat.Jpeg);

            SQLiteCommand command = this.connection.CreateCommand();
            command.CommandText = string.Format("INSERT INTO Bild (BildDaten) VALUES (@0);");
            SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
            param.Value = pic;
            command.Parameters.Add(param);
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SavePicture: " + ex.Message);
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
                Logger.WriteLogfile("ChangePicture: " + ex.Message);
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
                Logger.WriteLogfile("RemovePicture: " + ex.Message);
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
                        return new Bitmap(ByteToImage(a));
                    }
                }
                catch (Exception ex) {
                    Logger.WriteLogfile("GetPicture 1: " + ex.Message);
                }
            }
            catch (Exception ex) {
                Logger.WriteLogfile("GetPicture 2: " + ex.Message);
            }

            return null;
        }

        public int GetLatestPictureBildID()
        {
            string query = "SELECT BildID FROM Bild ORDER BY BildID DESC LIMIT 1;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        var a = dataReader["BildID"];
                        return Convert.ToInt32(a);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetLatestPicture 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetLatestPicture 2: " + ex.Message);
            }

            return 0;
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

        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(memoryStream);
            return image;
        }
        #endregion

        public void SetAllKarteikarten()
        {
            this.allKarteikarten.Clear();
        
            string query = "SELECT * FROM Karteikarten;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Karteikarten recordCard = new Karteikarten();
                        var topicID = dataReader["ThemaID"];
                        var questionID = dataReader["FrageID"];
                        var answerID = dataReader["AntwortID"];
                        var intervallID = dataReader["IntervallID"];
                        var lastRequest = dataReader["LetzteAbfrage"];

                        recordCard.ThemaID = Convert.ToInt32(topicID);
                        recordCard.FrageID = Convert.ToInt32(questionID);
                        recordCard.AntwortID = Convert.ToInt32(answerID);
                        recordCard.IntervallID = Convert.ToInt32(intervallID);
                        recordCard.LetzteAbfrage = Convert.ToDateTime(lastRequest);

                        this.allKarteikarten.Add(recordCard);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllKarteikarten 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllKarteikarten 2: " + ex.Message);
            }
        }

        public void SetAllUsersettings()
        {
            this.allUserSettings.Clear();
            string query = "SELECT * FROM UserSettings;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        UserSettings userSettings = new UserSettings();
                        var username = dataReader["Benutzername"];
                        var password = dataReader["Passwort"];
                        var autoLogin = dataReader["AutoLogin"];
                        var classID = dataReader["KlasseID"];

                        userSettings.Benutzername = username.ToString();
                        userSettings.Passwort = password.ToString();
                        userSettings.AutoLogin = Convert.ToInt32(autoLogin) == 1 ? true : false;
                        userSettings.KlasseID = Convert.ToInt32(classID);
                        this.allUserSettings.Add(userSettings);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllUsersettings 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllUsersettings 2: " + ex.Message);
            }
        }

        public void SetAllThema()
        {
            this.allThema.Clear();
            string query = "SELECT * FROM Thema;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Thema thema = new Thema();
                        var name = dataReader["Name"];
                        var subjectID = dataReader["FachID"];
                        var themaID = dataReader["ThemaID"];

                        thema.ThemaID = Convert.ToInt32(themaID);
                        thema.Name = name.ToString();
                        thema.FachID = Convert.ToInt32(subjectID);

                        this.allThema.Add(thema);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllThema 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllThema 2: " + ex.Message);
            }
        }

        public void SetAllKlasse()
        {
            this.allKlasse.Clear();
            string query = "SELECT * FROM Klasse;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Klasse klasse = new Klasse();
                        var classID = dataReader["KlasseID"];
                        var className = dataReader["Name"];
                        klasse.Name = className.ToString();
                        klasse.KlasseID = Convert.ToInt32(classID);

                        this.allKlasse.Add(klasse);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllKlasse 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllKlasse 2: " + ex.Message);
            }
        }

        public void SetAllIntervall()
        {
            this.allIntervall.Clear();
            string query = "SELECT * FROM Intervall;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Intervall intervall = new Intervall();
                        var dauer = dataReader["Dauer"];
                        var intervallID = dataReader["IntervallID"];
                        intervall.IntervallID = Convert.ToInt32(intervallID);
                        intervall.Dauer = Convert.ToInt32(dauer);

                        this.allIntervall.Add(intervall);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllIntervall 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllIntervall 2: " + ex.Message);
            }
        }

        public void SetAllFrage()
        {
            this.allFrage.Clear();

            string query = "SELECT * FROM Frage;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Frage frage = new Frage();
                        var text = dataReader["Text"];
                        var bildID = dataReader["BildID"];
                        var frageID = dataReader["FrageID"];

                        frage.Text = text.ToString();
                        frage.BildID = bildID.GetType() != typeof(DBNull) ? Convert.ToInt32(bildID) : 0;
                        frage.FrageID = Convert.ToInt32(frageID);
                        this.allFrage.Add(frage);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllFrage 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllFrage 2: " + ex.Message);
            }
        }

        public void SetAllFach()
        {
            this.allFach.Clear();
            string query = "SELECT * FROM Fach;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Fach fach = new Fach();
                        var name = dataReader["Name"];
                        var klasseID = dataReader["KlasseID"];
                        var fachID = dataReader["FachID"];

                        fach.Name = name.ToString();
                        fach.FachID = Convert.ToInt32(fachID);
                        fach.KlasseID = Convert.ToInt32(klasseID);

                        this.allFach.Add(fach);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllFach 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllFach 2: " + ex.Message);
            }
        }

        public void SetAllBild()
        {
            this.allBild.Clear();
            string query = "SELECT * FROM Bild;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Bild bild = new Bild();
                        byte[] bildDaten = (System.Byte[])dataReader["BildDaten"];
                        var bildID = dataReader["BildID"];

                        bild.BildDaten = bildDaten.Select(x => (int)x).ToArray() ?? new int[0];
                        bild.BildID = Convert.ToInt32(bildID);

                        this.allBild.Add(bild);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllBild 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllBild 2: " + ex.Message);
            }
        }

        public void SetAllAntwort()
        {
            this.allAntwort.Clear();
            string query = "SELECT * FROM Antwort;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        Antwort antwort = new Antwort();
                        var text = dataReader["Text"];
                        var bildID = dataReader["BildID"];
                        var antwortID = dataReader["AntwortID"];

                        antwort.Text = text.ToString();
                        antwort.BildID = bildID.GetType() != typeof(DBNull) ? Convert.ToInt32(bildID) : 0;
                        antwort.AntwortID = Convert.ToInt32(antwortID);
                        this.allAntwort.Add(antwort);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("SetAllAnswer 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("SetAllAnswer 2: " + ex.Message);
            }
        }

        public List<KarteikartenHelper> GetAllKarteikarten()
        {
            List<KarteikartenHelper> karteikartenHelpers = new List<KarteikartenHelper>();

            string query = "SELECT Karteikarten.KartenID, Thema.Name, Frage.Text, Frage.BildID, Antwort.Text, Antwort.BildID, Intervall.Dauer, Karteikarten.LetzteAbfrage " +
                "FROM Karteikarten " +
                "INNER JOIN Thema " +
                "ON Thema.ThemaID = Karteikarten.ThemaID " +
                "INNER JOIN Frage " +
                "ON Frage.FrageID = Karteikarten.FrageID " +
                "INNER JOIN Antwort " +
                "ON Antwort.AntwortID = Karteikarten.AntwortID " +
                "INNER JOIN Intervall " +
                "ON Intervall.IntervallID = Karteikarten.IntervallID;";
            SQLiteCommand command = new SQLiteCommand(query, this.connection);
            try
            {
                IDataReader dataReader = command.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        KarteikartenHelper karteikartenHelper = new KarteikartenHelper();
                        var kartenID = dataReader[0];
                        var themaName = dataReader[1];
                        var frageText = dataReader[2];
                        var frageBildID = dataReader[3];
                        var antwortText = dataReader[4];
                        var antwortBildID = dataReader[5];
                        var intervallDauer = dataReader[6];
                        var letzteAbfrage = dataReader[7];

                        karteikartenHelper.KartenID = Convert.ToInt32(kartenID);
                        karteikartenHelper.Thema = themaName.ToString();
                        karteikartenHelper.Frage = frageText.ToString();
                        karteikartenHelper.FrageBitmapID = frageBildID.GetType() == typeof(DBNull) ? 0 : Convert.ToInt32(frageBildID);
                        karteikartenHelper.Antwort = antwortText.ToString();
                        karteikartenHelper.AntwortBitmapID = antwortBildID.GetType() == typeof(DBNull) ? 0 : Convert.ToInt32(antwortBildID);
                        karteikartenHelper.Intervall = Convert.ToInt32(intervallDauer);
                        karteikartenHelper.LetzteAbfrage = Convert.ToDateTime(letzteAbfrage);

                        karteikartenHelpers.Add(karteikartenHelper);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogfile("GetAllKarteikarten 1: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogfile("GetAllKarteikarten 2: " + ex.Message);
            }

            for (int i = 0; i < karteikartenHelpers.Count; i++)
            {
                if (karteikartenHelpers[i].FrageBitmapID > 0)
                {
                    var queryFrage = "SELECT BildDaten " +
                    "FROM Bild " +
                    "WHERE BildID='" + karteikartenHelpers[i].FrageBitmapID + "';";

                    command = new SQLiteCommand(queryFrage, this.connection);
                    try
                    {
                        IDataReader dataReader = command.ExecuteReader();
                        try
                        {
                            while (dataReader.Read())
                            {
                                byte[] bildDaten = (System.Byte[])dataReader["BildDaten"];
                                karteikartenHelpers[i].FrageBitmap = new Bitmap(ByteToImage(bildDaten));
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteLogfile("GetAllKarteikarten 3: " + ex.Message);
                        }
                    } catch (Exception ex)
                    {
                        Logger.WriteLogfile("GetAllKarteikarten 4: " + ex.Message);
                    }
                }

                if (karteikartenHelpers[i].AntwortBitmapID > 0)
                {
                    var queryAntwort = "SELECT Bild.BildDaten" +
                    "FROM Bild" +
                    "WHERE Bild.BildID='" + karteikartenHelpers[i].AntwortBitmapID + "';";

                    command = new SQLiteCommand(queryAntwort, this.connection);
                    try
                    {
                        IDataReader dataReader = command.ExecuteReader();
                        try
                        {
                            while (dataReader.Read())
                            {
                                byte[] bildDaten = (System.Byte[])dataReader["BildDaten"];
                                karteikartenHelpers[i].AntwortBitmap = new Bitmap(ByteToImage(bildDaten));
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteLogfile("GetAllKarteikarten 5: " + ex.Message);
                        }
                    } catch (Exception ex)
                    {
                        Logger.WriteLogfile("GetAllKarteikarten 6: " + ex.Message);
                    }
                }
            }

            return karteikartenHelpers;
        }

        private void createTable(string tableName, string parameterString)
        {
            try
            {
                string sql = "create table " + tableName + " (" + parameterString + ")";
                SQLiteCommand command = new SQLiteCommand(sql, this.connection);
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                Logger.WriteLogfile("createTable: " + ex.Message);
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
            catch (Exception ex)
            {
                Logger.WriteLogfile("removeTable: " + ex.Message);
            }
        }

        public SQLiteConnection Connection { get => connection; set => connection = value; }
        public List<Karteikarten> AllKarteikarten { get => allKarteikarten; set => allKarteikarten = value; }
        public List<UserSettings> AllUsersettings { get => allUserSettings; set => allUserSettings = value; }
        public List<Thema> AllThema { get => allThema; set => allThema = value; }
        public List<Klasse> AllKlasse { get => allKlasse; set => allKlasse = value; }
        public List<Intervall> AllIntervall { get => allIntervall; set => allIntervall = value; }
        public List<Frage> AllFrage { get => allFrage; set => allFrage = value; }
        public List<Fach> AllFach { get => allFach; set => allFach = value; }
        public List<Bild> AllBild { get => allBild; set => allBild = value; }
        public List<Antwort> AllAntwort { get => allAntwort; set => allAntwort = value; }

        private SQLiteConnection connection;
        private List<Karteikarten> allKarteikarten = new List<Karteikarten>();
        private List<UserSettings> allUserSettings = new List<UserSettings>();
        private List<Thema> allThema = new List<Thema>();
        private List<Klasse> allKlasse = new List<Klasse>();
        private List<Intervall> allIntervall = new List<Intervall>();
        private List<Frage> allFrage = new List<Frage>();
        private List<Fach> allFach = new List<Fach>();
        private List<Bild> allBild = new List<Bild>();
        private List<Antwort> allAntwort = new List<Antwort>();
    }
}
