using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public class App : Xamarin.Forms.Application
	{
		public App ()
		{
			const bool XAML = true;

			if (XAML) {
				MainPage = new MyPage ();
			} else {
				const double fontSize = 9;
				MainPage = new ContentPage {
					Content = new ScrollView {
						Content = new StackLayout {
							Children = {
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
							}
						}
					}
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

