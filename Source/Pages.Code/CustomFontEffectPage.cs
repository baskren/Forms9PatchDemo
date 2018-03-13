// /*******************************************************************
//  *
//  * EmbeddedResourceFontEffectPage.cs copyright 2016 ben, 42nd Parallel - ALL RIGHTS RESERVED.
//  *
//  *******************************************************************/
using System;
using Xamarin.Forms;
using Forms9Patch;
namespace Forms9PatchDemo
{
    public class EmbeddedResourceFontEffectPage : Forms9Patch.HardwareKeyPage
    {
        public EmbeddedResourceFontEffectPage()
        {
            var label = new Xamarin.Forms.Label
            {
                Text = "Xamarin.Forms.Label",
                FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf"
            };
            Forms9Patch.EmbeddedResourceFontEffect.ApplyTo(label);

            var editor = new Xamarin.Forms.Editor
            {
                Text = "Xamarin.Forms.Editor",
                FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf"
            };
            editor.Effects.Add(new Forms9Patch.EmbeddedResourceFontEffect());

            var entry = new Xamarin.Forms.Entry
            {
                Text = "Xamarin.Forms.Entry",
                FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf"
            };
            entry.Effects.Add(new Forms9Patch.EmbeddedResourceFontEffect());

            Forms9Patch.SegmentedControl segmentedControl = new SegmentedControl
            {
                Margin = new Thickness(10, 0),
                FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf",
                Segments =
                {
                    new Forms9Patch.Segment("label"),
                    new Forms9Patch.Segment("editor"),
                    new Forms9Patch.Segment("entry"),
                }
            };

            Content = new Xamarin.Forms.StackLayout
            {
                Children =
                {
                    label,
                    editor,
                    entry,
                    new Xamarin.Forms.Label { Text="Focus:"},
                    segmentedControl
                }
            };

            segmentedControl.SegmentTapped += (sender, e) =>
            {
                switch (e.Segment.Text)
                {
                    case "label": label.HardwareKeyFocus(); break;
                    case "editor": editor.HardwareKeyFocus(); break;
                    case "entry": entry.HardwareKeyFocus(); break;
                }
            };

            HardwareKeyPage.FocusedElementChanged += (sender, e) =>
            {
                if (sender == label)
                    segmentedControl.SelectIndex(0);
                else if (sender == editor)
                    segmentedControl.SelectIndex(1);
                else if (sender == entry)
                    segmentedControl.SelectIndex(2);
                else
                    segmentedControl.DeselectAll();
            };

            label.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("label.Focused " + e.IsFocused);
            editor.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("editor.Focused " + e.IsFocused);
            entry.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("entry.Focused " + e.IsFocused);

            label.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("label.Unfocused " + e.IsFocused);
            editor.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("editor.Unfocused " + e.IsFocused);
            entry.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("entry.Unfocused " + e.IsFocused);

            label.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("label.FocusChangeRequested ");
            editor.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("editor.FocusChangeRequested ");
            entry.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("entry.FocusChangeRequested ");

            var pageKeyListener_a = this.AddHardwareKeyListener("A");
            pageKeyListener_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_cmd_a = this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.PlatformKey);
            pageKeyListener_cmd_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_div = this.AddHardwareKeyListener("/");
            pageKeyListener_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_option_div = this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Alternate);
            pageKeyListener_option_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_up = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            pageKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_down = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            pageKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_left = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            pageKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_right = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            pageKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_esc = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            pageKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_back_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.BackspaceDeleteInput);
            pageKeyListener_back_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_forward_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.ForwardDeleteInput);
            pageKeyListener_forward_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_insert = this.AddHardwareKeyListener(HardwareKey.InsertInput);
            pageKeyListener_insert.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_tab = this.AddHardwareKeyListener(HardwareKey.TabInput);
            pageKeyListener_tab.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_enter = this.AddHardwareKeyListener(HardwareKey.EnterReturnInput);
            pageKeyListener_enter.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_PageUp = this.AddHardwareKeyListener(HardwareKey.PageUpInput);
            pageKeyListener_PageUp.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_PageDown = this.AddHardwareKeyListener(HardwareKey.PageDownInput);
            pageKeyListener_PageDown.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_Home = this.AddHardwareKeyListener(HardwareKey.HomeInput);
            pageKeyListener_Home.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);
            var pageKeyListener_End = this.AddHardwareKeyListener(HardwareKey.EndInput);
            pageKeyListener_End.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page key=" + e.HardwareKey.Input);

            var entryKeyListener_up = entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            entryKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_down = entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            entryKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_left = entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            entryKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_right = entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            entryKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Entry key=" + e.HardwareKey.Input);
            var entryKeyListener_esc = entry.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            entryKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Entry key=" + e.HardwareKey.Input);

            var editorKeyListener_up = editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            editorKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_down = editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            editorKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_left = editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            editorKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_right = editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            editorKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Editor key=" + e.HardwareKey.Input);
            var editorKeyListener_esc = editor.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            editorKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Editor key=" + e.HardwareKey.Input);

            var labelKeyListener_up = label.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            labelKeyListener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Label key=" + e.HardwareKey.Input);
            var labelKeyListener_down = label.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            labelKeyListener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Label key=" + e.HardwareKey.Input);
            var labelKeyListener_left = label.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            labelKeyListener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Label key=" + e.HardwareKey.Input);
            var labelKeyListener_right = label.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            labelKeyListener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Label key=" + e.HardwareKey.Input);
            var labelKeyListener_esc = label.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            labelKeyListener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Label key=" + e.HardwareKey.Input);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HardwareKeyPage.DefaultFocusedElement = this;
        }
    }
}

