using System;
using Xamarin.Forms;

namespace Forms9PatchDemo
{
	class HomePage : ContentPage
	{
		public HomePage()
		{
			// Define command for the items in the TableView.
			Command<Type> navigateCommand = 
				new Command<Type>(async (Type pageType) => {
						Page page = (Page)Activator.CreateInstance(pageType);
						await this.Navigation.PushAsync(page);
					});

			this.Title = "Forms Gallery";
			this.Content = new TableView {
				Intent = TableIntent.Menu,
				Root = new TableRoot {
					new TableSection("XAML") {
						new TextCell {
							Text = "ContentView",
							Command = navigateCommand,
							CommandParameter = typeof(ContentViewDemoPage)
						},

						new TextCell {
							Text = "Frame",
							Command = navigateCommand,
							CommandParameter = typeof(FrameDemoPage)
						},

						new TextCell {
							Text = "ImageButton",
							Command = navigateCommand,
							CommandParameter = typeof(ImageButtonPage)
						},

						new TextCell {
							Text = "MaterialSegmentControl ",
							Command = navigateCommand,
							CommandParameter = typeof(MaterialSegmentControlPage)
						},

						new TextCell {
							Text = "Image",
							Command = navigateCommand,
							CommandParameter = typeof(MyPage)
						}
					}, 

					new TableSection("Code") {
						new TextCell {
							Text = "ImageButton",
							Command = navigateCommand,
							CommandParameter = typeof(ImageButtonCodePage)
						},

						new TextCell {
							Text = "Image",
							Command = navigateCommand,
							CommandParameter = typeof(ImageCodePage)
						},

						new TextCell {
							Text = "Layouts",
							Command = navigateCommand,
							CommandParameter = typeof(LayoutsPage)
						},

						new TextCell {
							Text = "Material Buttons",
							Command = navigateCommand,
							CommandParameter = typeof(MaterialButtonsPage)
						},

						new TextCell {
							Text = "Modal Popup",
							Command = navigateCommand,
							CommandParameter = typeof(ModalPopupTestPage),
						},

						new TextCell {
							Text = "Bubble Popup",
							Command = navigateCommand,
							CommandParameter = typeof(BubblePopupTestPage),
						},

					}
				}
			};
		}
	}
}
