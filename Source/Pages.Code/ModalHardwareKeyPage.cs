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

            var pageKeyListener_a = this.AddHardwareKeyListener("A");
            pageKeyListener_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_cmd_a = this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.PlatformKey);
            pageKeyListener_cmd_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_div = this.AddHardwareKeyListener("/");
            pageKeyListener_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_option_div = this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Alternate);
            pageKeyListener_option_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_up = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            pageKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_down = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            pageKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_left = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            pageKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_right = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            pageKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_esc = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            pageKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_back_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.BackspaceDeleteInput);
            pageKeyListener_back_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_forward_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.ForwardDeleteInput);
            pageKeyListener_forward_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_insert = this.AddHardwareKeyListener(HardwareKey.InsertInput);
            pageKeyListener_insert.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_tab = this.AddHardwareKeyListener(HardwareKey.TabInput);
            pageKeyListener_tab.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_enter = this.AddHardwareKeyListener(HardwareKey.EnterReturnInput);
            pageKeyListener_enter.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_PageUp = this.AddHardwareKeyListener(HardwareKey.PageUpInput);
            pageKeyListener_PageUp.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_PageDown = this.AddHardwareKeyListener(HardwareKey.PageDownInput);
            pageKeyListener_PageDown.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_Home = this.AddHardwareKeyListener(HardwareKey.HomeInput);
            pageKeyListener_Home.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);
            var pageKeyListener_End = this.AddHardwareKeyListener(HardwareKey.EndInput);
            pageKeyListener_End.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Page key=" + e.HardwareKey.Input);

            var entryKeyListener_up = _entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            entryKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_down = _entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            entryKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_left = _entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            entryKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_right = _entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            entryKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_esc = _entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            entryKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Entry key=" + e.HardwareKey.Input);

            var editorKeyListener_up = _editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            editorKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_down = _editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            editorKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_left = _editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            editorKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_right = _editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            editorKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_esc = _editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            editorKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Editor key=" + e.HardwareKey.Input);

            var labelKeyListener_up = _label.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            labelKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Label key=" + e.HardwareKey.Input);
            var labelKeyListener_down = _label.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            labelKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Label key=" + e.HardwareKey.Input);
            var labelKeyListener_left = _label.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            labelKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Label key=" + e.HardwareKey.Input);
            var labelKeyListener_right = _label.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            labelKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Label key=" + e.HardwareKey.Input);
            var labelKeyListener_esc = _label.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            labelKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Label key=" + e.HardwareKey.Input);

            var buttonKeyListener_up = _button.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            buttonKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Button key=" + e.HardwareKey.Input);
            var buttonKeyListener_down = _button.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            buttonKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Button key=" + e.HardwareKey.Input);
            var buttonKeyListener_left = _button.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            buttonKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Button key=" + e.HardwareKey.Input);
            var buttonKeyListener_right = _button.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            buttonKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Button key=" + e.HardwareKey.Input);
            var buttonKeyListener_esc = _button.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            buttonKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("ModalHardwareKeyPage Button key=" + e.HardwareKey.Input);


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
    }

}

