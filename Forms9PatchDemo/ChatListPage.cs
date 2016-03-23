
using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace Forms9PatchDemo
{
	public class ChatListPage : ContentPage
	{
		#region Model
		class Quote {
			public string Text;
		}

		class ExternalQuote : Quote {
		}

		class InternalQuote : Quote {
		}

		ObservableCollection<Quote> thread = new ObservableCollection<Quote> {
			new InternalQuote { Text = "I walk slowly, but I never walk backward." },
			new ExternalQuote { Text = "I have never seen a thin person drinking Diet Coke." },
			new InternalQuote { Text = "Whatever you are, be a good one." },
			new InternalQuote { Text = "Always bear in mind that your own resolution to succeed is more important than any other." },
			new ExternalQuote { Text = "President Obama - close down the flights from Ebola infected areas right now, before it is too late! What the hell is wrong with you?" },
			new InternalQuote { Text = "Nearly all men can stand adversity, but if you want to test a man's character, give him power." },
			new InternalQuote { Text = "I destroy my enemies when I make them my friends." },
			new ExternalQuote { Text = "Wind turbines are ripping your country apart and killing tourism.  Electric bills in Scotland are skyrocketing-stop the madness" },
			new InternalQuote { Text = "... for the people." },
			new InternalQuote { Text = "America will never be destroyed from the outside. If we falter and lose our freedoms, it will be because we destroyed ourselves." },
			new InternalQuote { Text = "A house divided against itself cannot stand." },
			new InternalQuote { Text = "Those who deny freedom to others deserve it not for themselves." },
			new ExternalQuote { Text = "Amazing how the haters & losers keep tweeting the name “F**kface Von Clownstick” like they are so original & like no one else is doing it..." },
			new ExternalQuote { Text = "BenCarson is now leading in the polls in Iowa.  Too much Monsanto in the corn creates issues in the brain?" },
			new ExternalQuote { Text = "I would like to extend my best wishes to all, even the haters and losers, on this special date, September 11th." },
			new InternalQuote { Text = "Things may come to those who wait, but only the things left by those who hustle." },
			new InternalQuote { Text = "Give me six hours to chop down a tree and I will spend the first four sharpening the axe." },
			new ExternalQuote { Text = "Loser!" },
			new ExternalQuote { Text = "My garndparents didn't come to America all the way from Germany just to see it get taken over by immigrants." },
			new InternalQuote { Text = "Character is like a tree and reputation like a shadow.  The shadow is what we think of it; the tree is the real thing." },
			new ExternalQuote { Text = "T-mobile service is terrible!  Why can't you do something to improve it for your customers.  I don't want it in my buildings." },
			new InternalQuote { Text = "Be sure you put your feet in the right place, then stand firm." },
			new ExternalQuote { Text = "Sorry losers and haters, but my I.Q. is one of the highest -and you all know it!  Please don't feel so stupid or insecure, it's not your fault." },
			new InternalQuote { Text = "In the end, it's not the years in your life that count. It's the life in your years." },
		};

		public void SimulateLoadPrevious(int count)
		{
			var previousTopItem = thread[0];

			for (var z = 0; z < count; z++)
			{
				var random = new Random((int)DateTime.UtcNow.Ticks);

				var length = random.Next(10, 250);
				const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
				var result = new StringBuilder(length);
				result.Append ("[" + z + "] ");

				for (int i = 0; i < length; i++)
					result.Append(characters[random.Next(characters.Length)]);

				Quote quote;
				var rand01 = random.Next (2);
				//System.Diagnostics.Debug.WriteLine ("rand01={0}", rand01);
				if (rand01 == 0)
					quote = new ExternalQuote { Text = result.ToString () };
				else
					quote = new InternalQuote { Text = result.ToString () };
				thread.Insert(0, quote);
				// counter act listview auto scrolling, ugly!
				_listView.ScrollTo(previousTopItem,ScrollToPosition.Start,false);
			}
		}



		#endregion

		#region Templates
		class QuoteViewCell : Xamarin.Forms.Grid {
			public static readonly BindableProperty TextProperty = BindableProperty.Create ("Text", typeof(string), typeof(QuoteViewCell), null);
			public string Text {
				get { return (string)GetValue (TextProperty);}
				set { SetValue (TextProperty, value);}
			}
			public readonly ImageCircle HeadShot = new ImageCircle {
				Aspect = Aspect.AspectFit,
				HeightRequest = 40,
				VerticalOptions = LayoutOptions.End,
			};

			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// [1] Swap the next two lines to see how bad this ListView rendering issue is ...z
			//public readonly Xamarin.Forms.Frame Bubble = new Xamarin.Forms.Frame();
			public readonly Forms9Patch.ContentView Bubble = new Forms9Patch.ContentView ();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


			public readonly Label Label = new Label {
				TextColor = Color.White,
			};


			public QuoteViewCell() {

				//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
				// [2] And then comment out the next line ...
				Bubble.BackgroundImage = new Forms9Patch.Image();
				//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

				Bubble.Content = Label;
				Label.SetBinding(Label.TextProperty,"Text");
				Padding = new Thickness(5);
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = new GridLength(10) },
				};
				Children.Add(HeadShot);
				Grid.SetRow(HeadShot,0);
				Grid.SetRowSpan(HeadShot,2);
				Children.Add(Bubble);
				Grid.SetRow(Bubble,0);
				Grid.SetRowSpan(Bubble,1);
			}

			protected override void OnPropertyChanged (string propertyName = null)
			{
				base.OnPropertyChanged (propertyName);
				if (propertyName == TextProperty.PropertyName)
					Label.Text = Text;
			}
		}


		class InternalQuoteCell : QuoteViewCell {
			public InternalQuoteCell() {
				
				//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
				// [3] swap the next line for the following two lines ...
				Bubble.BackgroundImage.Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.BubbleInternal");
				//Bubble.BackgroundColor = Color.Blue;
				//Bubble.OutlineColor = Color.Aqua;
				//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

				HeadShot.Source = ImageSource.FromResource("Forms9PatchDemo.Resources.236-lincoln.png");
				Bubble.Padding = new Thickness(10,10,17,10);

				Bubble.HorizontalOptions = LayoutOptions.End;

				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star),  },
					new ColumnDefinition { Width = 40 },
				};

				Children.Add(Bubble, 0,0);
				Children.Add(HeadShot, 1,0);
				Grid.SetRowSpan(HeadShot,2);
			}
		}

		class ExternalQuoteCell : QuoteViewCell {
			public ExternalQuoteCell() {
				//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
				// [4] swap the next line for the following two lines ...
				Bubble.BackgroundImage.Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.BubbleExternal");
				//Bubble.BackgroundColor = Color.Gray;
				//Bubble.OutlineColor = Color.Red;
				//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


				HeadShot.Source = ImageSource.FromResource("Forms9PatchDemo.Resources.236-baby.png");
				Bubble.Padding = new Thickness(17,10,10,10);
				Bubble.HorizontalOptions = LayoutOptions.Start;
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition { Width = 40 },
					new ColumnDefinition { Width = GridLength.Auto },
				};
				Children.Add(Bubble, 1,0);
				Children.Add(HeadShot, 0, 0);
				Grid.SetRowSpan(HeadShot,2);
			}
		}

		// Will have issues consistently rendering ContentView
		class DynamicCell : ViewCell {
			protected override void OnBindingContextChanged() {
				if (BindingContext != null) {
					if (BindingContext is ExternalQuote)
						View = new ExternalQuoteCell ();
					else
						View = new InternalQuoteCell ();
					View.BindingContext = BindingContext;
				}
				var quote = BindingContext as Quote;
				if (quote != null && View != null)
					((QuoteViewCell)View).Text = quote.Text;
				base.OnBindingContextChanged ();
			}
		}


		// Seems to be more consistent in rendering ContentView - not perfect but MUCH better than Xamarin does with their Frame.
		class DynamicCell2 : ViewCell {
			public DynamicCell2() {
				View = new QuoteViewCell();
			}

			protected override void OnPropertyChanging (string propertyName = null)
			{
				base.OnPropertyChanging (propertyName);
				if (propertyName == "BindingContext") {
					var quoteViewCell = View as QuoteViewCell;
					quoteViewCell.Bubble.BackgroundImage.Source = null;
					quoteViewCell.HeadShot.Source = null;
				}
			}

			protected override void OnBindingContextChanged() {
				var quoteViewCell = View as QuoteViewCell;
				if (BindingContext is ExternalQuote) {
					//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
					// [5] swap the next line for the following two lines ...
					quoteViewCell.Bubble.BackgroundImage.Source = Forms9Patch.ImageSource.FromMultiResource ("Forms9PatchDemo.Resources.BubbleExternal");
					//Bubble.BackgroundColor = Color.Gray;
					//Bubble.OutlineColor = Color.Red;
					//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

					quoteViewCell.HeadShot.Source = ImageSource.FromResource ("Forms9PatchDemo.Resources.236-baby.png");
					quoteViewCell.Bubble.Padding = new Thickness (17, 10, 10, 10);
					quoteViewCell.Bubble.HorizontalOptions = LayoutOptions.Start;
					quoteViewCell.ColumnDefinitions = new ColumnDefinitionCollection {
						new ColumnDefinition { Width = 40 },
						new ColumnDefinition { Width = GridLength.Auto },
					};
					Grid.SetColumn (quoteViewCell.HeadShot, 0);
					Grid.SetColumn (quoteViewCell.Bubble, 1);
				} else if (BindingContext is InternalQuote) {
					//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
					// [6] swap the next line for the following two lines ...
					quoteViewCell.Bubble.BackgroundImage.Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.BubbleInternal");
					//Bubble.BackgroundColor = Color.Gray;
					//Bubble.OutlineColor = Color.Red;
					//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


					quoteViewCell.HeadShot.Source = ImageSource.FromResource ("Forms9PatchDemo.Resources.236-lincoln.png");
					quoteViewCell.Bubble.Padding = new Thickness (10, 10, 17, 10);
					quoteViewCell.Bubble.HorizontalOptions = LayoutOptions.End;
					quoteViewCell.ColumnDefinitions = new ColumnDefinitionCollection {
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star),  },
						new ColumnDefinition { Width = 40 },
					};
					Grid.SetColumn (quoteViewCell.Bubble, 0);
					Grid.SetColumn (quoteViewCell.HeadShot, 1);
				} else {
					throw new Exception ();
				}
				var quote = BindingContext as Quote;
				if (quote != null && quoteViewCell != null)
					quoteViewCell.Text = quote.Text;
				base.OnBindingContextChanged ();
				quoteViewCell.ForceLayout ();
			}
		}

		#endregion


		readonly ListView _listView = new ListView {
			BackgroundColor = Color.Black,
			SeparatorColor = Color.Transparent,
			SeparatorVisibility = SeparatorVisibility.None,
			HasUnevenRows = true,
		};

		public ChatListPage ()
		{
			_listView.ItemsSource = thread;
			_listView.ItemTemplate = new DataTemplate (typeof(DynamicCell2));
			_listView.ItemAppearing += listView_ItemAppearing;

			BackgroundColor = Color.Black;
			Padding = new Thickness (0, 25, 0, 0);
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Forms9Patch.ContentView in dynamic view cell for ListView" , TextColor = Color.White,},
					_listView,
				}
			};
		}

		bool _init = true;
		void listView_ItemAppearing (object sender, ItemVisibilityEventArgs e)
		{
			if (e.Item == thread [0] && _init) {
				_init = false;
				return;
			}	
			if (e.Item == thread [0]) {
				_init = true;
				SimulateLoadPrevious (20);
			}
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			_listView.ScrollTo (thread.Last (), ScrollToPosition.End, false);
		}
	}
}




