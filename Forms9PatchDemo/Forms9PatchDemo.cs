using Xamarin.Forms;
using System.Windows.Input;
using System;

namespace Forms9PatchDemo
{
	public class App : Application
	{

		public App()
		{
			//MainPage = new Forms9Patch.RootPage(new NavigationPage(new HomePage ()));
			MainPage = Forms9Patch.RootPage.Create(new NavigationPage(new HomePage()));
			//MainPage = new xPage();
			//MainPage = new ImageCodePage();
		}


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

