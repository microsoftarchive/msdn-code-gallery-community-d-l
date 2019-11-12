namespace ExtendedDataGridView
{
    public class yC
	{

		private int _Y;

		private int _Height;
		public yC(int y, int h)
		{
			this.Y = y;
			this.Height = h;
		}

		public int Y {
			get { return _Y; }
			set { _Y = value; }
		}

		public int Height {
			get { return _Height; }
			set { _Height = value; }
		}

	}
}
