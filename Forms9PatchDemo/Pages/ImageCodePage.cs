﻿using System;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public class ImageCodePage : ContentPage
	{
		public ImageCodePage ()
		{
			const double fontSize = 9;
			Padding = 20;
			Content = new ScrollView { 
				Content = new StackLayout{
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
							Source = ImageSource.FromUri(new Uri("http://buildcalc.com/forms9patch/demo/redribbon.png")),
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
					},
				},
			};
		}
	}
}


