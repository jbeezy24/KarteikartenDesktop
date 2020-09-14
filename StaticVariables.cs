using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarteikartenDesktop
{
    public static class StaticVariables
    {
        public static string EnvironmentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
