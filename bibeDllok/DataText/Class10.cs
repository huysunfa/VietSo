using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x02000028 RID: 40
[global::System.Runtime.CompilerServices.CompilerGenerated]
internal sealed class Class10
{
	// Token: 0x060002BA RID: 698 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
	internal static uint smethod_0(string string_0)
	{
		uint num;
		if (string_0 != null)
		{
			num = 0x811C9DC5U;
			for (int i = 0; i < string_0.Length; i++)
			{
				num = ((uint)string_0[i] ^ num) * 0x1000193U;
			}
		}
		return num;
	}

	// Token: 0x0400009D RID: 157 RVA: 0x00002990 File Offset: 0x00000B90
	internal static readonly global::Class10.Struct5 struct5_0;

	// Token: 0x02000029 RID: 41
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Pack = 1, Size = 0xD)]
	private struct Struct5
	{
	}
}
