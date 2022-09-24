using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo
{
    public static class ConstData
    {
        public const string ExtentionsFile = ".hc";
        public static CellData getCellData(this object input)
        {
            var result = (CellData)input;
            if (result==null)
            {
                result = new CellData();
            }
            return result;
        }
    }
}
