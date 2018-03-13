using System;
using Xamarin.Forms;
using Forms9Patch;

namespace UiKeyCommandApp
{
    public class RootPage : Xamarin.Forms.ContentPage
    {

        Xamarin.Forms.Button _button = new Xamarin.Forms.Button { Text = "Push Page1" };

        Xamarin.Forms.Button _focusButton = new Xamarin.Forms.Button { Text = "Change Focus" };

        Entry _entry = new Entry { Text = "Entry" };

        bool _entryLastFocused;

        public RootPage()
        {
            //Padding = 40;
            var keylistener_a = this.AddHardwareKeyListener("A");
            keylistener_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_cmd_a = this.AddHardwareKeyListener("a", HardwareKeyModifierKeys.PlatformKey);
            keylistener_cmd_a.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);


            var keylistener_div = this.AddHardwareKeyListener("/");
            keylistener_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_option_div = this.AddHardwareKeyListener("/", HardwareKeyModifierKeys.Alternate);
            keylistener_option_div.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);



            var keylistener_up = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.UpArrowInput);
            keylistener_up.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_down = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.DownArrowInput);
            keylistener_down.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_left = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.LeftArrowInput);
            keylistener_left.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_right = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.RightArrowInput);
            keylistener_right.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_esc = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.EscapeInput);
            keylistener_esc.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);


            var keylistener_back_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.BackspaceDeleteInput);
            keylistener_back_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_forward_delete = this.AddHardwareKeyListener(Forms9Patch.HardwareKey.ForwardDeleteInput);
            keylistener_forward_delete.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_insert = this.AddHardwareKeyListener(HardwareKey.InsertInput);
            keylistener_insert.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            //var keylistener_tab = this.AddHardwareKeyListener(HardwareKey.TabInput);
            //keylistener_tab.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_enter = this.AddHardwareKeyListener(HardwareKey.EnterReturnInput);
            keylistener_enter.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_PageUp = this.AddHardwareKeyListener(HardwareKey.PageUpInput);
            keylistener_PageUp.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_PageDown = this.AddHardwareKeyListener(HardwareKey.PageDownInput);
            keylistener_PageDown.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_Home = this.AddHardwareKeyListener(HardwareKey.HomeInput);
            keylistener_Home.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);

            var keylistener_End = this.AddHardwareKeyListener(HardwareKey.EndInput);
            keylistener_End.Pressed += (object sender, HardwareKeyEventArgs e) => System.Diagnostics.Debug.WriteLine("RootPage Key=" + e.HardwareKey.Input);


            Content = new Xamarin.Forms.StackLayout
            {
                Children =
                {
                    new Xamarin.Forms.Label { Text = "ROOT PAGE" },
                    _entry,
                    _focusButton,
                    _button
                }
            };

            _entry.Focused += (s, e) => _entryLastFocused = true;
            //_entry.Unfocused += (s, e) => System.Diagnostics.Debug.WriteLine("Entry Unfocued!!!");

            _button.Clicked += async (object sender, EventArgs e) =>
            {
                var page1 = new Page1();
                await Navigation.PushModalAsync(page1);
                //await Navigation.PushAsync(page1);
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


        protected override void OnAppearing()
        {
            base.OnAppearing();
            HardwareKeyFocus.DefaultElement = this;

        }
    }
}
