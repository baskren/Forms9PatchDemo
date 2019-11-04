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
            },
        };
        #endregion


        #region Fields
        int attachments;
        #endregion


        #region Constructor
        public PngFromHtmlPage()
        {
            BackgroundColor = Color.White;

            _grid.Children.Add(new Xamarin.Forms.Label { Text = "Convert HTML to PNG", TextColor = Color.White });
            _grid.Children.Add(_htmlEditor, 0, 1);
            _grid.Children.Add(_destinationSelector, 0, 2);

            Padding = new Thickness(10, 40);

            Content = _grid;

            _destinationSelector.SegmentTapped += OnDestinationSelector_SegmentTapped;
        }

        private void OnDestinationSelector_SegmentTapped(object sender, SegmentedControlEventArgs e)
        {
            var entry = new Forms9Patch.MimeItemCollection();
            Forms9Patch.HtmlStringExtensions.ToPng(_htmlEditor.Text,"myHtmlPage", (string path) =>
            {
                if (path != null)
                {
                    if (path.Contains(".pdf"))
                        entry.AddBytesFromFile("application/pdf", path);
                    else if (path.Contains(".png"))
                        entry.AddBytesFromFile("image/png", path);
                    attachments--;
                }
                if (attachments <= 0)
                {
                    if (e.Segment.Text == shareButtonText)
                        Forms9Patch.Sharing.Share(entry, _destinationSelector);
                    else if (e.Segment.Text == copyButtonText)
                        Forms9Patch.Clipboard.Entry = entry;
                }
            });
        }
        #endregion
    }
}