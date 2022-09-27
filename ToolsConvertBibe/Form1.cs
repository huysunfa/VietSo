using AppVietSo;
using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsConvertBibe
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("input");
            foreach (var item in files)
            {
                var txt = File.ReadAllText(item);
                var giaima = Security.GiaiMa(txt);
                var mahoa = CryptoServiceProvider.EncryptPassword(giaima);
                File.WriteAllText("output/" + item.Split('\\').LastOrDefault().Split('.').FirstOrDefault()+".hc", mahoa);
            }

            MessageBox.Show("convert ok "+files.Length +" FILE");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var txt = richTextBox1.Text;
            var giaima = Security.GiaiMa(txt);
            richTextBox1.Text = giaima;
        }
        public static string String2Unicode(string source)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(source);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unicode string
        /// </summary>
        /// <param name="source">After a string of Unicode code</param>
        /// <returns>Normal string</returns>
        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                         source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var output = new Dictionary<string, string>();
            var data = SqlModuleLocal.GetDataTable("select * from [VnChinese]  WHERE [reading] IS   NULL ");
            foreach (DataRow item in data.Rows)
            {
                var cn = item["chinese"].ToString();
          //      cn = Unicode2String(cn);
    //       var     cn3 = Encoding.GetEncoding(cn);

                    ; var cn2= cn.ToList();
    
                if (cn2.Count()>1 && cn2.Count() <=5)
                {
                    var ID = item["ID"].ToString();
                    var newtxt = string.Join(" ", cn2);
            
                    SqlModuleLocal.ExcuteCommand($"update VnChinese set reading =N'{newtxt}' where id= "+ID);
                    output.Add(ID, newtxt);
                }

            }
            string txt = "";
            foreach (var item in output)
            {
                txt += item.Key + ","+item.Value + "\n";
            }
            File.WriteAllText("a.csv", txt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var output = new Dictionary<string, string>();
            var outputcn = new Dictionary<string, string>();
            AppVietSo.CNDictionary.loadDatabase(true);
            string[] files = Directory.GetFiles("output");
            foreach (var item in files)
            {
                string Namelds = item.Replace("\\","/").Split('/').LastOrDefault();
                var LSo = new LongSo() { FileName = Namelds };
               var data = LongSoData.get(LSo.FileName, LSo);
                foreach (var it in data.LgSo)
                {
                    foreach (var ix in it.Value)
                    {
                        if (string.IsNullOrEmpty(ix.Value.TextVN))
                        {
                            continue;
                        }
                        var cn = CNDictionary.getCN(ix.Value.TextVN);
                        if (cn==null||  cn == ix.Value.TextVN)
                        {
                            if (!output.ContainsKey(ix.Value.TextVN))
                            {
                                output.Add(ix.Value.TextVN, ix.Value.TextCN);
                            }
                        }   
                        
                        var vn = CNDictionary.getVN(ix.Value.TextCN);
                        if (string.IsNullOrEmpty(vn)|| vn == ix.Value.TextCN)
                        {
                            if (!outputcn.ContainsKey(ix.Value.TextCN))
                            {
                                outputcn.Add(ix.Value.TextCN, ix.Value.TextVN);
                            }
                        }
                    }
                
                }
            }

            foreach (var item in output)
            {
                var key = item.Key.Replace("'", "");
                var Value = item.Value.Replace("'", "");
                SqlModuleLocal.ExcuteCommand($"insert [VnChinese](vn,chinese) values (N'{key}',N'{Value}')");

            }
            
            foreach (var item in outputcn)
            {
                var key = item.Value.Replace("'", "");
                var Value = item.Key.Replace("'", "");
                SqlModuleLocal.ExcuteCommand($"insert [VnChinese](vn,chinese) values (N'{key}',N'{Value}')");

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
          SqlModule.ExcuteCommand("delete [VnChinese]");

            DataTable dtRRC = SqlModuleLocal.GetDataTable("SELECT *  FROM [VnChinese]");
            DataTable dt = SqlModule.GetDataTable("SELECT top 0  *  FROM [VnChinese]");
 
            int MaxRow = dtRRC.Rows.Count;
            //       MaxRow = 5000;
            for (int i = 0; i < MaxRow; i++)
            {
                var item = dtRRC.Rows[i];
                var row = dt.NewRow();

                foreach (DataColumn col in dtRRC.Columns)
                {
                    row[col.ColumnName] = item[col];
                }
                dt.Rows.Add(row);

            }

            new BulkCopy().BulkInsertAll(dt, "lts43636_vietso.dbo.[VnChinese]");
        }
    }
}
