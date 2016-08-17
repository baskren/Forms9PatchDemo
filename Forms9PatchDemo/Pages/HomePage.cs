﻿using System;
using Xamarin.Forms;
//using FormsMod;

namespace Forms9PatchDemo
{
	class HomePage : ContentPage
	{
		public HomePage()
		{
			// Define command for the items in the TableView.
			Command<Type> navigateCommand = 
				new Command<Type>(async (Type pageType) => {
						Page page = (Page)Activator.CreateInstance(pageType);
						await this.Navigation.PushAsync(page);
					});

			this.Title = "Forms9Patch Gallery";
			this.Content = new TableView {
				Intent = TableIntent.Menu,
				Root = new TableRoot {
					new TableSection("XAML") {
						new TextCell {
							Text = "ContentView",
							Command = navigateCommand,
							CommandParameter = typeof(ContentViewDemoPage)
						},

						new TextCell {
							Text = "Frame",
							Command = navigateCommand,
							CommandParameter = typeof(FrameDemoPage)
						},

						new TextCell {
							Text = "ImageButton",
							Command = navigateCommand,
							CommandParameter = typeof(ImageButtonPage)
						},

						new TextCell {
							Text = "MaterialSegmentControl ",
							Command = navigateCommand,
							CommandParameter = typeof(MaterialSegmentControlPage)
						},

						new TextCell {
							Text = "Image",
							Command = navigateCommand,
							CommandParameter = typeof(MyPage)
						},

						new TextCell {
							Text = "HTML Labels and Buttons",
							Command = navigateCommand,
							CommandParameter = typeof(HtmlLabelsAndButtons)
						},

						new TextCell {
							Text = "Unrequested Size, CapsInset Test",
							Command = navigateCommand,
							CommandParameter = typeof(UnRequestedSizeCapsInsetPage)
						}

					}, 

					new TableSection("Code") {

						new TextCell {
							Text = "Imposed Height Label Fit",
							Command = navigateCommand,
							CommandParameter = typeof(LabelFitPage)
						},

						new TextCell {
							Text = "Unimposed Height Label Fit",
							Command = navigateCommand,
							CommandParameter = typeof(UnconstrainedLabelFitPage)
						},

						new TextCell {
							Text = "External EmbeddedResource Image",
							Command = navigateCommand,
							CommandParameter = typeof(ExternalEmbeddedResourceImage)
						},

						new TextCell {
							Text = "Label in Layout",
							Command = navigateCommand,
							CommandParameter = typeof(LabelInHorizontalStackLayout)
						},


						new TextCell {
							Text = "HTML Formatted Labels",
							Command = navigateCommand,
							CommandParameter = typeof(HtmlLabelPage)
						},

						new TextCell {
							Text = "HTML Formatted Buttons",
							Command = navigateCommand,
							CommandParameter = typeof(HtmlButtonsPage)
						},

						new TextCell {
							Text = "Chat using ListView",
							Command = navigateCommand,
							CommandParameter = typeof(ChatListPage)
						},

						new TextCell {
							Text = "ImageButton",
							Command = navigateCommand,
							CommandParameter = typeof(ImageButtonCodePage)
						},

						new TextCell {
							Text = "Image",
							Command = navigateCommand,
							CommandParameter = typeof(ImageCodePage)
						},

						new TextCell {
							Text = "Layouts",
							Command = navigateCommand,
							CommandParameter = typeof(LayoutsPage)
						},

						new TextCell {
							Text = "Material Buttons",
							Command = navigateCommand,
							CommandParameter = typeof(MaterialButtonsPage)
						},

						new TextCell {
							Text = "Modal Popup",
							Command = navigateCommand,
							CommandParameter = typeof(ModalPopupTestPage),
						},

						new TextCell {
							Text = "Bubble Popup",
							Command = navigateCommand,
							CommandParameter = typeof(BubblePopupTestPage),
						},

						new TextCell {
							Text = "Gestures Test",
							Command = navigateCommand,
							CommandParameter = typeof(GesturesTestPage)
						},

						new TextCell {
							Text = "ImageButton in ContentView Test",
							Command = navigateCommand,
							CommandParameter = typeof(ZenmekPage)
						},

					}
				}
			};
		}
	}
}
