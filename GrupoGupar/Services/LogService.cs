using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoGupar.Services
{
    public class LogService
    {
        public static void Save(object obj, Exception ex)
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string hora = DateTime.Now.ToString("HH:mm:ss");

            string filePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dirLog = Path.Combine(Path.GetDirectoryName(filePath), "Log");
            if (!Directory.Exists(dirLog))
            {
                Directory.CreateDirectory(dirLog);
            }

            string path = Path.Combine(Path.GetDirectoryName(filePath), "Log", fecha + ".txt");

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
            sw.WriteLine(string.Empty);

            sw.Flush();
            sw.Close();
        }
    }
}
