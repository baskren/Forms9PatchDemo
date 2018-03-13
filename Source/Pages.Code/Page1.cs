using System;
using Forms9Patch;

using Xamarin.Forms;

namespace UiKeyCommandApp
{
    public class Page1 : Xamarin.Forms.ContentPage
    {
        readonly Xamarin.Forms.Button _button = new Xamarin.Forms.Button { Text = "Pop" };

        readonly Xamarin.Forms.Button _focusButton = new Xamarin.Forms.Button { Text = "Change Focus" };

        readonly Entry _entry = new Entry { Text = "Entry" };

        bool _entryLastFocused;

        public Page1()
        {

            var keylistener_a = this.AddHardwareKeyListener("A");
            keylistener_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_cmd_a = this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.PlatformKey);
            keylistener_cmd_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);


            var keylistener_div = this.AddHardwareKeyListener("/");
            keylistener_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_option_div = this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Alternate);
            keylistener_option_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);



            var keylistener_up = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            keylistener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_down = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            keylistener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_left = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            keylistener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_right = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            keylistener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_esc = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            keylistener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);


            var keylistener_back_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.BackspaceDeleteInput);
            keylistener_back_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_forward_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.ForwardDeleteInput);
            keylistener_forward_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_insert = this.AddHardwareKeyListener(HardwareKey.InsertInput);
            keylistener_insert.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            //var keylistener_tab = this.AddHardwareKeyListener(HardwareKey.TabInput);
            //keylistener_tab.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_enter = this.AddHardwareKeyListener(HardwareKey.EnterReturnInput);
            keylistener_enter.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_PageUp = this.AddHardwareKeyListener(HardwareKey.PageUpInput);
            keylistener_PageUp.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_PageDown = this.AddHardwareKeyListener(HardwareKey.PageDownInput);
            keylistener_PageDown.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_Home = this.AddHardwareKeyListener(HardwareKey.HomeInput);
            keylistener_Home.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);

            var keylistener_End = this.AddHardwareKeyListener(HardwareKey.EndInput);
            keylistener_End.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("Page1 Key=" + e.HardwareKey.Input);


            Padding = new Thickness(5, 25, 5, 5);

            _entry.Focused += (s, e) => _entryLastFocused = true;
            //_entry.Unfocused += (s, e) => System.Diagnostics.Debug.WriteLine("Entry Unfocued!!!");

            Content = new Xamarin.Forms.StackLayout
            {
                Children = {
                    new  Xamarin.Forms.Label { Text = "Hello Page 1" },
                    _entry,
                    _focusButton,
                    _button
                }
            };
            _button.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new Page1();
                await Navigation.PopModalAsync();
                //await Navigation.PopAsync();
            };
            _focusButton.Clicked += (object sender, EventArgs e) =>
            {
                if (_entryLastFocused)
                {
                    _button.Focus();
                    _entryLastFocused = false;

                }
                else
                    _entry.Focus();
            };


        }

        public Xamarin.Forms.Button Button => _button;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HardwareKeyFocus.DefaultElement = this;
        }
    }

}

