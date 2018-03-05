using System;

using Xamarin.Forms;

namespace UiKeyCommandApp
{
    public class Page1 : Forms9Patch.ContentPage
    {
        Button _button = new Button { Text = "Pop" };

        public Page1()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello Page 1" },
                    _button
                }
            };
            _button.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new Page1();
                //await Navigation.PopModalAsync();
                await Navigation.PopAsync();
            };
        }
    }
}

