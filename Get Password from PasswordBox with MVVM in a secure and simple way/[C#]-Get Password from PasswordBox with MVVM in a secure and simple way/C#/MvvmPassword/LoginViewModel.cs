/* 
   Copyright 2014 Christoph Gattnar 
 
   Licensed under the Apache License, Version 2.0 (the "License"); 
   you may not use this file except in compliance with the License. 
   You may obtain a copy of the License at 
 
	   http://www.apache.org/licenses/LICENSE-2.0 
 
   Unless required by applicable law or agreed to in writing, software 
   distributed under the License is distributed on an "AS IS" BASIS, 
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
   See the License for the specific language governing permissions and 
   limitations under the License. 
*/

using MvvmPassword.MVVMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmPassword
{
	public class LoginViewModel : ViewModelBase
	{
		private string _PasswordInVM;
		public LoginViewModel()
		{
			LoginCommand = new RelayCommand(Login);
		}

		public ICommand LoginCommand
		{
			get;
			private set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string PasswordInVM
		{
			get
			{
				return _PasswordInVM;
			}
			set
			{
				_PasswordInVM = value;
				OnPropertyChanged("PasswordInVM");
			}
		}

		private void Login(object parameter)
		{
			var passwordContainer = parameter as IHavePassword;
			if (passwordContainer != null)
			{
				var secureString = passwordContainer.Password;
				PasswordInVM = ConvertToUnsecureString(secureString);
			}
		}

		private string ConvertToUnsecureString(System.Security.SecureString securePassword)
		{
			if (securePassword == null)
			{
				return string.Empty;
			}

			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
				return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}
	}
}
