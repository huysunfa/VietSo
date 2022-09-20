using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class LabelText
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }

        public static List<LabelText> GetLabelTexts(bool require = false)
        {
            List<LabelText> data = new List<LabelText>();

            if (File.Exists(Util.getDicLabelText))
            {
                data = JsonConvert.DeserializeObject<List<LabelText>>(Security.Decrypt(System.IO.File.ReadAllText(Util.getDicLabelText)));
            }
            if (data.Count == 0 || require)
            {
                var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetLabelTexts");
                data = JsonConvert.DeserializeObject<List<LabelText>>(json);
                var output = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                output = Security.Encrypt(output);
                System.IO.File.WriteAllText(Util.getDicLabelText, output);
            }

            return data;
        }
        public static string Get(string key)
        {
            var data = GetLabelTexts();

            var result = data.Where(v => v.Label.ToUpper() == key.ToUpper()).Select(v => v.Title).FirstOrDefault();
            return result;
        }
    }
}
