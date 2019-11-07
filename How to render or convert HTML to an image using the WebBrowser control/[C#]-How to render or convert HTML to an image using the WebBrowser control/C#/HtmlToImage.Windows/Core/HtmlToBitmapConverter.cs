namespace EyeOpen.Imaging
{
	using System;
	using System.Drawing;
	using System.Threading;
	using System.Windows.Forms;
	using mshtml;

	public class HtmlToBitmapConverter
	{
		private const int SleepTimeMiliseconds = 5000;

		public Bitmap Render(string html, Size size)
		{
			var browser = CreateBrowser(size);

			browser.Navigate("about:blank");
			browser.Document.Write(html);

			return GetBitmapFromControl(browser, size);
		}

		public Bitmap Render(Uri uri, Size size)
		{
			var browser = CreateBrowser(size);

			NavigateAndWaitForLoad(browser, uri, 0);

			return GetBitmapFromControl(browser, size);
		}

		public void NavigateAndWaitForLoad(WebBrowser browser, Uri uri, int waitTime)
		{
			browser.Navigate(uri);
			var count = 0;

			while (browser.ReadyState != WebBrowserReadyState.Complete)
			{
				Thread.Sleep(SleepTimeMiliseconds);
				
				Application.DoEvents();
				count++;
				
				if (count > waitTime / SleepTimeMiliseconds)
				{
					break;
				}
			}

			while (browser.Document.Body == null)
			{
				Application.DoEvents();
			}

			HideScrollBars(browser);
		}

		private void HideScrollBars(WebBrowser browser)
		{
			const string Hidden = "hidden";
			var document = (IHTMLDocument2)browser.Document.DomDocument;
			var style = (IHTMLStyle2)document.body.style;
			style.overflowX = Hidden;
			style.overflowY = Hidden;
		}

		private WebBrowser CreateBrowser(Size size)
		{
			var 
				newBrowser =
					new WebBrowser
					{
						ScrollBarsEnabled = false,
						ScriptErrorsSuppressed = true,
						Size = size
					};

			newBrowser.BringToFront();

			return newBrowser;
		}

		private Bitmap GetBitmapFromControl(WebBrowser browser, Size size)
		{
			var bitmap = new Bitmap(size.Width, size.Height);

			NativeMethods.GetImage(browser.Document.DomDocument, bitmap, Color.White);
			return bitmap;
		}
	}
}