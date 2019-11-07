namespace EyeOpen.ViewModel.Test
{
	using EyeOpen.MvvmSample.ViewModel;

	internal class FooDialogService 
		: IDialogService
	{
		public string Message { get; private set; }

		public void Show(string message)
		{
			Message = message;
		}
	}
}