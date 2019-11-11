using Forms9Patch;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Forms9PatchDemo
{
    public class PngFromHtmlPage : Xamarin.Forms.ContentPage
    {

        const string shareButtonText = "SHARE PNG";
        const string copyButtonText = "COPY PNG";

        const string htmlText = @"
<!DOCTYPE html>
<html>
<body>

<h1>Convert to PNG</h1>

<p>This html will be converted to a PNG.</p>

</body>
</html>
";

        #region VisualElements
        Editor _htmlEditor = new Editor
        {
            Placeholder = "enter HTML to convert to PNG here",
            Text = htmlText,
            TextColor = Color.Black,
            BackgroundColor = Color.White
        };

        Forms9Patch.SegmentedControl _destinationSelector = new SegmentedControl
        {
            Segments =
            {
                new Segment(shareButtonText),
                new Segment(copyButtonText)
            },
            GroupToggleBehavior = GroupToggleBehavior.None
        };


        Xamarin.Forms.Grid _grid = new Xamarin.Forms.Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = 40 },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = 40 },
                new RowDefinition { Height = 100 }
            },
        };
        #endregion




        #region Constructor
        public PngFromHtmlPage()
        {
            BackgroundColor = Color.White;

            _grid.Children.Add(new Xamarin.Forms.Label { Text = "Convert HTML to PNG", TextColor = Color.White });
            _grid.Children.Add(_htmlEditor, 0, 1);
            _grid.Children.Add(_destinationSelector, 0, 2);
            _grid.Children.Add(new Xamarin.Forms.Label 
            {
                Text = "Size: " + P42.Utils.DiskSpace.Humanize(P42.Utils.DiskSpace.Size) + "\nUsed: " + P42.Utils.DiskSpace.Humanize( P42.Utils.DiskSpace.Used) + "\nFree: " + P42.Utils.DiskSpace.Humanize(P42.Utils.DiskSpace.Free),
                VerticalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,

            },0,3);

            Padding = new Thickness(10, 40);

            Content = _grid;

            _destinationSelector.SegmentTapped += OnDestinationSelector_SegmentTapped;
        }

        async void OnDestinationSelector_SegmentTapped(object sender, SegmentedControlEventArgs e)
        {
            var entry = new Forms9Patch.MimeItemCollection();
            
            if (await Forms9Patch.HtmlStringExtensions.ToPngAsync(_htmlEditor.Text, "myHtmlPage") is HtmlToPngResult result)
            {
                if (result.IsError)
                {
                    using (Forms9Patch.Toast.Create("PNG error", result.Result)) { }
                }
                else
                {
                    if (result.Result.Contains(".pdf"))
                        entry.AddBytesFromFile("application/pdf", result.Result);
                    else if (result.Result.Contains(".png"))
                        entry.AddBytesFromFile("image/png", result.Result);

                    if (e.Segment.Text == shareButtonText)
                        Forms9Patch.Sharing.Share(entry, _destinationSelector);
                    else if (e.Segment.Text == copyButtonText)
                        Forms9Patch.Clipboard.Entry = entry;
                }
            }
        }
        #endregion
    }
}