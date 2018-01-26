﻿// /*******************************************************************
//  *
//  * SegmentSelectedViaXaml.xaml.cs copyright 2017 ben, 42nd Parallel - ALL RIGHTS RESERVED.
//  *
//  *******************************************************************/
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Forms9PatchDemo
{
	public partial class SegmentBindingPage : ContentPage
	{
		private GameState state;

		public SegmentBindingPage()
		{
			InitializeComponent();

			state = new GameState();

			state.AddPlayer();

			tblPlayers.ItemsSource = state.multiPlayers;

		}
	}
}
