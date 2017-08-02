using Xamarin.Forms;
using System.Windows.Input;
using System;

namespace Forms9PatchDemo
{
    public class App : Application
    {

        public App()
        {
            //MainPage = new Forms9Patch.RootPage(new NavigationPage(new HomePage()));


            var contentPage = new ContentPage { Title = "Test", BackgroundColor = Color.Red };
            NavigationPage.SetHasNavigationBar(contentPage, false);

            var bubblePopupTestPage = new BubblePopupTestPage();
            NavigationPage.SetHasNavigationBar(bubblePopupTestPage, false);
            var masterDetailPage = new MasterDetailPage
            {
                Master = contentPage,
                Detail = bubblePopupTestPage
            };
            NavigationPage.SetHasNavigationBar(masterDetailPage, false);

            /*
            MainPage = new Forms9Patch.RootPage(masterDetailPage)
            {
                BackgroundColor = Color.Brown
            };
            */
            //NavigationPage.SetHasNavigationBar(MainPage, false);
            // masterDetailPage.

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

