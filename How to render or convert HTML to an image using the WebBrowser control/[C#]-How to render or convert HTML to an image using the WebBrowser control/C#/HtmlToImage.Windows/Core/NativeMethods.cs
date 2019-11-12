namespace EyeOpen.Imaging
{
	using System;
	using System.Drawing;
	using System.Runtime.InteropServices;

	public static class NativeMethods
	{
		private const int SM_CXVSCROLL = 2;

		[ComImport]
		[Guid("0000010D-0000-0000-C000-000000000046")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		private interface IViewObject
		{
			void Draw([MarshalAs(UnmanagedType.U4)] uint dwAspect, int lindex, IntPtr pvAspect, [In] IntPtr ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [MarshalAs(UnmanagedType.Struct)] ref Rect lprcBounds, [In] IntPtr lprcWBounds, IntPtr pfnContinue, [MarshalAs(UnmanagedType.U4)] uint dwContinue);
		}

		public static int GetSystemMetrics()
		{
			return GetSystemMetrics(SM_CXVSCROLL);
		}

		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int smIndex);

		public static void GetImage(object obj, Image destination, Color backgroundColor)
		{
			using (var graphics = Graphics.FromImage(destination))
			{
				var deviceContextHandle = IntPtr.Zero;
				var rectangle =
					new Rect
					{
						Right = destination.Width,
						Bottom = destination.Height
					};

				graphics.Clear(backgroundColor);

				try
				{
					deviceContextHandle = graphics.GetHdc();

					var viewObject = obj as IViewObject;
					viewObject.Draw(1, -1, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, deviceContextHandle, ref rectangle, IntPtr.Zero, IntPtr.Zero, 0);
				}
				finally
				{
					if (deviceContextHandle != IntPtr.Zero)
					{
						graphics.ReleaseHdc(deviceContextHandle);
					}
				}
			}
		}
	}
}