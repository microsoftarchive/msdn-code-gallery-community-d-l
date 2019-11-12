namespace HtmlToImage.Windows
{
	using System;
	using System.Drawing;
	using System.Windows.Forms;
	using EyeOpen.Imaging;

	public partial class MainForm : Form
	{
		private readonly Size size = new Size(1024, 768);

		public MainForm()
		{
			InitializeComponent();

			SetHtml();
		}

		private void RenderHtmlToBitmapLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			pictureBox.Image =
				new HtmlToBitmapConverter()
					.Render(htmlTextBox.Text, size);
		}

		private void NavigateLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			pictureBox.Image =
				new HtmlToBitmapConverter()
					.Render(new Uri(urlTextBox.Text), size);
		}

		private void SetHtml()
		{
			const string Html = 
				"<html>" + "\r\n" +
				"\t<body>" + "\r\n" +
				"\t\tleft" + "\r\n" +
				"\t\t<div style=\"text-align: right\">" + "\r\n" +
				"\t\t\tright" + "\r\n" +
				"\t\t</div>" + "\r\n" +
				"\t</body>" + "\r\n" +
			    "</html>";

			htmlTextBox.Text = Html;
		}
	}
}