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

        public static void UpdateDataByID()
        {
            var user = ActiveData.Get("@SelectedSoNos").Split(',').Where(v=>!string.IsNullOrEmpty(v)).FirstOrDefault();
            if (user == null)
            {
                return;
            }
            var chua = Models.PagodaBO.get(ActiveData.Get("@chua"));

            ActiveData.Update("@noicung", CNDictionary.getCN(chua.Name)+"_"+ chua.Name);
            int.TryParse(Program.Stg.Chua, out int NumChua);

          
           

            var gc = PersonBO.get(user);
            ActiveData.Update("@chua", Program.Stg.Chua);
                ActiveData.Update("@giachu", gc.FullName);
            ActiveData.Update("@tinchu", gc.FullName);
            var Address = gc.Address.Trim() == "" ? chua.Address : gc.Address;
            Address = (Address + "").Replace(","," ");
            Address = (Address + "").Replace("-"," ");
            Address = (Address + "").Replace(":"," ");
            Address = (Address + "").Replace("."," ");
            ActiveData.Update("@diachiyvu", CNDictionary.getCN(Address)+"_"+ Address);
            ActiveData.Update("@canchi", CNDictionary.getCN(gc.Menh) + "_" + gc.Menh);
            ActiveData.Update("@sotuoi", gc.Tuoi);
            ActiveData.Update("@tuoi", CNDictionary.getCN(CNDictionary.getChuNomYYYY(gc.Tuoi)) + "_" + CNDictionary.getChuNomYYYY(gc.Tuoi));

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

                            ActiveData.Update("@thietlaptinchuformtext", "$ten Bản Mệnh Sinh Ư $canchi Niên Hành Canh $tuoi Tuế");

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
                            if (!string.IsNullOrEmpty(person.NgayMat))
                            {
                                continue;
                            }
                            var text = txtForm.Replace("$", "@");

                             text = text.Replace("@canchi", person.Menh);
                            text = text.Replace("@sotuoi", person.Tuoi);
                            text = text.Replace("@tuoi", CNDictionary.getChuNomYYYY(person.Tuoi));
                            text = text.Replace("@sao", person.Sao);
                            text = text.Replace("@danh", (person.DanhXung + "").Trim());
                            text = text.Replace("@ten", (person.FullName + "").Trim());

                            VN += text+" ";
                            CN += CNDictionary.getCN(text) + " ";




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
        
        public static Dictionary<string, string> GetAll()
        {
 
            var result = new Dictionary<string, string>();
            string path = @"Data\Active";
            if (File.Exists(path))
            {

                var json = System.IO.File.ReadAllText(path);

                result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            }
            return result;
        }
    }
}
