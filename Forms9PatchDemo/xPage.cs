using System;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public class xPage : ContentPage
	{
		public xPage()
		{
			Content = new Forms9Patch.StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				/*
                BackgroundImage =new Forms9Patch.Image()
                {
                    Source = Forms9Patch.ImageSource.FromFile("button.9.png"),
					Fill = Forms9Patch.Fill.AspectFit,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                },
                */
				BackgroundColor = Color.Green,
				Children =  {
					new Forms9Patch.Label
					{
						HtmlText = "Now <b><i>this</i></b> is a label!",
						TextColor = Color.Blue,
						BackgroundColor = Color.Red,
					},
					new Xamarin.Forms.Image {
						Source = Forms9Patch.ImageSource.FromMultiResource("Forms9PatchDemo.Resources.button"),
						//Fill = Forms9Patch.Fill.AspectFit,
					},
				}
			};
		}
	}
}


