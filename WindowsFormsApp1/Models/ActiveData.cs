using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class ActiveData
    {
        public static void Update(string b, string t)
        {
            var result = new Dictionary<string, string>();
            string path = @"Data\Active";
            if (!File.Exists(path))
            {
                string jsonString = JsonConvert.SerializeObject(result);

                File.WriteAllText(path, jsonString);
            }
            var json = System.IO.File.ReadAllText(path);

            result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            if (!result.ContainsKey(b))
            {
                result.Add(b, t);
            }
            result[b] = t;
            string jsonOut = JsonConvert.SerializeObject(result);
            File.WriteAllText(path, jsonOut);
        }
        public static string Get(string b)
        {
            var result = new Dictionary<string, string>();
            string path = @"Data\Active";
            if (!File.Exists(path))
            {
                return null;
            }
            var json = System.IO.File.ReadAllText(path);

            result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            if (result.ContainsKey(b))
            {
                return result[b];

            }
            return null;


        }
    }
}
