using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public class App : Application
	{
		public App ()
		{
			const bool XAML = true;

			if (XAML) {
				//MainPage = new MyPage ();
				//MainPage = new ContentViewDemoPage ();
				MainPage = new FrameDemoPage ();
			} else {
				const double fontSize = 9;
				MainPage = new ContentPage {
					//Content = new ScrollView {
						Content = new StackLayout {
							Children = {
								/*
								#region Original Image
								new Forms9Patch.Image {
									Source = ImageSource.FromResource("Forms9PatchDemo.Resources.bubble.9.png"),
									HeightRequest = 110,
								},
								new Label { 
									Text = "9.png >> Xamarin.Forms.FromResource >> Forms9Patch.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.redribbon"), 
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiSource >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Forms9Patch.Image {
									Source = ImageSource.FromUri(new System.Uri("http://buildcalc.com/forms9patch/demo/redribbon.png")),
									CapInsets = new Thickness(23,0,111,0),
								},
								new Label { Text = "Xamarin.Forms.ImageSource.FromUri >> Forms9Patch.Image w/ CapInsets", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},


								new Forms9Patch.Image { 
									Source =Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.button"), 
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiResource >> Forms9Patch.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},


								new Forms9Patch.Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.button"), 
									CapInsets = new Thickness(111,3,4,5),
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiResource >> Forms9Patch.Image w/ CapInsets", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Forms9Patch.Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.redribbon"), 
									CapInsets = new Thickness(23.0/308.0,-1,111.0/308.0,-1),
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiResource >> Forms9Patch.Image w/ CapInsets", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.image.9.png") },
								new Label { Text = "9.png Xamarin.Forms.ImageSource.FromMultiResource >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Forms9Patch.Image {
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.image.9.png"),
									//HeightRequest = 100,
								},
								new Label { Text = "9.png Xamarin.Forms.ImageSource.FromMultiResource >> Forms9Patch.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.image") 
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiResource >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Forms9Patch.Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.image") ,
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiResource >> Forms9Patch.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},


								new Image { 
									Source = ImageSource.FromFile("cat.jpg"),
								},
								new Label { Text = "Xamarin.Forms.ImageSource.FromFile >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Image { 
									Source = ImageSource.FromFile("balloons.jpg"),
								},
								new Label { Text = "Xamarin.Forms.ImageSource.FromFile >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},

								new Image { 
									Source = ImageSource.FromFile("image.png"),
								},
								new Label { Text = "Xamarin.Forms.ImageSource.FromFile >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},
								#endregion
								#region Image
								new Label {
									Text = "Forms9Patch.Image",
								},
								new Forms9Patch.Image {
									Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
									Fill = Forms9Patch.Fill.AspectFill,
								},
								new Forms9Patch.Image {
									Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
									Fill = Forms9Patch.Fill.AspectFit,
								},
								new Forms9Patch.Image {
									Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
									Fill = Forms9Patch.Fill.Fill,
								},
								new Forms9Patch.Image {
									Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
									Fill = Forms9Patch.Fill.Tile,
								},
								new Forms9Patch.Image {
									Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
									Fill = Forms9Patch.Fill.AspectFill,
									CapInsets = new Thickness(10),
								},
								#endregion
								#region ContentView
								new Label {
									Text = "Forms9Patch.ContentView",
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.AspectFill,
									},
									Content = new Label{
										Text = "ContentView AspectFill",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.AspectFit,
									},
									Content = new Label{
										Text = "ContentView AspectFit",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.Fill,
									},
									Content = new Label{
										Text = "ContentView Fill",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.Tile,
									},
									Content = new Label{
										Text = "ContentView Tile",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.Tile,
										CapInsets = new Thickness(10),
									},
									Content = new Xamarin.Forms.Label{
										Text = "ContentView scalable (CapInsets)",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								#endregion
								#region Frame
								new Xamarin.Forms.Label {
									Text = "Forms9Patch.Frame",
								},
								new Forms9Patch.Frame {
									Content = new Xamarin.Forms.Label {
										Text = "Frame OutlineWidth & OutlineRadius",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
									OutlineColor = Color.Blue,
									OutlineWidth = 1,
									OutlineRadius = 4,
								},
								new Forms9Patch.Frame {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.AspectFill,
									},
									Content = new Xamarin.Forms.Label {
										Text = "Frame AspectFill",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
									OutlineColor = Color.Blue,
									OutlineWidth = 1,
									OutlineRadius = 4,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.AspectFit,
									},
									Content = new Xamarin.Forms.Label {
										Text = "Frame AspectFit",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.Fill,
									},
									Content = new Xamarin.Forms.Label {
										Text = "Frame Fill",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.Tile,
									},
									Content = new Xamarin.Forms.Label {
										Text = "Frame Tile",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redGridBox"),
										Fill = Forms9Patch.Fill.Tile,
										CapInsets = new Thickness(10),
									},
									Content = new Xamarin.Forms.Label {
										Text = "Frame scalable (CapInsets)",
										TextColor = Color.Black,
										FontSize = 12,
										BackgroundColor = Color.Green,
									},
									Padding = new Thickness(10),
									BackgroundColor = Color.Gray,
								},
								#endregion

								#region CapsInset ContentView
								new Image { 
									Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.redribbon"), 
								},
								new Label { Text = "Forms9Patch.ImageSource.FromMultiSource >> Xamarin.Forms.Image", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},
								*/
								new Forms9Patch.ContentView {
									BackgroundImage = new Forms9Patch.Image {
										Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redribbon"),
										Fill = Forms9Patch.Fill.Tile,
										CapInsets = new Thickness(30,-1,160,-1),
									},
									Content = new Xamarin.Forms.Label{
										Text = "ContentView scalable (CapInsets)",
										TextColor = Color.White,
										FontAttributes = FontAttributes.Bold,
										//BackgroundColor = Color.Gray,
										FontSize = 14,
										HorizontalOptions = LayoutOptions.Center,
										VerticalOptions = LayoutOptions.Center,
									},
									Padding = new Thickness(30,30,110,20),
									HeightRequest = 80,
								},
							/*
								new Label { Text = "Forms9atch.ImageSource.FromMultiSource >> Forms9Patch.ContentView", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},
								#endregion
*/
							}
						}
					//}
				};
				MainPage.Padding = new Thickness (5, Device.OnPlatform(20,5,5), 5, 5);			
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

