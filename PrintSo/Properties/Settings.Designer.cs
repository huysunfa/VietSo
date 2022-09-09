using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace PrintSo.Properties
{
	// Token: 0x0200001E RID: 30
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600015A RID: 346 RVA: 0x0001959D File Offset: 0x0001779D
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400014D RID: 333
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
