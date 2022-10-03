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


                    CN = (result[b] + "").Split('_').FirstOrDefault();
                    VN = (result[b] + "").Split('_').LastOrDefault();
                    if (b == "@tinchu")
                    {
                        if (!result.ContainsKey("@thietlaptinchuformtext"))
                        {

                            ActiveData.Update("@thietlaptinchuformtext", "$ten Bản Mệnh Sinh Ư $canchi Niên Hành Canh $tuoi Tuế Sao $sao Tinh Quân");

                        }

                        var txtMore = ActiveData.Get("@thietLapTinChuMoreText");
                        var txtForm = ActiveData.Get("@thietLapTinChuFormText") + " " + txtMore;

                        //VN = VN;
                        //CN = CN;
                         var user = PersonBO.getListSoNo(Program.Stg.Chua);
                        CN = "";
                        VN = "";
                        var SelectedSoNos = ActiveData.Get("@SelectedSoNos").Split(',');
                        foreach (string it in SelectedSoNos)
                        {
                            var ID = it;

                            if (string.IsNullOrEmpty(ID))
                            {
                                continue;
                            }
                            var person = PersonBO.get(ID);

                            var text = txtForm.Replace("$", "@");

                            text = text.Replace("@canchi", person.Menh);
                            text = text.Replace("@sotuoi", person.Tuoi);
                            text = text.Replace("@tuoi", CNDictionary.getChuNomYYYY(person.Tuoi));
                            text = text.Replace("@sao", person.Sao);
                            text = text.Replace("@danh", (person.DanhXung+"").Trim());
                            text = text.Replace("@ten", (person.FullName+"").Trim());

                            VN += text;
                            CN += CNDictionary.getCN(text);




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
