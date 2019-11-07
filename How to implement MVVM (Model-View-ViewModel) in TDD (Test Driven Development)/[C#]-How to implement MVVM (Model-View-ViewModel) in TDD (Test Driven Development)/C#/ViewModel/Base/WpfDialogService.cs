namespace EyeOpen.MvvmSample.ViewModel
{
	using System.Windows;

	public class WpfDialogService : IDialogService
	{
		public void Show(string message)
		{
			MessageBox.Show(message);
		}
	}
}