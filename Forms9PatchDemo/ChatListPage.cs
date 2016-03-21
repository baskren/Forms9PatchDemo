
using Xamarin.Forms;
using System.Collections.Generic;

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

		readonly List<Quote> thread = new List<Quote> {
			new InternalQuote { Text = "I walk slowly, but I never walk backward." },
			new ExternalQuote { Text = "I have never seen a thin person drinking Diet Coke." },
			new InternalQuote { Text = "Whatever you are, be a good one." },
			new InternalQuote { Text = "Always bear in mind that your own resolution to succeed is more important than any other." },
			new ExternalQuote { Text = "President Obama - close down the flights from Ebola infected areas right now, before it is too late! What the hell is wrong with you?" },
			new InternalQuote { Text = "Nearly all men can stand adversity, but if you want to test a man's character, give him power." },
			new InternalQuote { Text = "I destroy my enemies when I make them my friends." },
			new ExternalQuote { Text = "Wind turbines are ripping your country apart and killing tourism.Electric bills in Scotland are skyrocketing-stop the madness" },
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
			new InternalQuote { Text = "Character is like a tree and reputation like a shadow. The shadow is what we think of it; the tree is the real thing." },
			new ExternalQuote { Text = "T-mobile service is terrible!  Why can't you do something to improve it for your customers.  I don't want it in my buildings." },
			new InternalQuote { Text = "Be sure you put your feet in the right place, then stand firm." },
			new ExternalQuote { Text = "Sorry losers and haters, but my I.Q. is one of the highest -and you all know it!  Please don't feel so stupid or insecure, it's not your fault." },
			new InternalQuote { Text = "In the end, it's not the years in your life that count. It's the life in your years." },
		};
		#endregion

		#region Templates
		class QuoteViewCell : Grid {
			public static readonly BindableProperty TextProperty = BindableProperty.Create ("Text", typeof(string), typeof(QuoteViewCell), null);
			public string Text {
				get { return (string)GetValue (TextProperty);}
				set { SetValue (TextProperty, value);}
			}
			protected readonly ImageCircle _headShot = new ImageCircle {
				Aspect = Aspect.AspectFit,
				HeightRequest = 40,
				VerticalOptions = LayoutOptions.End,
			};
			protected readonly Forms9Patch.ContentView _bubble = new Forms9Patch.ContentView ();
			readonly Label _label = new Label {
				TextColor = Color.White,
			};

			public QuoteViewCell() {
				_bubble.Content = _label;	
				_bubble.BackgroundImage = new Forms9Patch.Image();
				_label.SetBinding(Label.TextProperty,"Text");
		
				Padding = new Thickness(5);

				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = new GridLength(10) },
				};
			}

			protected override void OnPropertyChanged (string propertyName = null)
			{
				base.OnPropertyChanged (propertyName);
				if (propertyName == TextProperty.PropertyName)
					_label.Text = Text;
			}
		}

		class InternalQuoteCell : QuoteViewCell {
			public InternalQuoteCell() {
				_bubble.BackgroundImage.Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.BubbleInternal");
				_headShot.Source = ImageSource.FromResource("Forms9PatchDemo.Resources.236-lincoln.png");
				_bubble.Padding = new Thickness(10,10,17,10);

				_bubble.HorizontalOptions = LayoutOptions.End;

				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = 40 },
				};

				Children.Add(_bubble, 0,0);
				Children.Add(_headShot, 1,0);
				Grid.SetRowSpan(_headShot,2);
			}
		}

		class ExternalQuoteCell : QuoteViewCell {
			public ExternalQuoteCell() {
				_bubble.BackgroundImage.Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.BubbleExternal");
				_headShot.Source = ImageSource.FromResource("Forms9PatchDemo.Resources.236-baby.png");
				_bubble.Padding = new Thickness(17,10,10,10);

				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition { Width = 40 },
					new ColumnDefinition { Width = GridLength.Auto },
				};

				Children.Add(_bubble, 1,0);
				Children.Add(_headShot, 0, 0);
				Grid.SetRowSpan(_headShot,2);
				}
		}

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
			_listView.ItemTemplate = new DataTemplate (typeof(DynamicCell));

			BackgroundColor = Color.Black;
			Padding = new Thickness (0, 25, 0, 0);
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Forms9Patch.ContentView in dynamic view cell for ListView" , TextColor = Color.White},
					_listView,
				}
			};
		}
	}
}


