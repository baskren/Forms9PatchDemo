// /*******************************************************************
//  *
//  * SegmentNavPage1.cs copyright 2016 ben, 42nd Parallel - ALL RIGHTS RESERVED.
//  *
//  *******************************************************************/
using System;
using Xamarin.Forms;

namespace Forms9PatchDemo
{
    public class SegmentNavPage1 : ContentPage
    {
        public SegmentNavPage1()
        {
            Padding = new Thickness(5);
            BackgroundColor = Color.Red;

            // Define command for the items in the SegmentedController.
            var navigateCommand = new Command<Type>(async (Type pageType) =>
            {
                var page = (Page)Activator.CreateInstance(pageType);
                await this.Navigation.PushAsync(page);
            });

            var backCommand = new Command<Type>(async (obj) =>
            {
                await this.Navigation.PopAsync();
            });


            var segmentControl = new Forms9Patch.SegmentedControl
            {
                Segments = {
                    new Forms9Patch.Segment
                    {
                        Text = "Back",
                        Command = backCommand

                    },
                    new Forms9Patch.Segment
                    {
                        Text = "Page 2",
                        Command = navigateCommand,
                        CommandParameter = typeof(SegmentNavPage2),
                    },
                    new Forms9Patch.Segment
                    {
                        Text = "Page 3",
                        Command = navigateCommand,
                        CommandParameter = typeof(SegmentNavPage3),
                    }
                },
            };

            var layout = new StackLayout
            {
                Children = {
                    new Label { Text = "Segment Nav Page 1" },
                    segmentControl,
                    new BoxView { HeightRequest = 1, BackgroundColor = Color.Black },
                    new Label {
                        Text = "1",
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = 50,
                    }
                }
            };

            Content = layout;
        }
    }
}
