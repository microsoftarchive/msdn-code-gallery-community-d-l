namespace ExtendedDataGridView
{
    public class xC
	{

		private int _X;

		private int _Width;

		public xC()
		{
		}

		public xC(int x, int w)
		{
			this.X = x;
			this.Width = w;
		}

		public int X {
			get { return _X; }
			set { _X = value; }
		}

		public int Width {
			get { return _Width; }
			set { _Width = value; }
		}

	}
}
