namespace EyeOpen.Imaging
{
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Rect
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}
}