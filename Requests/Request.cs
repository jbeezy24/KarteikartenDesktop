using KarteikartenDesktop.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class Request
    {
        /// <summary> Importiert !ALLE! Karteikarten mit dem angegebenen Code </summary>
        /// <param name="userSetting">Benutzereinstellung</param>
        /// <param name="allKlasse">alle Klassen</param>
        /// <param name="code">Code</param>
        public static void ImportKarteikarte(string code, DataBase database)
        {
            string jsonString = "{\"Code\": " + code + "}";
            // sendet ein "Post" an den Server
            string jsonObject = PostObject(jsonString, "/api_export.php");
            var exportObject = JsonConvert.DeserializeObject<ExportObject>(jsonObject);

            List<KarteikartenImportHelper> importHelper = new List<KarteikartenImportHelper>();
            for (int i = 0; i < exportObject.Karteikarten.Count; i++)
            {
                KarteikartenImportHelper helper = new KarteikartenImportHelper();
                helper.Thema = exportObject.Kontext.Thema;
                helper.Fach = exportObject.Kontext.Fach;
                helper.Frage = exportObject.Karteikarten[i].Frage;
                helper.Antwort = exportObject.Karteikarten[i].Antwort;

                // Bild und Antwort müssen konvertiert werden
                if (exportObject.Karteikarten[i].BildAntwort.GetType() == typeof(JArray))
                {
                    var array = exportObject.Karteikarten[i].BildAntwort as JArray;
                    int[] bitmapArray = array.Select(jv => (int)jv).ToArray();
                    byte[] bitmapByteArray = bitmapArray.Select(x => (byte)x).ToArray();
                    var bitmap = StaticVariables.ByteToImage(bitmapByteArray);
                    helper.AntwortBild = new Bitmap(bitmap);
                }
                else
                    helper.AntwortBild = null;

                if (exportObject.Karteikarten[i].BildFrage.GetType() == typeof(JArray))
                {
                    var array = exportObject.Karteikarten[i].BildFrage as JArray;
                    int[] bitmapArray = array.Select(jv => (int)jv).ToArray();
                    byte[] bitmapByteArray = bitmapArray.Select(x => (byte)x).ToArray();
                    var bitmap = StaticVariables.ByteToImage(bitmapByteArray);
                    helper.FrageBild = new Bitmap(bitmap);
                }
                else
                    helper.FrageBild = null;

                importHelper.Add(helper);
            }

            // Überprüfen ob Thema mit Name bereits vorhanden ist
            for (int i = 0; i < importHelper.Count; i++) {
                database.SetAllThema();
                var thema = database.AllThema.Where(x => x.Name.ToLower() == importHelper[i].Thema.ToLower()).FirstOrDefault();

                database.SetAllFach();
                var fach = database.AllFach.Where(x => x.Name.ToLower() == importHelper[i].Fach.ToLower()).FirstOrDefault(); 

                // wenn Fach nicht vorhanden, neu erstellen
                if (fach == null)
                {
                    database.CreateSubject(importHelper[i].Fach, database.GetUsersettings(1).KlasseID);
                    database.SetAllFach();
                    fach = database.AllFach.Where(x => x.Name.ToLower() == importHelper[i].Fach.ToLower()).FirstOrDefault();
                }

                // wenn Thema nicht vorhanden, neu erstellen
                if (thema == null)
                {
                    database.CreateTopic(importHelper[i].Thema, fach.FachID);
                    database.SetAllThema();
                    thema = database.AllThema.Where(x => x.Name.ToLower() == importHelper[i].Thema.ToLower()).FirstOrDefault();
                }

                // Überprüfen ob eine Karteikarte mit selbe Frage + Antwort existiert
                var allKarteikarten = database.GetAllKarteikarten();
                var karteikarte = allKarteikarten.Where(x => x.Frage == importHelper[i].Frage && x.Antwort == importHelper[i].Antwort).FirstOrDefault();
                
                // wenn keine Karteikarte gefunden mit selbe Frage + Antwort
                if (karteikarte == null)
                {
                    database.CreateQuestion(importHelper[i].Frage, importHelper[i].FrageBild);
                    database.CreateAnswer(importHelper[i].Antwort, importHelper[i].AntwortBild);

                    database.SetAllFrage();
                    database.SetAllAntwort();

                    var frage = database.AllFrage[database.AllFrage.Count - 1];
                    var antwort = database.AllAntwort[database.AllAntwort.Count - 1];

                    database.CreateRecordCard(thema.ThemaID, frage.FrageID, antwort.AntwortID, 1, DateTime.Now);
                }
            }
        }

        /// <summary> Exportiert !EINE! Karteikarte</summary>
        /// <param name="karteikartenHelper">Karteikartenhelper, bekommt man aus DataBase.GetAllKarteikarten()</param>
        /// <param name="userSetting">Benutzereinstellungen, !ACHTUNG! nur !EINE! Benutzereinstellung möglich, diese wird bei Initialisierung der Datenbank angelegt!!</param>
        /// <param name="AllKlasse">"DataBase.AllKlasse"</param>
        public static void ExportKarteikarte(KarteikartenHelper karteikartenHelper, UserSettings userSetting, List<Klasse> AllKlasse)
        {
            // Für den Import auf der Datenbank wird immer eine Liste benötigt, da sonst dies nicht ordentlich deserialisiert werden kann
            List<Antwort> antworts = new List<Antwort>();
            Antwort antwort = new Antwort();
            antwort.AntwortID = karteikartenHelper.AntwortID;
            antwort.BildID = karteikartenHelper.AntwortBitmapID == 0 ? null : karteikartenHelper.AntwortBitmapID;
            antwort.Text = karteikartenHelper.Antwort;
            antworts.Add(antwort);

            List<Frage> frages = new List<Frage>();
            Frage frage = new Frage();
            frage.FrageID = karteikartenHelper.FrageID;
            frage.BildID = karteikartenHelper.FrageBitmapID == 0 ? null : karteikartenHelper.FrageBitmapID;
            frage.Text = karteikartenHelper.Frage;
            frages.Add(frage);

            List<Fach> faecher = new List<Fach>();
            Fach fach = new Fach();
            fach.FachID = karteikartenHelper.FachID;
            fach.Name = karteikartenHelper.Fachname;
            faecher.Add(fach);

            List<Thema> themas = new List<Thema>();
            Thema thema = new Thema();
            thema.Name = karteikartenHelper.Thema;
            thema.ThemaID = karteikartenHelper.ThemaID;
            themas.Add(thema);

            List<Bild> bilder = new List<Bild>();
            Bild bild = new Bild();
            
            var antwortBitmap = StaticVariables.ImageToByte(karteikartenHelper.AntwortBitmap, System.Drawing.Imaging.ImageFormat.Png);
            var frageBitmap = StaticVariables.ImageToByte(karteikartenHelper.FrageBitmap, System.Drawing.Imaging.ImageFormat.Png);

            bild.BildDaten = antwortBitmap?.Select(x => (int)x).ToArray() ?? null;
            bild.BildID = karteikartenHelper.AntwortBitmapID;
            Bild bild1 = new Bild();
            bild1.BildDaten = frageBitmap?.Select(x => (int)x).ToArray() ?? null;
            bild1.BildID = karteikartenHelper.FrageBitmapID;

            bilder.Add(bild);
            bilder.Add(bild1);

            List<Karteikarten> karteikarten = new List<Karteikarten>();
            Karteikarten karteikarte = new Karteikarten();
            karteikarte.ThemaID = karteikartenHelper.ThemaID;
            karteikarte.FrageID = karteikartenHelper.FrageID;
            karteikarte.AntwortID = karteikartenHelper.AntwortID;

            karteikarten.Add(karteikarte);

            var klasseGet = AllKlasse.Where(x => x.KlasseID == userSetting.KlasseID).FirstOrDefault();

            List<Klasse> klassen = new List<Klasse>();
            Klasse klasse = new Klasse();
            klasse.KlasseID = Convert.ToInt32(klasseGet?.KlasseID);
            klasse.Name = klasseGet?.Name;
            klassen.Add(klasse);

            List<UserSettings> userSettings = new List<UserSettings>();
            userSettings.Add(userSetting);

            string json1 = JsonConvert.SerializeObject(karteikarten);
            string json2 = JsonConvert.SerializeObject(antworts);
            string json3 = JsonConvert.SerializeObject(frages);
            string json4 = JsonConvert.SerializeObject(faecher);
            string json5 = JsonConvert.SerializeObject(themas);
            string json6 = JsonConvert.SerializeObject(bilder);
            string json7 = JsonConvert.SerializeObject(klassen);
            string json8 = JsonConvert.SerializeObject(userSettings);


            string jsonString = "{\"Karteikarte\": " + json1 + "," + "\"Antwort\":" + json2 + "," + "\"Frage\":" + json3 + "," + "\"Fach\":" + json4 + "," + "\"Thema\":" + json5 + "," + "\"Bild\":" + json6 +
                "," + "\"Klasse\":" + json7 + "," + "\"Benutzer\":" + json8 + "}";

            // sendet ein "Post" an den Server
            PostObject(jsonString, "/api_import.php");
        }

        /// <summary> Postet ein angegebenen string an den angegebenen Endpunkt an den Server</summary>
        /// <param name="jsonString">zu postender JSON-String</param>
        /// <param name="endpoint">Endpunkt (Name der PHP Datei)</param>
        public static string PostObject(string jsonString, string endpoint)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://" + StaticVariables.ServerIP_Port + endpoint);
            webRequest.Accept = "application/json";
            webRequest.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = WebRequestMethods.Http.Post;

            try
            {
                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonString);
                }
            } catch (Exception ex) {
                Logger.WriteLogfile("PostObject Request: " + ex.Message);            
            }
                
            var response = webRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            responseStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
