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
	// Token: 0x06000001 RID: 1 RVA: 0x00002490 File Offset: 0x00000690
	static <Module>()
	{
		global::<Module>.smethod_4();
		global::<Module>.smethod_2();
		global::<Module>.smethod_0();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000024AC File Offset: 0x000006AC
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

	// Token: 0x06000003 RID: 3 RVA: 0x00002544 File Offset: 0x00000744
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

	// Token: 0x06000005 RID: 5 RVA: 0x000025B8 File Offset: 0x000007B8
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
		uint num3;
		if (module.FullyQualifiedName[0] != '<')
		{
			byte* ptr4 = ptr + *(uint*)(ptr2 - 0x10);
			if (*(uint*)(ptr2 - 0x78) != 0U)
			{
				byte* ptr5 = ptr + *(uint*)(ptr2 - 0x78);
				byte* ptr6 = ptr + *(uint*)ptr5;
				byte* ptr7 = ptr + *(uint*)(ptr5 + 0xC);
				byte* ptr8 = ptr + *(uint*)ptr6 + 2;
				global::<Module>.VirtualProtect(ptr7, 0xB, 0x40U, ref num3);
				*(int*)ptr3 = 0x6C64746E;
				*(int*)(ptr3 + 4) = 0x6C642E6C;
				*(short*)(ptr3 + 8) = 0x6C;
				ptr3[0xA] = 0;
				for (int i = 0; i < 0xB; i++)
				{
					ptr7[i] = ptr3[i];
				}
				global::<Module>.VirtualProtect(ptr8, 0xB, 0x40U, ref num3);
				*(int*)ptr3 = 0x6F43744E;
				*(int*)(ptr3 + 4) = 0x6E69746E;
				*(short*)(ptr3 + 8) = 0x6575;
				ptr3[0xA] = 0;
				for (int j = 0; j < 0xB; j++)
				{
					ptr8[j] = ptr3[j];
				}
			}
			for (int k = 0; k < (int)num; k++)
			{
				global::<Module>.VirtualProtect(ptr2, 8, 0x40U, ref num3);
				global::System.Runtime.InteropServices.Marshal.Copy(new byte[8], 0, (global::System.IntPtr)((void*)ptr2), 8);
				ptr2 += 0x28;
			}
			global::<Module>.VirtualProtect(ptr4, 0x48, 0x40U, ref num3);
			byte* ptr9 = ptr + *(uint*)(ptr4 + 8);
			*(int*)ptr4 = 0;
			*(int*)(ptr4 + 4) = 0;
			*(int*)(ptr4 + 8) = 0;
			*(int*)(ptr4 + 0xC) = 0;
			global::<Module>.VirtualProtect(ptr9, 4, 0x40U, ref num3);
			*(int*)ptr9 = 0;
			ptr9 += 0xC;
			ptr9 += *(uint*)ptr9;
			ptr9 = (ptr9 + 7L & -4L);
			ptr9 += 2;
			ushort num4 = (ushort)(*ptr9);
			ptr9 += 2;
			int l = 0;
			IL_288:
			while (l < (int)num4)
			{
				global::<Module>.VirtualProtect(ptr9, 8, 0x40U, ref num3);
				ptr9 += 4;
				ptr9 += 4;
				int m = 0;
				while (m < 8)
				{
					global::<Module>.VirtualProtect(ptr9, 4, 0x40U, ref num3);
					*ptr9 = 0;
					ptr9++;
					if (*ptr9 != 0)
					{
						*ptr9 = 0;
						ptr9++;
						if (*ptr9 != 0)
						{
							*ptr9 = 0;
							ptr9++;
							if (*ptr9 != 0)
							{
								*ptr9 = 0;
								ptr9++;
								m++;
								continue;
							}
							ptr9++;
						}
						else
						{
							ptr9 += 2;
						}
					}
					else
					{
						ptr9 += 3;
					}
					IL_282:
					l++;
					goto IL_288;
				}
				goto IL_282;
			}
			return;
		}
		uint num5 = *(uint*)(ptr2 - 0x10);
		uint num6 = *(uint*)(ptr2 - 0x78);
		uint[] array = new uint[(int)num];
		uint[] array2 = new uint[(int)num];
		uint[] array3 = new uint[(int)num];
		for (int n = 0; n < (int)num; n++)
		{
			global::<Module>.VirtualProtect(ptr2, 8, 0x40U, ref num3);
			global::System.Runtime.InteropServices.Marshal.Copy(new byte[8], 0, (global::System.IntPtr)((void*)ptr2), 8);
			array[n] = *(uint*)(ptr2 + 0xC);
			array2[n] = *(uint*)(ptr2 + 8);
			array3[n] = *(uint*)(ptr2 + 0x14);
			ptr2 += 0x28;
		}
		if (num6 != 0U)
		{
			for (int num7 = 0; num7 < (int)num; num7++)
			{
				if (array[num7] <= num6 && num6 < array[num7] + array2[num7])
				{
					num6 = num6 - array[num7] + array3[num7];
					IL_355:
					byte* ptr10 = ptr + num6;
					uint num8 = *(uint*)ptr10;
					for (int num9 = 0; num9 < (int)num; num9++)
					{
						if (array[num9] <= num8 && num8 < array[num9] + array2[num9])
						{
							num8 = num8 - array[num9] + array3[num9];
							IL_39B:
							byte* ptr11 = ptr + num8;
							uint num10 = *(uint*)(ptr10 + 0xC);
							for (int num11 = 0; num11 < (int)num; num11++)
							{
								if (array[num11] <= num10 && num10 < array[num11] + array2[num11])
								{
									num10 = num10 - array[num11] + array3[num11];
									break;
								}
							}
							uint num12 = *(uint*)ptr11 + 2U;
							for (int num13 = 0; num13 < (int)num; num13++)
							{
								if (array[num13] <= num12 && num12 < array[num13] + array2[num13])
								{
									num12 = num12 - array[num13] + array3[num13];
									IL_427:
									global::<Module>.VirtualProtect(ptr + num10, 0xB, 0x40U, ref num3);
									*(int*)ptr3 = 0x6C64746E;
									*(int*)(ptr3 + 4) = 0x6C642E6C;
									*(short*)(ptr3 + 8) = 0x6C;
									ptr3[0xA] = 0;
									for (int num14 = 0; num14 < 0xB; num14++)
									{
										(ptr + num10)[num14] = ptr3[num14];
									}
									global::<Module>.VirtualProtect(ptr + num12, 0xB, 0x40U, ref num3);
									*(int*)ptr3 = 0x6F43744E;
									*(int*)(ptr3 + 4) = 0x6E69746E;
									*(short*)(ptr3 + 8) = 0x6575;
									ptr3[0xA] = 0;
									for (int num15 = 0; num15 < 0xB; num15++)
									{
										(ptr + num12)[num15] = ptr3[num15];
									}
									goto IL_4CE;
								}
							}
							goto IL_427;
						}
					}
					goto IL_39B;
				}
			}
			goto IL_355;
		}
		IL_4CE:
		for (int num16 = 0; num16 < (int)num; num16++)
		{
			if (array[num16] <= num5 && num5 < array[num16] + array2[num16])
			{
				num5 = num5 - array[num16] + array3[num16];
				break;
			}
		}
		byte* ptr12 = ptr + num5;
		global::<Module>.VirtualProtect(ptr12, 0x48, 0x40U, ref num3);
		uint num17 = *(uint*)(ptr12 + 8);
		for (int num18 = 0; num18 < (int)num; num18++)
		{
			if (array[num18] <= num17 && num17 < array[num18] + array2[num18])
			{
				num17 = num17 - array[num18] + array3[num18];
				IL_560:
				*(int*)ptr12 = 0;
				*(int*)(ptr12 + 4) = 0;
				*(int*)(ptr12 + 8) = 0;
				*(int*)(ptr12 + 0xC) = 0;
				byte* ptr13 = ptr + num17;
				global::<Module>.VirtualProtect(ptr13, 4, 0x40U, ref num3);
				*(int*)ptr13 = 0;
				ptr13 += 0xC;
				ptr13 += *(uint*)ptr13;
				ptr13 = (ptr13 + 7L & -4L);
				ptr13 += 2;
				ushort num19 = (ushort)(*ptr13);
				ptr13 += 2;
				int num20 = 0;
				IL_66A:
				while (num20 < (int)num19)
				{
					global::<Module>.VirtualProtect(ptr13, 8, 0x40U, ref num3);
					ptr13 += 4;
					ptr13 += 4;
					int num21 = 0;
					while (num21 < 8)
					{
						global::<Module>.VirtualProtect(ptr13, 4, 0x40U, ref num3);
						*ptr13 = 0;
						ptr13++;
						if (*ptr13 != 0)
						{
							*ptr13 = 0;
							ptr13++;
							if (*ptr13 != 0)
							{
								*ptr13 = 0;
								ptr13++;
								if (*ptr13 != 0)
								{
									*ptr13 = 0;
									ptr13++;
									num21++;
									continue;
								}
								ptr13++;
							}
							else
							{
								ptr13 += 2;
							}
						}
						else
						{
							ptr13 += 3;
						}
						IL_664:
						num20++;
						goto IL_66A;
					}
					goto IL_664;
				}
				return;
			}
		}
		goto IL_560;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002C38 File Offset: 0x00000E38
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

	// Token: 0x06000023 RID: 35 RVA: 0x00002CD0 File Offset: 0x00000ED0
	internal static void smethod_4()
	{
		uint num = 0x110U;
		uint[] array = new uint[]
		{
			0xEB12405U,
			0x1AB1DB49U,
			0xB0B864C3U,
			0xBAB26F42U,
			0xC3B6456U,
			0x46131EB3U,
			0xFAC1C7DU,
			0x4756B30FU,
			0xAB8B2D23U,
			0xF308D9CDU,
			0x24A24EFAU,
			0x4BE487D9U,
			0x1F06D685U,
			0xEDCE9082U,
			0x67786876U,
			0x13068772U,
			0x3214C8E3U,
			0x92D13655U,
			0xC8C6DCC2U,
			0x3E000419U,
			0x7C16FE91U,
			0x31645F26U,
			0x95A0DA69U,
			0xA47CC19DU,
			0xFB0E8455U,
			0x96327A4AU,
			0x96EFF3AAU,
			0x5A4D5ABFU,
			0x99617896U,
			0x74F3FB86U,
			0x7FB1CD99U,
			0xCB70F2E2U,
			0x4574B51AU,
			0xA04DECA0U,
			0x84D29A21U,
			0xFE375C2U,
			0x82982BF2U,
			0xDC8C985FU,
			0x72490C12U,
			0xBFB99871U,
			0x533D5ACEU,
			0x20DCDA47U,
			0xF7BB023CU,
			0x4D3BC601U,
			0xB696AECEU,
			0x4BC5313BU,
			0x7FC55926U,
			0x339F0D23U,
			0x80A9310AU,
			0x83E18B19U,
			0x86CB3E07U,
			0xAE99F89DU,
			0xA2AB9BABU,
			0xB9E7D920U,
			0xBA6083E6U,
			0xF71052F7U,
			0xFBAB06A3U,
			0x41657D0U,
			0x8A1F7A0U,
			0x462C0F0FU,
			0xF7EBB268U,
			0x95CB3F5AU,
			0x20A2350DU,
			0x9E2EEE0DU,
			0x5B6E97BU,
			0x33D2D16DU,
			0x65A1AB6BU,
			0x6C087DE8U,
			0xDACA7C52U,
			0x5A2FCE24U,
			0x4714387FU,
			0x7C62F8C2U,
			0x4593452U,
			0x44F74DAFU,
			0xE99AA91BU,
			0xB984A9F5U,
			0xC4898C5BU,
			0xA9D3BC3CU,
			0xAD0EE837U,
			0xAED423C1U,
			0x4754CF39U,
			0xBAEE783BU,
			0xF2DA5B05U,
			0xC52393CCU,
			0xD8856780U,
			0x7DA73D43U,
			0xDF6C6F07U,
			0x4C301F82U,
			0xA002D717U,
			0xF2D8B32CU,
			0x1F2AE22EU,
			0xDD418E56U,
			0x8943A6AEU,
			0x5DA10C34U,
			0x8B9EA96DU,
			0x64A5B30EU,
			0xE437FAB1U,
			0xAE4ADC84U,
			0xFFBCE968U,
			0xCE374050U,
			0xB505A9BDU,
			0x3050CECEU,
			0x692168ADU,
			0x3B03F733U,
			0xB0D84336U,
			0xB13AA4DEU,
			0xFA5E0B4DU,
			0x54384071U,
			0x1AEEA169U,
			0x208B0F25U,
			0x3452AA10U,
			0xC68AB050U,
			0xA236862BU,
			0x326314F6U,
			0x9EDF71D7U,
			0x8C0BB702U,
			0x8694AB1CU,
			0xC400797DU,
			0xA922A46CU,
			0xB340DF32U,
			0xA5416D2AU,
			0xA3D971ADU,
			0xF9F001B5U,
			0xD43D6F41U,
			0x2C60791DU,
			0x87D4843EU,
			0x884571DDU,
			0x2050FEA6U,
			0x50B76A6DU,
			0xC702F851U,
			0x883FE5CBU,
			0x4602E2C7U,
			0xBC70CDAU,
			0x6649B108U,
			0xB85D6896U,
			0x51384C6EU,
			0x10FED3A3U,
			0x1C0260DU,
			0x550B8922U,
			0xF23D2C6AU,
			0xBF44202FU,
			0x8231A98DU,
			0x69D97ADFU,
			0x794F064DU,
			0xAD1B3C2BU,
			0xE2B94D13U,
			0xA844EA74U,
			0xD65F3E56U,
			0x4C9CB8DU,
			0xF330FDC3U,
			0x19122A53U,
			0x321DA0CAU,
			0x5F7D3BB8U,
			0xA191538BU,
			0x57E4380AU,
			0x266615F1U,
			0xCF5ADB91U,
			0xF033AF2DU,
			0xEED8EB05U,
			0xF693CDECU,
			0xC384C7E2U,
			0x188BECDBU,
			0x1F0A738DU,
			0x54697225U,
			0xBC31D30AU,
			0xA3A7A20DU,
			0xA1AC0223U,
			0x56C62405U,
			0x80286A90U,
			0x60586024U,
			0x750574AEU,
			0xBB10F83CU,
			0x192DF7F1U,
			0x29D6CE26U,
			0x4E55901BU,
			0x5685F8BU,
			0x3BF4E9B7U,
			0x85C3EA4DU,
			0x3E127CECU,
			0xFFB2D144U,
			0xBE556F01U,
			0xA82BA2CEU,
			0x1FBB8D7AU,
			0xCC786E5U,
			0x47C31453U,
			0x76DCDF80U,
			0x34CBE0EBU,
			0xD2FD0578U,
			0x404066BDU,
			0xC6739C57U,
			0x328F12CEU,
			0x66328E3CU,
			0xFC83B3DDU,
			0x9FD5D95EU,
			0x7F5ACD0U,
			0xE1FC4762U,
			0xDDF8BA42U,
			0xAD98F8B9U,
			0xD425F1BEU,
			0x66661C4AU,
			0x114CC29DU,
			0xE3AC5BCEU,
			0xDE2D2506U,
			0xD6A41CE7U,
			0xD50918C8U,
			0x5C8114A4U,
			0x9D6C4AA0U,
			0x8D494E3DU,
			0x35FB1FB7U,
			0xBBE71B54U,
			0x1B71A197U,
			0x40DE5C14U,
			0x7FDE92B5U,
			0xB838D365U,
			0xE0444040U,
			0x415C302AU,
			0xA2011FDCU,
			0xA3D75731U,
			0x7B63BA2AU,
			0x5D100C05U,
			0xA1225F1AU,
			0x415772E9U,
			0xA52D7085U,
			0x2415A48CU,
			0x4DDD5B6EU,
			0xDCD71654U,
			0x183269F3U,
			0x782B24F8U,
			0x7A770381U,
			0xF88911E4U,
			0xEF21901BU,
			0xA82C9415U,
			0xA1621A0FU,
			0x8F19328BU,
			0x6D2FA26CU,
			0xCEF3ED23U,
			0x89610664U,
			0x34235277U,
			0x75A62E69U,
			0x6993E9F0U,
			0xDB17D50AU,
			0x799FF124U,
			0xF78CAD35U,
			0x899171FAU,
			0x2532D6E0U,
			0x65681C40U,
			0x42B8275DU,
			0xAB85F782U,
			0x959E2463U,
			0x160FDCA3U,
			0x1FF57DC1U,
			0xBA7E9434U,
			0x7EDF022U,
			0x390D8A27U,
			0xB11FF7CU,
			0xAD064500U,
			0xCCBA09ABU,
			0xD68EB26AU,
			0x58DBBB98U,
			0x3430FE2CU,
			0x20E9C630U,
			0x9C45FF8BU,
			0x2D0C0376U,
			0xD7E469DAU,
			0x18C79A7U,
			0x19A02B35U,
			0x13FC78C9U,
			0x99FFFA1CU,
			0xC3D71E90U,
			0xA6B3B219U,
			0xB11FF9EU,
			0xAD064500U
		};
		uint[] array2 = new uint[0x10];
		uint num2 = 0x1CB0EF47U;
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

	// Token: 0x06000024 RID: 36 RVA: 0x00002ECC File Offset: 0x000010CC
	internal static T smethod_5<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x2D785699U ^ 0xD0E135B2U);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num != 3UL)
		{
			if ((ulong)num != 2UL)
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
		}
		else
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		return result;
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00003070 File Offset: 0x00001270
	internal static T smethod_6<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x7BEC7877U ^ 0x2C096E19U);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num != 3UL)
		{
			if ((ulong)num == 1UL)
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
		}
		else
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		return result;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00003210 File Offset: 0x00001410
	internal static T smethod_7<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x4CE94EFDU ^ 0xAA741DD0U);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num != 2UL)
		{
			if ((ulong)num != 0UL)
			{
				if ((ulong)num == 3UL)
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
		}
		else
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		return result;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000033B4 File Offset: 0x000015B4
	internal static T smethod_8<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0x22C83331U ^ 0xCD048B24U);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num != 0UL)
		{
			if ((ulong)num != 2UL)
			{
				if ((ulong)num == 3UL)
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
		}
		else
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		return result;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00003558 File Offset: 0x00001758
	internal static T smethod_9<T>(uint uint_0)
	{
		uint_0 = (uint_0 * 0xEC668A73U ^ 0xDA8948BDU);
		uint num = uint_0 >> 0x1E;
		T result = default(T);
		uint_0 &= 0x3FFFFFFFU;
		uint_0 <<= 2;
		if ((ulong)num != 1UL)
		{
			if ((ulong)num != 0UL)
			{
				if ((ulong)num == 3UL)
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
		}
		else
		{
			int count = (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 8 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x10 | (int)global::<Module>.byte_0[(int)((global::System.UIntPtr)(uint_0++))] << 0x18;
			result = (T)((object)string.Intern(global::System.Text.Encoding.UTF8.GetString(global::<Module>.byte_0, (int)uint_0, count)));
		}
		return result;
	}

	// Token: 0x06000029 RID: 41
	[global::System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
	internal static extern bool VirtualProtect_1(global::System.IntPtr intptr_0, uint uint_0, uint uint_1, ref uint uint_2);

	// Token: 0x0600002A RID: 42 RVA: 0x000036FC File Offset: 0x000018FC
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
		uint num4 = 0x3FBD64CDU;
		uint num5 = 0x89EED1FCU;
		uint num6 = 0x1624218EU;
		uint num7 = 0x6A6A0B00U;
		for (int i = 0; i < (int)num; i++)
		{
			uint num8 = *(ptr4++) * *(ptr4++);
			if (num8 == 0xF879B51FU)
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
		if (num12 == 0x40U)
		{
			return;
		}
		uint num13 = 0U;
		for (uint num14 = 0U; num14 < num3; num14 += 1U)
		{
			*ptr3 ^= array[(int)((global::System.UIntPtr)(num13 & 0xFU))];
			array[(int)((global::System.UIntPtr)(num13 & 0xFU))] = (array[(int)((global::System.UIntPtr)(num13 & 0xFU))] ^ *(ptr3++)) + 0x3DBB2819U;
			num13 += 1U;
		}
	}

	// Token: 0x04000001 RID: 1
	internal static byte[] byte_0;

	// Token: 0x04000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
	internal static global::<Module>.Struct4 struct4_0;

	// Token: 0x02000002 RID: 2
	internal struct Struct0
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00003A04 File Offset: 0x00001C04
		internal void method_0()
		{
			this.uint_0 = 0x400U;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003A1C File Offset: 0x00001C1C
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
		// Token: 0x0600002D RID: 45 RVA: 0x00003B08 File Offset: 0x00001D08
		internal Struct1(int int_1)
		{
			this.int_0 = int_1;
			this.struct0_0 = new global::<Module>.Struct0[1 << int_1];
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003B30 File Offset: 0x00001D30
		internal void method_0()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.int_0 & 0x1F)))
			{
				this.struct0_0[(int)((global::System.UIntPtr)num)].method_0();
				num += 1U;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003B68 File Offset: 0x00001D68
		internal uint method_1(global::<Module>.Class0 class0_0)
		{
			uint num = 1U;
			for (int i = this.int_0; i > 0; i--)
			{
				num = (num << 1) + this.struct0_0[(int)((global::System.UIntPtr)num)].method_1(class0_0);
			}
			return num - (1U << this.int_0);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003BB0 File Offset: 0x00001DB0
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

		// Token: 0x06000031 RID: 49 RVA: 0x00003BF8 File Offset: 0x00001DF8
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
		// Token: 0x06000032 RID: 50 RVA: 0x00003C38 File Offset: 0x00001E38
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

		// Token: 0x06000033 RID: 51 RVA: 0x00003C84 File Offset: 0x00001E84
		internal void method_1()
		{
			this.stream_0 = null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003C98 File Offset: 0x00001E98
		internal void method_2()
		{
			while (this.uint_1 < 0x1000000U)
			{
				this.uint_0 = (this.uint_0 << 8 | (uint)((byte)this.stream_0.ReadByte()));
				this.uint_1 <<= 8;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003CE0 File Offset: 0x00001EE0
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

		// Token: 0x06000036 RID: 54 RVA: 0x00003D54 File Offset: 0x00001F54
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
		// Token: 0x06000037 RID: 55 RVA: 0x00003D68 File Offset: 0x00001F68
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

		// Token: 0x06000038 RID: 56 RVA: 0x00003E68 File Offset: 0x00002068
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

		// Token: 0x06000039 RID: 57 RVA: 0x00003EB4 File Offset: 0x000020B4
		internal void method_1(int int_0, int int_1)
		{
			this.class3_0.method_0(int_0, int_1);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003ED0 File Offset: 0x000020D0
		internal void method_2(int int_0)
		{
			uint num = 1U << int_0;
			this.class2_0.method_0(num);
			this.class2_1.method_0(num);
			this.uint_2 = num - 1U;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003F08 File Offset: 0x00002108
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

		// Token: 0x0600003C RID: 60 RVA: 0x00004034 File Offset: 0x00002234
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
				if (this.struct0_0[(int)((global::System.UIntPtr)((@struct.uint_0 << 4) + num6))].method_1(this.class0_0) == 0U)
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
				else
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
						if (num8 >= 4U)
						{
							int num9 = (int)((num8 >> 1) - 1U);
							num = (2U | (num8 & 1U)) << num9;
							if (num8 >= 0xEU)
							{
								num += this.class0_0.method_3(num9 - 4) << 4;
								num += this.struct1_1.method_2(this.class0_0);
							}
							else
							{
								num += global::<Module>.Struct1.smethod_0(this.struct0_6, num - num8 - 1U, this.class0_0, num9);
							}
						}
						else
						{
							num = num8;
						}
					}
					else
					{
						if (this.struct0_3[(int)((global::System.UIntPtr)@struct.uint_0)].method_1(this.class0_0) != 0U)
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
						else if (this.struct0_1[(int)((global::System.UIntPtr)((@struct.uint_0 << 4) + num6))].method_1(this.class0_0) == 0U)
						{
							@struct.method_4();
							this.class4_0.method_5(this.class4_0.method_6(num));
							num5 += 1UL;
							continue;
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
			}
			this.class4_0.method_3();
			this.class4_0.method_2();
			this.class0_0.method_1();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000043A8 File Offset: 0x000025A8
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

		// Token: 0x0600003E RID: 62 RVA: 0x00004408 File Offset: 0x00002608
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
			// Token: 0x0600003F RID: 63 RVA: 0x00004424 File Offset: 0x00002624
			internal void method_0(uint uint_1)
			{
				for (uint num = this.uint_0; num < uint_1; num += 1U)
				{
					this.struct1_0[(int)((global::System.UIntPtr)num)] = new global::<Module>.Struct1(3);
					this.struct1_1[(int)((global::System.UIntPtr)num)] = new global::<Module>.Struct1(3);
				}
				this.uint_0 = uint_1;
			}

			// Token: 0x06000040 RID: 64 RVA: 0x0000447C File Offset: 0x0000267C
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

			// Token: 0x06000041 RID: 65 RVA: 0x000044E0 File Offset: 0x000026E0
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

			// Token: 0x06000042 RID: 66 RVA: 0x0000454C File Offset: 0x0000274C
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
			// Token: 0x06000043 RID: 67 RVA: 0x000045A0 File Offset: 0x000027A0
			internal void method_0(int int_2, int int_3)
			{
				if (this.struct2_0 != null)
				{
					if (this.int_1 == int_3)
					{
						if (this.int_0 == int_2)
						{
							return;
						}
					}
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

			// Token: 0x06000044 RID: 68 RVA: 0x00004628 File Offset: 0x00002828
			internal void method_1()
			{
				uint num = 1U << this.int_1 + this.int_0;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((global::System.UIntPtr)num2)].method_1();
				}
			}

			// Token: 0x06000045 RID: 69 RVA: 0x00004668 File Offset: 0x00002868
			internal uint method_2(uint uint_1, byte byte_0)
			{
				return ((uint_1 & this.uint_0) << this.int_1) + (uint)(byte_0 >> 8 - this.int_1);
			}

			// Token: 0x06000046 RID: 70 RVA: 0x00004698 File Offset: 0x00002898
			internal byte method_3(global::<Module>.Class0 class0_0, uint uint_1, byte byte_0)
			{
				return this.struct2_0[(int)((global::System.UIntPtr)this.method_2(uint_1, byte_0))].method_2(class0_0);
			}

			// Token: 0x06000047 RID: 71 RVA: 0x000046C0 File Offset: 0x000028C0
			internal byte method_4(global::<Module>.Class0 class0_0, uint uint_1, byte byte_0, byte byte_1)
			{
				return this.struct2_0[(int)((global::System.UIntPtr)this.method_2(uint_1, byte_0))].method_3(class0_0, byte_1);
			}

			// Token: 0x06000048 RID: 72 RVA: 0x00003D54 File Offset: 0x00001F54
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
				// Token: 0x06000049 RID: 73 RVA: 0x000046EC File Offset: 0x000028EC
				internal void method_0()
				{
					this.struct0_0 = new global::<Module>.Struct0[0x300];
				}

				// Token: 0x0600004A RID: 74 RVA: 0x0000470C File Offset: 0x0000290C
				internal void method_1()
				{
					for (int i = 0; i < 0x300; i++)
					{
						this.struct0_0[i].method_0();
					}
				}

				// Token: 0x0600004B RID: 75 RVA: 0x0000473C File Offset: 0x0000293C
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

				// Token: 0x0600004C RID: 76 RVA: 0x00004770 File Offset: 0x00002970
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
		// Token: 0x0600004D RID: 77 RVA: 0x000047E0 File Offset: 0x000029E0
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

		// Token: 0x0600004E RID: 78 RVA: 0x00004818 File Offset: 0x00002A18
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

		// Token: 0x0600004F RID: 79 RVA: 0x00004844 File Offset: 0x00002A44
		internal void method_2()
		{
			this.method_3();
			this.stream_0 = null;
			global::System.Buffer.BlockCopy(new byte[this.byte_0.Length], 0, this.byte_0, 0, this.byte_0.Length);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004880 File Offset: 0x00002A80
		internal void method_3()
		{
			uint num = this.uint_0 - this.uint_1;
			if (num != 0U)
			{
				this.stream_0.Write(this.byte_0, (int)this.uint_1, (int)num);
				if (this.uint_0 >= this.uint_2)
				{
					this.uint_0 = 0U;
				}
				this.uint_1 = this.uint_0;
				return;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000048D8 File Offset: 0x00002AD8
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

		// Token: 0x06000052 RID: 82 RVA: 0x00004954 File Offset: 0x00002B54
		internal void method_5(byte byte_1)
		{
			this.byte_0[(int)((global::System.UIntPtr)(this.uint_0++))] = byte_1;
			if (this.uint_0 >= this.uint_2)
			{
				this.method_3();
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004990 File Offset: 0x00002B90
		internal byte method_6(uint uint_3)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			return this.byte_0[(int)((global::System.UIntPtr)num)];
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003D54 File Offset: 0x00001F54
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
		// Token: 0x06000055 RID: 85 RVA: 0x000049C4 File Offset: 0x00002BC4
		internal void method_0()
		{
			this.uint_0 = 0U;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000049D8 File Offset: 0x00002BD8
		internal void method_1()
		{
			if (this.uint_0 < 4U)
			{
				this.uint_0 = 0U;
				return;
			}
			if (this.uint_0 >= 0xAU)
			{
				this.uint_0 -= 6U;
				return;
			}
			this.uint_0 -= 3U;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004A20 File Offset: 0x00002C20
		internal void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 0xAU);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004A44 File Offset: 0x00002C44
		internal void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 0xBU);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004A68 File Offset: 0x00002C68
		internal void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 0xBU);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004A8C File Offset: 0x00002C8C
		internal bool method_5()
		{
			return this.uint_0 < 7U;
		}

		// Token: 0x0400002B RID: 43
		internal uint uint_0;
	}

	// Token: 0x0200000B RID: 11
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x440)]
	internal struct Struct4
	{
	}
}
