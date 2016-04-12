using System;

using Xamarin.Forms;
using Forms9Patch;

namespace Forms9PatchDemo
{
	public class ModalPopupWithNavigationPages : ContentPage
	{
		public ModalPopupWithNavigationPages ()
		{
			var button = new Button {
				Text = "Show Test Page",
			};
			button.Clicked += (sender, e) => {
				var page = new BubbonPushModalAsyncPage ();
				page.Cancelled += (s, args) => {
					this.Navigation.PopModalAsync();
				};
				this.Navigation.PushModalAsync (page);
			};
			// The root page of your application
			var content = new Xamarin.Forms.ContentView
			{
				//Title = "BubbleTest",
				Content = new Xamarin.Forms.StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						button,
					}
				}
			};
			Content = content;
		}
	}

	public class BubbonPushModalAsyncPage : ContentPage
	{
		Button button1;
		Button button2;
		Button button3;
		BubblePopup bubble;

		public event EventHandler Cancelled;

		public BubbonPushModalAsyncPage()
		{
			button1 = new Button { Text = "No Target" };
			button2 = new Button { Text = "Target" };
			button3 = new Button { Text = "Cancel" };

			Content = new Xamarin.Forms.StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
					button1,
					button2,
					button3,
				}
			};

			bubble = new BubblePopup
			{
				Padding =25,
				BackgroundColor = Color.Blue,
				//Target = button, // Uncomment this line, and it crashes too
				Content = new Xamarin.Forms.StackLayout
				{
					Children = {
						new Label { Text = "This is a test bubble" }
					}
				}
			};

			button1.Clicked += (sender, e) => {
				bubble.Target = null;
				bubble.IsVisible = true;
			};

			button2.Clicked += (sender, e) => {
				bubble.Target = button1;
				bubble.IsVisible = true;
			};

			button3.Clicked += (sender, e) => {
				//Cancelled?.Invoke(this,new EventArgs());
				Navigation.PopModalAsync();
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			//bubble.IsVisible = true;
		}
	}
}




