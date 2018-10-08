using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Forms9PatchDemo.Pages
{
    public class StateButton : ContentPage
    {
        public StateButton()
        {
            var button = new Forms9Patch.Frame
            {
                //Text = "Click me",
                //ToggleBehavior = true,
                BackgroundColor = Color.NavajoWhite,
                OutlineRadius = 5,
                //BackgroundImage = new Forms9Patch.Image("Forms9PatchDemo.Resources.button"),
            };

            button.Content = new Xamarin.Forms.Label { Text = "Click me" };

            var listener = FormsGestures.Listener.For(button);


            var hasShadowSwitch = new Switch();
            hasShadowSwitch.Toggled += (sender, e) => button.HasShadow = e.Value;

            var hasOutlineSwitch = new Switch();
            hasOutlineSwitch.Toggled += (sender, e) => button.OutlineWidth = e.Value ? 1 : 0;


            Padding = 20;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "HasShadow" },
                    hasShadowSwitch,
                    new Label { Text = "HasOutline"},
                    hasOutlineSwitch,

                    button,
                }
            };

            listener.Tapped += (sender, e) =>
            //button.Clicked += (sender, e) =>
            {
                if (button.BackgroundImage == null)
                    button.BackgroundImage = new Forms9Patch.Image("Forms9PatchDemo.Resources.button");
                else
                    button.BackgroundImage = null;
            };
        }

    }
}