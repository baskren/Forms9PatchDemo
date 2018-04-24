using System;
using Xamarin.Forms;
using Forms9PatchDemo.Pages;
using Forms9PatchDemo.Pages.Code;

namespace Forms9PatchDemo
{
    class HomePage : Xamarin.Forms.ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            /*
			var modal = new Forms9Patch.ModalPopup
			{
				Content = new Forms9Patch.StackLayout
				{
					Children = {
										new Xamarin.Forms.Label {
											Text = "Hello Modal popup!",
											TextColor = Color.Black}
									},
					BackgroundColor = Color.FromRgb(100, 100, 100),
					Padding = 20,
				},
				OutlineRadius = 4,
				OutlineWidth = 1,
				OutlineColor = Color.Black,
				BackgroundColor = Color.Aqua,
				HasShadow = true,
				HeightRequest = 200,
				WidthRequest = 200,
			};
			modal.BindingContext = this;
			modal.IsVisible = true;		
			*/
        }


        public HomePage()
        {
            // Define command for the items in the TableView.



            var navigateCommand =
                new Command<Type>(async (Type pageType) =>
                {
                    var page = (Page)Activator.CreateInstance(pageType);
                    await this.Navigation.PushAsync(page);
                    //await this.Navigation.PushModalAsync(page);  // PushModalAsync will cause popups not to work
                });

            this.Title = "Forms Gallery";
            this.Content = new TableView
            {
                Intent = TableIntent.Menu,

                Root = new TableRoot {
                    new TableSection("User Pages") {
                        new TextCell {
                            Text = "User Pages",
                            Command = navigateCommand,
                            CommandParameter = typeof(UserPagesHomePage)
                        },
                    },

                    #if USE_XAML
                    new TableSection("XAML") {

                        new TextCell {
                            Text = "XamlCDATA",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlCDATA)
                        },

                        new TextCell {
                            Text = "XamlContentViewDemoPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlContentViewDemoPage)
                        },

                        new TextCell {
                            Text = "XamlFrameDemoPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlFrameDemoPage)
                        },

                        new TextCell {
                            Text = "XamlSingleStateButton",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlSingleStateButtonPage)
                        },

                        new TextCell {
                            Text = "XamlStateButtonsPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlStateButtonsPage)
                        },

                        new TextCell {
                            Text = "XamlSegmentedControlPage ",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlSegmentedControlPage)
                        },

                        new TextCell {
                            Text = "XamlImagesPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlImagesPage)
                        },

                        new TextCell {
                            Text = "XamlHtmlLabelsAndButtonsPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlHtmlLabelsAndButtonsPage)
                        },

                        new TextCell {
                            Text = "XamlCapsInsetPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(XamlCapsInsetPage)
                        },

                    },
                    #endif

                    new TableSection("Code") {

                        new TextCell {
                            Text = "Picker in Popup",
                            Command = navigateCommand,
                            CommandParameter = typeof(PickerInPopup)
                        },

                        new TextCell {
                            Text = "ListView Sandbox",
                            Command = navigateCommand,
                            CommandParameter = typeof(ListViewSandbox)
                        },

                        new TextCell {
                            Text = "ClipboardTest",
                            Command = navigateCommand,
                            CommandParameter = typeof(ClipboardTest)
                        },

                        new TextCell {
                            Text = "LabelAutoFitPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(LabelAutoFitPage)
                        },

                        new TextCell {
                            Text = "ImageCodePage",
                            Command = navigateCommand,
                            CommandParameter = typeof(ImageCodePage)
                        },

                        new TextCell {
                            Text = "Layout CodePage",
                            Command = navigateCommand,
                            CommandParameter = typeof(LayoutCodePage)
                        },

                        new TextCell {
                            Text = "Button & Segment Alignments",
                            Command = navigateCommand,
                            CommandParameter = typeof(ButtonAndSegmentAlignments)
                        },

                        new TextCell
                        {
                            Text = "Button CodePage",
                            Command = navigateCommand,
                            CommandParameter = typeof(ButtonCodePage)
                        },

                        new TextCell {
                            Text = "HTML Formatted Labels",
                            Command = navigateCommand,
                            CommandParameter = typeof(HtmlLabelPage)
                        },

                        new TextCell {
                            Text = "HTML Formatted Buttons",
                            Command = navigateCommand,
                            CommandParameter = typeof(HtmlButtonsPage)
                        },

                        new TextCell {
                            Text = "PopupsPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(PopupsPage)
                        },

                        new TextCell {
                            Text = "Gestures Test Page",
                            Command = navigateCommand,
                            CommandParameter = typeof(GestureTestPage)
                        },

                        new TextCell {
                            Text = "SVG ButtonBackgroundImage",
                            Command = navigateCommand,
                            CommandParameter = typeof(SVG_ButtonBackgroundImage)
                        },


                        new TextCell {
                            Text = "Simple Label Autofit test",
                            Command = navigateCommand,
                            CommandParameter = typeof(SimpleLabelFitting)
                        },

                    },

                    new TableSection("Single Examples")
                    {
                        new TextCell
                        {
                            Text = "Single Button",
                            Command = navigateCommand,
                            CommandParameter = typeof(SingleButton)
                        },

                        new TextCell
                        {
                            Text = "Single SegmentedControl",
                            Command = navigateCommand,
                            CommandParameter = typeof(SingleSegmentedControl)
                        },

                        new TextCell
                        {
                            Text = "Html Link",
                            Command = navigateCommand,
                            CommandParameter = typeof(HtmlLink)
                        },

                        new TextCell {
                            Text = "HardwareKeyPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(Forms9PatchDemo.HardwareKeyPage)
                        },


                        new TextCell {
                            Text = "EmbeddedResource Font Effect + HardwareKeyPage",
                            Command = navigateCommand,
                            CommandParameter = typeof(EmbeddedResourceFontEffectPage)
                        },

                        new TextCell {
                            Text = "External EmbeddedResource Image",
                            Command = navigateCommand,
                            CommandParameter = typeof(ExternalEmbeddedResourceImage)
                        },

                        new TextCell {
                            Text = "Modal Popup",
                            Command = navigateCommand,
                            CommandParameter = typeof(ModalPopupTestPage)
                        },

                        new TextCell {
                            Text = "Bubble Popup",
                            Command = navigateCommand,
                            CommandParameter = typeof(BubblePopupTestPage)
                        },

                        new TextCell {
                            Text = "FontSizeTest",
                            Command = navigateCommand,
                            CommandParameter = typeof(FontSizeTest)
                        },


                    }
                }
            };
        }
    }
}
