using System;
using Xamarin.Forms;

namespace UiKeyCommandApp
{
    public class RootPage : Forms9Patch.ContentPage
    {

        Button _button = new Button { Text = "Push Page1" };

        public RootPage()
        {
            //Padding = 40;

            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "ROOT PAGE" },
                    //new Entry { Text = "Entry"}
                    _button
                }
            };

            _button.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new Page1();
                //await Navigation.PushModalAsync(page1);
                await Navigation.PushAsync(page1);
            };
            //Content = new Label { Text = "ROOT PAGE" };
        }


    }
}
