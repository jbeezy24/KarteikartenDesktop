using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KarteikartenDesktop
{
    public static class StaticVariables
    {
        public static string ServerIP_Port = "89.163.227.54:83";

        public static string EnvironmentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string LogName = "log.txt";

        /// <summary> Konvertiert ein angegebenes Bild in ein Byte-Array um </summary>
        /// <param name="image">Bild</param>
        /// <param name="format">Format des Bildes</param>
        /// <returns>Byte Array</returns>
        public static byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            if (image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(memoryStream, format);
                    byte[] imageBytes = memoryStream.ToArray();
                    return imageBytes;
                }
            }

            return null;
        }

        /// <summary> Erstellt aus einem Byte-Array ein Bild</summary>
        /// <param name="imageBytes">Byte-Array</param>
        /// <returns>Bild</returns>
        public static Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(memoryStream);
            return image;
        }
    }
}
