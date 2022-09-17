using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public static class CheckKey
    {
        public static string getMac()
        {
            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            return macAddr;
        }
        public static bool checkOnline(string key)
        {
            var mac = CheckKey.getMac();

            var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/checkOnline?key=" + key + "&mac=" + mac);

            return json == "OK" ? true : false;
        }

        public static void UpdateKeyOnline(string key)
        {
            var mac = CheckKey.getMac();

            CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/UpdateKeyOnline?key=" + key + "&mac=" + mac);

        }
        public static void UpdateKeyInfoOnline(string key, string hoten, string diachi, string sdt)
        {
            var mac = CheckKey.getMac();

            CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/UpdateKeyInfoOnline?key=" + key
                + "&mac=" + mac
                + "&hoten=" + hoten
                + "&diachi=" + diachi
                + "&sdt=" + sdt
                );

        }

        public static DateTime infoKey(string key)
        {
            var mac = CheckKey.getMac();

            var data = FullinfoKey(key);
            if (data.Rows.Count > 0)
            {
                DateTime.TryParse(data.Rows[0]["ExpiryDate"].ToString(), out DateTime result);
                return result;
            }
            return new DateTime(2000, 1, 1);
        }
        public static DataTable FullinfoKey(string key)
        {
            var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetLicenceData?key=" + key);
            var data = JsonConvert.DeserializeObject<DataTable>(json);
            return data;

        }
        public static string LocalKey()
        {
            string value = "";
            var path = "Data/licence";
            if (File.Exists(path))
            {
                try
                {
                    var txt = File.ReadAllLines(path).FirstOrDefault();
                    txt = Security.Decrypt(txt);
                    value = txt;
                    var check = CheckKey.checkOnline(value);
                    if (check)
                    {
                        return value;
                    }
                }
                catch
                {
                }
            }
            return null;

        }


    }
}
