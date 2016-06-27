using System;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public class FormsButton : ContentPage
	{
		public FormsButton ()
		{
			Content = new StackLayout { 
				Children = {
					new Button() {
						Text = "Pizza",
						Image = Forms9Patch.ImageSource.FromResource ("Forms9PatchDemo.Resources.ArrowR"),
					}
				}
			};
		}
	}
}


