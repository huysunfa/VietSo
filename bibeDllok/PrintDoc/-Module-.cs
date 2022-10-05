using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

// Token: 0x02000001 RID: 1
internal class <Module>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002410 File Offset: 0x00000610
	static <Module>()
	{
		global::<Module>.smethod_4();
		global::<Module>.smethod_2();
		global::<Module>.smethod_0();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000242C File Offset: 0x0000062C
	private static void smethod_0()
	{
		string str = "COR";
		global::System.Type typeFromHandle = typeof(global::System.Environment);
		global::System.Reflection.MethodInfo method = typeFromHandle.GetMethod("GetEnvironmentVariable", new global::System.Type[]
		{
			typeof(string)
		});
		if (method != null && "1".Equals(method.Invoke(null, new object[]
		{
			str + "_ENABLE_PROFILING"
		})))
		{
			global::System.Environment.FailFast(null);
		}
		new global::System.Threading.Thread(new global::System.Threading.ParameterizedThreadStart(global::<Module>.smethod_1))
		{
			IsBackground = true
		}.Start(null);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000024C4 File Offset: 0x000006C4
	private static void smethod_1(object object_0)
	{
		global::System.Threading.Thread thread = object_0 as global::System.Threading.Thread;
		if (thread == null)
		{
			thread = new global::System.Threading.Thread(new global::System.Threading.ParameterizedThreadStart(global::<Module>.smethod_1));
			thread.IsBackground = true;
			thread.Start(global::System.Threading.Thread.CurrentThread);
			global::System.Threading.Thread.Sleep(0x1F4);
		}
		for (;;)
		{
			if (global::System.Diagnostics.Debugger.IsAttached)
			{
				goto IL_41;
			}
			if (global::System.Diagnostics.Debugger.IsLogging())
			{
				goto IL_41;
			}
			IL_47:
			if (!thread.IsAlive)
			{
				global::System.Environment.FailFast(null);
			}
			global::System.Threading.Thread.Sleep(0x3E8);
			continue;
			IL_41:
			global::System.Environment.FailFast(null);
			goto IL_47;
		}
	}

	// Token: 0x06000004 RID: 4
	[global::System.Runtime.InteropServices.DllImport("kernel32.dll")]
	internal unsafe static extern bool VirtualProtect(byte* pByte_0, int int_0, uint uint_0, ref uint uint_1);

	// Token: 0x06000005 RID: 5 RVA: 0x00002538 File Offset: 0x00000738
	internal unsafe static void smethod_2()
	{
		global::System.Reflection.Module module = typeof(global::<Module>).Module;
		byte* ptr = (byte*)((void*)global::System.Runtime.InteropServices.Marshal.GetHINSTANCE(module));
		byte* ptr2 = ptr + 0x3C;
		ptr2 = ptr + *(uint*)ptr2;
		ptr2 += 6;
		ushort num = *(ushort*)ptr2;
		ptr2 += 0xE;
		ushort num2 = *(ushort*)ptr2;
		ptr2 = ptr2 + 4 + num2;
		byte* ptr3 = stackalloc byte[(global::System.UIntPtr)0xB];
		uint num5;
		if (module.FullyQualifiedName[0] == '<')
		{
			uint num3 = *(uint*)(ptr2 - 0x10);
			uint num4 = *(uint*)(ptr2 - 0x78);
			uint[] array = new uint[(int)num];
			uint[] array2 = new uint[(int)num];
			uint[] array3 = new uint[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				global::<Module>.VirtualProtect(ptr2, 8, 0x40U, ref num5);
				global::System.Runtime.InteropServices.Marshal.Copy(new byte[8], 0, (global::System.IntPtr)((void*)ptr2), 8);
				array[i] = *(uint*)(ptr2 + 0xC);
				array2[i] = *(uint*)(ptr2 + 8);
				array3[i] = *(uint*)(ptr2 + 0x14);
				ptr2 += 0x28;
			}
			if (num4 != 0U)
			{
				for (int j = 0; j < (int)num; j++)
				{
					if (array[j] <= num4 && num4 < array[j] + array2[j])
					{
						num4 = num4 - array[j] + array3[j];
						IL_11F:
						byte* ptr4 = ptr + num4;
						uint num6 = *(uint*)ptr4;
						for (int k = 0; k < (int)num; k++)
						{
							if (array[k] <= num6 && num6 < array[k] + array2[k])
							{
								num6 = num6 - array[k] + array3[k];
								break;
							}
						}
						byte* ptr5 = ptr + num6;
						uint num7 = *(uint*)(ptr4 + 0xC);
						for (int l = 0; l < (int)num; l++)
						{
							if (array[l] <= num7 && num7 < array[l] + array2[l])
							{
								num7 = num7 - array[l] + array3[l];
								IL_1AF:
								uint num8 = *(uint*)ptr5 + 2U;
								for (int m = 0; m < (int)num; m++)
								{
									if (array[m] <= num8 && num8 < array[m] + array2[m])
									{
										num8 = num8 - array[m] + array3[m];
										break;
									}
								}
								global::<Module>.VirtualProtect(ptr + num7, 0xB, 0x40U, ref num5);
								*(int*)ptr3 = 0x6C64746E;
								*(int*)(ptr3 + 4) = 0x6C642E6C;
								*(short*)(ptr3 + 8) = 0x6C;
								ptr3[0xA] = 0;
								for (int n = 0; n < 0xB; n++)
								{
									(ptr + num7)[n] = ptr3[n];
								}
								global::<Module>.VirtualProtect(ptr + num8, 0xB, 0x40U, ref num5);
								*(int*)ptr3 = 0x6F43744E;
								*(int*)(ptr3 + 4) = 0x6E69746E;
								*(short*)(ptr3 + 8) = 0x6575;
								ptr3[0xA] = 0;
								for (int num9 = 0; num9 < 0xB; num9++)
								{
									(ptr + num8)[num9] = ptr3[num9];
								}
								goto IL_298;
							}
						}
						goto IL_1AF;
					}
				}
				goto IL_11F;
			}
			IL_298:
			for (int num10 = 0; num10 < (int)num; num10++)
			{
				if (array[num10] <= num3 && num3 < array[num10] + array2[num10])
				{
					num3 = num3 - array[num10] + array3[num10];
					break;
				}
			}
			byte* ptr6 = ptr + num3;
			global::<Module>.VirtualProtect(ptr6, 0x48, 0x40U, ref num5);
			uint num11 = *(uint*)(ptr6 + 8);
			for (int num12 = 0; num12 < (int)num; num12++)
			{
				if (array[num12] <= num11 && num11 < array[num12] + array2[num12])
				{
					num11 = num11 - array[num12] + array3[num12];
					break;
				}
			}
			*(int*)ptr6 = 0;
			*(int*)(ptr6 + 4) = 0;
			*(int*)(ptr6 + 8) = 0;
			*(int*)(ptr6 + 0xC) = 0;
			byte* ptr7 = ptr + num11;
			global::<Module>.VirtualProtect(ptr7, 4, 0x40U, ref num5);
			*(int*)ptr7 = 0;
			ptr7 += 0xC;
			ptr7 += *(uint*)ptr7;
			ptr7 = (ptr7 + 7L & -4L);
			ptr7 += 2;
			ushort num13 = (ushort)(*ptr7);
			ptr7 += 2;
			int num14 = 0;
			IL_434:
			while (num14 < (int)num13)
			{
				global::<Module>.VirtualProtect(ptr7, 8, 0x40U, ref num5);
				ptr7 += 4;
				ptr7 += 4;
				int num15 = 0;
				while (num15 < 8)
				{
					global::<Module>.VirtualProtect(ptr7, 4, 0x40U, ref num5);
					*ptr7 = 0;
					ptr7++;
					if (*ptr7 != 0)
					{
						*ptr7 = 0;
						ptr7++;
						if (*ptr7 != 0)
						{
							*ptr7 = 0;
							ptr7++;
							if (*ptr7 != 0)
							{
								*ptr7 = 0;
								ptr7++;
								num15++;
								continue;
							}
							ptr7++;
						}
						else
						{
							ptr7 += 2;
						}
					}
					else
					{
						ptr7 += 3;
					}
					IL_42E:
					num14++;
					goto IL_434;
				}
				goto IL_42E;
			}
			return;
		}
		byte* ptr8 = ptr + *(uint*)(ptr2 - 0x10);
		if (*(uint*)(ptr2 - 0x78) != 0U)
		{
			byte* ptr9 = ptr + *(uint*)(ptr2 - 0x78);
			byte* ptr10 = ptr + *(uint*)ptr9;
			byte* ptr11 = ptr + *(uint*)(ptr9 + 0xC);
			byte* ptr12 = ptr + *(uint*)ptr10 + 2;
			global::<Module>.VirtualProtect(ptr11, 0xB, 0x40U, ref num5);
			*(int*)ptr3 = 0x6C64746E;
			*(int*)(ptr3 + 4) = 0x6C642E6C;
			*(short*)(ptr3 + 8) = 0x6C;
			ptr3[0xA] = 0;
			for (int num16 = 0; num16 < 0xB; num16++)
			{
				ptr11[num16] = ptr3[num16];
			}
			global::<Module>.VirtualProtect(ptr12, 0xB, 0x40U, ref num5);
			*(int*)ptr3 = 0x6F43744E;
			*(int*)(ptr3 + 4) = 0x6E69746E;
			*(short*)(ptr3 + 8) = 0x6575;
			ptr3[0xA] = 0;
			for (int num17 = 0; num17 < 0xB; num17++)
			{
				ptr12[num17] = ptr3[num17];
			}
		}
		for (int num18 = 0; num18 < (int)num; num18++)
		{
			global::<Module>.VirtualProtect(ptr2, 8, 0x40U, ref num5);
			global::System.Runtime.InteropServices.Marshal.Copy(new byte[8], 0, (global::System.IntPtr)((void*)ptr2), 8);
			ptr2 += 0x28;
		}
		global::<Module>.VirtualProtect(ptr8, 0x48, 0x40U, ref num5);
		byte* ptr13 = ptr + *(uint*)(ptr8 + 8);
		*(int*)ptr8 = 0;
		*(int*)(ptr8 + 4) = 0;
		*(int*)(ptr8 + 8) = 0;
		*(int*)(ptr8 + 0xC) = 0;
		global::<Module>.VirtualProtect(ptr13, 4, 0x40U, ref num5);
		*(int*)ptr13 = 0;
		ptr13 += 0xC;
		ptr13 += *(uint*)ptr13;
		ptr13 = (ptr13 + 7L & -4L);
		ptr13 += 2;
		ushort num19 = (ushort)(*ptr13);
		ptr13 += 2;
		for (int num20 = 0; num20 < (int)num19; num20++)
		{
			global::<Module>.VirtualProtect(ptr13, 8, 0x40U, ref num5);
			ptr13 += 4;
			ptr13 += 4;
			for (int num21 = 0; num21 < 8; num21++)
			{
				global::<Module>.VirtualProtect(ptr13, 4, 0x40U, ref num5);
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 == 0)
				{
					ptr13 += 3;
					break;
				}
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 == 0)
				{
					ptr13 += 2;
					break;
				}
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 == 0)
				{
					ptr13++;
					break;
				}
				*ptr13 = 0;
				ptr13++;
			}
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002BB8 File Offset: 0x00000DB8
	internal static byte[] smethod_3(byte[] byte_1)
	{
		global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream(byte_1);
		global::<Module>.Class1 @class = new global::<Module>.Class1();
		byte[] buffer = new byte[5];
		memoryStream.Read(buffer, 0, 5);
		@class.method_5(buffer);
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			int num2 = memoryStream.ReadByte();
			num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
		}
		byte[] array = new byte[(int)num];
		global::System.IO.MemoryStream stream_ = new global::System.IO.MemoryStream(array, true);
		long long_ = memoryStream.Length - 0xDL;
		@class.method_4(memoryStream, stream_, long_, num);
		return array;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002C50 File Offset: 0x00000E50
	internal static void smethod_4()
	{
		uint num = 0xF0U;
		uint[] array = new uint[]
		{
			0x891FA14AU,
			0xD31828F7U,
			0xDB12011FU,
			0x251EB02BU,
			0xDB9E41E8U,
			0x49BB415EU,
			0xD004B90EU,
			0x6AF3ECF3U,
			0xD42CA885U,
			0x30A8A60BU,
			0x650E0B33U,
			0x104CD8DFU,
			0x42AB330DU,
			0x1C66AFCAU,
			0xDF4DB1U,
			0x1EA7D8C6U,
			0xB5BA4DACU,
			0x5B78C5EBU,
			0x8E64B91EU,
			0x5C47F14U,
			0x418CFBDU,
			0x6FEC148DU,
			0x1EF15BEDU,
			0x2F000837U,
			0x543FBA4DU,
			0xDCD1D9F3U,
			0xF8D51A51U,
			0xFB3EEF2DU,
			0x7F50ED78U,
			0xD8A8EE5BU,
			0x5FE00F95U,
			0x7E0B4DB9U,
			0xC598D9F1U,
			0xBF81A685U,
			0x343EC9BBU,
			0xDFD915CU,
			0x21B5092AU,
			0x688D6E66U,
			0xFAD6F745U,
			0xF00ADB70U,
			0x1E032335U,
			0x47349404U,
			0x89BE5E63U,
			0x5505E28CU,
			0x7B61D14EU,
			0x174BFE17U,
			0x8E67BACCU,
			0x20ACEDA1U,
			0xA5878CFU,
			0x775A770U,
			0x12D443A7U,
			0x6874C8B3U,
			0x1D760BD0U,
			0x964801EFU,
			0x84AB2BF1U,
			0xB2B8E42BU,
			0x5D9159B6U,
			0x681CE93EU,
			0x2772621U,
			0xBD0917F1U,
			0x8DFB9DB3U,
			0x82A9AA42U,
			0xCA70AEA5U,
			0x5026501CU,
			0xD6C36F6FU,
			0xFC08DAD9U,
			0x9D0F0F50U,
			0x86A17C86U,
			0x29EB41ADU,
			0x2DAFEC69U,
			0x4714FC86U,
			0x9A31EE48U,
			0x62307722U,
			0x88A6CA5FU,
			0xE240DE7BU,
			0x2316DE68U,
			0x6C1B8C70U,
			0xB063810CU,
			0xC5F42AFDU,
			0x9FCF5EE9U,
			0xAF2B92AAU,
			0x90AD26ADU,
			0x8E948B2BU,
			0xA5F98526U,
			0x3A5146C2U,
			0x1F8315B2U,
			0x60732E9CU,
			0xB0F959B1U,
			0xBE2E762EU,
			0x607D4878U,
			0xEE0BFD63U,
			0x7DE5EEC2U,
			0x9673664FU,
			0xC37BA92DU,
			0xFD859CD1U,
			0x4BBB0429U,
			0x825AE70EU,
			0x84D8C58CU,
			0xDCEDBE2AU,
			0x6E1BD6CCU,
			0x3EA13A33U,
			0x4CF3DC89U,
			0xB790305AU,
			0x4EFDE705U,
			0xCD1C7D88U,
			0x7C7557E8U,
			0x524B076EU,
			0xD737B541U,
			0x570E89CDU,
			0xDE1CB126U,
			0xE4339053U,
			0xFA34583BU,
			0x8385B219U,
			0x10BE25BBU,
			0x408C661FU,
			0xCCCCA110U,
			0x12A83377U,
			0x7E57E09FU,
			0x27E6D805U,
			0x9CCE6D09U,
			0x5A0ADBA8U,
			0x331C7632U,
			0x9E5960CFU,
			0xF234CCCAU,
			0x9CF2B65BU,
			0xCEEB5932U,
			0x8EF4F7EU,
			0x17AB9352U,
			0xCC9F7764U,
			0x5646ACE7U,
			0xE47AB5C7U,
			0x43A71B54U,
			0x675D2018U,
			0x3DD05218U,
			0x38576298U,
			0x32155B28U,
			0xA30DBEDFU,
			0xCDA2E408U,
			0xF70DDA49U,
			0x22EC9906U,
			0x80698BEDU,
			0x56E497B8U,
			0xA5FBBEE7U,
			0x5469DA26U,
			0xC512FA9EU,
			0x310FEFD6U,
			0x84CED604U,
			0x5057A770U,
			0x8A95EA82U,
			0x1D7915DU,
			0x4EB3913BU,
			0x4FD80EB5U,
			0x67691AB4U,
			0x88C22F38U,
			0x9121558BU,
			0x462B5A37U,
			0x3CA38D55U,
			0xE0D5AB9FU,
			0xF0927706U,
			0x64FCA2E5U,
			0x45D2588U,
			0x20379709U,
			0xF76FC751U,
			0xD235A2C6U,
			0xF33B9080U,
			0x89A9FB15U,
			0xE9BD00BU,
			0x4A682171U,
			0x711E200CU,
			0xD908F791U,
			0x265D8C03U,
			0xAE4B1B57U,
			0xF460A0A9U,
			0xBAF902FFU,
			0xD6BA2EFU,
			0x9A705C7EU,
			0x846A6C7EU,
			0x196E07B7U,
			0xA372CF26U,
			0x7C3B90B7U,
			0xF3DEE1E3U,
			0xDCA6748EU,
			0x7A901EE0U,
			0x9584CC83U,
			0x3FC4AEDAU,
			0x6657ED0FU,
			0x7BC8E666U,
			0x5D186D67U,
			0x37A0CDB9U,
			0x699FCCF6U,
			0xC58D0C4FU,
			0xE143A3D3U,
			0x62F5BD79U,
			0x294994D1U,
			0x8911E17U,
			0xF5343976U,
			0x3FF125E1U,
			0xC95CA7D9U,
			0x33F8D49FU,
			0x10EF5E16U,
			0x3B30D5C2U,
			0x3687EAB3U,
			0x3BAF713BU,
			0x97ECFB27U,
			0x4FC21645U,
			0x40FA3298U,
			0x6AF0D7U,
			0x1D072F5BU,
			0xDC849870U,
			0xA110C37CU,
			0x2F11273BU,
			0x312344C5U,
			0x724372E9U,
			0xC6BFF1EFU,
			0x447D81BEU,
			0x28A87DE5U,
			0x3C058CF0U,
			0x697C05FU,
			0x6C0AF4C6U,
			0x6723282CU,
			0x40A65194U,
			0xB27A9766U,
			0x3779C639U,
			0x74863903U,
			0x26D31C8BU,
			0xCAF5893EU,
			0x62A2EF94U,
			0x224A8F20U,
			0xFA88C5B4U,
			0x722BC77CU,
			0x24618170U,
			0x2935B10BU,
			0x49F9E8C6U,
			0x3ED7C601U,
			0x4F74B851U,
			0x99DF3F8DU,
			0xE47994D9U,
			0xB296E8DEU,
			0x3779C639U,
			0x74863903U
		};
		uint[] array2 = new uint[0x10];
		uint num2 = 0x251DF0C9U;
		for (int i = 0; i < 0x10; i++)
		{
			num2 ^= num2 >> 0xC;
			num2 ^= num2 << 0x19;
			num2 ^= num2 >> 0x1B;
			array2[i] = num2;
		}
		int num3 = 0;
		int num4 = 0;
		uint[] array3 = new uint[0x10];
		byte[] array4 = new byte[num * 4U];
		while ((long)num3 < (long)((ulong)num))
		{
			for (int j = 0; j < 0x10; j++)
			{
				array3[j] = array[num3 + j];
			}
			array3[0] = (array3[0] ^ array2[0]);
			array3[1] = (array3[1] ^ array2[1]);
			array3[2] = (array3[2] ^ array2[2]);
			array3[3] = (array3[3] ^ array2[3]);
			array3[4] = (array3[4] ^ array2[4]);
			array3[5] = (array3[5] ^ array2[5]);
			array3[6] = (array3[6] ^ array2[6]);
			array3[7] = (array3[7] ^ array2[7]);
			array3[8] = (array3[8] ^ array2[8]);
			array3[9] = (array3[9] ^ array2[9]);
			array3[0xA] = (array3[0xA] ^ array2[0xA]);
			array3[0xB] = (array3[0xB] ^ array2[0xB]);
			array3[0xC] = (array3[0xC] ^ array2[0xC]);
			array3[0xD] = (array3[0xD] ^ array2[0xD]);
			array3[0xE] = (array3[0xE] ^ array2[0xE]);
			array3[0xF] = (array3[0xF] ^ array2[0xF]);
			for (int k = 0; k < 0x10; k++)
			{
				uint num5 = array3[k];
				array4[num4++] = (byte)num5;
				array4[num4++] = (byte)(num5 >> 8);
				array4[num4++] = (byte)(num5 >> 0x10);
				array4[num4++] = (byte)(num5 >> 0x18);
				array2[k] ^= num5;
			}
			num3 += 0x10;
		}
		global::<Module>.byte_0 = global::<Module>.smethod_3(array4);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002E4C File Offset: 0x0000104C
	internal static T smethod_5<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x1D8F1CEBU ^ 0x8789E2BAU);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num == 0UL)
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		else if ((ulong)num == 1UL)
		{
			T[] array = new T[1];
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array, 0, sizeof(T));
			result = array[0];
		}
		else if ((ulong)num == 2UL)
		{
			int num2 = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			int length = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			global::System.Array array2 = global::System.Array.CreateInstance(typeof(T).GetElementType(), length);
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array2, 0, num2 - 4);
			result = (T)((object)array2);
		}
		return result;
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002FEC File Offset: 0x000011EC
	internal static T smethod_6<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x62EDEEA3U ^ 0x687B110BU);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num == 2UL)
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		else if ((ulong)num == 1UL)
		{
			T[] array = new T[1];
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array, 0, sizeof(T));
			result = array[0];
		}
		else if ((ulong)num == 0UL)
		{
			int num2 = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			int length = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			global::System.Array array2 = global::System.Array.CreateInstance(typeof(T).GetElementType(), length);
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array2, 0, num2 - 4);
			result = (T)((object)array2);
		}
		return result;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x0000318C File Offset: 0x0000138C
	internal static T smethod_7<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x2FC1457DU ^ 0x7F92EFCEU);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num != 1UL)
		{
			if ((ulong)num == 2UL)
			{
				T[] array = new T[1];
				global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array, 0, sizeof(T));
				result = array[0];
			}
			else if ((ulong)num == 0UL)
			{
				int num2 = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
				int length = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
				global::System.Array array2 = global::System.Array.CreateInstance(typeof(T).GetElementType(), length);
				global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array2, 0, num2 - 4);
				result = (T)((object)array2);
			}
		}
		else
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		return result;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000332C File Offset: 0x0000152C
	internal static T smethod_8<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x1FB7436FU ^ 0xDF6E6423U);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num == 2UL)
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		else if ((ulong)num != 0UL)
		{
			if ((ulong)num == 1UL)
			{
				int num2 = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
				int length = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
				global::System.Array array = global::System.Array.CreateInstance(typeof(T).GetElementType(), length);
				global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array, 0, num2 - 4);
				result = (T)((object)array);
			}
		}
		else
		{
			T[] array2 = new T[1];
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array2, 0, sizeof(T));
			result = array2[0];
		}
		return result;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000034CC File Offset: 0x000016CC
	internal static T smethod_9<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x3636072DU ^ 0x47BE03D5U);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num == 0UL)
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		else if ((ulong)num == 1UL)
		{
			T[] array = new T[1];
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array, 0, sizeof(T));
			result = array[0];
		}
		else if ((ulong)num == 2UL)
		{
			int num2 = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			int length = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			global::System.Array array2 = global::System.Array.CreateInstance(typeof(T).GetElementType(), length);
			global::System.Buffer.BlockCopy(global::<Module>.byte_0, (int)uint_0, array2, 0, num2 - 4);
			result = (T)((object)array2);
		}
		return result;
	}

	// Token: 0x06000029 RID: 41
	[global::System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
	internal static extern bool VirtualProtect_1(global::System.IntPtr intptr_0, uint uint_0, uint uint_1, ref uint uint_2);

	// Token: 0x0600002A RID: 42 RVA: 0x0000366C File Offset: 0x0000186C
	internal unsafe static void smethod_10()
	{
		global::System.Reflection.Module module = typeof(global::<Module>).Module;
		string fullyQualifiedName = module.FullyQualifiedName;
		bool flag = fullyQualifiedName.Length > 0 && fullyQualifiedName[0] == '<';
		byte* ptr = (byte*)((void*)global::System.Runtime.InteropServices.Marshal.GetHINSTANCE(module));
		byte* ptr2 = ptr + *(uint*)(ptr + 0x3C);
		ushort num = *(ushort*)(ptr2 + 6);
		ushort num2 = *(ushort*)(ptr2 + 0x14);
		uint* ptr3 = null;
		uint num3 = 0U;
		uint* ptr4 = (uint*)(ptr2 + 0x18 + num2);
		uint num4 = 0xFB9E0193U;
		uint num5 = 0x76529F95U;
		uint num6 = 0xB49502BBU;
		uint num7 = 0x4E5AF2AU;
		for (int i = 0; i < (int)num; i++)
		{
			uint num8 = *(ptr4++) * *(ptr4++);
			if (num8 == 0x210838C4U)
			{
				ptr3 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]) / 4U);
				num3 = (flag ? ptr4[2] : (*ptr4)) >> 2;
			}
			else if (num8 != 0U)
			{
				uint* ptr5 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]) / 4U);
				uint num9 = ptr4[2] >> 2;
				for (uint num10 = 0U; num10 < num9; num10 += 1U)
				{
					uint num11 = (num4 ^ *(ptr5++)) + num5 + num6 * num7;
					num4 = num5;
					num5 = num7;
					num7 = num11;
				}
			}
			ptr4 += 8;
		}
		uint[] array = new uint[0x10];
		uint[] array2 = new uint[0x10];
		for (int j = 0; j < 0x10; j++)
		{
			array[j] = num7;
			array2[j] = num5;
			num4 = (num5 >> 5 | num5 << 0x1B);
			num5 = (num6 >> 3 | num6 << 0x1D);
			num6 = (num7 >> 7 | num7 << 0x19);
			num7 = (num4 >> 0xB | num4 << 0x15);
		}
		array[0] = (array[0] ^ array2[0]);
		array[1] = array[1] * array2[1];
		array[2] = array[2] + array2[2];
		array[3] = (array[3] ^ array2[3]);
		array[4] = array[4] * array2[4];
		array[5] = array[5] + array2[5];
		array[6] = (array[6] ^ array2[6]);
		array[7] = array[7] * array2[7];
		array[8] = array[8] + array2[8];
		array[9] = (array[9] ^ array2[9]);
		array[0xA] = array[0xA] * array2[0xA];
		array[0xB] = array[0xB] + array2[0xB];
		array[0xC] = (array[0xC] ^ array2[0xC]);
		array[0xD] = array[0xD] * array2[0xD];
		array[0xE] = array[0xE] + array2[0xE];
		array[0xF] = (array[0xF] ^ array2[0xF]);
		uint num12 = 0x40U;
		global::<Module>.VirtualProtect_1((global::System.IntPtr)((void*)ptr3), num3 << 2, 0x40U, ref num12);
		if (num12 != 0x40U)
		{
			uint num13 = 0U;
			for (uint num14 = 0U; num14 < num3; num14 += 1U)
			{
				*ptr3 ^= array[(int)((global::System.UIntPtr)(num13 & 0xFU))];
				array[(int)((global::System.UIntPtr)(num13 & 0xFU))] = (array[(int)((global::System.UIntPtr)(num13 & 0xFU))] ^ *(ptr3++)) + 0x3DBB2819U;
				num13 += 1U;
			}
			return;
		}
	}

	// Token: 0x04000001 RID: 1
	internal static byte[] byte_0;

	// Token: 0x04000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
	internal static global::<Module>.Struct4 struct4_0;

	// Token: 0x02000002 RID: 2
	internal struct Struct0
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00003974 File Offset: 0x00001B74
		internal void method_0()
		{
			this.uint_0 = 0x400U;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000398C File Offset: 0x00001B8C
		internal uint method_1(global::<Module>.Class0 class0_0)
		{
			uint num = (class0_0.uint_1 >> 0xB) * this.uint_0;
			if (class0_0.uint_0 < num)
			{
				class0_0.uint_1 = num;
				this.uint_0 += 0x800U - this.uint_0 >> 5;
				if (class0_0.uint_1 < 0x1000000U)
				{
					class0_0.uint_0 = (class0_0.uint_0 << 8 | (uint)((byte)class0_0.stream_0.ReadByte()));
					class0_0.uint_1 <<= 8;
				}
				return 0U;
			}
			class0_0.uint_1 -= num;
			class0_0.uint_0 -= num;
			this.uint_0 -= this.uint_0 >> 5;
			if (class0_0.uint_1 < 0x1000000U)
			{
				class0_0.uint_0 = (class0_0.uint_0 << 8 | (uint)((byte)class0_0.stream_0.ReadByte()));
				class0_0.uint_1 <<= 8;
			}
			return 1U;
		}

		// Token: 0x04000003 RID: 3
		internal uint uint_0;
	}

	// Token: 0x02000003 RID: 3
	internal struct Struct1
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00003A78 File Offset: 0x00001C78
		internal Struct1(int int_1)
		{
			this.int_0 = int_1;
			this.struct0_0 = new global::<Module>.Struct0[1 << int_1];
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003AA0 File Offset: 0x00001CA0
		internal void method_0()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.int_0 & 0x1F)))
			{
				this.struct0_0[(int)((global::System.UIntPtr)num)].method_0();
				num += 1U;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003AD8 File Offset: 0x00001CD8
		internal uint method_1(global::<Module>.Class0 class0_0)
		{
			uint num = 1U;
			for (int i = this.int_0; i > 0; i--)
			{
				num = (num << 1) + this.struct0_0[(int)((global::System.UIntPtr)num)].method_1(class0_0);
			}
			return num - (1U << this.int_0);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003B20 File Offset: 0x00001D20
		internal uint method_2(global::<Module>.Class0 class0_0)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < this.int_0; i++)
			{
				uint num3 = this.struct0_0[(int)((global::System.UIntPtr)num)].method_1(class0_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003B68 File Offset: 0x00001D68
		internal static uint smethod_0(global::<Module>.Struct0[] struct0_1, uint uint_0, global::<Module>.Class0 class0_0, int int_1)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < int_1; i++)
			{
				uint num3 = struct0_1[(int)((global::System.UIntPtr)(uint_0 + num))].method_1(class0_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x04000004 RID: 4
		internal readonly global::<Module>.Struct0[] struct0_0;

		// Token: 0x04000005 RID: 5
		internal readonly int int_0;
	}

	// Token: 0x02000004 RID: 4
	internal class Class0
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00003BA8 File Offset: 0x00001DA8
		internal void method_0(global::System.IO.Stream stream_1)
		{
			this.stream_0 = stream_1;
			this.uint_0 = 0U;
			this.uint_1 = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.uint_0 = (this.uint_0 << 8 | (uint)((byte)this.stream_0.ReadByte()));
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003BF4 File Offset: 0x00001DF4
		internal void method_1()
		{
			this.stream_0 = null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003C08 File Offset: 0x00001E08
		internal void method_2()
		{
			while (this.uint_1 < 0x1000000U)
			{
				this.uint_0 = (this.uint_0 << 8 | (uint)((byte)this.stream_0.ReadByte()));
				this.uint_1 <<= 8;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003C50 File Offset: 0x00001E50
		internal uint method_3(int int_0)
		{
			uint num = this.uint_1;
			uint num2 = this.uint_0;
			uint num3 = 0U;
			for (int i = int_0; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 0x1F;
				num2 -= (num & num4 - 1U);
				num3 = (num3 << 1 | 1U - num4);
				if (num < 0x1000000U)
				{
					num2 = (num2 << 8 | (uint)((byte)this.stream_0.ReadByte()));
					num <<= 8;
				}
			}
			this.uint_1 = num;
			this.uint_0 = num2;
			return num3;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003CC4 File Offset: 0x00001EC4
		internal Class0()
		{
		}

		// Token: 0x04000006 RID: 6
		internal uint uint_0;

		// Token: 0x04000007 RID: 7
		internal uint uint_1;

		// Token: 0x04000008 RID: 8
		internal global::System.IO.Stream stream_0;
	}

	// Token: 0x02000005 RID: 5
	internal class Class1
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00003CD8 File Offset: 0x00001ED8
		internal Class1()
		{
			this.uint_0 = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.struct1_0[num] = new global::<Module>.Struct1(6);
				num++;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003DD8 File Offset: 0x00001FD8
		internal void method_0(uint uint_3)
		{
			if (this.uint_0 != uint_3)
			{
				this.uint_0 = uint_3;
				this.uint_1 = global::System.Math.Max(this.uint_0, 1U);
				uint uint_4 = global::System.Math.Max(this.uint_1, 0x1000U);
				this.class4_0.method_0(uint_4);
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003E24 File Offset: 0x00002024
		internal void method_1(int int_0, int int_1)
		{
			this.class3_0.method_0(int_0, int_1);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003E40 File Offset: 0x00002040
		internal void method_2(int int_0)
		{
			uint num = 1U << int_0;
			this.class2_0.method_0(num);
			this.class2_1.method_0(num);
			this.uint_2 = num - 1U;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003E78 File Offset: 0x00002078
		internal void method_3(global::System.IO.Stream stream_0, global::System.IO.Stream stream_1)
		{
			this.class0_0.method_0(stream_0);
			this.class4_0.method_1(stream_1, this.bool_0);
			for (uint num = 0U; num < 0xCU; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this.uint_2; num2 += 1U)
				{
					uint num3 = (num << 4) + num2;
					this.struct0_0[(int)((global::System.UIntPtr)num3)].method_0();
					this.struct0_1[(int)((global::System.UIntPtr)num3)].method_0();
				}
				this.struct0_2[(int)((global::System.UIntPtr)num)].method_0();
				this.struct0_3[(int)((global::System.UIntPtr)num)].method_0();
				this.struct0_4[(int)((global::System.UIntPtr)num)].method_0();
				this.struct0_5[(int)((global::System.UIntPtr)num)].method_0();
			}
			this.class3_0.method_1();
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this.struct1_0[(int)((global::System.UIntPtr)num)].method_0();
			}
			for (uint num = 0U; num < 0x72U; num += 1U)
			{
				this.struct0_6[(int)((global::System.UIntPtr)num)].method_0();
			}
			this.class2_0.method_1();
			this.class2_1.method_1();
			this.struct1_1.method_0();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003FA4 File Offset: 0x000021A4
		internal void method_4(global::System.IO.Stream stream_0, global::System.IO.Stream stream_1, long long_0, long long_1)
		{
			this.method_3(stream_0, stream_1);
			global::<Module>.Struct3 @struct = default(global::<Module>.Struct3);
			@struct.method_0();
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			ulong num5 = 0UL;
			if (0L < long_1)
			{
				this.struct0_0[(int)((global::System.UIntPtr)(@struct.uint_0 << 4))].method_1(this.class0_0);
				@struct.method_1();
				byte byte_ = this.class3_0.method_3(this.class0_0, 0U, 0);
				this.class4_0.method_5(byte_);
				num5 += 1UL;
			}
			while (num5 < (ulong)long_1)
			{
				uint num6 = (uint)num5 & this.uint_2;
				if (this.struct0_0[(int)((global::System.UIntPtr)((@struct.uint_0 << 4) + num6))].method_1(this.class0_0) != 0U)
				{
					uint num7;
					if (this.struct0_2[(int)((global::System.UIntPtr)@struct.uint_0)].method_1(this.class0_0) != 1U)
					{
						num4 = num3;
						num3 = num2;
						num2 = num;
						num7 = 2U + this.class2_0.method_2(this.class0_0, num6);
						@struct.method_2();
						uint num8 = this.struct1_0[(int)((global::System.UIntPtr)global::<Module>.Class1.smethod_0(num7))].method_1(this.class0_0);
						if (num8 < 4U)
						{
							num = num8;
						}
						else
						{
							int num9 = (int)((num8 >> 1) - 1U);
							num = (2U | (num8 & 1U)) << num9;
							if (num8 < 0xEU)
							{
								num += global::<Module>.Struct1.smethod_0(this.struct0_6, num - num8 - 1U, this.class0_0, num9);
							}
							else
							{
								num += this.class0_0.method_3(num9 - 4) << 4;
								num += this.struct1_1.method_2(this.class0_0);
							}
						}
					}
					else
					{
						if (this.struct0_3[(int)((global::System.UIntPtr)@struct.uint_0)].method_1(this.class0_0) == 0U)
						{
							if (this.struct0_1[(int)((global::System.UIntPtr)((@struct.uint_0 << 4) + num6))].method_1(this.class0_0) == 0U)
							{
								@struct.method_4();
								this.class4_0.method_5(this.class4_0.method_6(num));
								num5 += 1UL;
								continue;
							}
						}
						else
						{
							uint num10;
							if (this.struct0_4[(int)((global::System.UIntPtr)@struct.uint_0)].method_1(this.class0_0) == 0U)
							{
								num10 = num2;
							}
							else
							{
								if (this.struct0_5[(int)((global::System.UIntPtr)@struct.uint_0)].method_1(this.class0_0) == 0U)
								{
									num10 = num3;
								}
								else
								{
									num10 = num4;
									num4 = num3;
								}
								num3 = num2;
							}
							num2 = num;
							num = num10;
						}
						num7 = this.class2_1.method_2(this.class0_0, num6) + 2U;
						@struct.method_3();
					}
					if (((ulong)num >= num5 || num >= this.uint_1) && num == 0xFFFFFFFFU)
					{
						break;
					}
					this.class4_0.method_4(num, num7);
					num5 += (ulong)num7;
				}
				else
				{
					byte byte_2 = this.class4_0.method_6(0U);
					byte byte_3;
					if (@struct.method_5())
					{
						byte_3 = this.class3_0.method_3(this.class0_0, (uint)num5, byte_2);
					}
					else
					{
						byte_3 = this.class3_0.method_4(this.class0_0, (uint)num5, byte_2, this.class4_0.method_6(num));
					}
					this.class4_0.method_5(byte_3);
					@struct.method_1();
					num5 += 1UL;
				}
			}
			this.class4_0.method_3();
			this.class4_0.method_2();
			this.class0_0.method_1();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004320 File Offset: 0x00002520
		internal void method_5(byte[] byte_0)
		{
			int int_ = (int)(byte_0[0] % 9);
			int num = (int)(byte_0[0] / 9);
			int int_2 = num % 5;
			int int_3 = num / 5;
			uint num2 = 0U;
			for (int i = 0; i < 4; i++)
			{
				num2 += (uint)((uint)byte_0[1 + i] << i * 8);
			}
			this.method_0(num2);
			this.method_1(int_2, int_);
			this.method_2(int_3);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004380 File Offset: 0x00002580
		internal static uint smethod_0(uint uint_3)
		{
			uint_3 -= 2U;
			if (uint_3 < 4U)
			{
				return uint_3;
			}
			return 3U;
		}

		// Token: 0x04000009 RID: 9
		internal readonly global::<Module>.Struct0[] struct0_0 = new global::<Module>.Struct0[0xC0];

		// Token: 0x0400000A RID: 10
		internal readonly global::<Module>.Struct0[] struct0_1 = new global::<Module>.Struct0[0xC0];

		// Token: 0x0400000B RID: 11
		internal readonly global::<Module>.Struct0[] struct0_2 = new global::<Module>.Struct0[0xC];

		// Token: 0x0400000C RID: 12
		internal readonly global::<Module>.Struct0[] struct0_3 = new global::<Module>.Struct0[0xC];

		// Token: 0x0400000D RID: 13
		internal readonly global::<Module>.Struct0[] struct0_4 = new global::<Module>.Struct0[0xC];

		// Token: 0x0400000E RID: 14
		internal readonly global::<Module>.Struct0[] struct0_5 = new global::<Module>.Struct0[0xC];

		// Token: 0x0400000F RID: 15
		internal readonly global::<Module>.Class1.Class2 class2_0 = new global::<Module>.Class1.Class2();

		// Token: 0x04000010 RID: 16
		internal readonly global::<Module>.Class1.Class3 class3_0 = new global::<Module>.Class1.Class3();

		// Token: 0x04000011 RID: 17
		internal readonly global::<Module>.Class4 class4_0 = new global::<Module>.Class4();

		// Token: 0x04000012 RID: 18
		internal readonly global::<Module>.Struct0[] struct0_6 = new global::<Module>.Struct0[0x72];

		// Token: 0x04000013 RID: 19
		internal readonly global::<Module>.Struct1[] struct1_0 = new global::<Module>.Struct1[4];

		// Token: 0x04000014 RID: 20
		internal readonly global::<Module>.Class0 class0_0 = new global::<Module>.Class0();

		// Token: 0x04000015 RID: 21
		internal readonly global::<Module>.Class1.Class2 class2_1 = new global::<Module>.Class1.Class2();

		// Token: 0x04000016 RID: 22
		internal bool bool_0;

		// Token: 0x04000017 RID: 23
		internal uint uint_0;

		// Token: 0x04000018 RID: 24
		internal uint uint_1;

		// Token: 0x04000019 RID: 25
		internal global::<Module>.Struct1 struct1_1 = new global::<Module>.Struct1(4);

		// Token: 0x0400001A RID: 26
		internal uint uint_2;

		// Token: 0x02000006 RID: 6
		internal class Class2
		{
			// Token: 0x0600003F RID: 63 RVA: 0x0000439C File Offset: 0x0000259C
			internal void method_0(uint uint_1)
			{
				for (uint num = this.uint_0; num < uint_1; num += 1U)
				{
					this.struct1_0[(int)((global::System.UIntPtr)num)] = new global::<Module>.Struct1(3);
					this.struct1_1[(int)((global::System.UIntPtr)num)] = new global::<Module>.Struct1(3);
				}
				this.uint_0 = uint_1;
			}

			// Token: 0x06000040 RID: 64 RVA: 0x000043F4 File Offset: 0x000025F4
			internal void method_1()
			{
				this.struct0_0.method_0();
				for (uint num = 0U; num < this.uint_0; num += 1U)
				{
					this.struct1_0[(int)((global::System.UIntPtr)num)].method_0();
					this.struct1_1[(int)((global::System.UIntPtr)num)].method_0();
				}
				this.struct0_1.method_0();
				this.struct1_2.method_0();
			}

			// Token: 0x06000041 RID: 65 RVA: 0x00004458 File Offset: 0x00002658
			internal uint method_2(global::<Module>.Class0 class0_0, uint uint_1)
			{
				if (this.struct0_0.method_1(class0_0) == 0U)
				{
					return this.struct1_0[(int)((global::System.UIntPtr)uint_1)].method_1(class0_0);
				}
				uint num = 8U;
				if (this.struct0_1.method_1(class0_0) != 0U)
				{
					num += 8U;
					num += this.struct1_2.method_1(class0_0);
				}
				else
				{
					num += this.struct1_1[(int)((global::System.UIntPtr)uint_1)].method_1(class0_0);
				}
				return num;
			}

			// Token: 0x06000042 RID: 66 RVA: 0x000044C4 File Offset: 0x000026C4
			internal Class2()
			{
			}

			// Token: 0x0400001B RID: 27
			internal readonly global::<Module>.Struct1[] struct1_0 = new global::<Module>.Struct1[0x10];

			// Token: 0x0400001C RID: 28
			internal readonly global::<Module>.Struct1[] struct1_1 = new global::<Module>.Struct1[0x10];

			// Token: 0x0400001D RID: 29
			internal global::<Module>.Struct0 struct0_0 = default(global::<Module>.Struct0);

			// Token: 0x0400001E RID: 30
			internal global::<Module>.Struct0 struct0_1 = default(global::<Module>.Struct0);

			// Token: 0x0400001F RID: 31
			internal global::<Module>.Struct1 struct1_2 = new global::<Module>.Struct1(8);

			// Token: 0x04000020 RID: 32
			internal uint uint_0;
		}

		// Token: 0x02000007 RID: 7
		internal class Class3
		{
			// Token: 0x06000043 RID: 67 RVA: 0x00004518 File Offset: 0x00002718
			internal void method_0(int int_2, int int_3)
			{
				if (this.struct2_0 != null && this.int_1 == int_3 && this.int_0 == int_2)
				{
					return;
				}
				this.int_0 = int_2;
				this.uint_0 = (1U << int_2) - 1U;
				this.int_1 = int_3;
				uint num = 1U << this.int_1 + this.int_0;
				this.struct2_0 = new global::<Module>.Class1.Class3.Struct2[num];
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((global::System.UIntPtr)num2)].method_0();
				}
			}

			// Token: 0x06000044 RID: 68 RVA: 0x0000459C File Offset: 0x0000279C
			internal void method_1()
			{
				uint num = 1U << this.int_1 + this.int_0;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((global::System.UIntPtr)num2)].method_1();
				}
			}

			// Token: 0x06000045 RID: 69 RVA: 0x000045DC File Offset: 0x000027DC
			internal uint method_2(uint uint_1, byte byte_0)
			{
				return ((uint_1 & this.uint_0) << this.int_1) + (uint)(byte_0 >> 8 - this.int_1);
			}

			// Token: 0x06000046 RID: 70 RVA: 0x0000460C File Offset: 0x0000280C
			internal byte method_3(global::<Module>.Class0 class0_0, uint uint_1, byte byte_0)
			{
				return this.struct2_0[(int)((global::System.UIntPtr)this.method_2(uint_1, byte_0))].method_2(class0_0);
			}

			// Token: 0x06000047 RID: 71 RVA: 0x00004634 File Offset: 0x00002834
			internal byte method_4(global::<Module>.Class0 class0_0, uint uint_1, byte byte_0, byte byte_1)
			{
				return this.struct2_0[(int)((global::System.UIntPtr)this.method_2(uint_1, byte_0))].method_3(class0_0, byte_1);
			}

			// Token: 0x06000048 RID: 72 RVA: 0x00003CC4 File Offset: 0x00001EC4
			internal Class3()
			{
			}

			// Token: 0x04000021 RID: 33
			internal global::<Module>.Class1.Class3.Struct2[] struct2_0;

			// Token: 0x04000022 RID: 34
			internal int int_0;

			// Token: 0x04000023 RID: 35
			internal int int_1;

			// Token: 0x04000024 RID: 36
			internal uint uint_0;

			// Token: 0x02000008 RID: 8
			internal struct Struct2
			{
				// Token: 0x06000049 RID: 73 RVA: 0x00004660 File Offset: 0x00002860
				internal void method_0()
				{
					this.struct0_0 = new global::<Module>.Struct0[0x300];
				}

				// Token: 0x0600004A RID: 74 RVA: 0x00004680 File Offset: 0x00002880
				internal void method_1()
				{
					for (int i = 0; i < 0x300; i++)
					{
						this.struct0_0[i].method_0();
					}
				}

				// Token: 0x0600004B RID: 75 RVA: 0x000046B0 File Offset: 0x000028B0
				internal byte method_2(global::<Module>.Class0 class0_0)
				{
					uint num = 1U;
					do
					{
						num = (num << 1 | this.struct0_0[(int)((global::System.UIntPtr)num)].method_1(class0_0));
					}
					while (num < 0x100U);
					return (byte)num;
				}

				// Token: 0x0600004C RID: 76 RVA: 0x000046E4 File Offset: 0x000028E4
				internal byte method_3(global::<Module>.Class0 class0_0, byte byte_0)
				{
					uint num = 1U;
					for (;;)
					{
						uint num2 = (uint)(byte_0 >> 7 & 1);
						byte_0 = (byte)(byte_0 << 1);
						uint num3 = this.struct0_0[(int)((global::System.UIntPtr)((1U + num2 << 8) + num))].method_1(class0_0);
						num = (num << 1 | num3);
						if (num2 != num3)
						{
							break;
						}
						if (num >= 0x100U)
						{
							goto IL_5E;
						}
					}
					while (num < 0x100U)
					{
						num = (num << 1 | this.struct0_0[(int)((global::System.UIntPtr)num)].method_1(class0_0));
					}
					IL_5E:
					return (byte)num;
				}

				// Token: 0x04000025 RID: 37
				internal global::<Module>.Struct0[] struct0_0;
			}
		}
	}

	// Token: 0x02000009 RID: 9
	internal class Class4
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00004754 File Offset: 0x00002954
		internal void method_0(uint uint_3)
		{
			if (this.uint_2 != uint_3)
			{
				this.byte_0 = new byte[uint_3];
			}
			this.uint_2 = uint_3;
			this.uint_0 = 0U;
			this.uint_1 = 0U;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000478C File Offset: 0x0000298C
		internal void method_1(global::System.IO.Stream stream_1, bool bool_0)
		{
			this.method_2();
			this.stream_0 = stream_1;
			if (!bool_0)
			{
				this.uint_1 = 0U;
				this.uint_0 = 0U;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000047B8 File Offset: 0x000029B8
		internal void method_2()
		{
			this.method_3();
			this.stream_0 = null;
			global::System.Buffer.BlockCopy(new byte[this.byte_0.Length], 0, this.byte_0, 0, this.byte_0.Length);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000047F4 File Offset: 0x000029F4
		internal void method_3()
		{
			uint num = this.uint_0 - this.uint_1;
			if (num == 0U)
			{
				return;
			}
			this.stream_0.Write(this.byte_0, (int)this.uint_1, (int)num);
			if (this.uint_0 >= this.uint_2)
			{
				this.uint_0 = 0U;
			}
			this.uint_1 = this.uint_0;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000484C File Offset: 0x00002A4C
		internal void method_4(uint uint_3, uint uint_4)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			while (uint_4 > 0U)
			{
				if (num >= this.uint_2)
				{
					num = 0U;
				}
				this.byte_0[(int)((global::System.UIntPtr)(this.uint_0++))] = this.byte_0[(int)((global::System.UIntPtr)(num++))];
				if (this.uint_0 >= this.uint_2)
				{
					this.method_3();
				}
				uint_4 -= 1U;
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000048C8 File Offset: 0x00002AC8
		internal void method_5(byte byte_1)
		{
			this.byte_0[(int)((global::System.UIntPtr)(this.uint_0++))] = byte_1;
			if (this.uint_0 >= this.uint_2)
			{
				this.method_3();
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004904 File Offset: 0x00002B04
		internal byte method_6(uint uint_3)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			return this.byte_0[(int)((global::System.UIntPtr)num)];
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003CC4 File Offset: 0x00001EC4
		internal Class4()
		{
		}

		// Token: 0x04000026 RID: 38
		internal byte[] byte_0;

		// Token: 0x04000027 RID: 39
		internal uint uint_0;

		// Token: 0x04000028 RID: 40
		internal global::System.IO.Stream stream_0;

		// Token: 0x04000029 RID: 41
		internal uint uint_1;

		// Token: 0x0400002A RID: 42
		internal uint uint_2;
	}

	// Token: 0x0200000A RID: 10
	internal struct Struct3
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00004938 File Offset: 0x00002B38
		internal void method_0()
		{
			this.uint_0 = 0U;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000494C File Offset: 0x00002B4C
		internal void method_1()
		{
			if (this.uint_0 < 4U)
			{
				this.uint_0 = 0U;
				return;
			}
			if (this.uint_0 < 0xAU)
			{
				this.uint_0 -= 3U;
				return;
			}
			this.uint_0 -= 6U;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004994 File Offset: 0x00002B94
		internal void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 0xAU);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000049B8 File Offset: 0x00002BB8
		internal void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 0xBU);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000049DC File Offset: 0x00002BDC
		internal void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 0xBU);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004A00 File Offset: 0x00002C00
		internal bool method_5()
		{
			return this.uint_0 < 7U;
		}

		// Token: 0x0400002B RID: 43
		internal uint uint_0;
	}

	// Token: 0x0200000B RID: 11
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x3C0)]
	internal struct Struct4
	{
	}
}
