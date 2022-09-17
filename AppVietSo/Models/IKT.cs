using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public interface IKT
    {
        // Token: 0x06000096 RID: 150
        object getId();

        // Token: 0x06000097 RID: 151
        string getLimitScript();

        // Token: 0x06000098 RID: 152
        void setLimitScript(string moreScript);

        // Token: 0x06000099 RID: 153
        string getMoreScript();

        // Token: 0x0600009A RID: 154
        void setMoreScript(string moreScript);

        // Token: 0x0600009B RID: 155
        bool getAutoGenerateScript();

        // Token: 0x0600009C RID: 156
        void setAutoGenerateScript(bool b);
    }
}
