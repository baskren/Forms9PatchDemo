using System;

using Xamarin.Forms;
using System.Windows.Input;

namespace Forms9PatchDemo
{
	public class EllipticalMaterialButtonsPage : ContentPage
	{
		readonly ICommand _trueCommand = new Command (parameter => System.Diagnostics.Debug.WriteLine ("_simpleCommand Parameter[" + parameter + "]"), parameter=>true );

		readonly ICommand _falseCommand = new Command (parameter => System.Diagnostics.Debug.WriteLine ("_commandB [" + parameter + "]"), parameter => false);


		static void OnSegmentTapped(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Tapped Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		static void OnSegmentSelected(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Selected Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		static void OnSegmentLongPressing(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressing Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		static void OnSegmentLongPressed(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressed Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		static void OnMaterialButtonTapped(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Tapped Button Text=["+((Forms9Patch.Button)sender).Text+"]");
		}

		static void OnMaterialButtonSelected(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Selected Button Text=["+((Forms9Patch.Button)sender).Text+"]");
		}

		static void OnMaterialButtonLongPressing(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressing Button Text=["+((Forms9Patch.Button)sender).Text+"]");
		}

		static void OnMaterialButtonLongPressed(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressed Button Text=["+((Forms9Patch.Button)sender).Text+"]");
		}


		public EllipticalMaterialButtonsPage ()
		{
			var infoIcon =  Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.Info");
			var arrowIcon = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.ArrowR");

			#region Material Buttons
			var grid = new Grid {
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				}
			};



			var mb1 = new Forms9Patch.Button {
				Text = "",
				IconImage = new Forms9Patch.Image(arrowIcon),
				ElementShape = Forms9Patch.ElementShape.Obround
			};
			mb1.Tapped += OnMaterialButtonTapped;
			mb1.Selected += OnMaterialButtonSelected;
			mb1.LongPressing += OnMaterialButtonLongPressing;
			mb1.LongPressed += OnMaterialButtonLongPressed;
			var mb2 = new Forms9Patch.Button {
				//Text = "toggle",
				ToggleBehavior = true,
                IconImage = new Forms9Patch.Image(infoIcon),
				ElementShape = Forms9Patch.ElementShape.Obround,

			};
			mb2.Tapped += OnMaterialButtonTapped;
			mb2.Selected += OnMaterialButtonSelected;
			mb2.LongPressing += OnMaterialButtonLongPressing;
			mb2.LongPressed += OnMaterialButtonLongPressed;
			var mb3 = new Forms9Patch.Button {
				//Text = "disabled",
				ToggleBehavior = true,
				IsEnabled = false,
                IconImage = new Forms9Patch.Image(arrowIcon),
				ElementShape = Forms9Patch.ElementShape.Obround
			};
			mb3.Tapped += OnMaterialButtonTapped;
			mb3.Selected += OnMaterialButtonSelected;
			mb3.LongPressing += OnMaterialButtonLongPressing;
			mb3.LongPressed += OnMaterialButtonLongPressed;
			var mb4 = new Forms9Patch.Button {
				//Text = "selected disabled",
				IsEnabled = false,
				IsSelected = true,
				IconImage = new Forms9Patch.Image(infoIcon),
				ElementShape = Forms9Patch.ElementShape.Obround
			};
			mb4.Tapped += OnMaterialButtonTapped;
			mb4.Selected += OnMaterialButtonSelected;
			mb4.LongPressing += OnMaterialButtonLongPressing;
			mb4.LongPressed += OnMaterialButtonLongPressed;


			var label1 = new Label {
				Text = "Gesture Label",
				BackgroundColor = Color.Blue,
				HeightRequest = 50
			};

			var label1Listener = FormsGestures.Listener.For (label1);
			label1Listener.Tapped += (sender, e) => System.Diagnostics.Debug.WriteLine($"Tapped:{((Label)sender).Text}");
			label1Listener.DoubleTapped += (sender, e) => System.Diagnostics.Debug.WriteLine($"DoubleTapped:{((Label)sender).Text}");
			label1Listener.LongPressing += (sender, e) => System.Diagnostics.Debug.WriteLine($"LongPressing:{((Label)sender).Text}");
			// How to remove a listener!
			label1Listener.LongPressed += (sender, e) => {
				label1Listener.Dispose();
				System.Diagnostics.Debug.WriteLine("Removed FormsGestures.Listener");
			};


			grid.Children.Add (new StackLayout {
				BackgroundColor = Color.FromHex("#33FF33"),
				Padding = new Thickness(10),
				Children = {

					new Label {
						Text = "Default, Light",
						TextColor = Color.Black
					},
					mb1,mb2, mb3, mb4,

					new Label {
						Text = "Outline, Light",
						TextColor = Color.Black
					},
					new Forms9Patch.Button {
						Text = "",
						IconImage = new Forms9Patch.Image(arrowIcon),
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						//Text = "toggle",
						ToggleBehavior = true,
						IconImage = new Forms9Patch.Image(infoIcon),
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						//Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						IconImage = new Forms9Patch.Image(arrowIcon),
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						//Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						IconImage = new Forms9Patch.Image(infoIcon),
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Label {
						Text = "Background Color, Light Theme",
						TextColor = Color.Black
					},
					new Forms9Patch.Button {
						Text = "default",
						BackgroundColor = Color.FromHex("#E0E0E0"),
						IconImage = new Forms9Patch.Image(arrowIcon),
						Orientation = StackOrientation.Vertical,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						BackgroundColor = Color.FromHex("#E0E0E0"),
						IconImage = new Forms9Patch.Image(infoIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						BackgroundColor = Color.FromHex("#E0E0E0"),
						IconImage = new Forms9Patch.Image(arrowIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						BackgroundColor = Color.FromHex("#E0E0E0"),
						IconImage = new Forms9Patch.Image(infoIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},	

					new Label {
						Text = "Shadow, Light Theme",
						TextColor = Color.Black
					},
					new Forms9Patch.Button {
						Text = "default",
						HasShadow = true,
						IconImage = new Forms9Patch.Image(infoIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						HasShadow = true,
						IconImage = new Forms9Patch.Image(arrowIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						HasShadow = true,
						IconImage = new Forms9Patch.Image(infoIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						HasShadow = true,
						IconImage = new Forms9Patch.Image(arrowIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Label {
						Text = "Shadow Background Color, Light Theme",
						TextColor = Color.Black
					},
					new Forms9Patch.Button {
						Text = "default",
						BackgroundColor = Color.FromHex("#E0E0E0"),
						HasShadow = true,
						IconImage = new Forms9Patch.Image(infoIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						BackgroundColor = Color.FromHex("#E0E0E0"),
						HasShadow = true,
						IconImage = new Forms9Patch.Image(arrowIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						BackgroundColor = Color.FromHex("#E0E0E0"),
						HasShadow = true,
						IconImage = new Forms9Patch.Image(infoIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						BackgroundColor = Color.FromHex("#E0E0E0"),
						HasShadow = true,
						IconImage = new Forms9Patch.Image(arrowIcon),
						ElementShape = Forms9Patch.ElementShape.Obround
					},	

				},
			}, 0, 0);


			grid.Children.Add(new StackLayout {
				Padding = new Thickness(10),
				BackgroundColor = Color.FromHex("#003"),
				Children = {
					new Label {
						Text = "Default, Dark Theme",
						TextColor = Color.White
					},
					new Forms9Patch.Button {
						Text = "default",
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Label {
						Text = "Outline, Dark Theme",
						TextColor = Color.White
					},
					new Forms9Patch.Button {
						Text = "default",
						DarkTheme = true,
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						DarkTheme = true,
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						DarkTheme = true,
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						DarkTheme = true,
						OutlineWidth = 0,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Label {
						Text = "Background Color, Dark Theme",
						TextColor = Color.White
					},
					new Forms9Patch.Button {
						Text = "default",
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						IconImage = new Forms9Patch.Image(arrowIcon),
						Orientation = StackOrientation.Vertical,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Label {
						Text = "Shadow, Dark Theme",
						TextColor = Color.White
					},
					new Forms9Patch.Button {
						Text = "default",
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Label {
						Text = "Shadow Background Color, Dark Theme",
						TextColor = Color.White
					},
					new Forms9Patch.Button {
						Text = "default",
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
					new Forms9Patch.Button {
						Text = "toggle",
						ToggleBehavior = true,
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Forms9Patch.Button {
						Text = "disabled",
						ToggleBehavior = true,
						IsEnabled = false,
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},

					new Forms9Patch.Button {
						Text = "selected disabled",
						IsEnabled = false,
						IsSelected = true,
						BackgroundColor = Color.FromHex("#1194F6"),
						DarkTheme = true,
						HasShadow = true,
						ElementShape = Forms9Patch.ElementShape.Obround
					},
				},
			},1,0);
			#endregion


			Padding = 20;
			Content = new ScrollView { 
				Content = new StackLayout{
					Children = {
						grid,
					},
				},
			};
		}
	}
}


