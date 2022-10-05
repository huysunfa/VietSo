using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DataText
{
	// Token: 0x02000019 RID: 25
	public static class Extensions
	{
		// Token: 0x0600016F RID: 367 RVA: 0x00007478 File Offset: 0x00005678
		public static global::System.Collections.Generic.List<T> ToList<T>(this global::System.Data.DataTable dataTable) where T : new()
		{
			global::System.Collections.Generic.List<T> list = new global::System.Collections.Generic.List<T>();
			global::System.Collections.Generic.List<global::Class5<string, global::System.Type>> list2 = typeof(T).GetProperties(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public).Cast<global::System.Reflection.PropertyInfo>().Select(new global::System.Func<global::System.Reflection.PropertyInfo, global::Class5<string, global::System.Type>>(global::DataText.Extensions.Class8<T>.<>9.method_0)).ToList<global::Class5<string, global::System.Type>>();
			global::System.Collections.Generic.List<global::Class5<string, global::System.Type>> list3 = dataTable.Columns.Cast<global::System.Data.DataColumn>().Select(new global::System.Func<global::System.Data.DataColumn, global::Class5<string, global::System.Type>>(global::DataText.Extensions.Class8<T>.<>9.method_1)).ToList<global::Class5<string, global::System.Type>>();
			foreach (object obj in dataTable.Rows)
			{
				global::System.Data.DataRow dataRow = (global::System.Data.DataRow)obj;
				T t = global::System.Activator.CreateInstance<T>();
				using (global::System.Collections.Generic.List<global::Class5<string, global::System.Type>>.Enumerator enumerator2 = list3.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						global::DataText.Extensions.Class7<T> @class = new global::DataText.Extensions.Class7<T>();
						@class.class5_0 = enumerator2.Current;
						global::System.Reflection.PropertyInfo property = t.GetType().GetProperty(@class.class5_0.Name);
						if (list2.Find(new global::System.Predicate<global::Class5<string, global::System.Type>>(@class.method_0)) != null)
						{
							if (!(property.PropertyType == typeof(global::System.DateTime)))
							{
								if (property.PropertyType == typeof(int))
								{
									property.SetValue(t, global::DataText.Extensions.smethod_2(dataRow[@class.class5_0.Name]), null);
								}
								else if (!(property.PropertyType == typeof(long)))
								{
									if (property.PropertyType == typeof(decimal))
									{
										property.SetValue(t, global::DataText.Extensions.smethod_4(dataRow[@class.class5_0.Name]), null);
									}
									else if (property.PropertyType == typeof(bool))
									{
										property.SetValue(t, global::DataText.Extensions.smethod_5(dataRow[@class.class5_0.Name]), null);
									}
									else if (property.PropertyType == typeof(string))
									{
										if (dataRow[@class.class5_0.Name].GetType() == typeof(global::System.DateTime))
										{
											property.SetValue(t, global::DataText.Extensions.smethod_0(dataRow[@class.class5_0.Name]), null);
										}
										else
										{
											property.SetValue(t, global::DataText.Extensions.smethod_1(dataRow[@class.class5_0.Name]), null);
										}
									}
								}
								else
								{
									property.SetValue(t, global::DataText.Extensions.smethod_3(dataRow[@class.class5_0.Name]), null);
								}
							}
							else
							{
								property.SetValue(t, global::DataText.Extensions.smethod_6(dataRow[@class.class5_0.Name]), null);
							}
						}
					}
				}
				list.Add(t);
			}
			return list;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00007800 File Offset: 0x00005A00
		public static global::System.Data.DataTable ToDataTable<T>(this global::System.Collections.Generic.IList<T> list)
		{
			if (list == null)
			{
				return null;
			}
			global::System.ComponentModel.PropertyDescriptorCollection properties = global::System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
			global::System.Data.DataTable dataTable = new global::System.Data.DataTable("TempTable");
			for (int i = 0; i < properties.Count; i++)
			{
				global::System.ComponentModel.PropertyDescriptor propertyDescriptor = properties[i];
				dataTable.Columns.Add(propertyDescriptor.Name, global::System.Nullable.GetUnderlyingType(propertyDescriptor.PropertyType) ?? propertyDescriptor.PropertyType);
			}
			object[] array = new object[properties.Count];
			foreach (T t in list)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = (properties[j].GetValue(t) ?? global::System.DBNull.Value);
				}
				dataTable.Rows.Add(array);
			}
			return dataTable;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000078FC File Offset: 0x00005AFC
		private static string smethod_0(object object_0)
		{
			if (object_0 == null)
			{
				return string.Empty;
			}
			return object_0.ToString();
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00007918 File Offset: 0x00005B18
		private static string smethod_1(object object_0)
		{
			return global::System.Convert.ToString(object_0.smethod_8());
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00007930 File Offset: 0x00005B30
		private static int smethod_2(object object_0)
		{
			return global::System.Convert.ToInt32(object_0.smethod_9());
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00007948 File Offset: 0x00005B48
		private static long smethod_3(object object_0)
		{
			return global::System.Convert.ToInt64(object_0.smethod_9());
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00007960 File Offset: 0x00005B60
		private static decimal smethod_4(object object_0)
		{
			return global::System.Convert.ToDecimal(object_0.smethod_9());
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00007978 File Offset: 0x00005B78
		private static bool smethod_5(object object_0)
		{
			return global::System.Convert.ToBoolean(object_0.smethod_9());
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007990 File Offset: 0x00005B90
		private static global::System.DateTime smethod_6(object object_0)
		{
			return global::System.Convert.ToDateTime(object_0.smethod_7());
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000079A8 File Offset: 0x00005BA8
		private static object smethod_7(this object object_0)
		{
			if (object_0 == global::System.DBNull.Value)
			{
				return global::System.DateTime.MinValue;
			}
			if (object_0 == null)
			{
				return global::System.DateTime.MinValue;
			}
			return object_0;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000079D8 File Offset: 0x00005BD8
		private static object smethod_8(this object object_0)
		{
			if (object_0 == global::System.DBNull.Value)
			{
				return string.Empty;
			}
			if (object_0 != null)
			{
				return object_0;
			}
			return string.Empty;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00007A00 File Offset: 0x00005C00
		private static object smethod_9(this object object_0)
		{
			if (object_0 == global::System.DBNull.Value)
			{
				return 0;
			}
			if (object_0 != null)
			{
				return object_0;
			}
			return 0;
		}

		// Token: 0x0200001A RID: 26
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class Class7<T> where T : new()
		{
			// Token: 0x0600019A RID: 410 RVA: 0x00004254 File Offset: 0x00002454
			public Class7()
			{
			}

			// Token: 0x0600019B RID: 411 RVA: 0x00007A28 File Offset: 0x00005C28
			internal bool method_0(global::Class5<string, global::System.Type> class5_1)
			{
				return global::DataText.Extensions.Class7<T>.smethod_0(class5_1.Name, this.class5_0.Name);
			}

			// Token: 0x0600019C RID: 412 RVA: 0x00007A4C File Offset: 0x00005C4C
			static bool smethod_0(string string_0, string string_1)
			{
				return string_0 == string_1;
			}

			// Token: 0x04000047 RID: 71
			public global::Class5<string, global::System.Type> class5_0;
		}

		// Token: 0x0200001B RID: 27
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		[global::System.Serializable]
		private sealed class Class8<T> where T : new()
		{
			// Token: 0x0600019D RID: 413 RVA: 0x00007A60 File Offset: 0x00005C60
			// Note: this type is marked as 'beforefieldinit'.
			static Class8()
			{
			}

			// Token: 0x0600019E RID: 414 RVA: 0x00004254 File Offset: 0x00002454
			public Class8()
			{
			}

			// Token: 0x0600019F RID: 415 RVA: 0x00007A78 File Offset: 0x00005C78
			internal global::Class5<string, global::System.Type> method_0(global::System.Reflection.PropertyInfo propertyInfo_0)
			{
				return new global::Class5<string, global::System.Type>(global::DataText.Extensions.Class8<T>.smethod_0(propertyInfo_0), global::DataText.Extensions.Class8<T>.smethod_2(global::DataText.Extensions.Class8<T>.smethod_1(propertyInfo_0)) ?? global::DataText.Extensions.Class8<T>.smethod_1(propertyInfo_0));
			}

			// Token: 0x060001A0 RID: 416 RVA: 0x00007AA8 File Offset: 0x00005CA8
			internal global::Class5<string, global::System.Type> method_1(global::System.Data.DataColumn dataColumn_0)
			{
				return new global::Class5<string, global::System.Type>(global::DataText.Extensions.Class8<T>.smethod_3(dataColumn_0), global::DataText.Extensions.Class8<T>.smethod_4(dataColumn_0));
			}

			// Token: 0x060001A1 RID: 417 RVA: 0x00007AC8 File Offset: 0x00005CC8
			static string smethod_0(global::System.Reflection.MemberInfo memberInfo_0)
			{
				return memberInfo_0.Name;
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x00007ADC File Offset: 0x00005CDC
			static global::System.Type smethod_1(global::System.Reflection.PropertyInfo propertyInfo_0)
			{
				return propertyInfo_0.PropertyType;
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x00007AF0 File Offset: 0x00005CF0
			static global::System.Type smethod_2(global::System.Type type_0)
			{
				return global::System.Nullable.GetUnderlyingType(type_0);
			}

			// Token: 0x060001A4 RID: 420 RVA: 0x00007B04 File Offset: 0x00005D04
			static string smethod_3(global::System.Data.DataColumn dataColumn_0)
			{
				return dataColumn_0.ColumnName;
			}

			// Token: 0x060001A5 RID: 421 RVA: 0x00007B18 File Offset: 0x00005D18
			static global::System.Type smethod_4(global::System.Data.DataColumn dataColumn_0)
			{
				return dataColumn_0.DataType;
			}

			// Token: 0x04000048 RID: 72
			public static readonly global::DataText.Extensions.Class8<T> <>9 = new global::DataText.Extensions.Class8<T>();

			// Token: 0x04000049 RID: 73
			public static global::System.Func<global::System.Reflection.PropertyInfo, global::Class5<string, global::System.Type>> <>9__0_0;

			// Token: 0x0400004A RID: 74
			public static global::System.Func<global::System.Data.DataColumn, global::Class5<string, global::System.Type>> <>9__0_1;
		}
	}
}
