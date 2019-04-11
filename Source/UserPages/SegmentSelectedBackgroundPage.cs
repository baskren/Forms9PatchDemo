using System;

using Xamarin.Forms;
using Forms9Patch;

namespace Forms9PatchDemo
{
    public class SegmentSelectedBackgroundPage : Xamarin.Forms.ContentPage
    {
        SegmentedControl segCtrl = new SegmentedControl
        {
            HorizontalOptions = LayoutOptions.Start,
            WidthRequest = 1500,
            Padding = 4,
            OutlineWidth = 0,
            BackgroundColor = Color.FromRgb(112, 128, 144).MultiplyAlpha(0.5),
            OutlineColor = Color.FromRgb(112, 128, 144).WithLuminosity(0.25),
            Segments =
                {
                    new Segment { Text = "Orange" },
                    new Segment { Text = "Blue" },
                    new Segment { Text = "Yellow" },
                    new Segment { Text = "Orange" },
                    new Segment { Text = "Blue" },
                    new Segment { Text = "Yellow" }
                },
            SyncSegmentFontSizes = false
        };

        public SegmentSelectedBackgroundPage()
        {

            var borderSegCtrl = new SegmentedControl
            {
                Padding = 4,
                //OutlineWidth = 0,
                BackgroundColor = Color.FromRgb(112, 128, 144).MultiplyAlpha(0.5),
                OutlineColor = Color.FromRgb(112, 128, 144).WithLuminosity(0.25),
                Segments =
                {
                    new Segment { Text = "Orange" },
                    new Segment { Text = "Blue" },
                    new Segment { Text = "Yellow" }
                }
            };

            borderSegCtrl.SegmentSelected += (sender, e) =>
            {
                switch (e.Segment.Text)
                {
                    case "Orange":
                        borderSegCtrl.SelectedBackgroundColor = Color.Orange;
                        borderSegCtrl.SelectedTextColor = Color.Default;
                        break;
                    case "Blue":
                        borderSegCtrl.SelectedBackgroundColor = Color.Blue;
                        borderSegCtrl.SelectedTextColor = Color.White;
                        break;
                    case "Yellow":
                        borderSegCtrl.SelectedBackgroundColor = Color.Yellow;
                        borderSegCtrl.SelectedTextColor = Color.Default;
                        break;
                }
            };

            Content = new Xamarin.Forms.StackLayout
            {
                Padding = new Thickness(20),
                Children = {
                    new Xamarin.Forms.Label { Text = "SegmentSelectedBackgroundPage" },
                    //borderSegCtrl,
                    segCtrl
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
                Device.StartTimer(TimeSpan.FromSeconds(0.2), () =>
                {
                    //System.Diagnostics.Debug.WriteLine("=================================================");
                    segCtrl.WidthRequest -= 0.1;
                    return true;
                });

        }
    }
}

