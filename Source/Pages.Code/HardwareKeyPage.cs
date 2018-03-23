using System;
using Xamarin.Forms;
using Forms9Patch;

namespace Forms9PatchDemo
{
    public class HardwareKeyPage : Forms9Patch.HardwareKeyPage
    {

        readonly Xamarin.Forms.Label _label = new Xamarin.Forms.Label { Text = "Xamarin.Forms.Label: HardwareKeyPage" };

        readonly Xamarin.Forms.Button _modalButton = new Xamarin.Forms.Button { Text = "Modal Push Page1" };
        readonly Xamarin.Forms.Button _navButton = new Xamarin.Forms.Button { Text = "Navigate Push Page1" };

        readonly Xamarin.Forms.Editor _editor = new Xamarin.Forms.Editor { Text = "Xamarin.Forms.Editor: RootPage" };

        readonly Xamarin.Forms.Entry _entry = new Xamarin.Forms.Entry { Text = "Xamarin.Forms.Entry: RootPage" };

        readonly Xamarin.Forms.Label _inputLabel = new Xamarin.Forms.Label { Text = "Hardware Keyboard Input" };
        readonly Xamarin.Forms.Label _modifiersLabel = new Xamarin.Forms.Label { Text = "Hardware Keyboard Modifiers" };
        readonly Xamarin.Forms.Label _keyboardType = new Xamarin.Forms.Label { Text = "Hardware Keyboard Type" };

        Forms9Patch.SegmentedControl _segmentedControl = new SegmentedControl
        {
            Margin = new Thickness(10, 0),
            FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf",
            Segments =
                {
                    new Forms9Patch.Segment("label"),
                    new Forms9Patch.Segment("editor"),
                    new Forms9Patch.Segment("entry"),
                    new Forms9Patch.Segment("button"),
                }
        };

        public HardwareKeyPage()
        {
            this.AddHardwareKeyListener("ç", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("é", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("ф", OnHardwareKeyPressed);

            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.Any, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.Any, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("+", HardwareKeyModifierKeys.Any, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Any, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("(", HardwareKeyModifierKeys.Any, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(")", HardwareKeyModifierKeys.Any, OnHardwareKeyPressed);

            this.AddHardwareKeyListener(HardwareKey.UpArrowKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.DownArrowKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.LeftArrowKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.RightArrowKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.EscapeKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.BackspaceDeleteKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.ForwardDeleteKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.InsertKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.TabKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.EnterReturnKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.PageUpKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.PageDownKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.HomeKeyInput, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.EndKeyInput, OnHardwareKeyPressed);

            _entry.AddHardwareKeyListener(HardwareKey.UpArrowKeyInput, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.DownArrowKeyInput, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.LeftArrowKeyInput, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.RightArrowKeyInput, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.EscapeKeyInput, OnHardwareKeyPressed);

            _editor.AddHardwareKeyListener(HardwareKey.UpArrowKeyInput, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.DownArrowKeyInput, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.LeftArrowKeyInput, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.RightArrowKeyInput, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.EscapeKeyInput, OnHardwareKeyPressed);

            _label.AddHardwareKeyListener(HardwareKey.UpArrowKeyInput, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.DownArrowKeyInput, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.LeftArrowKeyInput, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.RightArrowKeyInput, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.EscapeKeyInput, OnHardwareKeyPressed);

            _modalButton.AddHardwareKeyListener(HardwareKey.UpArrowKeyInput, OnHardwareKeyPressed);
            _modalButton.AddHardwareKeyListener(HardwareKey.DownArrowKeyInput, OnHardwareKeyPressed);
            _modalButton.AddHardwareKeyListener(HardwareKey.LeftArrowKeyInput, OnHardwareKeyPressed);
            _modalButton.AddHardwareKeyListener(HardwareKey.RightArrowKeyInput, OnHardwareKeyPressed);
            _modalButton.AddHardwareKeyListener(HardwareKey.EscapeKeyInput, OnHardwareKeyPressed);


            _segmentedControl.SegmentTapped += (sender, e) =>
            {
                switch (e.Segment.Text)
                {
                    case "label": _label.HardwareKeyFocus(); break;
                    case "editor": _editor.HardwareKeyFocus(); break;
                    case "entry": _entry.HardwareKeyFocus(); break;
                    case "button": _modalButton.HardwareKeyFocus(); break;
                }
            };

            HardwareKeyPage.FocusedElementChanged += (sender, e) =>
            {
                if (sender == _label)
                    _segmentedControl.SelectIndex(0);
                else if (sender == _editor)
                    _segmentedControl.SelectIndex(1);
                else if (sender == _entry)
                    _segmentedControl.SelectIndex(2);
                else if (sender == _modalButton)
                    _segmentedControl.SelectIndex(3);
                else
                    _segmentedControl.DeselectAll();
            };


            Padding = new Thickness(5, 25, 5, 5);

            Content = new Xamarin.Forms.StackLayout
            {
                Children = {
                    _label,
                    _editor,
                    _entry,
                    _modalButton,
                    _navButton,
                    new Xamarin.Forms.Label { Text="Focus:"},
                    _segmentedControl,
                    new BoxView { Color = Color.Black, HeightRequest = 2 },
                    _inputLabel,
                    _modifiersLabel,
                    _keyboardType
                }
            };

            _modalButton.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new HardwareKeyPage1(true);
                await Navigation.PushModalAsync(page1);
                //await Navigation.PushAsync(page1);
            };

            _navButton.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new HardwareKeyPage1(false);
                //await Navigation.PushModalAsync(page1);
                await Navigation.PushAsync(page1);
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HardwareKeyPage.DefaultFocusedElement = this;
        }

        void OnHardwareKeyPressed(object sender, HardwareKeyEventArgs e)
        {
            _inputLabel.Text = e.HardwareKey.KeyInput;
            _modifiersLabel.Text = e.HardwareKey.ModifierKeys.ToString();
            _keyboardType.Text = Forms9Patch.KeyboardService.LanguageRegion;
            System.Diagnostics.Debug.WriteLine("FocusedElement=[" + Forms9Patch.HardwareKeyPage.FocusedElement + "] KeyInput=[" + e.HardwareKey.KeyInput + "] ModifierKeys=[" + e.HardwareKey.ModifierKeys + "] Layout=[" + Forms9Patch.KeyboardService.LanguageRegion + "]");
        }

    }
}
