using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Phedun.Classes
{
    internal static class Helper
    {
        public static string Serialize(Event worker)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true 
            };
            string jsonEvent = JsonSerializer.Serialize(worker, options).Replace("\\u0027", "'"); ;
            return jsonEvent;
        }
        public static async Task<List<Event>?> Deserialize(string path)
        {
            try
            {
                using FileStream fs = new FileStream(path, FileMode.Open);
                var events = await JsonSerializer.DeserializeAsync<List<Event>>(fs);
                return events;
            }
            catch { 
                return null;
            }
        }
    }
}
