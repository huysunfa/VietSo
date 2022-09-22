using AppVietSo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo
{
    public class CNDictionary
    {
        public static Dictionary<string, string> database;
        public static DataTable databaseNguCanh;
        public static void loadDatabase()
        {
            if (File.Exists(Util.getDictionaryPath))
            {
                database = JsonConvert.DeserializeObject<Dictionary<string, string>>(Security.Decrypt(System.IO.File.ReadAllText(Util.getDictionaryPath)));
                databaseNguCanh = JsonConvert.DeserializeObject<DataTable>(Security.Decrypt(System.IO.File.ReadAllText(Util.getDictionaryNguCanhPath)));
            }
            if (database == null)
            {
                #region database
                database = new Dictionary<string, string>();
                var json = getDataFromUrl(Util.mainURL + "/AppSync/GetDictionary");

                var data = JsonConvert.DeserializeObject<DataTable>(json);

                foreach (DataRow item in data.Rows)
                {
                    database.Add((item["vn"] + "").ToLower(), item["chinese"] + "");
                }
                var output = Newtonsoft.Json.JsonConvert.SerializeObject(database);
                output = Security.Encrypt(output);
                System.IO.File.WriteAllText(Util.getDictionaryPath, output);
                #endregion

                #region databaseNguCanh
                databaseNguCanh = JsonConvert.DeserializeObject<DataTable>(getDataFromUrl(Util.mainURL + "/AppSync/GetDictionaryNguCanh"));
                System.IO.File.WriteAllText(Util.getDictionaryNguCanhPath, Security.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(databaseNguCanh)));
                #endregion
            }


        }
        public static string getDataFromUrl(string inputURL)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var result = webClient.DownloadData(inputURL);
                var htmlCode = Encoding.UTF8.GetString(result);
                return htmlCode;

            }
        }
        public static string getCN(string vn)
        {
            if (string.IsNullOrEmpty(vn))
            {
                return vn;
            }

            var result = "";
            var newkey = vn.Replace(" ", "").Trim().ToLower();

            if (database.ContainsKey(newkey))
            {

                result = result + " " + database[newkey];
            }
            else
            {


                foreach (var item in vn.Split(' '))
                {
                    var key = item.ToLower();
                    if (string.IsNullOrEmpty(key))
                    {
                        continue;
                    }
                    if (database.ContainsKey(key))
                    {

                        result = result + " " + database[key];
                    }
                }
            }
            if (result == "")
            {
                result = vn;
            }

            return result;
        }
        public static string getVN(string cn)
        {
            if (string.IsNullOrEmpty(cn))
            {
                return cn;
            }

            var result = "";
            foreach (var item in cn.Split(' '))
            {
                var key = item;
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }
                if (database.ContainsValue(key))
                {
                    result = result + " " + database.Where(v => v.Value == key).Select(z => z.Key).FirstOrDefault();
                }
            }
            if (result == "")
            {
                result = cn;
            }

            return result.Trim();
        }

        public static string getChuNomDD(string A_0)
        {
            uint num = 0;
            if (A_0 != null)
            {
                num = 0x811C9DC5U;
                for (int i = 0; i < A_0.Length; i++)
                {
                    num = ((uint)A_0[i] ^ num) * 0x1000193U;
                }
            }
            if (num > 0x340CA71CU)
            {
                if (num <= 0x89F29333U)
                {
                    if (num <= 0x3C0CB3B4U)
                    {
                        if (num != 0x360CAA42U)
                        {
                            if (num != 0x370CABD5U)
                            {
                                if (num == 0x3C0CB3B4U)
                                {
                                    if (A_0 == "9")
                                    {
                                        return "SƠ CỬU";
                                    }
                                }
                            }

                            else if (A_0 == "2")
                            {
                                return "SƠ NHỊ";
                            }
                        }

                        else if (A_0 == "3")
                        {
                            return "SƠ TAM";
                        }
                    }

                    else if (num > 0x87F05176U)
                    {
                        if (num == 0x88F291A0U)
                        {
                            if (A_0 == "25")
                            {
                                return "NHỊ THẬP NGŨ";
                            }
                        }
                        else if (num == 0x89F29333U && A_0 == "24")
                        {
                            return "NHỊ THẬP TỨ";
                        }
                    }
                    else if (num != 0x3D0CB547U)
                    {
                        if (num == 0x87F05176U && A_0 == "30")
                        {
                            return "TAM THẬP";
                        }
                    }
                    else if (A_0 == "8")
                    {
                        return "SƠ BÁT";
                    }
                }

                else if (num <= 0x8DF2997FU)
                {
                    if (num > 0x8BF29659U)
                    {
                        if (num != 0x8CF297ECU)
                        {
                            if (num == 0x8DF2997FU)
                            {
                                if (A_0 == "20")
                                {
                                    return "NHỊ THẬP";
                                }
                            }
                        }
                        else if (A_0 == "21")
                        {
                            return "NHỊ THẬP NHẤT";
                        }
                    }
                    else if (num != 0x8AF294C6U)
                    {
                        if (num == 0x8BF29659U)
                        {
                            if (A_0 == "26")
                            {
                                return "NHỊ THẬP LỤC";
                            }
                        }
                    }
                    else if (A_0 == "27")
                    {
                        return "NHỊ THẬP THẤT";
                    }
                }
                else if (num <= 0x8FF29CA5U)
                {
                    if (num == 0x8EF29B12U)
                    {
                        if (A_0 == "23")
                        {
                            return "NHỊ THẬP TAM";
                        }
                    }
                    else if (num == 0x8FF29CA5U)
                    {
                        if (A_0 == "22")
                        {
                            return "NHỊ THẬP NHỊ";
                        }
                    }
                }
                else if (num != 0x94F2A484U)
                {
                    if (num == 0x95F2A617U)
                    {
                        if (A_0 == "28")
                        {
                            return "NHỊ THẬP BÁT";
                        }
                    }
                }
                else if (A_0 == "29")
                {
                    return "NHỊ THẬP CỬU";
                }
            }

            else if (num > 0x1BEB2A44U)
            {
                if (num > 0x300CA0D0U)
                {
                    if (num > 0x320CA3F6U)
                    {
                        if (num != 0x330CA589U)
                        {
                            if (num == 0x340CA71CU && A_0 == "1")
                            {
                                return "SƠ NHẤT";
                            }
                        }
                        else if (A_0 == "6")
                        {
                            return "SƠ LỤC";
                        }
                    }
                    else if (num == 0x310CA263U)
                    {
                        if (A_0 == "4")
                        {
                            return "SƠ TỨ";
                        }
                    }
                    else if (num == 0x320CA3F6U)
                    {
                        if (A_0 == "7")
                        {
                            return "SƠ THẤT";
                        }
                    }
                }
                else if (num <= 0x1DEB2D6AU)
                {
                    if (num == 0x1CEB2BD7U)
                    {
                        if (A_0 == "11")
                        {
                            return "THẬP NHẤT";
                        }
                    }
                    else if (num == 0x1DEB2D6AU)
                    {
                        if (A_0 == "12")
                        {
                            return "THẬP NHỊ";
                        }
                    }
                }
                else if (num != 0x1EEB2EFDU)
                {
                    if (num == 0x300CA0D0U && A_0 == "5")
                    {
                        return "SƠ NGŨ";
                    }
                }
                else if (A_0 == "13")
                {
                    return "THẬP TAM";
                }
            }
            else if (num > 0x17EB23F8U)
            {
                if (num > 0x19EB271EU)
                {
                    if (num != 0x1AEB28B1U)
                    {
                        if (num == 0x1BEB2A44U && A_0 == "10")
                        {
                            return "SƠ THẬP";
                        }
                    }
                    else if (A_0 == "17")
                    {
                        return "THẬP THẤT";
                    }
                }
                else if (num != 0x18EB258BU)
                {
                    if (num == 0x19EB271EU)
                    {
                        if (A_0 == "16")
                        {
                            return "THẬP LỤC";
                        }
                    }
                }
                else if (A_0 == "15")
                {
                    return "THẬP NGŨ";
                }
            }
            else if (num != 0x13EB1DACU)
            {
                if (num == 0x14EB1F3FU)
                {
                    if (A_0 == "19")
                    {
                        return "THẬP CỬU";
                    }
                }
                else if (num == 0x17EB23F8U && A_0 == "14")
                {
                    return "THẬP TỨ";
                }
            }
            else if (A_0 == "18")
            {
                return "THẬP BÁT";
            }
            return A_0;
        }

        // Token: 0x060001CB RID: 459 RVA: 0x00009484 File Offset: 0x00007684
        public static string getChuNomMM(string A_0)
        {
            uint num = 0;
            if (A_0 != null)
            {
                num = 0x811C9DC5U;
                for (int i = 0; i < A_0.Length; i++)
                {
                    num = ((uint)A_0[i] ^ num) * 0x1000193U;
                }
            }
            if (num <= 0x320CA3F6U)
            {
                if (num > 0x1DEB2D6AU)
                {
                    if (num == 0x300CA0D0U)
                    {
                        if (A_0 == "5")
                        {
                            return "NGŨ";
                        }
                    }
                    else if (num != 0x310CA263U)
                    {
                        if (num == 0x320CA3F6U && A_0 == "7")
                        {
                            return "THẤT";
                        }
                    }

                    else if (A_0 == "4")
                    {
                        return "TỨ";
                    }
                }

                else if (num == 0x1BEB2A44U)
                {
                    if (A_0 == "10")
                    {
                        return "THẬP";
                    }
                }
                else if (num != 0x1CEB2BD7U)
                {
                    if (num == 0x1DEB2D6AU)
                    {
                        if (A_0 == "12")
                        {
                            return "THẬP NHỊ";
                        }
                    }
                }
                else if (A_0 == "11")
                {
                    return "THẬP NHẤT";
                }
            }

            else if (num <= 0x360CAA42U)
            {
                if (num == 0x330CA589U)
                {
                    if (A_0 == "6")
                    {
                        return "LỤC";
                    }
                }
                else if (num == 0x340CA71CU)
                {
                    if (A_0 == "1")
                    {
                        return "CHÍNH";
                    }
                }
                else if (num == 0x360CAA42U && A_0 == "3")
                {
                    return "TAM";
                }
            }
            else if (num == 0x370CABD5U)
            {
                if (A_0 == "2")
                {
                    return "NHỊ";
                }
            }
            else if (num == 0x3C0CB3B4U)
            {
                if (A_0 == "9")
                {
                    return "CỬU";
                }
            }
            else if (num == 0x3D0CB547U)
            {
                if (A_0 == "8")
                {
                    return "BÁT";
                }
            }
            return A_0;
        }
        public static string getChuNomYYYY(string A_0)
        {
            uint num = 0;
            if (A_0 != null)
            {
                num = 0x811C9DC5U;
                for (int i = 0; i < A_0.Length; i++)
                {
                    num = ((uint)A_0[i] ^ num) * 0x1000193U;
                }
            }
            if (num <= 0x86E14559U)
            {
                if (num > 0x1BEB2A44U)
                {
                    if (num > 0x6433CFE3U)
                    {
                        if (num > 0x6D361CA5U)
                        {
                            if (num <= 0x83E140A0U)
                            {
                                if (num != 0x6F33E134U)
                                {
                                    if (num != 0x7033E2C7U)
                                    {
                                        if (num == 0x83E140A0U)
                                        {
                                            if (A_0 == "50")
                                            {
                                                return "NGŨ THẬP";
                                            }
                                        }
                                    }
                                    else if (A_0 == "109")
                                    {
                                        return "NHẤT BÁCH CỬU";
                                    }
                                }
                                else if (A_0 == "108")
                                {
                                    return "NHẤT BÁCH BÁT";
                                }
                            }
                            else if (num > 0x85E143C6U)
                            {
                                if (num != 0x85F04E50U)
                                {
                                    if (num == 0x86E14559U)
                                    {
                                        if (A_0 == "53")
                                        {
                                            return "NGŨ THẬP TAM";
                                        }
                                    }
                                }
                                else if (A_0 == "32")
                                {
                                    return "TAM THẬP NHỊ";
                                }
                            }
                            else if (num == 0x84E14233U)
                            {
                                if (A_0 == "51")
                                {
                                    return "NGŨ THẬP NHẤT";
                                }
                            }
                            else if (num == 0x85E143C6U)
                            {
                                if (A_0 == "52")
                                {
                                    return "NGŨ THẬP NHỊ";
                                }
                            }
                        }
                        else if (num > 0x6733D49CU)
                        {
                            if (num <= 0x6933D7C2U)
                            {
                                if (num == 0x6833D62FU)
                                {
                                    if (A_0 == "101")
                                    {
                                        return "NHẤT BÁCH NHẤT";
                                    }
                                }
                                else if (num == 0x6933D7C2U && A_0 == "102")
                                {
                                    return "NHẤT BÁCH NHỊ";
                                }
                            }
                            else if (num == 0x6A33D955U)
                            {
                                if (A_0 == "103")
                                {
                                    return "NHẤT BÁCH TAM";
                                }
                            }
                            else if (num == 0x6D361CA5U && A_0 == "110")
                            {
                                return "NHẤT BÁCH THẬP";
                            }
                        }
                        else if (num != 0x6533D176U)
                        {
                            if (num != 0x6633D309U)
                            {
                                if (num == 0x6733D49CU && A_0 == "100")
                                {
                                    return "NHẤT BÁCH";
                                }
                            }
                            else if (A_0 == "107")
                            {
                                return "NHẤT BÁCH THẤT";
                            }
                        }
                        else if (A_0 == "106")
                        {
                            return "NHẤT BÁCH LỤC";
                        }
                    }
                    else if (num > 0x330CA589U)
                    {
                        if (num > 0x370CABD5U)
                        {
                            if (num <= 0x3D0CB547U)
                            {
                                if (num != 0x3C0CB3B4U)
                                {
                                    if (num == 0x3D0CB547U)
                                    {
                                        if (A_0 == "8")
                                        {
                                            return "BÁT";
                                        }
                                    }
                                }
                                else if (A_0 == "9")
                                {
                                    return "CỬU";
                                }
                            }
                            else if (num == 0x6333CE50U)
                            {
                                if (A_0 == "104")
                                {
                                    return "NHẤT BÁCH TỨ";
                                }
                            }
                            else if (num == 0x6433CFE3U)
                            {
                                if (A_0 == "105")
                                {
                                    return "NHẤT BÁCH NGŨ";
                                }
                            }
                        }
                        else if (num == 0x340CA71CU)
                        {
                            if (A_0 == "1")
                            {
                                return "NHẤT";
                            }
                        }
                        else if (num != 0x360CAA42U)
                        {
                            if (num == 0x370CABD5U && A_0 == "2")
                            {
                                return "NHỊ";
                            }
                        }
                        else if (A_0 == "3")
                        {
                            return "TAM";
                        }
                    }
                    else if (num <= 0x1EEB2EFDU)
                    {
                        if (num != 0x1CEB2BD7U)
                        {
                            if (num != 0x1DEB2D6AU)
                            {
                                if (num == 0x1EEB2EFDU && A_0 == "13")
                                {
                                    return "THẬP TAM";
                                }
                            }
                            else if (A_0 == "12")
                            {
                                return "THẬP NHỊ";
                            }
                        }
                        else if (A_0 == "11")
                        {
                            return "THẬP NHẤT";
                        }
                    }
                    else if (num <= 0x310CA263U)
                    {
                        if (num == 0x300CA0D0U)
                        {
                            if (A_0 == "5")
                            {
                                return "NGŨ";
                            }
                        }
                        else if (num == 0x310CA263U)
                        {
                            if (A_0 == "4")
                            {
                                return "TỨ";
                            }
                        }
                    }
                    else if (num != 0x320CA3F6U)
                    {
                        if (num == 0x330CA589U && A_0 == "6")
                        {
                            return "LỤC";
                        }
                    }
                    else if (A_0 == "7")
                    {
                        return "THẤT";
                    }
                }
                else if (num > 0x14E8E0A8U)
                {
                    if (num <= 0x18E8E6F4U)
                    {
                        if (num <= 0x15E8E23BU)
                        {
                            if (num != 0x14EB1F3FU)
                            {
                                if (num != 0x14FEA6F7U)
                                {
                                    if (num == 0x15E8E23BU)
                                    {
                                        if (A_0 == "60")
                                        {
                                            return "LỤC THẬP";
                                        }
                                    }
                                }
                                else if (A_0 == "99")
                                {
                                    return "CỬU THẬP CỬU";
                                }
                            }
                            else if (A_0 == "19")
                            {
                                return "THẬP CỬU";
                            }
                        }
                        else if (num <= 0x17E8E561U)
                        {
                            if (num != 0x16E8E3CEU)
                            {
                                if (num == 0x17E8E561U)
                                {
                                    if (A_0 == "62")
                                    {
                                        return "LỤC THẬP NHỊ";
                                    }
                                }
                            }
                            else if (A_0 == "63")
                            {
                                return "LỤC THẬP TAM";
                            }
                        }
                        else if (num != 0x17EB23F8U)
                        {
                            if (num == 0x18E8E6F4U)
                            {
                                if (A_0 == "65")
                                {
                                    return "LỤC THẬP NGŨ";
                                }
                            }
                        }
                        else if (A_0 == "14")
                        {
                            return "THẬP TỨ";
                        }
                    }
                    else if (num <= 0x19EB271EU)
                    {
                        if (num != 0x18EB258BU)
                        {
                            if (num == 0x19E8E887U)
                            {
                                if (A_0 == "64")
                                {
                                    return "LỤC THẬP TỨ";
                                }
                            }
                            else if (num == 0x19EB271EU && A_0 == "16")
                            {
                                return "THẬP LỤC";
                            }
                        }
                        else if (A_0 == "15")
                        {
                            return "THẬP NGŨ";
                        }
                    }
                    else if (num > 0x1AEB28B1U)
                    {
                        if (num != 0x1BE8EBADU)
                        {
                            if (num == 0x1BEB2A44U)
                            {
                                if (A_0 == "10")
                                {
                                    return "THẬP";
                                }
                            }
                        }
                        else if (A_0 == "66")
                        {
                            return "LỤC THẬP LỤC";
                        }
                    }
                    else if (num != 0x1AE8EA1AU)
                    {
                        if (num == 0x1AEB28B1U && A_0 == "17")
                        {
                            return "THẬP THẤT";
                        }
                    }
                    else if (A_0 == "67")
                    {
                        return "LỤC THẬP THẤT";
                    }
                }
                else if (num <= 0xCE8D410U)
                {
                    if (num > 0x9FE95A6U)
                    {
                        if (num == 0xAFE9739U)
                        {
                            if (A_0 == "97")
                            {
                                return "CỬU THẬP THẤT";
                            }
                        }
                        else if (num == 0xBFE98CCU)
                        {
                            if (A_0 == "90")
                            {
                                return "CỬU THẬP";
                            }
                        }
                        else if (num == 0xCE8D410U && A_0 == "69")
                        {
                            return "LỤC THẬP CỬU";
                        }
                    }
                    else if (num == 0x7FE9280U)
                    {
                        if (A_0 == "94")
                        {
                            return "CỬU THẬP TỨ";
                        }
                    }
                    else if (num != 0x8FE9413U)
                    {
                        if (num == 0x9FE95A6U && A_0 == "96")
                        {
                            return "CỬU THẬP LỤC";
                        }
                    }
                    else if (A_0 == "95")
                    {
                        return "CỬU THẬP NGŨ";
                    }
                }
                else if (num <= 0xDFE9BF2U)
                {
                    if (num != 0xCFE9A5FU)
                    {
                        if (num != 0xDE8D5A3U)
                        {
                            if (num == 0xDFE9BF2U && A_0 == "92")
                            {
                                return "CỬU THẬP NHỊ";
                            }
                        }
                        else if (A_0 == "68")
                        {
                            return "LỤC THẬP BÁT";
                        }
                    }
                    else if (A_0 == "91")
                    {
                        return "CỬU THẬP NHẤT";
                    }
                }
                else if (num <= 0x13EB1DACU)
                {
                    if (num == 0xEFE9D85U)
                    {
                        if (A_0 == "93")
                        {
                            return "CỬU THẬP TAM";
                        }
                    }
                    else if (num == 0x13EB1DACU)
                    {
                        if (A_0 == "18")
                        {
                            return "THẬP BÁT";
                        }
                    }
                }
                else if (num == 0x13FEA564U)
                {
                    if (A_0 == "98")
                    {
                        return "CỬU THẬP BÁT";
                    }
                }
                else if (num == 0x14E8E0A8U && A_0 == "61")
                {
                    return "LỤC THẬP NHẤT";
                }
            }
            else if (num > 0x8CE14ECBU)
            {
                if (num > 0x8FF05E0EU)
                {
                    if (num > 0x91E39541U)
                    {
                        if (num > 0x95F2A617U)
                        {
                            if (num <= 0x98E5DEDDU)
                            {
                                if (num == 0x97E5DD4AU)
                                {
                                    if (A_0 == "78")
                                    {
                                        return "THẤT THẬP BÁT";
                                    }
                                }
                                else if (num == 0x98E5DEDDU)
                                {
                                    if (A_0 == "79")
                                    {
                                        return "THẤT THẬP CỬU";
                                    }
                                }
                            }
                            else if (num == 0x9901B55AU)
                            {
                                if (A_0 == "89")
                                {
                                    return "BÁT THẬP CỬU";
                                }
                            }
                            else if (num == 0x9A01B6EDU && A_0 == "88")
                            {
                                return "BÁT THẬP BÁT";
                            }
                        }
                        else if (num == 0x9201AA55U)
                        {
                            if (A_0 == "80")
                            {
                                return "BÁT THẬP";
                            }
                        }
                        else if (num == 0x94F2A484U)
                        {
                            if (A_0 == "29")
                            {
                                return "NHỊ THẬP CỬU";
                            }
                        }
                        else if (num == 0x95F2A617U)
                        {
                            if (A_0 == "28")
                            {
                                return "NHỊ THẬP BÁT";
                            }
                        }
                    }
                    else if (num <= 0x90E393AEU)
                    {
                        if (num == 0x8FF29CA5U)
                        {
                            if (A_0 == "22")
                            {
                                return "NHỊ THẬP NHỊ";
                            }
                        }
                        else if (num == 0x9001A72FU)
                        {
                            if (A_0 == "82")
                            {
                                return "BÁT THẬP NHỊ";
                            }
                        }
                        else if (num == 0x90E393AEU)
                        {
                            if (A_0 == "49")
                            {
                                return "TỨ THẬP CỬU";
                            }
                        }
                    }
                    else if (num > 0x90F05FA1U)
                    {
                        if (num != 0x9101A8C2U)
                        {
                            if (num == 0x91E39541U && A_0 == "48")
                            {
                                return "TỨ THẬP BÁT";
                            }
                        }
                        else if (A_0 == "81")
                        {
                            return "BÁT THẬP NHẤT";
                        }
                    }
                    else if (num != 0x90E5D245U)
                    {
                        if (num == 0x90F05FA1U)
                        {
                            if (A_0 == "39")
                            {
                                return "TAM THẬP CỬU";
                            }
                        }
                    }
                    else if (A_0 == "71")
                    {
                        return "THẤT THẬP NHẤT";
                    }
                }
                else if (num <= 0x8DE5CD8CU)
                {
                    if (num <= 0x8CF05955U)
                    {
                        if (num == 0x8CE38D62U)
                        {
                            if (A_0 == "45")
                            {
                                return "TỨ THẬP NGŨ";
                            }
                        }
                        else if (num == 0x8CE5CBF9U)
                        {
                            if (A_0 == "75")
                            {
                                return "THẤT THẬP NGŨ";
                            }
                        }
                        else if (num == 0x8CF05955U && A_0 == "35")
                        {
                            return "TAM THẬP NGŨ";
                        }
                    }
                    else if (num > 0x8D01A276U)
                    {
                        if (num != 0x8DE38EF5U)
                        {
                            if (num == 0x8DE5CD8CU)
                            {
                                if (A_0 == "72")
                                {
                                    return "THẤT THẬP NHỊ";
                                }
                            }
                        }
                        else if (A_0 == "44")
                        {
                            return "TỨ THẬP TỨ";
                        }
                    }
                    else if (num == 0x8CF297ECU)
                    {
                        if (A_0 == "21")
                        {
                            return "NHỊ THẬP NHẤT";
                        }
                    }
                    else if (num == 0x8D01A276U)
                    {
                        if (A_0 == "85")
                        {
                            return "BÁT THẬP NGŨ";
                        }
                    }
                }
                else if (num > 0x8EE5CF1FU)
                {
                    if (num > 0x8F01A59CU)
                    {
                        if (num != 0x8FE5D0B2U)
                        {
                            if (num == 0x8FF05E0EU)
                            {
                                if (A_0 == "38")
                                {
                                    return "TAM THẬP BÁT";
                                }
                            }
                        }
                        else if (A_0 == "70")
                        {
                            return "THẤT THẬP";
                        }
                    }
                    else if (num == 0x8EF29B12U)
                    {
                        if (A_0 == "23")
                        {
                            return "NHỊ THẬP TAM";
                        }
                    }
                    else if (num == 0x8F01A59CU)
                    {
                        if (A_0 == "83")
                        {
                            return "BÁT THẬP TAM";
                        }
                    }
                }
                else if (num != 0x8DF2997FU)
                {
                    if (num != 0x8E01A409U)
                    {
                        if (num == 0x8EE5CF1FU && A_0 == "73")
                        {
                            return "THẤT THẬP TAM";
                        }
                    }
                    else if (A_0 == "84")
                    {
                        return "BÁT THẬP TỨ";
                    }
                }
                else if (A_0 == "20")
                {
                    return "NHỊ THẬP";
                }
            }
            else if (num > 0x89F0549CU)
            {
                if (num > 0x8B019F50U)
                {
                    if (num > 0x8BE5CA66U)
                    {
                        if (num > 0x8BF29659U)
                        {
                            if (num == 0x8C01A0E3U)
                            {
                                if (A_0 == "86")
                                {
                                    return "BÁT THẬP LỤC";
                                }
                            }
                            else if (num == 0x8CE14ECBU && A_0 == "59")
                            {
                                return "NGŨ THẬP CỬU";
                            }
                        }
                        else if (num == 0x8BF057C2U)
                        {
                            if (A_0 == "34")
                            {
                                return "TAM THẬP TỨ";
                            }
                        }
                        else if (num == 0x8BF29659U)
                        {
                            if (A_0 == "26")
                            {
                                return "NHỊ THẬP LỤC";
                            }
                        }
                    }
                    else if (num != 0x8BE14D38U)
                    {
                        if (num != 0x8BE38BCFU)
                        {
                            if (num == 0x8BE5CA66U)
                            {
                                if (A_0 == "74")
                                {
                                    return "THẤT THẬP TỨ";
                                }
                            }
                        }
                        else if (A_0 == "46")
                        {
                            return "TỨ THẬP LỤC";
                        }
                    }
                    else if (A_0 == "58")
                    {
                        return "NGŨ THẬP BÁT";
                    }
                }
                else if (num <= 0x8AE38A3CU)
                {
                    if (num == 0x89F29333U)
                    {
                        if (A_0 == "24")
                        {
                            return "NHỊ THẬP TỨ";
                        }
                    }
                    else if (num == 0x8AE14BA5U)
                    {
                        if (A_0 == "57")
                        {
                            return "NGŨ THẬP THẤT";
                        }
                    }
                    else if (num == 0x8AE38A3CU)
                    {
                        if (A_0 == "47")
                        {
                            return "TỨ THẬP THẤT";
                        }
                    }
                }
                else if (num <= 0x8AF0562FU)
                {
                    if (num != 0x8AE5C8D3U)
                    {
                        if (num == 0x8AF0562FU && A_0 == "37")
                        {
                            return "TAM THẬP THẤT";
                        }
                    }
                    else if (A_0 == "77")
                    {
                        return "THẤT THẬP THẤT";
                    }
                }
                else if (num == 0x8AF294C6U)
                {
                    if (A_0 == "27")
                    {
                        return "NHỊ THẬP THẤT";
                    }
                }
                else if (num == 0x8B019F50U && A_0 == "87")
                {
                    return "BÁT THẬP THẤT";
                }
            }
            else if (num <= 0x88E1487FU)
            {
                if (num <= 0x87E146ECU)
                {
                    if (num != 0x86E383F0U)
                    {
                        if (num == 0x86F04FE3U)
                        {
                            if (A_0 == "33")
                            {
                                return "TAM THẬP TAM";
                            }
                        }
                        else if (num == 0x87E146ECU)
                        {
                            if (A_0 == "54")
                            {
                                return "NGŨ THẬP TỨ";
                            }
                        }
                    }
                    else if (A_0 == "43")
                    {
                        return "TỨ THẬP TAM";
                    }
                }
                else if (num != 0x87E38583U)
                {
                    if (num != 0x87F05176U)
                    {
                        if (num == 0x88E1487FU && A_0 == "55")
                        {
                            return "NGŨ THẬP NGŨ";
                        }
                    }
                    else if (A_0 == "30")
                    {
                        return "TAM THẬP";
                    }
                }
                else if (A_0 == "42")
                {
                    return "TỨ THẬP NHỊ";
                }
            }
            else if (num <= 0x88F291A0U)
            {
                if (num == 0x88E38716U)
                {
                    if (A_0 == "41")
                    {
                        return "TỨ THẬP NHẤT";
                    }
                }
                else if (num != 0x88F05309U)
                {
                    if (num == 0x88F291A0U)
                    {
                        if (A_0 == "25")
                        {
                            return "NHỊ THẬP NGŨ";
                        }
                    }
                }
                else if (A_0 == "31")
                {
                    return "TAM THẬP NHẤT";
                }
            }
            else if (num > 0x89E388A9U)
            {
                if (num == 0x89E5C740U)
                {
                    if (A_0 == "76")
                    {
                        return "THẤT THẬP LỤC";
                    }
                }
                else if (num == 0x89F0549CU)
                {
                    if (A_0 == "36")
                    {
                        return "TAM THẬP LỤC";
                    }
                }
            }
            else if (num == 0x89E14A12U)
            {
                if (A_0 == "56")
                {
                    return "NGŨ THẬP LỤC";
                }
            }
            else if (num == 0x89E388A9U)
            {
                if (A_0 == "40")
                {
                    return "TỨ THẬP";
                }
            }
            return A_0;
        }



    }
}
