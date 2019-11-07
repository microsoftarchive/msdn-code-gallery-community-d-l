// Copyright 2015-2016 gekka.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


//#define CS6
#pragma warning disable 67,162,168,169,219,414,429,649,661,1718
//[assembly: System.Reflection.AssemblyTitle("ConsoleApplication1")]
//[module: CLSCompliant(true)]

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using XXX = System.Collections.Generic;

class OutsideClass
{
}
enum OutSideEnum
{
    None
}
struct OutSideStruct
{
    public int Value;
}

delegate void OutSideDelegate();

namespace FirstNameSpace
{
	namespace FirstNameSpace_InnerNameSpace
	{
	}
}

namespace TestEnum
{
	enum TestEnumBlank
	{
	}

	[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Enum")]
	enum TestEnum_Value
	{
		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Enum Member")]
		A,
		B,
		C
	}

	enum TestEnum_ValueInitialize
	{
		A,
		B = 1,
		C = B + 0x10
	}
	enum TestEnum_Byte : byte { None }
	enum TestEnum_SByte : sbyte { None }
	enum TestEnum_Short : short { None }
	enum TestEnum_UShort : ushort { None }
	enum TestEnum_Int : int { None }
	enum TestEnum_UInt : uint { None }
	enum TestEnum_Long : long { None }
	enum TestEnum_ULong : ulong { None }
}

namespace TestStruct
{
	struct TestStruct_Blank
	{
	}

	struct TestStruct_Member
	{
		bool BOOLEAN;
        public byte BYTE;
		private sbyte SBYTE;
		internal short SHORT;

		public ushort USHORT;
		public int INTEGER;
		public uint UINTEGER;
		public long LONG;
		public ulong ULONG;
		public float SINGLE;
		public double DOUBLE;
		public decimal DECIMAL;
		public char CHAR;
		public string STRING;
		public DateTime DATETIME;
		public DateTimeOffset DATETIMEOFFSET;
		public object OBJECT;

		private bool? NullableBOOL;
	}

	[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Struct")]
	struct TestStruct_Constructor
	{
		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Struct Field")]
		private static int StaticField;

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Struct Field")]
		private int StructField;

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Struct Property")]
		public int StructProperty { get { return StructField; } set { StructField = value; } }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Constructor")]
		static TestStruct_Constructor()
		{
			StaticField = 123;
		}

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Constructor")]
		public TestStruct_Constructor(int x)
		{
			StructField = x;
			StructProperty = x;
		}
	}

	struct TestGenericStructConstraint<T, U, V>
		where T : class,new()
		where U : struct
		where V : EventArgs
	{
		public void GenericMethod<X, Y, Z>()
			where X : class ,new()
			where Y : struct
			where Z : EventArgs
		{
		}

		public delegate void GenericDelegate<A, B, C>()
			where A : class, new()
			where B : struct
			where C : EventArgs;

		T Test(T value) { return value; }
		T TestReadOnlyProperty { get { return default(T); } }
		T TestProperty { get { return default(T); } set { } }
		event System.Action<U> TestActionEvent;
		event EventHandler<V> TestEvent;
	}
}
namespace TestInterface
{
	interface ITestInterface_Blank
	{
	}

	[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface")]
	interface ITestInterface_Member
	{
		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface Method")]
		void TestSub();

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface Function")]
		int TestFunction();

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface ReaonlyProperty")]
		int TestReadOnlyProperty { get; }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface Property")]
		int TestProperty { get; set; }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface Event Action")]
		event System.Action TestActionEvent;

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Interface Event EventHandler")]
		event System.EventHandler<EventArgs> TestEvent;
	}

	interface ITestInterface_Generic<T, U>
		where T : EventArgs
	{
	}

	interface ITestGenericInterfaceConstraint<T, U, V>
		where T : class,new()
		where U : struct
		where V : EventArgs
	{
		void GenericMethod<X, Y, Z>();

		T Test(U value);
		T TestReadOnlyProperty { get; }
		T TestProperty { get; set; }
		event System.Action<U> TestActionEvent;
		event EventHandler<V> TestEvent;
	}


}

namespace TestClass
{
	[System.Serializable()]
	[System.ComponentModel.Browsable(true)]
	class TestClass_Blank
	{
	}

	public sealed class TestClass_MultiInherits
		: System.Exception, System.ICloneable, TestInterface.ITestInterface_Blank
	{
		public object Clone()
		{
			return null;
		}
	}

	[System.Serializable()]
	[System.ComponentModel.Browsable(true)]
	[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class")]
	class TestClass_Member
	{
        [System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Event")]
        event System.EventHandler<EventArgs> TestEvent1 = delegate { };
        public event System.EventHandler<EventArgs> TestEvent2 = delegate(object o,EventArgs e){ };
		private event System.EventHandler<EventArgs> TestEvent3;
		internal System.EventHandler<EventArgs> TestEvent4;
		protected System.EventHandler<EventArgs> TestEvent5;

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Delegate")]
		[return: System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Field Return")]
		delegate object DELEGATE1(int i);
		public delegate object DELEGATE2(int i);
		private delegate object DELEGATE3(int i);
		private delegate object DELEGATE4(int i);
		protected delegate object DELEGATE5(int i);

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Const Field")]
		const int CONST_INT0 = 0;
		public const int CONST_INT1 = 1;
		private const int CONST_INT = 2, CONST_INT3 = 3;
		internal const char CONST_CHAR = 'A';
		protected const string CONST_STRING = "ABC" + "XYZ";

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Field")]
		int Field_INT0 = 0;
		public int Field_INT1 = 1;
		private int Field_INT = 2, Field_INT3 = 3;
		internal char Field_CHAR = 'A';
		protected string Field_STRING = "ABC".Substring(1, 2) + "XYZ";
		private int[] Field_Array1 = new int[2];
		private int[,] Field_Array2 = { { 0, 1 }, { 2, 3 } };

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Constructor")]
		TestClass_Member() { }
		public TestClass_Member(int a) { }
		private TestClass_Member(long a) { }
		internal TestClass_Member(double a) { }
		protected TestClass_Member(string a) { }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Destructor")]
		~TestClass_Member()
		{
		}
	}

	/// <summary></summary>
	/// <remarks>
	/// I don't know how to get member of interface that matched interface, when the code has implemented by implicit.
	/// 一致するインターフェースのメンバーを見つける方法は不明です。
	/// </remarks>
	[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class")]
	public abstract class TestClass_Interface
		: TestInterface.ITestInterface_Member
	{
		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class Field")]
		private int x;

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class Method")]
		public void TestSub() { }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class Functino")]
		[return: System.ComponentModel.Description("Return")]
		public int TestFunction() { return 1; }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class ReadonlyProperty")]
		public int TestReadOnlyProperty { get { return 1; } }

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class Proeperty")]
		public int TestProperty
		{
			[System.ComponentModel.Description("Getter")]
			get { return 1; }
			[System.ComponentModel.Description("Setter")]
			set { value = 1; }
		}

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class Event Action")]
		public event System.Action TestActionEvent;

		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Class Event EventHandler")]
		public event EventHandler<EventArgs> TestEvent;
	}

	public abstract class TestClass_InterfaceExplicit
		: TestInterface.ITestInterface_Member
	{
		void TestInterface.ITestInterface_Member.TestSub() { }

		int TestInterface.ITestInterface_Member.TestFunction() { return 1; }

		int TestInterface.ITestInterface_Member.TestReadOnlyProperty { get { return 1; } }

		int TestInterface.ITestInterface_Member.TestProperty { get { return 1; } set { value = 1; } }

		event Action TestInterface.ITestInterface_Member.TestActionEvent
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}
		event EventHandler<EventArgs> TestInterface.ITestInterface_Member.TestEvent
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}
	}

	class TestClass_Inner
	{
		public enum TestEnum_Inner
		{
			A, B, C
		}

		protected struct TestStruct_Inner
		{
			public int a, b, c;
		}

		internal interface ITestInterface_Inner
		{
			void A();
		}

		private class TestClass_InnerInner
		{
			class TestClass_Inner2
			{
				public int X;
			}
		}
		class TestClass
		{
		}
	}

	class A
	{
		public A()
		{
		}
		public A(int i)
			: this((long)i)
		{
			int ai = i;
		}
		protected A(long l)
		{
			long al = l;
		}
		protected A(int i, long l, double d = 0)
		{
		}

		public virtual void X() { }

		[System.ComponentModel.Category("AttributeTest")]
		[System.ComponentModel.Description("Destructor")]
		~A()
		{
			int x;
		}
	}
	class TestClassConstructor : A
	{
		public TestClassConstructor()
			: base()
		{
		}
		public TestClassConstructor(int i)
			: base(i)
		{
		}
		public TestClassConstructor(long l)
			: base(l)
		{
		}
		public TestClassConstructor(int i, long l, double d)
			: base(i, l, d)
		{
		}



		public sealed override void X() { }
	}

	class TestConstructorInitialize
	{
		public TestConstructorInitialize(int a = 0, int b = 0)
		{

		}
		public int P { get; set; }

		public static void Test()
		{
			var a0 = new TestConstructorInitialize(1, 2);
            var a1 = new TestConstructorInitialize(b: 3);
            var a2 = new TestConstructorInitialize() { P = int.MaxValue };
		}

	}

	abstract class TestGenericClassConstraint<T, U, V>
		where T : class,new()
		where U : struct
		where V : EventArgs
	{
		public void GenericMethod<X, Y, Z>()
			where X : class ,new()
			where Y : struct
			where Z : EventArgs
		{
		}

		public delegate void GenericDelegate<A, B, C>()
			where A : class, new()
			where B : struct
			where C : EventArgs;

		protected abstract T Test(U value);
		protected abstract T TestReadOnlyProperty { get; }
		protected abstract T TestProperty { get; set; }
		event System.Action<U> TestActionEvent;
		event EventHandler<V> TestEvent;
	}

	class TestExtern
	{
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [System.Runtime.InteropServices.Out] System.Text.StringBuilder lParam);
	}
}

namespace TestNameSpace
{

	public sealed class C
	{
		private static void TestArgumentParams(int a, params int[] values)
		{
		}
		private static void TestArgumentOptional(int a, int b = 1, int? c = null)
		{
		}
		private static void TestArgumentRefOut(ref int a, out int b)
		{
			b = a;
		}


		private static void TestFieldInitialize()
		{
			int i0;
			int j0, k0;
			int i1 = 1;
			int i2 = 2, i3 = 3, i4 = i1 + i3;
			const int CON = 1 + 2 * 3;

			object obj = null;

			var vBool = true;
			var vInt = -1;
			var vUInt = 2u;
			var vLong = -3L;
			var vULong = 4UL;
			var vULong2 = 10000000000U;
			var vFloat = -5F;
			var vDouble = -6d;
			var vDecimal = -7m;
			var vDecimal000 = -7.0000000m;
			var vDateTime = DateTime.Now; //TODO:
			//var vDateTime2 = DateTime.Parse("2000/12/31 01:23:45");//C# not support. Dim vDateTime=#12/31/2000 01:23:45 AM#
			var vChar = 'a';

            var vhexL = 0x123L;
            var vhexU = 0x123U;


			var vString = "";

			dynamic dynamicField = vDateTime.TimeOfDay; ;

			var defaultInt = default(int);
			var defaultEnum = default(TestEnum.TestEnum_Long);
			var defaultStruct = default(TestStruct.TestStruct_Blank);
			var defaultClass = default(C);
		}

		private static void TestArrayAndInitialize()
		{
			int[] a0 = new int[0];
			int[,] a1 = new int[1, 1];

			int[] n1 = new int[4] { 2, 4, 6, 8 };
			int[] n2 = new int[] { 2, 4, 6, 8 };
			int[] n3 = { 2, 4, 6, 8 };

			string[] s1 = new string[3] { "A", "B", "C" };
			string[] s2 = new string[] { "A", "B", "C" };
			string[] s3 = { "A", "B", "C" };

			int[,] n4 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
			int[,] n5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
			int[,] n6 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

			// Jagged array.
			int[][] n7 = new int[2][] { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };
			int[][] n8 = new int[][] { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };
			int[][] n9 = { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };
			int[,][] n10 = new int[,][] { };// = ??
		}

		private static void TestStringLiteral()
		{
			char c0 = '\0';
			char c1 = '\x1';
			char cTab = '\t';
			char cBack = '\b';
			char cLf = '\n';
			char cFF = '\f';
			char cVTab = '\v';
			char cCR = '\r';
			char cA = 'a';

			string sNull = null;
			string s1 = "A";
			string s2 = "ABC";
			string s3 = "ABC" + "DEF";
			string s00 = "ABC\x0000DEF";
			string s01 = "ABC\x0001DEF";
			string s08 = "ABC\tDEF";
			string s09 = "ABC\bDEF";
			string s10 = "ABC\nDEF";
			string s11 = "ABC\fDEF";
			string s12 = "ABC\vDEF";
			string s13 = "ABC\rDEF";

			string s14 = "ABC\rDEF\r\nGHI";
		}
#if CS6
        private static void TestInterpolatedString()
        {
            int variable=0;
            string Interpolate0 = $"ABC\0_\t_\b_\n_\f_\v_\r_\n_DEF";
            string Interpolate1 = $"ABC{variable}DEF";
            string Interpolate2 = $"ABC{variable= 1+2}DEF";
            string Interpolate3 = $@"ABC\0_t_\b_\n_\f_\v_\r_\n_DEF{variable}GHI";
        }
#endif

		private static void Expression()
		{
			{
				int i = 0, K = 10;
				i = 222 + 34;
				i = i + K;

				i = 222 - 34;
				i = i - K;

				i = 222 * 34;
				i = i * K;

				i = 222 / 34;
				i = i / K;

				i = 222 % 34;
				i = i % K;


				i = 222 << 2;
				i = 222 >> 2;
				i = 222 & 34;
				i = 222 | 34;
				i = 222 ^ 34;
			}

			{
				int i = 0;
				i += 1;
				i -= 2;
				i *= 3;
				i /= 4;
				i <<= 5;
				i >>= 6;
			}
			{
				int i = 0;

				i %= 7;
				i &= 8;
				i |= 9;
				i ^= 10;
			}

			{
				int a, b, c, d = 1, e = 1;
				a = b = c = 123;
				a += b -= c *= d /= e %= 456;
				a <<= b >>= c <<= 1;
			}

			var longExpression1 = (0 == (1 + 2 * 3 / (4 % 5) ^ 6) << (7 >> 8))
										& !(9 == 10) & (~11 != 12) && (13 == 14) || (15 != 16) && (17 < 18) && (19 > 20) && (21 <= 22) && (23 >= 24)
										&& (new object() is List<object>) && (new object() == null) && (new object() != null);

			int x = 5, y = 2;
			var longExpression2 = (x == (x + x * x / (x % y) ^ x) << (x >> x))
									& !(x == x) & (~x != x) && (x == x) || (x != x) && (x < x) && (x > x) && (x <= x) && (x >= x);
		}

		private static int TestPrePostIncDec(int x)
		{
			int local = x;
			++local;
			--local;
			local++;
			local--;
			return local;
		}
		#region for VB
		private static int __PreIncrement__(ref int i)
		{
			i = i + 1;
			return i;
		}
		private static int __PreDecrement__(ref int i)
		{
			i = i - 1;
			return i;
		}
		private static int __PostIncrement__(ref int i)
		{
			int j = i;
			j = j + 1;
			return j;
		}
		private static int __PostDecrement__(ref int i)
		{
			int j = i;
			i = i - 1;
			return j;
		}
		#endregion

		private static int? TestReturnNullable(int? x)
		{
			return x;
		}

		private static List<int?> TestReturnNullable(List<int?> x)
		{
			return x;
		}

		private static int?[] TestReturnNullable(int?[] x)
		{
			return x;
		}

		private static List<int?[][]>[,][] TestReturnNullable(List<int?[][]>[,][] x)
		{
			return x;
		}

		private static List<dynamic[][]>[,][] TestReturnNullable(List<dynamic[][]>[,][] x)
		{
			return x;
		}

		private static int TestIF(int x)
		{
			if (x == 1)
				return 1;

			if (x == 2 || x == 3)
			{
				if (x == 2)
					return 2;
				else
					return 3;
			}
			else if (4 <= x && x <= 7)
			{
				if (x == 4)
					return 4;
				else if (x == 5)
					return 5;
				else if (x == 6)
					return 6;
				else
					return 7;
			}
			else if (x <= 8 && x <= 9)
			{
				if (x == 8)
				{
					return 8;
				}
				else
				{
					return 9;
				}
			}
			else if (10 <= x && x <= 11)
			{
				if (x == 10)
				{
					return 10;
				}
				else
				{
					return 11;
				}
			}
			else if (12 <= x && x <= 13)
			{
				if (x == 12)
				{
					return 12;
				}
				else if (x == 13)
				{
					return 13;
				}
			}
			else if (x == 14)
			{
				return 14;
			}
			else if (x == 15)
			{
				if (x != 15)
				{
					int y;
				}
				else if (false)
				{
					int y;
				}
				else
				{
					int y;
				}
				return 15; ;
			}
			return -x;
		}

		private static int TestLoop(int x)
		{
			while (x == 0) ;

			while (x == 1) return 1;

			while (x == 2)
			{
				int y = x;
				return 2;
			}
			while (true)
			{
				break;
			}

			do
			{
				int y = x;
				return 3;
			} while (false);

			do
			{
				break;
			} while (true);

			while (true)
			{
				do
				{
					while (true)
					{
						if (true)
						{
							break;
						}
						else
						{
							continue;
						}
					}
					break;
					continue;
				} while (true);
				break;
				continue;
			}

			goto JUMP;
			while (true) ;
		JUMP:
			return x;
		}

		private static int TestFor(int x)
		{
			int y = x;
			for (; ; )
			{
				break;
			}
			for (; false; )
			{
			}

			for (int i = 0, j = 0; i < x; i++, j += 2) ;

			for (int i = 0; i < x; i += 2)
			{
				double d = Math.PI;
			}


			for (int i = 0, j = 0; i < 100; ++i)
			{
				if (++j == 1)
				{
					continue;
				}
				break;
			}

			for (int i = 1; 0 <= i && i < 10; i *= 2 + 1)
			{
				if (i == 2)
				{
					continue;
				}
				for (int j = 0; j < 10; j++)
				{
					if (j == 1)
					{
						continue;
					}
				}
			}


			for (int i = 0; i < 10; i++)
			{
				continue;
				while (true)
				{
					do
					{
						for (int j = 0; i < 10; j++)
						{
							continue;
							break;
						}
						break;
						continue;
					} while (true);

					break;
					continue;
				}
				break;
			}

			for (var i = 0; i < 10; i++)
			{
			}
			for (dynamic i = 0; i < 10; i++)
			{
			}

			return x;
		}

		public static void TestForEach()
		{
			int x = 0;
			foreach (int i in new int[] { 1, 2, 3 })
			{
				x += i;
				continue;
				x += 1000;
			}

			foreach (int i in TestYield1(x))
			{
			}
			foreach (var i in TestYield1(x))
			{
				for (int j = 0; j < 10; j++)
				{
					foreach (int k in new int[] { 4, 5, 6 })
					{
						continue;
						break;
					}
				}
				continue;
				break;
			}
			foreach (int n in new int[] { 1, 2, 3 })
			{
				x++;
			}
			foreach (int n in TestYield1(x))
			{
				x++;
			}
			foreach (dynamic n in TestYield1(x))
			{
				x++;
			}
		}

		public static IEnumerable<int> TestYield1(int x)
		{
			if (x == 1)
			{
				yield return 1;
			}
			yield break;
		}
		public static IEnumerable<int> TestYield2(int x)
		{
			yield return 2;
		}
		public static IEnumerable<int> TestYield3(int x)
		{
			yield break;
		}

		private static int TestSelect(int x)
		{
			switch (x)
			{
				case 1:
					goto A;
				A:
					return 1;
				case 2:
					{
						return 2;
					}
				case 1 + 2:
				case 4:
					switch (x)
					{
						case 2:
							return 4;
						case 3:
							goto default;
						case 4:
							goto case 6;
						case 6:
							return 2;
						default:
							return 3;
					}
					break;
				case 5:
					goto case 6;
				case 6:
					return 5;

				case 7:
					x = -x;
					for (int i = 0; i < 10; i++)
					{
						break;
					}
					return 7;
				case 8:
					x = -x;
					foreach (int i in new int[0])
					{
						break;
					}
					return 8;
				case 9:
					x = -x;
					do
					{
						break;
					} while (false);
					return 9;
				case 10:
					x = -x;
					while (false)
					{
						break;
					}
					return 10;
				case 11:
					goto case 11 + 1;
					goto default;
				default:
				case 12:

					break;
			}
			return x;
		}


		class UsingTestClass : IDisposable
		{
			public void Dispose() { }
		}

		private static int TestUsing(int x)
		{
			UsingTestClass utemp1 = new UsingTestClass();
			using (utemp1)
			{
			}
			using (new UsingTestClass())
			{
			}
			using (UsingTestClass u = new UsingTestClass())
			{
				bool flag = true;
			}
			using (var u = new UsingTestClass())
			{
				bool flag = false;
			}
			using (UsingTestClass u1 = new UsingTestClass(), u2 = new UsingTestClass())
			{
				bool flag = false;
			}
			using (dynamic u1 = new UsingTestClass(), u2 = new UsingTestClass())
			{
				bool flag = false;
			}

			return x;
		}

		private static int TestTryCatchFinally(int x)
		{
			int y = x;
			try
			{
				y += 1;
				try
				{
					throw new System.IO.IOException();
				}
				catch (System.IO.IOException ex)
				{
					y += 2;
					throw;
				}
				catch (System.NullReferenceException)
				{
				}
				catch (Exception)
				{
					throw;
				}
			}
			catch (System.NullReferenceException) //if(y==0) //C#6 later
			{
				throw;
			}
			catch
			{
				y += 4;
			}
			finally
			{
				y += 8;
			}

			return x;
		}

		private static void TestLock(int x)
		{
			object o = new object();
			object p = new object();
			lock (o)
			{
				lock (p)
				{
					int q = 0;
				}
			}
		}
	}

	class TestProperty
	{

#if CS6
		#region AutoProperty
        int TestAutoProperty0 { get; set; }
        public int TestAutoProperty1 { get; set; }=1;
        private int TestAutoProperty2 { get; set; }=2;
        internal int TestAutoProperty3 { get; set; }=3;
        protected int TestAutoProperty4 { get; set; }=4;
        protected internal int TestAutoProperty5 { get; set; }=5;
        protected internal static int TestAutoProperty6 { get; set; }=6;
        public List<int> TestAutoProperty7 { get; set; }=new List<int>();


        public int TestUnbackProperty0 { private get; set; }=0;
        public int TestUnbackProperty1 { internal get; set; }=1;
        public int TestUnbackProperty2 { protected get; set; }=2;
        public int TestUnbackProperty3 { protected internal get; set; }=3;

        public int TestUnbackProperty4 { get; set; }=4;
        public int TestUnbackProperty5 { get; private set; }=5;
        public int TestUnbackProperty6 { get; internal set; }=6;
        public int TestUnbackProperty7 { get; protected set; }=7;
        public int TestUnbackProperty8 { get; protected internal set; }=8;

        public static int TestUnbackProperty9 { get; private set; }=9;

        public int TestUnbackProperty10 { get; }=10;

        public List<int> TestUnbackProperty11 { get; set; }=new List<int>();
		#endregion
        

        public int TestProperty0
        {
            get { return TestAutoProperty0; }
        }

        private int TestProperty1
        {
            set
            {
                TestAutoProperty0 = value;
            }
        }

        private int TestProperty2
        {
            get { return TestAutoProperty0; }
            set { TestAutoProperty0 = value; }
        }

        public int TestProperty3
        {
            get { return TestAutoProperty0; }
            private set { TestAutoProperty0 = value; }
        }
        public int TestProperty4
        {
            private get { return TestAutoProperty0; }
            set { TestAutoProperty0 = value; }
        }

        public static int TestProperty5
        {
            get { return TestAutoProperty5; }
            set { TestAutoProperty5 = value; }
        }

        public List<int> TestProperty6
        {
            get { return _TestPropert6; }
            set { _TestProperty6 = value; }
        }
        private List<int> _TestProperty6;

#else
		#region AutoProperty
		int TestAutoProperty0 { get; set; }
		public int TestAutoProperty1 { get; set; }
		private int TestAutoProperty2 { get; set; }
		internal int TestAutoProperty3 { get; set; }
		protected int TestAutoProperty4 { get; set; }
		protected internal int TestAutoProperty5 { get; set; }
		protected internal static int TestAutoProperty6 { get; set; }
		public List<int> TestAutoProperty7 { get; set; }


		public int TestUnbackProperty0 { private get; set; }
		public int TestUnbackProperty1 { internal get; set; }
		public int TestUnbackProperty2 { protected get; set; }
		public int TestUnbackProperty3 { protected internal get; set; }

		public int TestUnbackProperty4 { get; set; }
		public int TestUnbackProperty5 { get; private set; }
		public int TestUnbackProperty6 { get; internal set; }
		public int TestUnbackProperty7 { get; protected set; }
		public int TestUnbackProperty8 { get; protected internal set; }

		public static int TestUnbackProperty9 { get; private set; }

		//public int TestUnbackProperty10 { get; }
		//public List<int> TestUnbackProperty11 { get; set; }
		#endregion


		public int TestProperty0
		{
			get { return TestAutoProperty0; }
		}

		private int TestProperty1
		{
			set
			{
				TestAutoProperty0 = value;
			}
		}

		private int TestProperty2
		{
			get { return TestAutoProperty0; }
			set { TestAutoProperty0 = value; }
		}

		public int TestProperty3
		{
			get { return TestAutoProperty0; }
			private set { TestAutoProperty0 = value; }
		}
		public int TestProperty4
		{
			private get { return TestAutoProperty0; }
			set { TestAutoProperty0 = value; }
		}

		public static int TestProperty5
		{
			get { return TestUnbackProperty9; }
			set { TestUnbackProperty9 = value; }
		}

		public List<int> TestProperty6
		{
			get { return _TestProperty6; }
			set { _TestProperty6 = value; }
		}
		private List<int> _TestProperty6;
#endif

		int this[int a, int b]
		{
			get
			{
				return TestProperty6[a];
			}
			set
			{
				TestProperty6[a] = value;
			}
		}
	}

	struct TestOperator
	{
		public int Value;

		public static TestOperator operator +(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value + b.Value;
			return opNew;
		}

		public static TestOperator operator -(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value - b.Value;
			return opNew;
		}

		public static TestOperator operator *(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value * b.Value;
			return opNew;
		}

		public static TestOperator operator /(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value / b.Value;
			return opNew;
		}
		public static TestOperator operator %(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value % b.Value;
			return opNew;
		}
		public static TestOperator operator ~(TestOperator a)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = ~a.Value;
			return opNew;
		}

		public static TestOperator operator <<(TestOperator a, int i)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value << i;
			return opNew;
		}
		public static TestOperator operator >>(TestOperator a, int i)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value >> i;
			return opNew;
		}

		public static bool operator !(TestOperator a)
		{
			return false;
		}

		public static TestOperator operator &(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value & b.Value;
			return opNew;
		}

		public static TestOperator operator |(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value | b.Value;
			return opNew;
		}

		public static TestOperator operator ^(TestOperator a, TestOperator b)
		{
			TestOperator opNew = new TestOperator();
			opNew.Value = a.Value | b.Value;
			return opNew;
		}

		public static bool operator ==(TestOperator a, TestOperator b)
		{
			return a.Value == b.Value;
		}
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

		public static bool operator !=(TestOperator a, TestOperator b)
		{
			return a.Value != b.Value;
		}

		public static bool operator <(TestOperator a, TestOperator b)
		{
			return a.Value < b.Value;
		}

		public static bool operator <=(TestOperator a, TestOperator b)
		{
			return a.Value <= b.Value;
		}

		public static bool operator >(TestOperator a, TestOperator b)
		{
			return a.Value > b.Value;
		}

		public static bool operator >=(TestOperator a, TestOperator b)
		{
			return a.Value >= b.Value;
		}



		public static implicit operator int(TestOperator a)
		{
			return a.Value;
		}

		public static explicit operator short(TestOperator a)
		{
			return (short)a.Value;
		}


		//VB not supported
		[System.ComponentModel.Category("AttributeTest"), System.ComponentModel.Description("Operator")]
		[return: System.ComponentModel.Description("Return")]
		public static IEnumerable<int> operator +(IEnumerable<TestOperator> a, TestOperator b)
		{
			foreach (TestOperator o in a)
			{
				yield return o.Value + b.Value;
			}
		}
	}

	class L
	{
		private static void Lamba()
		{
			Action a0 = () => Console.ReadLine();

			Action a1 = () => { int x; };

			Action<int> a2 = (i) =>
			{
				Func<int> f = () =>
				{
					return 1;
				};
				i = i + 1;
				return;
			};


			Func<int> f0 = () => 0;
			Func<int> f1 = () => { return 0; };
			Func<int, int, int> f2 = (i, j) =>
			{
				Action a = () =>
				{
					return;
				};
				return i;
			};

			Lambda(a1);
			Lambda(() => { int x; });
			Lambda<int>(a => { int x; });

			Lambda(() => 1);
		}

		private static void Lambda(System.Action action)
		{
		}
		private static void Lambda<T>(System.Action<T> action)
		{
		}
		private static void Lambda(System.Func<int> action)
		{

		}
	}

	static class ExtentionMethodTest
	{

		public static int A { get; set; }
		public static void B() { }
		public static event EventHandler C;
		public static int D;

		public static IEnumerable<T> E<T>(this IEnumerable<T> ie1, IEnumerable<T> ie2, Func<T, T, bool> eq, Func<T, int> hash)
		{
			yield return default(T);
			yield break;
		}
	}

	interface IIndexer<T>
	{
		T this[int index] { get; }
	}
	class IndexerImplementTest : IIndexer<int>
	{
		[System.Runtime.CompilerServices.IndexerNameAttribute("Indexer")]
		public int this[int index]
		{
			get { return index; }
		}

		int IIndexer<int>.this[int index]
		{
			get { return index; }
		}
	}

}