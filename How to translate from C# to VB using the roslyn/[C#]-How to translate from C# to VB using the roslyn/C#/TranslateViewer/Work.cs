using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.CodeAnalysis;
using CS = Microsoft.CodeAnalysis.CSharp;
using VB = Microsoft.CodeAnalysis.VisualBasic;

namespace Gekka.Roslyn.TranslateViewer
{
	enum TargetLanguage
	{
		CS, VB,
	}
	enum ItemType
	{
		Token, Node, Trivia
	}

	class Worker : System.ComponentModel.INotifyPropertyChanged, IDisposable
	{
		public Worker()
		{
			doCancel = new System.Threading.ManualResetEvent(false);
			doConvert = new System.Threading.ManualResetEvent(true);
			doSelect = new System.Threading.ManualResetEvent(false);

			Languages = (TargetLanguage[])Enum.GetValues(typeof(TargetLanguage)).Cast<TargetLanguage>().ToArray();

			dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;

			background = new System.Threading.Thread(Work);
			background.IsBackground = true;
			background.Start();
		}
		System.Windows.Threading.Dispatcher dispatcher;

		private bool changed;
		private System.Threading.ManualResetEvent doCancel;
		private System.Threading.ManualResetEvent doConvert;
		private System.Threading.ManualResetEvent doSelect;
		private System.Threading.Thread background;

		public TargetLanguage[] Languages { get; private set; }

		public TargetLanguage InputLanguage
		{
			get { return _InputLanguage; }
			set
			{
				_InputLanguage = value;
				OnPropertyChanged("InputLanguage");

				changed = true;
				doConvert.Set();
			}
		}
		private TargetLanguage _InputLanguage;

		public string InputText
		{
			get { return _InputText; }
			set
			{
				canSetSelection = false;
				_InputText = value;
				OnPropertyChanged("InputText");
				changed = true;
				doConvert.Set();
			}
		}
		private string _InputText;

		public string OutputText
		{
			get { return _OutputText; }
			private set
			{
				_OutputText = value;
				OnPropertyChanged("OutputText");
			}
		}
		private string _OutputText;

		/// <summary></summary>
		public Selection InputSelection
		{
			get
			{
				return _InputSelection;
			}
			set
			{
				if (_InputSelection != value)
				{
					_InputSelection = value;
					OnPropertyChanged("InputSelection");

					//doSelect.Set();
				}
			}
		}
		private Selection _InputSelection;

		private static Item Find(IEnumerable<Item> items, Selection sel)
		{
			foreach (Item item in items)
			{
				var node = item.Node;
				if (node != null)
				{
					var span = item.Node.FullSpan;
					if (item.Node.FullSpan.Start <= sel.Start && sel.End <= span.End)
					{
						var child = Find(item.Items, sel);
						if (child != null)
						{
							return child;
						}
						return item;
					}
				}
			}
			return null;
		}

		public Item Result
		{
			get { return _Result; }
			private set
			{
				_Result = value;
				OnPropertyChanged("Result");
			}
		}
		private Item _Result;

		/// <summary></summary>
		public Item SelectedItem
		{
			get
			{
				return _SelectedItem;
			}
			set
			{
				if (_SelectedItem != value)
				{
					_SelectedItem = value;
					OnPropertyChanged("SelectedItem");
					if (value != null)
					{
						SetSelection(value);
					}
				}
			}
		}
		private Item _SelectedItem;

		private bool canSetSelection = false;
		private void SetSelection(Item value)
		{
			if (!canSetSelection)
			{
				return;
			}

			int start = 0;
			int len = 0;
			if (value != null && value.Node != null)
			{
				var node = _SelectedItem.Node;
				start = node.Span.Start;
				len = node.Span.Length;

			}
			else if (value.LeadingTrivia.Count() > 0)
			{
				SyntaxTrivia trivia = value.LeadingTrivia.Last();
				start = trivia.Span.End;
				len = value.Text.Length;
			}
			else if (value.TrailingTrivia.Count() > 0)
			{
				SyntaxTrivia trivia = value.TrailingTrivia.First();
				start = trivia.Span.Start - value.Text.Length;
				len = value.Text.Length;
			}
			else if (value.Parent != null)
			{
				var parent = value.Parent;
				int index = parent.Items.IndexOf(value);
                if(index<0)
                {
                    return;
                }
                else if(index==0)
                {
                    start = 0;
                }
				else if (index > 0)
				{
					var prev = parent.Items[index - 1];
					if (prev.Node != null)
					{
						start = prev.Node.Span.Start;
					}
					else if (prev.TrailingTrivia.Count() > 0)
					{
						start = prev.TrailingTrivia.Last().Span.End;
					}
					else if (prev.LeadingTrivia.Count() > 0)
					{
						start = prev.LeadingTrivia.Last().Span.End + prev.Text.Length;
					}
					else
					{
						return;
					}
				}

				start = this.InputText.IndexOf(value.Text, start);
				if (start == -1)
				{
					return;
				}
				len = value.Text.Length;

			}
			else
			{
				return;
			}
			Selection sel = new Selection(start, len);
			this.InputSelection = sel;
		}

		public Microsoft.CodeAnalysis.SyntaxNode root;

		public int ConvertStartDelay
		{
			get
			{
				return _ConvertStartDelay;
			}
			set
			{
				_ConvertStartDelay = value;
				OnPropertyChanged("ConvertDelay");
			}
		}
		private int _ConvertStartDelay = 1000;

		private void Work()
		{
			string text = string.Empty;
			TargetLanguage language = TargetLanguage.VB; ;
			System.Threading.ManualResetEvent[] events2 = { doCancel, doConvert };
			while (true)
			{

				var evIndex = System.Threading.WaitHandle.WaitAny(events2);
				switch (evIndex)
				{
					case 0:
						return;
					case 1:
						#region
						{
							doConvert.Reset();
							evIndex = System.Threading.WaitHandle.WaitAny(events2, _ConvertStartDelay);
							if (evIndex == 0)
							{
								return;
							}
                            if (evIndex == 1)
                            {
                                continue;
                            }

							text = this.InputText;
							this.OutputText = "";
							language = this.InputLanguage;
							changed = false;
							doConvert.Reset();
							if (string.IsNullOrWhiteSpace(text))
							{
								Result = null;
								continue;
							}
							this.root = null;
							try
							{
								Item item;
								if (this.InputLanguage == TargetLanguage.VB)
								{
									var vbTree = VB.VisualBasicSyntaxTree.ParseText(text);
									var vbRoot = (VB.VisualBasicSyntaxNode)vbTree.GetRoot();

									var vbRoot2 = vbRoot.NormalizeWhitespace();

									this.OutputText = vbRoot2.ToFullString();


									item = Item.Create(vbRoot);
									this.root = vbRoot;
								}
								else
								{
									var csTree = CS.CSharpSyntaxTree.ParseText(this.InputText);
									var csRoot = (CS.CSharpSyntaxNode)csTree.GetRoot();

									Gekka.Roslyn.Translator.CS2VB.ResetCounter();
									var vbRoot = Gekka.Roslyn.Translator.CS2VB.Translate(text).NormalizeWhitespace();
									this.OutputText = vbRoot.ToFullString();


									item = Item.Create(csRoot);
									this.root = csRoot;
								}

								this.Result = item;
								this.doSelect.Set();
								GenerateItems(item);
								canSetSelection = true;
							}
							catch (Exception ex)
							{
								OutputText = ex.Message;
							}

						}
						#endregion
						break;
					case 2:
						#region
						{
							this.doSelect.Reset();

							//var sel = this.InputSelection;
							//var result = this.Result;
							//var root = this.root;
							//if (result != null && root != null && sel != null)
							//{
							//	var item = Find(result.Items, sel);
							//	if (item != null)
							//	{

							//	}
							//}
						}
						#endregion
						break;
					default:
						break;
				}

			}
		}

		private void GenerateItems(Item item)
		{
			Stack<Pack> stack = new Stack<Pack>();
			Pack pack;
			pack = new Pack(item);
			stack.Push(pack);
			while (stack.Count > 0 && !changed)
			{
				pack = stack.Peek();
				if (pack.ie == null || !pack.ie.MoveNext())
				{
					stack.Pop();
				}
				else
				{
					object o = pack.ie.Current;
					item = Item.Create(o);
					if (item != null)
					{
						item.Parent = pack.item;
						dispatcher.Invoke(() =>
						{
							pack.item.Items.Add(item);
						}, System.Windows.Threading.DispatcherPriority.Background);

						pack = new Pack(item);
						stack.Push(pack);
					}
				}
			}
		}

		struct Pack
		{
			public Item item;
			public IEnumerator<object> ie;

			public Pack(Item item)
			{
				this.item = item;
				this.ie = null;
				var x = item.GetItemObjects();
				if (x != null)
				{
					this.ie = x.GetEnumerator();
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string name)
		{
			var pc = PropertyChanged;
			if (pc != null)
			{
				pc(this, new System.ComponentModel.PropertyChangedEventArgs(name));
			}
		}

		public void Dispose()
		{
			//this.background.CancelAsync();
			//doConvert.Set();
			this.doCancel.Set();
			this.background.Join();
		}
	}

	class Item
	{
		#region Constructor

		public static Item Create(object o)
		{
			if (o is SyntaxNode)
			{
				return new Item((SyntaxNode)o);
			}
			else if (o is SyntaxNodeOrToken)
			{
				return new Item((SyntaxNodeOrToken)o);
			}
			if (o is SyntaxTrivia)
			{
				return new Item((SyntaxTrivia)o);
			}
			return null;
		}

		//public Item(Diagnostic d)
		//{
		//    this.ItemType = WpfApplication2.ItemType.Diagnostic;
		//    this.Value = d;
		//    this.Text = d.ToString();
		//}

		private Item(SyntaxTrivia t)
		{
			this.ItemType = ItemType.Trivia;
			this.Value = t;
			this.Text = t.ToFullString();
			bool isVB = IsVB(t.Language);
			this.Language = isVB ? TargetLanguage.VB : TargetLanguage.CS;
			if (this.Language == TargetLanguage.VB)
			{
				foreach (var k in kindsVB)
				{
					if (t.IsKind(k))
					{
						this.Text = k.ToString();
						break;
					}
				}
			}
			else
			{
				foreach (var k in kindsCS)
				{
					if (t.IsKind(k))
					{
						this.Text = k.ToString();
						break;
					}
				}
			}
		}
		private Item(SyntaxNodeOrToken x)
		{
			this.SyntaxNodeOrToken = x;
			this.ChildList = x.ChildNodesAndTokens();
			this.Language = IsVB(x.Language) ? TargetLanguage.VB : TargetLanguage.CS;
			if (this.SyntaxNodeOrToken.IsToken)
			{
				Value = this.Token = x.AsToken();
				Text = this.Token.Text;

				if (this.Language == TargetLanguage.VB)
				{
					foreach (var k in kindsVB)
					{
						if (this.Token.IsKind(k))
						{
							this.Kind = k;
							break;
						}
					}
				}
				else
				{
					foreach (var k in kindsCS)
					{
						if (this.Token.IsKind(k))
						{
							this.Kind = k;
							break;
						}
					}
				}
				this.ItemType = ItemType.Token;
			}
			else
			{
				Value = this.Node = x.AsNode();

				if (this.Node is VB.VisualBasicSyntaxNode)
				{
					var node = (VB.VisualBasicSyntaxNode)this.Node;
					this.Kind = node.Kind();
					this.Text = this.Kind.ToString();
				}
				else
				{
					this.Text = ((CS.CSharpSyntaxNode)Node).Kind().ToString();
					//Text = this.Node.ToString();
				}
				this.ItemType = ItemType.Node;
			}

		}

		#endregion

		#region

		public ItemType ItemType { get; set; }

		public object Kind { get; set; }

		public SyntaxNodeOrToken SyntaxNodeOrToken { get; set; }

		[System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
		public object Value { get; set; }

		[System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
		public SyntaxToken Token { get; private set; }

		public SyntaxNode Node { get; private set; }

		[System.ComponentModel.TypeConverter(typeof(System.ComponentModel.CollectionConverter))]
		//public IEnumerable<SyntaxTrivia> LeadingTrivia
		public List<SyntaxTrivia> LeadingTrivia
		{
			get
			{
				if (this.ItemType == ItemType.Token)
				{

                    return ConvertTrivia(this.Token.LeadingTrivia).ToList();

				}
				else if (this.ItemType == ItemType.Node)
				{

					return ConvertTrivia(this.Node.GetLeadingTrivia()).ToList();
				}
				else
				{
                    return new List<SyntaxTrivia>();
				}
			}
		}

        [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.CollectionConverter))]
        public List<SyntaxTrivia> TrailingTrivia
		{
			get
			{
				if (this.ItemType == ItemType.Token)
				{
					return ConvertTrivia(this.Token.TrailingTrivia).ToList();
				}
                else if (this.ItemType == ItemType.Node)
                {
                    return ConvertTrivia(this.Node.GetTrailingTrivia()).ToList();
                }
                else
                {
                    return new List<SyntaxTrivia>();
                }
			}
		}

		internal ChildSyntaxList ChildList { get; set; }

		internal IEnumerable<object> GetItemObjects()
		{
			if (this.ItemType == ItemType.Trivia)
			{
				SyntaxTrivia t = (SyntaxTrivia)Value;
				foreach (Diagnostic d in t.GetDiagnostics())
				{
					yield return d;
				}
			}
			else
			{
				if (this.ChildList != null)
				{
					foreach (SyntaxNodeOrToken c in this.ChildList)
					{
						if (c.IsKind(CS.SyntaxKind.EmptyStatement) || c.IsKind(VB.SyntaxKind.EmptyStatement))
						{
							continue;
						}
						yield return c;
					}
				}
			}
		}

		public System.Collections.ObjectModel.ObservableCollection<Item> Items
		{
			get
			{
				return _Items;
			}
		}
		private System.Collections.ObjectModel.ObservableCollection<Item> _Items = new System.Collections.ObjectModel.ObservableCollection<Item>();

		public TargetLanguage Language { get; set; }
		private static bool IsVB(string s)
		{
			return s == "Visual Basic";
		}

		static VB.SyntaxKind[] kindsVB = Enum.GetValues(typeof(VB.SyntaxKind)).Cast<VB.SyntaxKind>().ToArray();
		static CS.SyntaxKind[] kindsCS = Enum.GetValues(typeof(CS.SyntaxKind)).Cast<CS.SyntaxKind>().ToArray();

		#endregion

		public string Text { get; set; }
		public Item Parent { get; set; }
		public override string ToString()
		{
			return Text;
		}

		private static IEnumerable<SyntaxTrivia> ConvertTrivia(SyntaxTriviaList list)
		{
			foreach (SyntaxTrivia t in list)
			{
				if (!t.IsKind(CS.SyntaxKind.None))
				{
					yield return t;
				}
			}
		}
	}
}
