using System;
using Forms9Patch;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
    public class ModalHardwareKeyPage : Forms9Patch.HardwareKeyPage
    {
        readonly Xamarin.Forms.Label _label = new Xamarin.Forms.Label { Text = "Xamarin.Forms.Label: ModalHardwareKeyPage" };

        readonly Xamarin.Forms.Button _button = new Xamarin.Forms.Button { Text = "Pop Page1" };

        readonly Xamarin.Forms.Editor _editor = new Xamarin.Forms.Editor { Text = "Xamarin.Forms.Editor: Page1" };

        readonly Xamarin.Forms.Entry _entry = new Xamarin.Forms.Entry { Text = "Xamarin.Forms.Entry: Page1" };

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

        public ModalHardwareKeyPage()
        {
            this.AddHardwareKeyListener("ç", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("é", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("ф", OnHardwareKeyPressed);

            this.AddHardwareKeyListener("A", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.PlatformKey, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.Control, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.Alternate, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.CapsLock, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.FunctionKey, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("A", HardwareKeyModifierKeys.Shift, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.Shift | HardwareKeyModifierKeys.Alternate, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.Shift | HardwareKeyModifierKeys.Control, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.Shift | HardwareKeyModifierKeys.PlatformKey, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.Control | HardwareKeyModifierKeys.Alternate, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.Control | HardwareKeyModifierKeys.PlatformKey, OnHardwareKeyPressed);


            this.AddHardwareKeyListener("5", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.NumericPadKey, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.PlatformKey, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.Control, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.Alternate, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.CapsLock, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.FunctionKey, OnHardwareKeyPressed);
            this.AddHardwareKeyListener("5", HardwareKeyModifierKeys.Shift, OnHardwareKeyPressed);



            this.AddHardwareKeyListener("/", OnHardwareKeyPressed);
            this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Alternate, OnHardwareKeyPressed);

            this.AddHardwareKeyListener(HardwareKey.UpArrowKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.DownArrowKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.LeftArrowKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.RightArrowKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.EscapeKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.BackspaceDeleteKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.ForwardDeleteKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.InsertKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.TabKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.EnterReturnKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.PageUpKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.PageDownKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.HomeKeyLabel, OnHardwareKeyPressed);
            this.AddHardwareKeyListener(HardwareKey.EndKeyLabel, OnHardwareKeyPressed);

            _entry.AddHardwareKeyListener(HardwareKey.UpArrowKeyLabel, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.DownArrowKeyLabel, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.LeftArrowKeyLabel, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.RightArrowKeyLabel, OnHardwareKeyPressed);
            _entry.AddHardwareKeyListener(HardwareKey.EscapeKeyLabel, OnHardwareKeyPressed);

            _editor.AddHardwareKeyListener(HardwareKey.UpArrowKeyLabel, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.DownArrowKeyLabel, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.LeftArrowKeyLabel, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.RightArrowKeyLabel, OnHardwareKeyPressed);
            _editor.AddHardwareKeyListener(HardwareKey.EscapeKeyLabel, OnHardwareKeyPressed);

            _label.AddHardwareKeyListener(HardwareKey.UpArrowKeyLabel, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.DownArrowKeyLabel, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.LeftArrowKeyLabel, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.RightArrowKeyLabel, OnHardwareKeyPressed);
            _label.AddHardwareKeyListener(HardwareKey.EscapeKeyLabel, OnHardwareKeyPressed);

            _button.AddHardwareKeyListener(HardwareKey.UpArrowKeyLabel, OnHardwareKeyPressed);
            _button.AddHardwareKeyListener(HardwareKey.DownArrowKeyLabel, OnHardwareKeyPressed);
            _button.AddHardwareKeyListener(HardwareKey.LeftArrowKeyLabel, OnHardwareKeyPressed);
            _button.AddHardwareKeyListener(HardwareKey.RightArrowKeyLabel, OnHardwareKeyPressed);
            _button.AddHardwareKeyListener(HardwareKey.EscapeKeyLabel, OnHardwareKeyPressed);


            _segmentedControl.SegmentTapped += (sender, e) =>
            {
                switch (e.Segment.Text)
                {
                    case "label": _label.HardwareKeyFocus(); break;
                    case "editor": _editor.HardwareKeyFocus(); break;
                    case "entry": _entry.HardwareKeyFocus(); break;
                    case "button": _button.HardwareKeyFocus(); break;
                }
            };

            Forms9Patch.HardwareKeyPage.FocusedElementChanged += (sender, e) =>
            {
                if (sender == _label)
                    _segmentedControl.SelectIndex(0);
                else if (sender == _editor)
                    _segmentedControl.SelectIndex(1);
                else if (sender == _entry)
                    _segmentedControl.SelectIndex(2);
                else if (sender == _button)
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
                    _button,
                    new Xamarin.Forms.Label { Text="Focus:"},
                    _segmentedControl
                }
            };

            _button.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new ModalHardwareKeyPage();
                await Navigation.PopModalAsync();
                //await Navigation.PopAsync();
            };



        }

        public Xamarin.Forms.Button Button => _button;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Forms9Patch.HardwareKeyPage.DefaultFocusedElement = this;
        }

        void OnHardwareKeyPressed(object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("FocusedElement=[" + Forms9Patch.HardwareKeyPage.FocusedElement + "] KeyLabel=[" + e.HardwareKey.KeyLabel + "] ModifierKeys=[" + e.HardwareKey.ModifierKeys + "]");

    }

}

