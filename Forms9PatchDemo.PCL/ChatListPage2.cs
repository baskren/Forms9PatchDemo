using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Forms9PatchDemo
{
	public class Quote {
		public string QuoteText { get; set; }
	}

	class QuoteCell : ViewCell {
		readonly Label _label = new Label {
			TextColor = Color.White,
			Text = "default text",
		};

		public QuoteCell() {
			_label.SetBinding(Label.TextProperty,"QuoteText");
			View  = _label;
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			_label.BindingContext = BindingContext;
		}
	}

	public class ChatListPage : ContentPage
	{
		readonly ObservableCollection<Quote> thread = new ObservableCollection<Quote> {
			new Quote { QuoteText = "1" }, new Quote { QuoteText = "2" },
			new Quote { QuoteText = "3" }, new Quote { QuoteText = "4" },
			new Quote { QuoteText = "5" }, new Quote { QuoteText = "6" },
			new Quote { QuoteText = "7" }, new Quote { QuoteText = "8" },
			new Quote { QuoteText = "9" }, new Quote { QuoteText = "10" },
		};


		public ChatListPage ()
		{
			Padding = new Thickness (0, 25, 0, 0);
			var _listView = new ListView {
				ItemsSource = thread,
				ItemTemplate = new DataTemplate(typeof(QuoteCell)),
			};
			Content = _listView;
		}
	}
}




