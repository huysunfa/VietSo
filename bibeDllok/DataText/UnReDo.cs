using System;
using System.Collections.Generic;
using System.Linq;
using CommonModel;

namespace DataText
{
	// Token: 0x02000025 RID: 37
	public class UnReDo<T>
	{
		// Token: 0x06000278 RID: 632 RVA: 0x0000B768 File Offset: 0x00009968
		public UnReDo()
		{
			this.stack_0 = new global::System.Collections.Generic.Stack<string>();
			this.stack_1 = new global::System.Collections.Generic.Stack<string>();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000B794 File Offset: 0x00009994
		public void Store(T v)
		{
			if (v == null)
			{
				return;
			}
			string item = global::DataText.UnReDo<T>.smethod_0(v);
			this.stack_0.Push(item);
			global::System.Collections.Generic.Stack<string> stack = new global::System.Collections.Generic.Stack<string>();
			if (7 < this.stack_0.Count)
			{
				while (1 < this.stack_0.Count)
				{
					stack.Push(this.stack_0.Pop());
				}
				this.stack_0.Clear();
				while (0 < stack.Count)
				{
					this.stack_0.Push(stack.Pop());
				}
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000B820 File Offset: 0x00009A20
		public T Undo(T v)
		{
			if (this.stack_0.Count == 0)
			{
				return default(T);
			}
			if (v != null)
			{
				string item = global::DataText.UnReDo<T>.smethod_0(v);
				this.stack_1.Push(item);
				global::System.Collections.Generic.Stack<string> stack = new global::System.Collections.Generic.Stack<string>();
				if (5 < this.stack_1.Count<string>() && 5 < this.stack_1.Count)
				{
					while (1 < this.stack_1.Count)
					{
						stack.Push(this.stack_1.Pop());
					}
					this.stack_1.Clear();
					while (0 < stack.Count)
					{
						this.stack_1.Push(stack.Pop());
					}
				}
			}
			return global::CommonModel.UtilModel.ConvertJSON2Obj<T>(this.stack_0.Pop());
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000B8E4 File Offset: 0x00009AE4
		public T Redo(T v)
		{
			if (this.stack_1.Count == 0)
			{
				return default(T);
			}
			this.Store(v);
			return global::CommonModel.UtilModel.ConvertJSON2Obj<T>(this.stack_1.Pop());
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600027C RID: 636 RVA: 0x0000B920 File Offset: 0x00009B20
		public bool CanUndo
		{
			get
			{
				return this.stack_0.Count > 0;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600027D RID: 637 RVA: 0x0000B93C File Offset: 0x00009B3C
		public bool CanRedo
		{
			get
			{
				return this.stack_1.Count > 0;
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000B958 File Offset: 0x00009B58
		static string smethod_0(object object_0)
		{
			return global::CommonModel.UtilModel.Convert2JSON(object_0);
		}

		// Token: 0x04000082 RID: 130
		private global::System.Collections.Generic.Stack<string> stack_0;

		// Token: 0x04000083 RID: 131
		private global::System.Collections.Generic.Stack<string> stack_1;
	}
}
