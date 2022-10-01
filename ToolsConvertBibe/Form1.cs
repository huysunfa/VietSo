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

        private void button6_Click(object sender, EventArgs e)
        {
          var  text = Util.UnZIP(richTextBox1.Text);

            var ck = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerKey>(text);
         }
        public class CustomerKey
        {


            // Token: 0x17000001 RID: 1
            // (get) Token: 0x0600005D RID: 93 RVA: 0x00004E78 File Offset: 0x00003078
            // (set) Token: 0x0600005E RID: 94 RVA: 0x00004E8C File Offset: 0x0000308C
            public string CusKey { get; set; }

            // Token: 0x17000002 RID: 2
            // (get) Token: 0x0600005F RID: 95 RVA: 0x00004EA0 File Offset: 0x000030A0
            // (set) Token: 0x06000060 RID: 96 RVA: 0x00004EB4 File Offset: 0x000030B4
            public string ComputerID { get; set; }

            // Token: 0x17000003 RID: 3
            // (get) Token: 0x06000061 RID: 97 RVA: 0x00004EC8 File Offset: 0x000030C8
            // (set) Token: 0x06000062 RID: 98 RVA: 0x00004EDC File Offset: 0x000030DC
            public DateTime StartDtime { get; set; }

            // Token: 0x17000004 RID: 4
            // (get) Token: 0x06000063 RID: 99 RVA: 0x00004EF0 File Offset: 0x000030F0
            // (set) Token: 0x06000064 RID: 100 RVA: 0x00004F04 File Offset: 0x00003104
            public DateTime EndDtime { get; set; }

            // Token: 0x17000005 RID: 5
            // (get) Token: 0x06000065 RID: 101 RVA: 0x00004F18 File Offset: 0x00003118
            // (set) Token: 0x06000066 RID: 102 RVA: 0x00004F2C File Offset: 0x0000312C
            public DateTime CheckDtime { get; set; }

            // Token: 0x17000006 RID: 6
            // (get) Token: 0x06000067 RID: 103 RVA: 0x00004F40 File Offset: 0x00003140
            // (set) Token: 0x06000068 RID: 104 RVA: 0x00004F54 File Offset: 0x00003154
            public string Action { get; set; }

            // Token: 0x17000007 RID: 7
            // (get) Token: 0x06000069 RID: 105 RVA: 0x00004F68 File Offset: 0x00003168
            // (set) Token: 0x0600006A RID: 106 RVA: 0x00004F7C File Offset: 0x0000317C
            public string Name { get; set; }

            // Token: 0x17000008 RID: 8
            // (get) Token: 0x0600006B RID: 107 RVA: 0x00004F90 File Offset: 0x00003190
            // (set) Token: 0x0600006C RID: 108 RVA: 0x00004FA4 File Offset: 0x000031A4
            public string Phone { get; set; }

            // Token: 0x17000009 RID: 9
            // (get) Token: 0x0600006D RID: 109 RVA: 0x00004FB8 File Offset: 0x000031B8
            // (set) Token: 0x0600006E RID: 110 RVA: 0x00004FCC File Offset: 0x000031CC
            public string Note { get; set; }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var text = ZIP(richTextBox1.Text);
            richTextBox1.Text = text;
        }
        public static string ZIP(string str)
        {
            if (str == "")
            {
                return "";
            }
            return global::System.Convert.ToBase64String(bzupp(str));
        }
        // Token: 0x06000081 RID: 129 RVA: 0x00005520 File Offset: 0x00003720
        private static byte[] bzupp(string A_0)
		{
			byte[] bytes = global::System.Text.Encoding.UTF8.GetBytes(A_0);
        global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
        global::System.IO.Compression.GZipStream gzipStream = new global::System.IO.Compression.GZipStream(memoryStream, global::System.IO.Compression.CompressionMode.Compress, true);
        gzipStream.Write(bytes, 0, bytes.Length);
			gzipStream.Dispose();
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length + 1L];
        memoryStream.Read(array, 0, array.Length);
			memoryStream.Dispose();
			return array;
		}

}
}
