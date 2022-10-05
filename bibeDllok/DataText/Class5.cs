using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200000C RID: 12
[global::System.Runtime.CompilerServices.CompilerGenerated]
internal sealed class Class5<T, U>
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600005B RID: 91 RVA: 0x00004FA8 File Offset: 0x000031A8
	public T Name
	{
		get
		{
			return this.gparam_0;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600005C RID: 92 RVA: 0x00004FBC File Offset: 0x000031BC
	public U Type
	{
		get
		{
			return this.gparam_1;
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00004FD0 File Offset: 0x000031D0
	[global::System.Diagnostics.DebuggerHidden]
	public Class5(T gparam_2, U gparam_3)
	{
		this.gparam_0 = gparam_2;
		this.gparam_1 = gparam_3;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00004FF4 File Offset: 0x000031F4
	[global::System.Diagnostics.DebuggerHidden]
	public bool Equals(object obj)
	{
		global::Class5<T, U> @class = obj as global::Class5<T, U>;
		return this == @class || (@class != null && global::System.Collections.Generic.EqualityComparer<T>.Default.Equals(this.gparam_0, @class.gparam_0) && global::System.Collections.Generic.EqualityComparer<U>.Default.Equals(this.gparam_1, @class.gparam_1));
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00005044 File Offset: 0x00003244
	[global::System.Diagnostics.DebuggerHidden]
	public int GetHashCode()
	{
		return (0x498105 + global::System.Collections.Generic.EqualityComparer<T>.Default.GetHashCode(this.gparam_0)) * -0x5AAAAAD7 + global::System.Collections.Generic.EqualityComparer<U>.Default.GetHashCode(this.gparam_1);
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00005080 File Offset: 0x00003280
	[global::System.Diagnostics.DebuggerHidden]
	public string ToString()
	{
		global::System.IFormatProvider iformatProvider_ = null;
		string string_ = "{{ Name = {0}, Type = {1} }}";
		object[] array = new object[2];
		int num = 0;
		T t = this.gparam_0;
		array[num] = ((t != null) ? t.ToString() : null);
		int num2 = 1;
		U u = this.gparam_1;
		array[num2] = ((u != null) ? u.ToString() : null);
		return global::Class5<T, U>.smethod_0(iformatProvider_, string_, array);
	}

	// Token: 0x06000061 RID: 97 RVA: 0x000050F0 File Offset: 0x000032F0
	static string smethod_0(global::System.IFormatProvider iformatProvider_0, string string_0, object[] object_0)
	{
		return string.Format(iformatProvider_0, string_0, object_0);
	}

	// Token: 0x0400002C RID: 44
	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	private readonly T gparam_0;

	// Token: 0x0400002D RID: 45
	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	private readonly U gparam_1;
}
