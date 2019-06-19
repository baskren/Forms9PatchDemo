using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

//[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace Forms9PatchDemo
{
    /*
    public class App : Application
    {

        ICommand _trueCommand = new Command((parameter) => System.Diagnostics.Debug.WriteLine("_simpleCommand Parameter[" + parameter + "]"), parameter => true);

        ICommand _falseCommand = new Command(parameter => System.Diagnostics.Debug.WriteLine("_commandB [" + parameter + "]"), parameter => false);


        void OnSegmentTapped(object sender, Forms9Patch.SegmentedControlEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Tapped Segment[" + e.Index + "] Text=[" + e.Segment.Text + "]");
        }

        void OnSegmentSelected(object sender, Forms9Patch.SegmentedControlEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Selected Segment[" + e.Index + "] Text=[" + e.Segment.Text + "]");
        }

        void OnSegmentLongPressing(object sender, Forms9Patch.SegmentedControlEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LongPressing Segment[" + e.Index + "] Text=[" + e.Segment.Text + "]");
        }

        void OnSegmentLongPressed(object sender, Forms9Patch.SegmentedControlEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LongPressed Segment[" + e.Index + "] Text=[" + e.Segment.Text + "]");
        }

        void OnMaterialButtonTapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Tapped Button Text=[" + ((Forms9Patch.Button)sender).Text + "]");
        }

        void OnMaterialButtonSelected(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Selected Button Text=[" + ((Forms9Patch.Button)sender).Text + "]");
        }

        void OnMaterialButtonLongPressing(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LongPressing Button Text=[" + ((Forms9Patch.Button)sender).Text + "]");
        }

        void OnMaterialButtonLongPressed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LongPressed Button Text=[" + ((Forms9Patch.Button)sender).Text + "]");
        }

        void OnImageButtonTapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Tapped Button Text=[" + ((Forms9Patch.StateButton)sender).Text + "]");
        }

        void OnImageButtonSelected(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Selected Button Text=[" + ((Forms9Patch.StateButton)sender).Text + "]");
        }

        void OnImageButtonLongPressing(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LongPressing Button Text=[" + ((Forms9Patch.StateButton)sender).Text + "]");
        }

        void OnImageButtonLongPressed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LongPressed Button Text=[" + ((Forms9Patch.StateButton)sender).Text + "]");
        }

        const bool debugProperties = true;
        //static bool debugCollections = true;

        HomePage homePage = new HomePage();
        NavigationPage navPage;
        Forms9PatchDemo.Shell shell;


        public App()
        {
            var pageStyle = new Style(typeof(Page))
            {
                Setters = {
                    new Setter { Property = Page.BackgroundColorProperty, Value = Color.White }
                },
                ApplyToDerivedTypes = true
            };
            var labelStyle = new Style(typeof(Label))
            {
                Setters = { new Setter { Property = Label.TextColorProperty, Value = Color.Black } },
                ApplyToDerivedTypes = true
            };
            var entryStyle = new Style(typeof(Entry))
            {
                Setters = { new Setter { Property = Entry.TextColorProperty, Value = Color.Black } },
                ApplyToDerivedTypes = true
            };
            var editorStyle = new Style(typeof(Editor))
            {
                Setters = { new Setter { Property = Editor.TextColorProperty, Value = Color.Black } },
                ApplyToDerivedTypes = true
            };
            var buttonStyle = new Style(typeof(Button))
            {
                Setters = { new Setter { Property = Button.TextColorProperty, Value = Color.Blue } },
                ApplyToDerivedTypes = true
            };
            var textCellStyle = new Style(typeof(TextCell))
            {
                Setters = { new Setter { Property = TextCell.TextColorProperty, Value = Color.Black } },
                ApplyToDerivedTypes = true
            };

            Resources = new ResourceDictionary();
            Resources.Add(pageStyle);
            Resources.Add(labelStyle);
            Resources.Add(entryStyle);
            Resources.Add(editorStyle);
            Resources.Add(buttonStyle);
            Resources.Add(textCellStyle);


            if (Device.RuntimePlatform == Device.UWP)
                MainPage = navPage = new NavigationPage(homePage);
            else
                MainPage = shell = new Forms9PatchDemo.Shell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
    */
}

