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
    public class EmbeddedResourceFontEffectPage : Xamarin.Forms.ContentPage
    {
        public EmbeddedResourceFontEffectPage()
        {
            var label = new Xamarin.Forms.Label
            {
                Text = "Xamarin.Forms.Label",
                FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf"
            };
            //label.Effects.Add(new Forms9Patch.EmbeddedResourceFontEffect());
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

            var button = new Xamarin.Forms.Button
            {
                Text = "Xamarin.Forms.Button",
                FontFamily = "Forms9PatchDemo.Resources.Fonts.Pacifico.ttf"
            };
            button.Effects.Add(new Forms9Patch.EmbeddedResourceFontEffect());

            Content = new Xamarin.Forms.StackLayout
            {
                Children =
                {
                    label,
                    editor,
                    entry,
                    button
                }
            };


            label.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("label.Focused " + e.IsFocused);
            editor.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("editor.Focused " + e.IsFocused);
            entry.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("entry.Focused " + e.IsFocused);
            button.Focused += (sender, e) => System.Diagnostics.Debug.WriteLine("button.Focused " + e.IsFocused);

            label.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("label.Unfocused " + e.IsFocused);
            editor.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("editor.Unfocused " + e.IsFocused);
            entry.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("entry.Unfocused " + e.IsFocused);
            button.Unfocused += (sender, e) => System.Diagnostics.Debug.WriteLine("button.Unfocused " + e.IsFocused);

            label.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("label.FocusChangeRequested ");
            editor.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("editor.FocusChangeRequested ");
            entry.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("entry.FocusChangeRequested ");
            button.FocusChangeRequested += (object sender, FocusRequestArgs e) => System.Diagnostics.Debug.WriteLine("button.FocusChangeRequested ");

            button.Clicked += (sender, e) =>
            {
                label.Focus();
            };

            //Forms9Patch.FocusableEffect.ApplyTo(label);

            var keylistener_a = this.AddHardwareKeyListener("A");
            keylistener_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_cmd_a = this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.PlatformKey);
            keylistener_cmd_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);


            var keylistener_div = this.AddHardwareKeyListener("/");
            keylistener_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_option_div = this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Alternate);
            keylistener_option_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);



            var keylistener_up = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            keylistener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_down = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            keylistener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_left = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            keylistener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_right = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            keylistener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_esc = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            keylistener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);


            var keylistener_back_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.BackspaceDeleteInput);
            keylistener_back_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_forward_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.ForwardDeleteInput);
            keylistener_forward_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_insert = this.AddHardwareKeyListener(HardwareKey.InsertInput);
            keylistener_insert.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_tab = this.AddHardwareKeyListener(HardwareKey.TabInput);
            keylistener_tab.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_enter = this.AddHardwareKeyListener(HardwareKey.EnterReturnInput);
            keylistener_enter.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_PageUp = this.AddHardwareKeyListener(HardwareKey.PageUpInput);
            keylistener_PageUp.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_PageDown = this.AddHardwareKeyListener(HardwareKey.PageDownInput);
            keylistener_PageDown.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_Home = this.AddHardwareKeyListener(HardwareKey.HomeInput);
            keylistener_Home.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);

            var keylistener_End = this.AddHardwareKeyListener(HardwareKey.EndInput);
            keylistener_End.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Key=" + e.HardwareKey.Input);


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HardwareKeyFocus.Element = this;
        }
    }
}

