﻿using KarteikartenDesktop.Database;
using Newtonsoft.Json;
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


            string jsonString = "[{\"Karteikarte\": " + json1 + "," + "\"Antwort\":" + json2 + "," + "\"Frage\":" + json3 + "," + "\"Fach\":" + json4 + "," + "\"Thema\":" + json5 + "," + "\"Bild\":" + json6 +
                "," + "\"Klasse\":" + json7 + "," + "\"Benutzer\":" + json8 + "}]";

            // sendet ein "Post" an den Server
            PostObject(jsonString, "/api_import.php");
        }

        /// <summary> Postet ein angegebenen string an den angegebenen Endpunkt an den Server</summary>
        /// <param name="jsonString">zu postender JSON-String</param>
        /// <param name="endpoint">Endpunkt (Name der PHP Datei)</param>
        public static void PostObject(string jsonString, string endpoint)
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
            } catch (Exception ex) { }

            var response = webRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            responseStream.Close();
            response.Close();
        }
    }
}