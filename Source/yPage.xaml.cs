using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public partial class yPage : ContentPage
	{
		public yPage()
		{
			//InitializeComponent();
			Content = new Xamarin.Forms.Frame()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				/*
                BackgroundImage =new Forms9Patch.Image()
                {
                    Source = Forms9Patch.ImageSource.FromFile("button.9.png"),
                    Fill = Fill.AspectFit,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                },
                */
				BackgroundColor = Color.Green,
				Content =
					new Forms9Patch.Label
					{
						Text = "Now <b><i>this</i></b> is a label!",
						TextColor = Color.Blue,
						BackgroundColor = Color.Red,
						FontSize = 30
					},

			};
		}
	}
}

