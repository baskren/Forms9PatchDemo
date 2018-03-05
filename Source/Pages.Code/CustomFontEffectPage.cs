// /*******************************************************************
//  *
//  * EmbeddedResourceFontEffectPage.cs copyright 2016 ben, 42nd Parallel - ALL RIGHTS RESERVED.
//  *
//  *******************************************************************/
using System;
using Xamarin.Forms;
namespace Forms9PatchDemo
{
    public class EmbeddedResourceFontEffectPage : ContentPage
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

            Content = new StackLayout
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

            Forms9Patch.FocusableEffect.ApplyTo(label);
        }
    }
}

