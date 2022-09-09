using System;

namespace PrintSo
{
	// Token: 0x02000006 RID: 6
	public class ComboboxItem
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00004980 File Offset: 0x00002B80
		public ComboboxItem()
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004988 File Offset: 0x00002B88
		public ComboboxItem(string text, object value)
		{
			this.Text = text;
			this.Value = value;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000499E File Offset: 0x00002B9E
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000049A6 File Offset: 0x00002BA6
		public string Text { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000049AF File Offset: 0x00002BAF
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000049B7 File Offset: 0x00002BB7
		public object Value { get; set; }

		// Token: 0x06000034 RID: 52 RVA: 0x000049C0 File Offset: 0x00002BC0
		public override string ToString()
		{
			return this.Text;
		}
	}
}
