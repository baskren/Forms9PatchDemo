using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Forms9PatchDemo.Pages
{
    public class SingleButton : ContentPage
    {
        public SingleButton()
        {
            var button = new Forms9Patch.Button { Text = "Click me", ToggleBehavior = true, BackgroundColor = Color.NavajoWhite, OutlineRadius = 5 };

            var hasShadowSwitch = new Switch();
            hasShadowSwitch.Toggled += (sender, e) => button.HasShadow = e.Value;

            var hasOutlineSwitch = new Switch();
            hasOutlineSwitch.Toggled += (sender, e) => button.OutlineWidth = e.Value ? 1 : 0;

            var longPressSwitch = new Switch();
            longPressSwitch.Toggled += (s, e) => button.IsLongPressEnabled = e.Value;

            Padding = 20;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "HasShadow" },
                    hasShadowSwitch,
                    new Label { Text = "HasOutline"},
                    hasOutlineSwitch,
                    new Label { Text = "Long Press Enabled"},
                    longPressSwitch,

                    button,
                }
            };
            button.IsLongPressEnabled = longPressSwitch.IsToggled;
            button.HasShadow = hasShadowSwitch.IsToggled;
            button.OutlineWidth = hasOutlineSwitch.IsToggled ? 1 : 0;

            button.Tapped += (object sender, EventArgs e) => Forms9Patch.Toast.Create(null, "Tapped: ");

            button.Clicked += (object sender, EventArgs e) => Forms9Patch.Toast.Create(null, "Clicked");

            button.Selected += (object sender, EventArgs e) => Forms9Patch.Toast.Create(null, "Selected");

            button.LongPressed += (object sender, EventArgs e) => Forms9Patch.Toast.Create(null, "Long Pressed");

            button.LongPressing += (object sender, EventArgs e) => Forms9Patch.Toast.Create(null, "Long Pressing");

        }

    }
}