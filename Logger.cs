using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public class Logger
    {
        public static void WriteLogfile(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(StaticVariables.EnvironmentPath() + @"\" + StaticVariables.LogName, true)) {
                    sw.WriteLine("[" + DateTime.Now + "] " + text);
                }
            } catch { }
        }
    }
}
