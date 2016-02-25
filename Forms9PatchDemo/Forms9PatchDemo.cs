 using Xamarin.Forms;
using System.Windows.Input;
using System;

namespace Forms9PatchDemo
{
	public class App : Application
	{
		ICommand _trueCommand = new Command ((parameter) => System.Diagnostics.Debug.WriteLine ("_simpleCommand Parameter[" + parameter + "]"), parameter=>true );

		ICommand _falseCommand = new Command (parameter => System.Diagnostics.Debug.WriteLine ("_commandB [" + parameter + "]"), parameter => false);


		void OnSegmentTapped(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Tapped Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		void OnSegmentSelected(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Selected Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		void OnSegmentLongPressing(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressing Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		void OnSegmentLongPressed(object sender, Forms9Patch.SegmentedControlEventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressed Segment[" + e.Index + "] Text=["+e.Segment.Text+"]");
		}

		void OnMaterialButtonTapped(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Tapped Button Text=["+((Forms9Patch.MaterialButton)sender).Text+"]");
		}

		void OnMaterialButtonSelected(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Selected Button Text=["+((Forms9Patch.MaterialButton)sender).Text+"]");
		}

		void OnMaterialButtonLongPressing(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressing Button Text=["+((Forms9Patch.MaterialButton)sender).Text+"]");
		}

		void OnMaterialButtonLongPressed(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressed Button Text=["+((Forms9Patch.MaterialButton)sender).Text+"]");
		}

		void OnImageButtonTapped(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Tapped Button Text=["+((Forms9Patch.ImageButton)sender).Text+"]");
		}

		void OnImageButtonSelected(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("Selected Button Text=["+((Forms9Patch.ImageButton)sender).Text+"]");
		}

		void OnImageButtonLongPressing(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressing Button Text=["+((Forms9Patch.ImageButton)sender).Text+"]");
		}

		void OnImageButtonLongPressed(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("LongPressed Button Text=["+((Forms9Patch.ImageButton)sender).Text+"]");
		}

		public App ()
		{
			const bool XAML = false;


			if (XAML) {
				//MainPage = new MyPage ();
				//MainPage = new ContentViewDemoPage ();
				//MainPage = new FrameDemoPage ();
				//MainPage = new MaterialSegmentControlPage();
				MainPage = new ImageButtonPage();
			} else {


				#region Material Buttons
				var grid = new Xamarin.Forms.Grid {
					RowDefinitions = {
						new RowDefinition { Height = GridLength.Auto },
					},
					ColumnDefinitions = {
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					},

				};

				var infoIcon =  Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.Info");
				var arrowIcon = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.ArrowR");


				var mb1 = new Forms9Patch.MaterialButton {
					Text = "",
					ImageSource = arrowIcon,
				};
				mb1.Tapped += OnMaterialButtonTapped;
				mb1.Selected += OnMaterialButtonSelected;
				mb1.LongPressing += OnMaterialButtonLongPressing;
				mb1.LongPressed += OnMaterialButtonLongPressed;
				var mb2 = new Forms9Patch.MaterialButton {
					//Text = "sticky",
					StickyBehavior = true,
					ImageSource = infoIcon,
				};
				mb2.Tapped += OnMaterialButtonTapped;
				mb2.Selected += OnMaterialButtonSelected;
				mb2.LongPressing += OnMaterialButtonLongPressing;
				mb2.LongPressed += OnMaterialButtonLongPressed;
				var mb3 = new Forms9Patch.MaterialButton {
					//Text = "disabled",
					StickyBehavior = true,
					IsEnabled = false,
					ImageSource = arrowIcon,
				};
				mb3.Tapped += OnMaterialButtonTapped;
				mb3.Selected += OnMaterialButtonSelected;
				mb3.LongPressing += OnMaterialButtonLongPressing;
				mb3.LongPressed += OnMaterialButtonLongPressed;
				var mb4 = new Forms9Patch.MaterialButton {
					//Text = "selected disabled",
					IsEnabled = false,
					IsSelected = true,
					ImageSource = infoIcon,
				};
				mb4.Tapped += OnMaterialButtonTapped;
				mb4.Selected += OnMaterialButtonSelected;
				mb4.LongPressing += OnMaterialButtonLongPressing;
				mb4.LongPressed += OnMaterialButtonLongPressed;


				var label1 = new Xamarin.Forms.Label {
					Text = "Gesture Label",
					BackgroundColor = Color.Blue,
					HeightRequest = 50,
				};

				var label1Listener = new FormsGestures.Listener (label1);
				label1Listener.Tapped += (sender, e) => System.Diagnostics.Debug.WriteLine($"Tapped:{((Xamarin.Forms.Label)sender).Text}");
				label1Listener.DoubleTapped += (sender, e) => System.Diagnostics.Debug.WriteLine($"DoubleTapped:{((Xamarin.Forms.Label)sender).Text}");
				label1Listener.LongPressing += (sender, e) => System.Diagnostics.Debug.WriteLine($"LongPressing:{((Xamarin.Forms.Label)sender).Text}");
				// How to remove a listener!
				label1Listener.LongPressed += (sender, e) => {
					label1Listener.Dispose();
					System.Diagnostics.Debug.WriteLine("Removed FormsGestures.Listener");
				};


				grid.Children.Add (new Xamarin.Forms.StackLayout {
					BackgroundColor = Color.FromHex("#33FF33"),
					Padding = new Thickness(10),
					Children = {

						new Xamarin.Forms.Label {
							Text = "Default, Light",
							TextColor = Color.Black,
						},
						mb1,mb2, mb3, mb4,

						new Xamarin.Forms.Label {
							Text = "Outline, Light",
							TextColor = Color.Black,
						},
						new Forms9Patch.MaterialButton {
							Text = "",
							ImageSource = arrowIcon,
							OutlineWidth = 0,
						},
						new Forms9Patch.MaterialButton {
							//Text = "sticky",
							StickyBehavior = true,
							ImageSource = infoIcon,
							OutlineWidth = 0,
						},
						new Forms9Patch.MaterialButton {
							//Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							ImageSource = arrowIcon,
							OutlineWidth = 0,
						},
						new Forms9Patch.MaterialButton {
							//Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							ImageSource = infoIcon,
							OutlineWidth = 0,
						},

						new Xamarin.Forms.Label {
							Text = "Background Color, Light Theme",
							TextColor = Color.Black,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							BackgroundColor = Color.FromHex("#E0E0E0"),
							ImageSource = arrowIcon,
							Orientation = StackOrientation.Vertical,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							BackgroundColor = Color.FromHex("#E0E0E0"),
							ImageSource = infoIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							BackgroundColor = Color.FromHex("#E0E0E0"),
							ImageSource = arrowIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							BackgroundColor = Color.FromHex("#E0E0E0"),
							ImageSource = infoIcon,
						},	

						new Xamarin.Forms.Label {
							Text = "Shadow, Light Theme",
							TextColor = Color.Black,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							HasShadow = true,
							ImageSource = infoIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							HasShadow = true,
							ImageSource = arrowIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							HasShadow = true,
							ImageSource = infoIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							HasShadow = true,
							ImageSource = arrowIcon,
						},

						new Xamarin.Forms.Label {
							Text = "Shadow Background Color, Light Theme",
							TextColor = Color.Black,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							BackgroundColor = Color.FromHex("#E0E0E0"),
							HasShadow = true,
							ImageSource = infoIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							BackgroundColor = Color.FromHex("#E0E0E0"),
							HasShadow = true,
							ImageSource = arrowIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							BackgroundColor = Color.FromHex("#E0E0E0"),
							HasShadow = true,
							ImageSource = infoIcon,
						},
						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							BackgroundColor = Color.FromHex("#E0E0E0"),
							HasShadow = true,
							ImageSource = arrowIcon,
						},	

					},
				}, 0, 0);


				grid.Children.Add(new Xamarin.Forms.StackLayout {
					Padding = new Thickness(10),
					BackgroundColor = Color.FromHex("#003"),
					Children = {
						new Xamarin.Forms.Label {
							Text = "Default, Dark Theme",
							TextColor = Color.White,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							DarkTheme = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							DarkTheme = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							DarkTheme = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							DarkTheme = true,
						},

						new Xamarin.Forms.Label {
							Text = "Outline, Dark Theme",
							TextColor = Color.White,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							DarkTheme = true,
							OutlineWidth = 0,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							DarkTheme = true,
							OutlineWidth = 0,
						},
						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							DarkTheme = true,
							OutlineWidth = 0,
						},
						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							DarkTheme = true,
							OutlineWidth = 0,
						},

						new Xamarin.Forms.Label {
							Text = "Background Color, Dark Theme",
							TextColor = Color.White,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
							ImageSource = arrowIcon,
							Orientation = StackOrientation.Vertical,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
						},

						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
						},

						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
						},
						new Xamarin.Forms.Label {
							Text = "Shadow, Dark Theme",
							TextColor = Color.White,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							DarkTheme = true,
							HasShadow = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							DarkTheme = true,
							HasShadow = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							DarkTheme = true,
							HasShadow = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							DarkTheme = true,
							HasShadow = true,
						},
						new Xamarin.Forms.Label {
							Text = "Shadow Background Color, Dark Theme",
							TextColor = Color.White,
						},
						new Forms9Patch.MaterialButton {
							Text = "default",
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
							HasShadow = true,
						},
						new Forms9Patch.MaterialButton {
							Text = "sticky",
							StickyBehavior = true,
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
							HasShadow = true,
						},

						new Forms9Patch.MaterialButton {
							Text = "disabled",
							StickyBehavior = true,
							IsEnabled = false,
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
							HasShadow = true,
						},

						new Forms9Patch.MaterialButton {
							Text = "selected disabled",
							IsEnabled = false,
							IsSelected = true,
							BackgroundColor = Color.FromHex("#1194F6"),
							DarkTheme = true,
							HasShadow = true,
						},
					},
				},1,0);
				#endregion


				#region Light SegmentedControl

				var sc1 = new Forms9Patch.MaterialSegmentedControl {
					Segments = {

						new Forms9Patch.Segment {
							Text = "A",
							ImageSource = arrowIcon,
							Command = _trueCommand,
							CommandParameter = "sc1 A",
						},
						new Forms9Patch.Segment {
							//Text = "B",
							IsSelected = true,
							ImageSource = arrowIcon,
							Command = _trueCommand,
							CommandParameter = "sc1 B",
						},
						new Forms9Patch.Segment {
							Text = "C",
							Command = _trueCommand,
							CommandParameter = "sc1 C",
						},

						new Forms9Patch.Segment {
							Text = "D",
							//IsEnabled = false,
							Command = _falseCommand,
							CommandParameter = "sc1 D",
						},
					},
				};
				sc1.SegmentSelected += OnSegmentSelected;
				sc1.SegmentTapped += OnSegmentTapped;
				sc1.SegmentLongPressing += OnSegmentLongPressing;
				sc1.SegmentLongPressed += OnSegmentLongPressed;

				var seg1 = new Forms9Patch.Segment {
					//Text = "A",
					ImageSource = arrowIcon,
				};
				seg1.Tapped += OnMaterialButtonTapped;
				seg1.Selected += OnMaterialButtonTapped;
				seg1.LongPressing += OnMaterialButtonLongPressing;
				seg1.LongPressed += OnMaterialButtonLongPressed;
				var seg2 = new Forms9Patch.Segment {
					Text = "B",
					IsSelected = true,
				};
				seg2.Tapped += OnMaterialButtonTapped;
				seg2.Selected += OnMaterialButtonTapped;
				seg2.LongPressing += OnMaterialButtonLongPressing;
				seg2.LongPressed += OnMaterialButtonLongPressed;
				var seg3 = new Forms9Patch.Segment {
					Text = "C",
				};
				seg3.Tapped += OnMaterialButtonTapped;
				seg3.Selected += OnMaterialButtonTapped;
				seg3.LongPressing += OnMaterialButtonLongPressing;
				seg3.LongPressed += OnMaterialButtonLongPressed;
				var seg4 = new Forms9Patch.Segment {
					Text = "D",
					IsEnabled = false,
				};
				seg4.Tapped += OnMaterialButtonTapped;
				seg4.Selected += OnMaterialButtonTapped;
				seg4.LongPressing += OnMaterialButtonLongPressing;
				seg4.LongPressed += OnMaterialButtonLongPressed;


				var sc2 = new Forms9Patch.MaterialSegmentedControl {
					OutlineWidth = 0,
					Segments = {
						seg1, seg2, seg3, seg4,
					},
				};
				sc2.SegmentSelected += OnSegmentSelected;
				sc2.SegmentTapped += OnSegmentTapped;
				sc2.SegmentLongPressing += OnSegmentLongPressing;
				sc2.SegmentLongPressed += OnSegmentLongPressed;

				var sc3 = new Forms9Patch.MaterialSegmentedControl {
					//OutlineColor = Color.Transparent,
					BackgroundColor = Color.FromHex("#E0E0E0"),
					Segments = {
						new Forms9Patch.Segment {
							Text = "A",
						},
						new Forms9Patch.Segment {
							Text = "B",
							IsSelected = true,
						},
						new Forms9Patch.Segment {
							Text = "C",
						},
						new Forms9Patch.Segment {
							//Text = "D",
							IsEnabled = false,
							ImageSource = arrowIcon,
						},
					},
				};
				sc3.SegmentSelected += OnSegmentSelected;
				sc3.SegmentTapped += OnSegmentTapped;
				sc3.SegmentLongPressing += OnSegmentLongPressing;
				sc3.SegmentLongPressed += OnSegmentLongPressed;

				var sc4 = new Forms9Patch.MaterialSegmentedControl {
					BackgroundColor = Color.FromHex("#E0E0E0"),
					OutlineWidth = 0,
					SeparatorWidth = 1,
					StickyBehavior = Forms9Patch.SegmentControlStickyBehavior.None,
					Segments = {
						new Forms9Patch.Segment {
							Text = "A",
							ImageSource = arrowIcon,
							Orientation = StackOrientation.Vertical,
						},
						new Forms9Patch.Segment {
							Text = "B",
							IsSelected = true,
							ImageSource = infoIcon,
							Orientation = StackOrientation.Vertical,
						},

						new Forms9Patch.Segment {
							Text = "C",
							ImageSource = arrowIcon,
						},
						new Forms9Patch.Segment {
							Text = "D",
							IsEnabled = false,
							ImageSource = infoIcon,
							Orientation = StackOrientation.Vertical,
						},

					},
				};
				sc4.SegmentSelected += OnSegmentSelected;
				sc4.SegmentTapped += OnSegmentTapped;
				sc4.SegmentLongPressing += OnSegmentLongPressing;
				sc4.SegmentLongPressed += OnSegmentLongPressed;

				var sc5 = new Forms9Patch.MaterialSegmentedControl {
					BackgroundColor = Color.FromHex("#E0E0E0"),
					HasShadow = true,
					//OutlineRadius = 0,
					//OutlineWidth = 0,
					Orientation = StackOrientation.Vertical,
					StickyBehavior = Forms9Patch.SegmentControlStickyBehavior.Multiselect,
					Segments = {

						new Forms9Patch.Segment {
							Text = "A",
							ImageSource = arrowIcon,
						},

						new Forms9Patch.Segment {
							Text = "B",
							IsSelected = true,
						},
						new Forms9Patch.Segment {
							Text = "C",
						},
						new Forms9Patch.Segment {
							Text = "D",
							IsEnabled = false,
						},

					},
				};
				sc5.SegmentSelected += OnSegmentSelected;
				sc5.SegmentTapped += OnSegmentTapped;
				sc5.SegmentLongPressing += OnSegmentLongPressing;
				sc5.SegmentLongPressed += OnSegmentLongPressed;

				var sc6 = new Forms9Patch.MaterialSegmentedControl {
					BackgroundColor = Color.FromHex("#E0E0E0"),
					HasShadow = true,
					//OutlineRadius = 0,
					OutlineWidth = 0,
					SeparatorWidth = 1,
					Orientation = StackOrientation.Vertical,
					StickyBehavior = Forms9Patch.SegmentControlStickyBehavior.Multiselect,
					Segments = {

						new Forms9Patch.Segment {
							Text = "A",
						},

						new Forms9Patch.Segment {
							Text = "B",
							IsSelected = true,
							ImageSource = arrowIcon,
							//Orientation = StackOrientation.Vertical,
						},
						new Forms9Patch.Segment {
							Text = "C",
						},
						new Forms9Patch.Segment {
							Text = "D",
							IsEnabled = false,
						},

					},
				};
				sc6.SegmentSelected += OnSegmentSelected;
				sc6.SegmentTapped += OnSegmentTapped;
				sc6.SegmentLongPressing += OnSegmentLongPressing;
				sc6.SegmentLongPressed += OnSegmentLongPressed;

				#endregion


				#region RelativeLayout
				var heading = new Xamarin.Forms.Label {
					Text = "RelativeLayout Example",
					TextColor = Color.Red,
				};

				var relativelyPositioned = new Xamarin.Forms.Label {
					Text = "Positioned relative to my parent."
				};

				var relativeLayout = new Forms9Patch.RelativeLayout {
					BackgroundImage = new Forms9Patch.Image {
						Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.ghosts"),
						Fill = Forms9Patch.Fill.Tile,
					},
					BackgroundColor = Color.White,
					OutlineColor = Color.Green,
					OutlineWidth = 3,
					OutlineRadius = 2,
					HeightRequest = 100,
				};

				relativeLayout.Children.Add (heading, Constraint.RelativeToParent (parent => 0));

				relativeLayout.Children.Add (relativelyPositioned,
					Constraint.RelativeToParent (parent => parent.Width / 3),
					Constraint.RelativeToParent (parent => parent.Height / 2)
				);
				#endregion


				#region ImageButtons
				var b2 = new Forms9Patch.ImageButton {
					DefaultState = new Forms9Patch.ImageButtonState {
						BackgroundImage = new Forms9Patch.Image {
							Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.button"),
						},
						Image = new Xamarin.Forms.Image {
							Source = ImageSource.FromFile("five.png"),
						},
						FontColor = Color.White,
						Text = "Sticky w/ SelectedState",
					},
					SelectedState = new Forms9Patch.ImageButtonState {
						BackgroundImage = new Forms9Patch.Image {
							Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.image"),
						},
						FontColor = Color.Red,
						Text = "Selected",
					},
					StickyBehavior = true,
					HeightRequest = 50,
					Alignment = TextAlignment.Start,
				};
				b2.Tapped += OnImageButtonTapped;
				b2.Selected += OnImageButtonSelected;
				b2.LongPressing += OnImageButtonLongPressing;
				b2.LongPressed += OnImageButtonLongPressed;


				var b3 = new Forms9Patch.ImageButton {
					DefaultState = new Forms9Patch.ImageButtonState {
						BackgroundImage = new Forms9Patch.Image {
							Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.button"),
						},
						Image = new Xamarin.Forms.Image {
							Source = ImageSource.FromFile("five.png"),
						},
						FontColor = Color.FromRgb(0.0, 0.0, 0.8),
						Text = "Sticky w/o SelectedState",
					},
					PressingState = new Forms9Patch.ImageButtonState {
						BackgroundImage = new Forms9Patch.Image {
							Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.redButton"),
						},
					},
					StickyBehavior = true,
					HeightRequest = 50,
					Alignment = TextAlignment.Center,
				};
				b3.Tapped += OnImageButtonTapped;
				b3.Selected += OnImageButtonSelected;
				b3.LongPressing += OnImageButtonLongPressing;
				b3.LongPressed += OnImageButtonLongPressed;

				var b4 = new Forms9Patch.ImageButton {
					DefaultState = new Forms9Patch.ImageButtonState {
						BackgroundImage = new Forms9Patch.Image {
							Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.button"),
						},
						Image = new Xamarin.Forms.Image {
							Source = ImageSource.FromFile("five.png"),
						},
						FontColor = Color.White,
						Text = "Not sticky",
					},
					//StickyBehavior = true,
					HeightRequest = 50,
					Alignment = TextAlignment.End,
				};
				b4.Tapped += OnImageButtonTapped;
				b4.Selected += OnImageButtonSelected;
				b4.LongPressing += OnImageButtonLongPressing;
				b4.LongPressed += OnImageButtonLongPressed;

				#endregion


				const double fontSize = 9;
				MainPage = new ContentPage {
					Content = new ScrollView {
						Content = new StackLayout {
							Children = {
								
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

								new Label { Text = "Forms9atch.ImageSource.FromMultiSource >> Forms9Patch.ContentView", 
									FontSize = fontSize,
									HorizontalOptions = LayoutOptions.Center,
								},
								#endregion

								b2,b3,b4,

								grid,


								#region MaterialSegmentControl

								new Xamarin.Forms.StackLayout {
									Orientation = StackOrientation.Horizontal,
									Children = {

										#region Light
										new Xamarin.Forms.StackLayout {
											BackgroundColor = Color.Lime,
											HorizontalOptions = LayoutOptions.FillAndExpand,
											Padding = new Thickness(10),
											Children = {
												new Xamarin.Forms.Label {
													Text = "Default, Light",
													TextColor = Color.Black,
												},

												sc1, sc2, sc3, sc4, sc5, sc6,

											},
										},
										#endregion


										#region Dark
										new Xamarin.Forms.StackLayout {
											BackgroundColor = Color.FromHex("#003"),
											HorizontalOptions = LayoutOptions.FillAndExpand,
											Padding = new Thickness(10),
											Children = {
												new Xamarin.Forms.Label {
													Text = "Default, Dark",
													TextColor = Color.White,
												},

												new Forms9Patch.MaterialSegmentedControl {
													//OutlineColor = Color.Transparent,
													DarkTheme = true,
													Segments = {

														new Forms9Patch.Segment {
															Text = "A",
														},
														new Forms9Patch.Segment {
															//Text = "B",
															IsSelected = true,
															ImageSource = arrowIcon,
														},
														new Forms9Patch.Segment {
															Text = "C",
														},

														new Forms9Patch.Segment {
															Text = "D",
															IsEnabled = false,
														},
													},
												},

												new Forms9Patch.MaterialSegmentedControl {
													DarkTheme = true,
													OutlineWidth = 0,
													Segments = {

														new Forms9Patch.Segment {
															//Text = "A",
															ImageSource = arrowIcon,
														},
														new Forms9Patch.Segment {
															Text = "B",
															IsSelected = true,
														},
														new Forms9Patch.Segment {
															Text = "C",
														},

														new Forms9Patch.Segment {
															Text = "D",
															IsEnabled = false,
														},
													},
												},

												new Forms9Patch.MaterialSegmentedControl {
													DarkTheme = true,
													BackgroundColor = Color.FromHex("#1194F6"),
													Segments = {
														new Forms9Patch.Segment {
															Text = "A",
														},
														new Forms9Patch.Segment {
															Text = "B",
															IsSelected = true,
														},
														new Forms9Patch.Segment {
															Text = "C",
														},
														new Forms9Patch.Segment {
															//Text = "D",
															IsEnabled = false,
															ImageSource = arrowIcon,
														},
													},
												},

												new Forms9Patch.MaterialSegmentedControl {
													DarkTheme = true,
													BackgroundColor = Color.FromHex("#1194F6"),
													OutlineWidth = 0,
													Segments = {
														new Forms9Patch.Segment {
															Text = "A",
															ImageSource = arrowIcon,
															Orientation = StackOrientation.Vertical,
														},
														new Forms9Patch.Segment {
															Text = "B",
															IsSelected = true,
															ImageSource = infoIcon,
															Orientation = StackOrientation.Vertical,
														},

														new Forms9Patch.Segment {
															Text = "C",
															ImageSource = arrowIcon,
														},
														new Forms9Patch.Segment {
															Text = "D",
															IsEnabled = false,
															ImageSource = infoIcon,
															Orientation = StackOrientation.Vertical,
														},

													},
												},

												new Forms9Patch.MaterialSegmentedControl {
													DarkTheme = true,
													BackgroundColor = Color.FromHex("#1194F6"),
													HasShadow = true,
													//OutlineRadius = 0,
													//OutlineWidth = 0,
													Orientation = StackOrientation.Vertical,
													StickyBehavior = Forms9Patch.SegmentControlStickyBehavior.Multiselect,
													Segments = {

														new Forms9Patch.Segment {
															Text = "A",
															ImageSource = arrowIcon,
														},

														new Forms9Patch.Segment {
															Text = "B",
															IsSelected = true,
														},
														new Forms9Patch.Segment {
															Text = "C",
														},
														new Forms9Patch.Segment {
															Text = "D",
															IsEnabled = false,
														},

													},
												},

												new Forms9Patch.MaterialSegmentedControl {
													DarkTheme = true,
													BackgroundColor = Color.FromHex("#1194F6"),
													HasShadow = true,
													//OutlineRadius = 0,
													OutlineWidth = 0,
													SeparatorWidth = 1,
													Orientation = StackOrientation.Vertical,
													StickyBehavior = Forms9Patch.SegmentControlStickyBehavior.Multiselect,
													Segments = {

														new Forms9Patch.Segment {
															Text = "A",
														},

														new Forms9Patch.Segment {
															Text = "B",
															IsSelected = true,
															ImageSource = arrowIcon,
														},
														new Forms9Patch.Segment {
															Text = "C",
														},
														new Forms9Patch.Segment {
															Text = "D",
															IsEnabled = false,
														},

													},
												},
											},
										},
										#endregion

									},
								},

								#endregion

								grid,


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

