using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class ComboboxItem
    {
        public ComboboxItem()
        {
        }

        // Token: 0x0600002F RID: 47 RVA: 0x00004988 File Offset: 0x00002B88
        public ComboboxItem(string text, object value)
        {
            this.Text = text;
            this.Value = value;
        }
        public string Text { get; set; }

        public object Value { get; set; }

        // Token: 0x06000034 RID: 52 RVA: 0x000049C0 File Offset: 0x00002BC0
        public override string ToString()
        {
            return this.Text;
        }
    }
}
