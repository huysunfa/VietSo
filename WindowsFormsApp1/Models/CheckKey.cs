using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
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

            var data = SqlModule.GetDataTable($@"select * from LicenceData where Licence ='{key}'
                and ISNULL(ExpiryDate, getdate()) >= CONVERT(date, getdate()) and isnull(IP_Active,'{mac}') ='{mac}' ");

            if (data.Rows.Count > 0)
            {
                return true;
            }

            return false;

        }

        public static void UpdateKeyOnline(string key)
        {
            var mac = CheckKey.getMac();

            SqlModule.ExcuteCommand($@"update LicenceData set IP_Active ='{mac}',Date_Active = getdate() where  Licence ='{key}'");

        }

        public static DateTime infoKey(string key)
        {
            var mac = CheckKey.getMac();

            var data = SqlModule.GetDataTable($@" SELECT [ExpiryDate]
  FROM [LicenceData] where Licence='{key}'");
            if (data.Rows.Count > 0)
            {
                DateTime.TryParse(data.Rows[0]["ExpiryDate"].ToString(), out DateTime result);
                return result;
            }
            return new DateTime(2000, 1, 1);
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
