using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursorEventHandler
{
    public class ReadJson
    {
        public string Filename { get; set; }
        private static JObject JsonObject { get; set; }

        public ReadJson()
        {
            Filename = "values.json";
            JsonObject = JObject.Parse(File.ReadAllText("values.json"));
        }

        public string GetValueIf(string key)
        {
            return JsonObject.SelectToken("if." + key).Value<string>();
        }

        public string GetValueElse(string key)
        {
            return JsonObject.SelectToken("else." + key).Value<string>();
        }
    }
}