using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class ActiveData
    {
        public static void Update(string b, string t)
        {
            b = b.ToLower();
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
        public static bool Get(string b, out string CN, out string VN)
        {
            b = b.ToLower();
            VN = null;
            CN = null;
            var result = new Dictionary<string, string>();
            string path = @"Data\Active";
            if (File.Exists(path))
            {

                var json = System.IO.File.ReadAllText(path);

                result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (result.ContainsKey(b))
                {
                    CN = (result[b]+"").Split('_').FirstOrDefault();
                    VN = (result[b]+"").Split('_').LastOrDefault();
                    if (b == "@tinchu")
                    {
                         var txtMore = ActiveData.Get("@thietLapTinChuMoreText");
                        var txtForm = ActiveData.Get("@thietLapTinChuFormText") +" "+ txtMore;

                        //VN = VN;
                        //CN = CN;
                        var dt = CsvExtentions.ConvertCSVtoDataTable(Util.getTinChuPath);

                        foreach (var item in txtForm.Split(' '))
                        {
                            var key = item.Replace("$", "@");
                            if (key.Contains("@"))
                            {
                                if (key == "@tinchu")
                                {
                                    continue;
                                }
                                if (key == "@ten")
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if ((row["Chk"] + "") == "True")
                                        {
                                            VN += " " + row[key];
                                            CN += " " + CNDictionary.getCN(row[key] + "");
                                        }
                                    }
                                }
                                else
                                {
                                    var cache = ActiveData.Get(key, out string tmpCN, out string tmpVN);
                                    CN += " " + tmpCN;
                                    VN += " " + tmpVN;
                                }
                            }
                            else
                            {
                                VN += " " + key;
                                CN += " " + CNDictionary.getCN(key);
                            }
                        }

                    }

                    return true;

                }
            }
            return false;

        }
        public static string Get(string b)
        {
            b = b.ToLower();

            var result = new Dictionary<string, string>();
            string path = @"Data\Active";
            if (File.Exists(path))
            {

                var json = System.IO.File.ReadAllText(path);

                result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (result.ContainsKey(b))
                {

                    return result[b];

                }
            }
            return null;

        }
    }
}
