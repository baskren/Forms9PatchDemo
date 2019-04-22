using System;
using Xamarin.Forms;

namespace Forms9PatchDemo
{
    public class FlyoutDemo : ContentPage
    {
        #region VisualElements
        Forms9Patch.FlyoutPopup _flyout = new Forms9Patch.FlyoutPopup
        {
            Content = new Label { Text = "Flyout Content" },
            IsAnimationEnabled = true
        };

        Forms9Patch.SegmentedControl _orientationControl = new Forms9Patch.SegmentedControl
        {
            Segments =
            {
                new Forms9Patch.Segment("Horizontal"),
                new Forms9Patch.Segment("Vertical")
            }
        };

        Forms9Patch.SegmentedControl _alignmentControl = new Forms9Patch.SegmentedControl
        {
            Segments =
            {
                new Forms9Patch.Segment("Start"),
                new Forms9Patch.Segment("End")
            }
        };


        #endregion

        public FlyoutDemo()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Label{Text = "Orientation:"},
                    _orientationControl,
                    new Label{Text = "Alignment:"},
                    _alignmentControl
                }
            };

            _orientationControl.SegmentTapped += (sender, e) =>
            {
                _flyout.Orientation = e.Segment.Text == "Horizontal"
                    ? StackOrientation.Horizontal
                    : StackOrientation.Vertical;
                _flyout.IsVisible = true;
            };

            _alignmentControl.SegmentTapped += (sender, e) =>
            {
                _flyout.Alignment = e.Segment.Text == "Start"
                    ? Forms9Patch.FlyoutAlignment.Start
                    : Forms9Patch.FlyoutAlignment.End;
                _flyout.IsVisible = true;
            };
        }
    }
}