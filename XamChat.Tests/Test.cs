using NUnit.Framework;
using System;
using XamChat.Core;
using System.Threading.Tasks;

namespace XamChat.Tests
{
	public class Test
	{
		public static void Setup()
		{
			ServiceContrainer.Register<IWebService> (() => new FakeWebService { SleepDuration = 0 });
			ServiceContrainer.Register<ISettings> (() => new FakeSettings());
		}
	}

	[TestFixture]
	public class LoginViewModelTests 
	{
		LoginViewModel loginViewModel;
		ISettings settings;

		[SetUp]
		public void Setup()
		{
			Test.Setup ();
			settings = ServiceContrainer.Resolve<ISettings> ();
			loginViewModel = new LoginViewModel ();
		}

		[Test]
		public async Task LoginSuccessfully()
		{
			loginViewModel.Username = "andrebaltieri";
			loginViewModel.Password = "andrebaltieri";
			await loginViewModel.Login ();
			Assert.That (settings.User, Is.Not.Null);
		}
	}
}

