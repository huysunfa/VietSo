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
        //public Dictionary<string,  UserSettingPrint> PrintSetting { get; set; }

        public static UserSetting Load()
        {
            string text = global::System.IO.Path.Combine(Util.getDataPath, "App.set");
            if (!global::System.IO.File.Exists(text))
            {
                return new UserSetting();
            }
            UserSetting userSetting = UtilModel.readObjFromJsonFile<UserSetting>(text);
            if (userSetting != null)
            {
                return userSetting;
            }
            return new UserSetting();
        }

    }
}
