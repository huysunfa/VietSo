using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DataText
{
	// Token: 0x0200001C RID: 28
	public class Family
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00007B2C File Offset: 0x00005D2C
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00007B40 File Offset: 0x00005D40
		public int SoNo
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00007B54 File Offset: 0x00005D54
		public Family()
		{
		}

		// Token: 0x0400004B RID: 75
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_0;

		// Token: 0x0400004C RID: 76
		public global::System.Collections.Generic.List<string> IDs = new global::System.Collections.Generic.List<string>();
	}
}
