using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
             var result = json == "OK" ? true : false;
            if (result)
            {
                var info= CheckKey.infoKey(key);
                ActiveData.Update("DateLicence", info.ToString("dd/MM/yyyy"));
            }
            return result;
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
            try
            {
                var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetLicenceData?key=" + key);
                var data = JsonConvert.DeserializeObject<DataTable>(json);
                return data;
            }
            catch (Exception)
            {
                return new DataTable();
            }

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
              //      var check = CheckKey.checkOnline(value);
               //     if (check)
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
        public static bool CheckLogin()
        {

            string value = CheckKey.LocalKey();
            if (Program.IsConnectedToInternet()==false)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                return true;
            }

            var check = false;
            check = CheckKey.checkOnline(value);

            if (check == false)
            {
                if (InputBox("Nhập key kích hoạt", "Nhập key kích hoạt", ref value) == DialogResult.OK)
                {
                    check = CheckKey.checkOnline(value);
                }
            }


            if (check)
            {


                CheckKey.UpdateKeyOnline(value);


                value = Security.Encrypt(value);
                File.WriteAllText("Data/" + "licence", value);

                return true;
            }
            else
            {
                MessageBox.Show("Key không chính xác ...");
                Application.Exit();
                return false;
            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.PasswordChar = '*';

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }
}
