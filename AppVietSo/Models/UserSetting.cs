using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class UserSetting
    {
        public string Chua { get; set; }
        public bool IsGiaChu { get; set; }
        public bool IsPrintMaSo { get; set; }
        public string LoaiSo { get; set; }
        public Dictionary<string, string> LongSoUserData { get; set; }
        public string NgonNgu { get; set; }
        public Dictionary<string,  UserSettingPrint> PrintSetting { get; set; }

        public static UserSetting Load()
        {
            string text = global::System.IO.Path.Combine(Util.getDataPath, "App.set");
            if (!global::System.IO.File.Exists(text))
            {
                return new UserSetting() {  PrintSetting= new Dictionary<string, UserSettingPrint>()};
            }
            UserSetting userSetting = UtilModel.readObjFromJsonFile<UserSetting>(text);
            if (userSetting != null)
            {
                return userSetting;
            }
    return new UserSetting() { PrintSetting = new Dictionary<string, UserSettingPrint>() };

        }
        // Token: 0x060002A6 RID: 678 RVA: 0x0000BFC0 File Offset: 0x0000A1C0
        public   UserSettingPrint GetPrintSetting(string sheet)
        {
            if (!PrintSetting.ContainsKey(sheet))
            {
                this.PrintSetting.Add(sheet, new UserSettingPrint() { ColHiden= new List<int>(), ColWidth = new Dictionary<int, ushort>() });
            }
            return this.PrintSetting[sheet];
        }

    }
}
