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
	// Token: 0x06000001 RID: 1 RVA: 0x000029A0 File Offset: 0x00000BA0
	static <Module>()
	{
		global::<Module>.smethod_4();
		global::<Module>.smethod_2();
		global::<Module>.smethod_0();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000029BC File Offset: 0x00000BBC
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

	// Token: 0x06000003 RID: 3 RVA: 0x00002A54 File Offset: 0x00000C54
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

	// Token: 0x06000005 RID: 5 RVA: 0x00002AC8 File Offset: 0x00000CC8
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

	// Token: 0x06000022 RID: 34 RVA: 0x00003148 File Offset: 0x00001348
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

	// Token: 0x06000023 RID: 35 RVA: 0x000031E0 File Offset: 0x000013E0
	internal static void smethod_4()
	{
		uint num = 0x250U;
		uint[] array = new uint[]
		{
			0xA3D9960FU,
			0xB5C57FDDU,
			0x7BD0F668U,
			0x35D64B71U,
			0x6157B62AU,
			0x49791A03U,
			0x20C6EE68U,
			0x1C3EB7BEU,
			0x92E69F15U,
			0x1066FD3CU,
			0xE1C25CF1U,
			0x9A88C3C9U,
			0x6667845EU,
			0x8A85450U,
			0xFE10FADBU,
			0xC267834CU,
			0x9F7C7AE9U,
			0x3DA592C1U,
			0x3AE4E69U,
			0xF9BF0018U,
			0xECDF52ABU,
			0xA9B8DED3U,
			0xD9475152U,
			0xC526F477U,
			0x4B22B87CU,
			0xC8AF6F2U,
			0x593FB362U,
			0xDAB7DB02U,
			0xE51F71EBU,
			0x8ED9513U,
			0x77E62EE1U,
			0x182FDF3BU,
			0x2114A0AFU,
			0x31797BCEU,
			0xB12EF732U,
			0x3F9DE5C0U,
			0xCB6E79AFU,
			0x3AFF83B9U,
			0xB5196D8U,
			0xC002FF83U,
			0x9DD48B11U,
			0x919E1DA1U,
			0xEBA622E6U,
			0x606D6D2U,
			0xAA64ECFCU,
			0x41BB014EU,
			0xCB30E1FCU,
			0xCDF5DF3FU,
			0xE6EAAAAEU,
			0xC6DD0CBBU,
			0x185A401CU,
			0x63C89FE5U,
			0xBC2AC1B0U,
			0xAC3838BBU,
			0x4463C1E3U,
			0x6885C936U,
			0xFB57E433U,
			0x1DB5863BU,
			0x8E3DA239U,
			0x4E1EA122U,
			0xC64CB68BU,
			0xE93D7FA5U,
			0xA363A834U,
			0x97D78F6BU,
			0xDF61B7B2U,
			0xE1CC124DU,
			0xA7615A69U,
			0xF458C512U,
			0xD7E832CAU,
			0x4121C5D0U,
			0x2E0538ACU,
			0xFDC26E13U,
			0xE7BD6DF2U,
			0x356406B4U,
			0x35219935U,
			0xB1766BBAU,
			0x14D138AAU,
			0x69357CAU,
			0xC181E64FU,
			0xDF23359U,
			0xE8A948B9U,
			0x78692A3FU,
			0xDAB10C6EU,
			0xFEB98C7BU,
			0xD61D0BC0U,
			0x3FBAA571U,
			0xB94C8D04U,
			0x709B0CE8U,
			0x3865AA00U,
			0xFC486B29U,
			0x82BAB4BEU,
			0xC81F3C3EU,
			0xDE01CABFU,
			0x1395CF20U,
			0xD25E879FU,
			0xD85E2650U,
			0x46A3DCE9U,
			0xEFE77DCFU,
			0x43D95DA5U,
			0x9E8D1DFAU,
			0x2FC1337DU,
			0xD98FF148U,
			0x839F2897U,
			0xF5882FA7U,
			0xAF076331U,
			0xB2EAA46EU,
			0xAD9D7F64U,
			0xDC064953U,
			0x9BE19E0U,
			0x7CD7A798U,
			0x1786FA14U,
			0x3808F7A2U,
			0x3573DD67U,
			0x9E94090FU,
			0xEC83D896U,
			0xB4CF46B8U,
			0xEB930BFU,
			0x33A68785U,
			0x9A858200U,
			0xBC032044U,
			0xD7C8D489U,
			0xFD1592E3U,
			0xA82388CEU,
			0x7A0C4C43U,
			0x4A2C3B95U,
			0xDA189CCBU,
			0x4708A98FU,
			0xE75A1A95U,
			0x67DB51CBU,
			0x7346C2DCU,
			0x192A380U,
			0x9448580DU,
			0x699B71DDU,
			0xBD1F4A13U,
			0x88294B73U,
			0x17629FCAU,
			0x502E9CEAU,
			0x137BF224U,
			0x744BE116U,
			0xE15E6B42U,
			0x244B386DU,
			0xE2F1080AU,
			0x78499EF9U,
			0xB476A87U,
			0xFE39C955U,
			0x29C61DC5U,
			0xBD46FAA9U,
			0x530AA0FCU,
			0x9C76B470U,
			0x46246A2BU,
			0x3608A2EEU,
			0x713A3FC4U,
			0xCC5F0E9DU,
			0xD2792AEDU,
			0xB55D2F77U,
			0xA844C547U,
			0x1402E7B0U,
			0xA173AD2U,
			0x60A05F16U,
			0xED364CFBU,
			0xCA738C55U,
			0x2B007156U,
			0xFE268399U,
			0x9DF08AAEU,
			0x10CA9041U,
			0x837BBFCCU,
			0xA77E0AF6U,
			0x51BB4084U,
			0x6CFB2C7AU,
			0x497797CAU,
			0x1F38A324U,
			0x71E52F2CU,
			0xFC7D4255U,
			0xBA04F680U,
			0x9960054AU,
			0xC544850BU,
			0x8330D91U,
			0xE7DFD80FU,
			0xBDE2A02CU,
			0xD061DBFEU,
			0x68D876C7U,
			0xBAAFE62EU,
			0x5788F9C8U,
			0x5D204571U,
			0xA08E4FDFU,
			0x54729CB2U,
			0x9F7F4795U,
			0xC460CDA9U,
			0x7AA34F84U,
			0x305EC00FU,
			0xE0B7AA5BU,
			0x2E10C67BU,
			0x7C58184DU,
			0x8D01B442U,
			0xF8C1C4A9U,
			0xF3C9D854U,
			0x9264AE89U,
			0xB26CA0AFU,
			0x34D0483DU,
			0x88B7D6EAU,
			0xB125AC09U,
			0xEA683B7CU,
			0xA42EC61U,
			0x50D28B9AU,
			0x50FA77ECU,
			0x588CAC1EU,
			0x39B058D3U,
			0x22EB74A6U,
			0xC44285DU,
			0x7D4BBF33U,
			0x6DF34E75U,
			0x2DFF3467U,
			0x23107A23U,
			0xCFF5B52FU,
			0x2CCFD3EEU,
			0x3A566867U,
			0xF7B5922EU,
			0xC1DACF2CU,
			0x259833C1U,
			0x9159E2D1U,
			0x2E8BDCD3U,
			0x5995A10EU,
			0xCBD3E8FU,
			0xDD02CAB8U,
			0x6BD22E95U,
			0x4FF98679U,
			0x41FC68F3U,
			0x2C9C2D36U,
			0x8A54AD3AU,
			0xDA20969FU,
			0x356C4F51U,
			0xD7C5B7F5U,
			0x7FEAC928U,
			0xFC6EADD3U,
			0x2E88F797U,
			0x29D010D2U,
			0xEC4CFCADU,
			0x57BC4965U,
			0x54975776U,
			0xCB07AE31U,
			0xF6BEB208U,
			0xD099BCFFU,
			0xD37991D4U,
			0x250288AAU,
			0x3ED80FBU,
			0x77D30956U,
			0xD9BD968AU,
			0x6277AB38U,
			0x8EFB57DEU,
			0x219914CBU,
			0x32919F1EU,
			0xE68C9F29U,
			0xE8613CFFU,
			0x8F0D9F94U,
			0x68829D34U,
			0xEDF13B47U,
			0x20A8FA79U,
			0x7176B20BU,
			0xB4C2657FU,
			0xB939020U,
			0xF5E48443U,
			0x6253FAEAU,
			0x7E9299F2U,
			0x3BB2E5D0U,
			0x308CA4C6U,
			0x37734B5BU,
			0xFF4642ECU,
			0xB121D899U,
			0x690D2F5AU,
			0x44553E01U,
			0x1068F58CU,
			0x5B0AE527U,
			0xC926E36AU,
			0x76A70A17U,
			0xDD36636U,
			0x1F6FE60EU,
			0x4600AA23U,
			0xA66851B1U,
			0x88552C1DU,
			0x5B196F7CU,
			0xC6058E79U,
			0xEEB14A71U,
			0x6B2D132EU,
			0x962D8FF0U,
			0xBC753E9EU,
			0xCA6149F7U,
			0x516C9D0BU,
			0xB5B13D6FU,
			0x895FEC68U,
			0x1E01BE53U,
			0x12A04E35U,
			0x19632C51U,
			0xF477A52U,
			0x736475FAU,
			0xFD79F4ADU,
			0x85A6395BU,
			0xF601A1CDU,
			0xAA46EB76U,
			0x26A56B8DU,
			0x37DE93F6U,
			0x683A7F1CU,
			0x518CF422U,
			0x8738AC90U,
			0x742E429BU,
			0x2E6ED08AU,
			0x63199059U,
			0xDDD1160CU,
			0xFADBECC4U,
			0x2B0B3D33U,
			0xC555B782U,
			0x1A484474U,
			0xBE387E84U,
			0x529519C4U,
			0xD68290E8U,
			0xFCEC7F6U,
			0x9A821671U,
			0x8AD681D5U,
			0xFE283BA2U,
			0x8904CCA5U,
			0x6AE60EECU,
			0xB182A73AU,
			0x5DEF6599U,
			0x3A0AB73DU,
			0x97058FAFU,
			0xD9694494U,
			0x5A039C69U,
			0x33D7A767U,
			0xADAE800CU,
			0x69FCBEAAU,
			0x61601613U,
			0x100887BEU,
			0x5E694DBDU,
			0x49BD2B81U,
			0x8611D3B4U,
			0x9AC0151FU,
			0x131E7C13U,
			0x148CA8CAU,
			0x77EFA652U,
			0xA470228DU,
			0x7D423A2U,
			0xAFCFE63BU,
			0x721DB4CBU,
			0x8F1066A2U,
			0xE6163D33U,
			0xDFBCC93U,
			0xB4E488F4U,
			0x7C37DC1U,
			0x33B1B99CU,
			0xEC300A22U,
			0xED94C694U,
			0xCED04DDBU,
			0x884F14A5U,
			0xC88AA9FDU,
			0x668ED8A7U,
			0x30671A90U,
			0xEE6684B2U,
			0x774A5EC2U,
			0xF9E72719U,
			0x7C554669U,
			0x73FDF4DFU,
			0x911CD9E3U,
			0x8DAA5C38U,
			0x2E8A65D2U,
			0xE8A965CAU,
			0xBF4EB30EU,
			0xC77B6233U,
			0x4C814C28U,
			0xC6B217E0U,
			0x9311A5B5U,
			0x48EB0E23U,
			0xBF60D0ACU,
			0x8C171968U,
			0x8C937B3EU,
			0x876EDDEU,
			0xB7AB962EU,
			0xFD72668BU,
			0x19BDC641U,
			0xD485003DU,
			0x5F7B16CEU,
			0xF5A2B97EU,
			0x45BE12F6U,
			0x578CE44CU,
			0xFA538891U,
			0xDBC56C12U,
			0x29023055U,
			0x6344E555U,
			0x43E59740U,
			0x346FE0E7U,
			0x11B9B343U,
			0xF431268BU,
			0xADDFDFADU,
			0x2D5E1411U,
			0xC714E3CEU,
			0x97BF47F9U,
			0x66EF7762U,
			0xC81037B0U,
			0x157A95D0U,
			0xDD596816U,
			0x1F54B293U,
			0xB728F01BU,
			0xC30864A8U,
			0x4ADAE3A8U,
			0x91E9EA41U,
			0x4E031B47U,
			0x3C313239U,
			0x683A7404U,
			0xEB4D6516U,
			0x5A631B29U,
			0xC9BCBEF4U,
			0xEACD7EB0U,
			0x9219E9FFU,
			0xCDB99F8DU,
			0x88C91F9AU,
			0x73C84F76U,
			0xDCB1BFC3U,
			0x67F2685CU,
			0xE554CB48U,
			0xBB240470U,
			0x7F4E37E9U,
			0x95B03DAU,
			0x7A369421U,
			0xB137612FU,
			0x80870C8FU,
			0xE9A0B367U,
			0x9F0BA493U,
			0xDE9BB5D8U,
			0x5C3C1D61U,
			0x48386EEBU,
			0xD1C444DDU,
			0x3A2C21DCU,
			0xCEAB36ABU,
			0xA4882CADU,
			0xF6280D7BU,
			0x128FEBE3U,
			0xC6983272U,
			0x60101E18U,
			0xADBD70BBU,
			0xBDF5C952U,
			0xEB18E366U,
			0x6B100D01U,
			0x97915D67U,
			0xAB322EC5U,
			0x1738BC3FU,
			0x1938FA36U,
			0x18A70711U,
			0xE4C63F9FU,
			0xA87CC5A0U,
			0xBEB93EB4U,
			0x45280005U,
			0x9B121AE3U,
			0x6334A596U,
			0xFD91F65AU,
			0x4EE86897U,
			0x12481BEEU,
			0xBFEABC0DU,
			0x25BF4DE3U,
			0x4A23C654U,
			0xB749975FU,
			0x3D6C1FE8U,
			0x246E0D51U,
			0x49213F5EU,
			0x6A14841DU,
			0x27542F65U,
			0x2DA5A298U,
			0x33EBE616U,
			0xFF78442CU,
			0xF4A92A0EU,
			0x991199F9U,
			0x229A16FFU,
			0x6B624C47U,
			0x1573F1DBU,
			0x6A1D28E8U,
			0x2B63A42FU,
			0xD797015BU,
			0xEB5BEFDFU,
			0xE2DBA625U,
			0xAB047510U,
			0x9D4EDF12U,
			0x6B683D17U,
			0xAD8C91D7U,
			0xBE3F46B8U,
			0x913E8DD1U,
			0x52BB8DEFU,
			0x6D6A07E1U,
			0x3752E094U,
			0xB2B5CF34U,
			0xEEC6677AU,
			0xAD875BCCU,
			0xC7597EE2U,
			0xC1C1B98BU,
			0x52095AB1U,
			0xA5F9C925U,
			0xC5B6BABDU,
			0xF7BB3CAFU,
			0x1B6B9F2FU,
			0x98BCA745U,
			0x7D1FFA0AU,
			0x194B7922U,
			0xAA5A6A7BU,
			0x74F9BD94U,
			0x686280A4U,
			0xD643C1F8U,
			0x644749E8U,
			0xE3BC4BF2U,
			0xF61873C6U,
			0x21E416D8U,
			0xCE50DD79U,
			0x2DE27A10U,
			0x3959927BU,
			0xDC097450U,
			0x8C430496U,
			0xDDD95233U,
			0xD38F6E78U,
			0x41F42834U,
			0x3CBCDC18U,
			0xF736F285U,
			0x222D7E46U,
			0x59243D8AU,
			0x2DB299D3U,
			0x1DC6D06CU,
			0xEBC2D853U,
			0x8DF99BA7U,
			0xA10D9179U,
			0x49682A66U,
			0x4C751D92U,
			0x6BFA80A7U,
			0xE7746BA3U,
			0x7ECE1762U,
			0xFB8A82B0U,
			0x482CCB56U,
			0xAD496DB7U,
			0xED0AF404U,
			0x20B158D5U,
			0x3E434C18U,
			0xE35AB7D6U,
			0x3AD8F44BU,
			0xB68732A4U,
			0x72D3F81DU,
			0x86AA028AU,
			0xCAAAA17FU,
			0x456F2B42U,
			0xEFB688D5U,
			0xCACEE64BU,
			0x3BEBE9CBU,
			0x2921C19BU,
			0x175B0132U,
			0xE597419BU,
			0xADB7D891U,
			0xB1DE3AD5U,
			0x254CCB64U,
			0xCEEAB7E7U,
			0x5E385130U,
			0x1A9A14ADU,
			0x9B740B08U,
			0xEBA44F5FU,
			0xA7D43BFDU,
			0x20AB19E4U,
			0x822A3793U,
			0x21237AB6U,
			0x69E2304DU,
			0x1379C78BU,
			0x5F36562EU,
			0xF674A5D2U,
			0xC1EB3BC8U,
			0x79B141BEU,
			0xB78A5A7CU,
			0x10019017U,
			0x9717ACB9U,
			0x665C22DAU,
			0xD9530072U,
			0x1AEC0DDAU,
			0x70186551U,
			0xB2E02A6BU,
			0xE12838B3U,
			0x3D1A1518U,
			0xC220CC60U,
			0xD60673D5U,
			0x5FB5AD75U,
			0xF674A5D2U,
			0xC1EB3BC8U,
			0x79B141BEU,
			0xB78A5A7CU,
			0x10019017U,
			0x9717ACB9U,
			0x665C22DAU,
			0xD9530072U,
			0x1AEC0DDAU,
			0x70186551U,
			0xB2E02A6BU,
			0xE12838B3U,
			0x3D1A1518U,
			0xC220CC60U
		};
		uint[] array2 = new uint[0x10];
		uint num2 = 0x8FD16B40U;
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

	// Token: 0x06000024 RID: 36 RVA: 0x000033DC File Offset: 0x000015DC
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

	// Token: 0x06000025 RID: 37 RVA: 0x0000357C File Offset: 0x0000177C
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

	// Token: 0x06000026 RID: 38 RVA: 0x0000371C File Offset: 0x0000191C
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

	// Token: 0x06000027 RID: 39 RVA: 0x000038BC File Offset: 0x00001ABC
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

	// Token: 0x06000028 RID: 40 RVA: 0x00003A5C File Offset: 0x00001C5C
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

	// Token: 0x0600002A RID: 42 RVA: 0x00003BFC File Offset: 0x00001DFC
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
		// Token: 0x0600002B RID: 43 RVA: 0x00003F04 File Offset: 0x00002104
		internal void method_0()
		{
			this.uint_0 = 0x400U;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003F1C File Offset: 0x0000211C
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
		// Token: 0x0600002D RID: 45 RVA: 0x00004008 File Offset: 0x00002208
		internal Struct1(int int_1)
		{
			this.int_0 = int_1;
			this.struct0_0 = new global::<Module>.Struct0[1 << int_1];
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004030 File Offset: 0x00002230
		internal void method_0()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.int_0 & 0x1F)))
			{
				this.struct0_0[(int)((global::System.UIntPtr)num)].method_0();
				num += 1U;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004068 File Offset: 0x00002268
		internal uint method_1(global::<Module>.Class0 class0_0)
		{
			uint num = 1U;
			for (int i = this.int_0; i > 0; i--)
			{
				num = (num << 1) + this.struct0_0[(int)((global::System.UIntPtr)num)].method_1(class0_0);
			}
			return num - (1U << this.int_0);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000040B0 File Offset: 0x000022B0
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

		// Token: 0x06000031 RID: 49 RVA: 0x000040F8 File Offset: 0x000022F8
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
		// Token: 0x06000032 RID: 50 RVA: 0x00004138 File Offset: 0x00002338
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

		// Token: 0x06000033 RID: 51 RVA: 0x00004184 File Offset: 0x00002384
		internal void method_1()
		{
			this.stream_0 = null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004198 File Offset: 0x00002398
		internal void method_2()
		{
			while (this.uint_1 < 0x1000000U)
			{
				this.uint_0 = (this.uint_0 << 8 | (uint)((byte)this.stream_0.ReadByte()));
				this.uint_1 <<= 8;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000041E0 File Offset: 0x000023E0
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

		// Token: 0x06000036 RID: 54 RVA: 0x00004254 File Offset: 0x00002454
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
		// Token: 0x06000037 RID: 55 RVA: 0x00004268 File Offset: 0x00002468
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

		// Token: 0x06000038 RID: 56 RVA: 0x00004368 File Offset: 0x00002568
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

		// Token: 0x06000039 RID: 57 RVA: 0x000043B4 File Offset: 0x000025B4
		internal void method_1(int int_0, int int_1)
		{
			this.class3_0.method_0(int_0, int_1);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000043D0 File Offset: 0x000025D0
		internal void method_2(int int_0)
		{
			uint num = 1U << int_0;
			this.class2_0.method_0(num);
			this.class2_1.method_0(num);
			this.uint_2 = num - 1U;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004408 File Offset: 0x00002608
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

		// Token: 0x0600003C RID: 60 RVA: 0x00004534 File Offset: 0x00002734
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

		// Token: 0x0600003D RID: 61 RVA: 0x000048B0 File Offset: 0x00002AB0
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

		// Token: 0x0600003E RID: 62 RVA: 0x00004910 File Offset: 0x00002B10
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
			// Token: 0x0600003F RID: 63 RVA: 0x0000492C File Offset: 0x00002B2C
			internal void method_0(uint uint_1)
			{
				for (uint num = this.uint_0; num < uint_1; num += 1U)
				{
					this.struct1_0[(int)((global::System.UIntPtr)num)] = new global::<Module>.Struct1(3);
					this.struct1_1[(int)((global::System.UIntPtr)num)] = new global::<Module>.Struct1(3);
				}
				this.uint_0 = uint_1;
			}

			// Token: 0x06000040 RID: 64 RVA: 0x00004984 File Offset: 0x00002B84
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

			// Token: 0x06000041 RID: 65 RVA: 0x000049E8 File Offset: 0x00002BE8
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

			// Token: 0x06000042 RID: 66 RVA: 0x00004A54 File Offset: 0x00002C54
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
			// Token: 0x06000043 RID: 67 RVA: 0x00004AA8 File Offset: 0x00002CA8
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

			// Token: 0x06000044 RID: 68 RVA: 0x00004B2C File Offset: 0x00002D2C
			internal void method_1()
			{
				uint num = 1U << this.int_1 + this.int_0;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((global::System.UIntPtr)num2)].method_1();
				}
			}

			// Token: 0x06000045 RID: 69 RVA: 0x00004B6C File Offset: 0x00002D6C
			internal uint method_2(uint uint_1, byte byte_0)
			{
				return ((uint_1 & this.uint_0) << this.int_1) + (uint)(byte_0 >> 8 - this.int_1);
			}

			// Token: 0x06000046 RID: 70 RVA: 0x00004B9C File Offset: 0x00002D9C
			internal byte method_3(global::<Module>.Class0 class0_0, uint uint_1, byte byte_0)
			{
				return this.struct2_0[(int)((global::System.UIntPtr)this.method_2(uint_1, byte_0))].method_2(class0_0);
			}

			// Token: 0x06000047 RID: 71 RVA: 0x00004BC4 File Offset: 0x00002DC4
			internal byte method_4(global::<Module>.Class0 class0_0, uint uint_1, byte byte_0, byte byte_1)
			{
				return this.struct2_0[(int)((global::System.UIntPtr)this.method_2(uint_1, byte_0))].method_3(class0_0, byte_1);
			}

			// Token: 0x06000048 RID: 72 RVA: 0x00004254 File Offset: 0x00002454
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
				// Token: 0x06000049 RID: 73 RVA: 0x00004BF0 File Offset: 0x00002DF0
				internal void method_0()
				{
					this.struct0_0 = new global::<Module>.Struct0[0x300];
				}

				// Token: 0x0600004A RID: 74 RVA: 0x00004C10 File Offset: 0x00002E10
				internal void method_1()
				{
					for (int i = 0; i < 0x300; i++)
					{
						this.struct0_0[i].method_0();
					}
				}

				// Token: 0x0600004B RID: 75 RVA: 0x00004C40 File Offset: 0x00002E40
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

				// Token: 0x0600004C RID: 76 RVA: 0x00004C74 File Offset: 0x00002E74
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
		// Token: 0x0600004D RID: 77 RVA: 0x00004CE4 File Offset: 0x00002EE4
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

		// Token: 0x0600004E RID: 78 RVA: 0x00004D1C File Offset: 0x00002F1C
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

		// Token: 0x0600004F RID: 79 RVA: 0x00004D48 File Offset: 0x00002F48
		internal void method_2()
		{
			this.method_3();
			this.stream_0 = null;
			global::System.Buffer.BlockCopy(new byte[this.byte_0.Length], 0, this.byte_0, 0, this.byte_0.Length);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004D84 File Offset: 0x00002F84
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

		// Token: 0x06000051 RID: 81 RVA: 0x00004DDC File Offset: 0x00002FDC
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

		// Token: 0x06000052 RID: 82 RVA: 0x00004E58 File Offset: 0x00003058
		internal void method_5(byte byte_1)
		{
			this.byte_0[(int)((global::System.UIntPtr)(this.uint_0++))] = byte_1;
			if (this.uint_0 >= this.uint_2)
			{
				this.method_3();
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004E94 File Offset: 0x00003094
		internal byte method_6(uint uint_3)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			return this.byte_0[(int)((global::System.UIntPtr)num)];
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004254 File Offset: 0x00002454
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
		// Token: 0x06000055 RID: 85 RVA: 0x00004EC8 File Offset: 0x000030C8
		internal void method_0()
		{
			this.uint_0 = 0U;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004EDC File Offset: 0x000030DC
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

		// Token: 0x06000057 RID: 87 RVA: 0x00004F24 File Offset: 0x00003124
		internal void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 0xAU);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004F48 File Offset: 0x00003148
		internal void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 0xBU);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004F6C File Offset: 0x0000316C
		internal void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 0xBU);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004F90 File Offset: 0x00003190
		internal bool method_5()
		{
			return this.uint_0 < 7U;
		}

		// Token: 0x0400002B RID: 43
		internal uint uint_0;
	}

	// Token: 0x0200000B RID: 11
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x940)]
	internal struct Struct4
	{
	}
}
