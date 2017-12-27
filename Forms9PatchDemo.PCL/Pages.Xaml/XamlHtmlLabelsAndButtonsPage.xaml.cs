using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
    public partial class XamlHtmlLabelsAndButtonsPage : ContentPage
    {
        public XamlHtmlLabelsAndButtonsPage()
        {
            InitializeComponent();

            TightSpacingButton.Clicked += (sender, e) =>
            {
                StateButton.HasTightSpacing = TightSpacingButton.IsSelected;
            };

            TrailingIconButton.Clicked += (sender, e) =>
            {
                StateButton.TrailingIcon = TrailingIconButton.IsSelected;
            };

            TextAlignmentControl.SegmentSelected += (sender, e) =>
            {
                switch (e.Segment.Text.ToLower())
                {
                    case "start":
                        msc.HorizontalTextAlignment = TextAlignment.Start;
                        StateButton.HorizontalTextAlignment = TextAlignment.Start;
                        break;
                    case "center":
                        msc.HorizontalTextAlignment = TextAlignment.Center;
                        StateButton.HorizontalTextAlignment = TextAlignment.Center;
                        break;
                    case "end":
                        msc.HorizontalTextAlignment = TextAlignment.End;
                        StateButton.HorizontalTextAlignment = TextAlignment.End;
                        break;

                }
            };
        }


    }
}

