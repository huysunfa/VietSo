using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Suggets
    {
        public Dictionary<string,List<string>> get()
        {
            string[] lines = System.IO.File.ReadAllLines(@"data/dataSugget.csv");
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            var data = lines.Select(z => new { key = z.Split('|').LastOrDefault(), value = z.Split('|').FirstOrDefault() }).ToList();
            foreach (var item in data)
            {
                var key = item.key.ToUpper();
                if (!result.ContainsKey(key))
                {
                    result.Add(key, new List<string>());
                }

                result[key].Add(item.value);
            }
             return result;
        }
    }
}
