using System;

namespace XamChat.Core
{
	public class BaseViewModel
	{
		protected readonly IWebService service = ServiceContrainer.Resolve<IWebService> ();
		protected readonly ISettings settings = ServiceContrainer.Resolve<ISettings> ();

		public event EventHandler IsBusyChanged = delegate { };

		private bool isBusy = false;

		public bool IsBusy {
			get { return isBusy; }
			set {
				isBusy = value;
				IsBusyChanged (this, EventArgs.Empty);
			}
		}
	}
}

