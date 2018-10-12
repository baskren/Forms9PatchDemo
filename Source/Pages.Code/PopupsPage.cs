﻿using System;
using Xamarin.Forms;
using Forms9Patch;
using System.Collections.Generic;

namespace Forms9PatchDemo.Pages.Code
{
    public class PopupsPage : Xamarin.Forms.ContentPage
    {
        bool _hasShadow;
        bool _shadowInverted;
        bool _blueOutline;

        const string _hasShadowText = "HasShadow";
        const string _shadowInvertedText = "ShadowInverted";
        const string _blueOutlineText = "Blue Outline";
        readonly SegmentedControl _decoration = new SegmentedControl
        {
            Segments = {
                new Segment(_hasShadowText),
                new Segment(_shadowInvertedText),
                new Segment(_blueOutlineText),
            },
            GroupToggleBehavior = GroupToggleBehavior.Multiselect,
            BackgroundColor = Color.White,
        };

        #region Modal Popup VisualElements
        readonly Forms9Patch.Button showModalButton = new Forms9Patch.Button("ModalPopup") { BackgroundColor = Color.White };
        static readonly Forms9Patch.Button cancelModalButton = new Forms9Patch.Button("CANCEL");

        readonly ModalPopup _modalPopup = new ModalPopup(true)
        {
            Content = new Xamarin.Forms.StackLayout
            {
                Children = {
                        new Forms9Patch.Label("ModalPopup") { FontAttributes=FontAttributes.Bold },
                        cancelModalButton
                    }
            },
            OutlineColor = Color.Blue,
        };
        #endregion

        readonly Forms9Patch.ActivityIndicatorPopup _activity = new ActivityIndicatorPopup();

        public PopupsPage()
        {
            Padding = 20;

            #region ModalPopup
            cancelModalButton.Clicked += (sender, e) => _modalPopup.Cancel();
            showModalButton.Clicked += (sender, e) =>
            {
                _modalPopup.HasShadow = _hasShadow;
                _modalPopup.ShadowInverted = _shadowInverted;
                _modalPopup.OutlineWidth = _blueOutline ? 1 : 0;
                _modalPopup.IsVisible = true;
            };
            #endregion


            #region BubblePopup
            var showBubbleButton = new Forms9Patch.Button("BubblePopup") { BackgroundColor = Color.White };
            var cancelBubbleButton = new Forms9Patch.Button("CANCEL");
            var bubble = new BubblePopup(showBubbleButton)
            {
                OutlineColor = Color.Blue,
                Content = new Xamarin.Forms.StackLayout
                {
                    Children = {
                        new Forms9Patch.Label("BubblePopup") { FontAttributes=FontAttributes.Bold },
                        cancelBubbleButton
                    }
                }
            };
            cancelBubbleButton.Clicked += (sender, e) => bubble.Cancel();
            showBubbleButton.Clicked += (sender, e) =>
            {
                bubble.OutlineColor = Color.Blue;
                bubble.HasShadow = _hasShadow;
                bubble.ShadowInverted = _shadowInverted;
                bubble.OutlineWidth = _blueOutline ? 1 : 0;
                bubble.IsVisible = true;
            };
            #endregion


            #region ActivityPopup
            Forms9Patch.Button showActivityPopupButton = new Forms9Patch.Button("ActivityIndicatorPopup") { BackgroundColor = Color.White };
            showActivityPopupButton.Clicked += (sender, e) =>
            {
                //var activity = Forms9Patch.ActivityIndicatorPopup.Create();
                _activity.CancelOnPageOverlayTouch = true;
                _activity.IsVisible = true;
            };
            #endregion


            #region PermissionPopup
            var showPermissionButton = new Forms9Patch.Button("PermissionPopup") { BackgroundColor = Color.White };
            showPermissionButton.Clicked += (sender, e) =>
            {
                var permission = PermissionPopup.Create("PermissionPopup", "Do you agree?");
                permission.OutlineColor = Color.Blue;
                permission.HasShadow = _hasShadow;
                permission.ShadowInverted = _shadowInverted;
                permission.OutlineWidth = _blueOutline ? 1 : 0;
            };
            #endregion


            #region Toast
            var showToastButton = new Forms9Patch.Button("Toast") { BackgroundColor = Color.White };
            showToastButton.Clicked += (sender, e) =>
            {
                var toast = Toast.Create("Toast", "... of the town!");
                toast.OutlineColor = Color.Blue;
                toast.HasShadow = _hasShadow;
                toast.ShadowInverted = _shadowInverted;
                toast.OutlineWidth = _blueOutline ? 1 : 0;
            };
            #endregion


            #region TargetedToast
            var showTargetedToash = new Forms9Patch.Button("TargetedToast") { BackgroundColor = Color.White };
            showTargetedToash.Clicked += (sender, e) =>
            {
                var toast = TargetedToast.Create(showTargetedToash, "TargetedToast", "... has the far getted most!");
                toast.OutlineColor = Color.Blue;
                toast.HasShadow = _hasShadow;
                toast.ShadowInverted = _shadowInverted;
                toast.OutlineWidth = _blueOutline ? 1 : 0;
            };
            #endregion


            #region TargetedMenu
            var showTargetedMenu = new Forms9Patch.Button("TargetedMenu") { BackgroundColor = Color.White };
            var targetedMenu = new Forms9Patch.TargetedMenu(showTargetedMenu)
            {
                Segments =
                {
                    new Segment("Copy", "<font face=\"Forms9PatchDemo.Resources.Fonts.MaterialIcons-Regular.ttf\">&#xE14D;</font>"),
                    new Segment("Cut", "<font face=\"Forms9PatchDemo.Resources.Fonts.MaterialIcons-Regular.ttf\">&#xE14E;</font>"),
                    new Segment("Paste", "<font face=\"Forms9PatchDemo.Resources.Fonts.MaterialIcons-Regular.ttf\">&#xE14F;</font>"),
                    new Segment("Segment A"),
                    new Segment("Segment B"),
                    new Segment("Segment C"),
                    new Segment("Segment D"),
                    new Segment("Segment E"),
                    new Segment("Segment F"),
                    new Segment("Segment G"),
                    new Segment("Segment H"),
                }
            };
            showTargetedMenu.Clicked += (s, e) =>
            {
                targetedMenu.OutlineColor = Color.Blue;
                targetedMenu.IsVisible = true;
                targetedMenu.HasShadow = _hasShadow;
                targetedMenu.ShadowInverted = _shadowInverted;
                targetedMenu.OutlineWidth = _blueOutline ? 1 : 0;
                targetedMenu.IsVisible = true;
            };
            targetedMenu.SegmentTapped += (s, e) => System.Diagnostics.Debug.WriteLine("TargetedMenu.SegmentTapped: " + e.Segment.Text);
            #endregion


            #region SoftwareKeyboardTest

            var yearPicker = new Xamarin.Forms.Picker
            {
                Title = "SELECT YEAR",
                ItemsSource = new List<string> { "SELECT YEAR", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2006", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020" },
                SelectedItem = "SELECT YEAR",
                SelectedIndex = 0,
                TextColor = Color.LightGray,
            };
            yearPicker.SelectedIndexChanged += (s, e) => yearPicker.TextColor = yearPicker.SelectedIndex == 0 ? Color.LightGray : Color.Blue;

            var monthPicker = new Xamarin.Forms.Picker
            {
                Title = "SELECT MONTH",
                ItemsSource = new List<string> { "SELECT MONTH", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" },
                SelectedItem = "SELECT MONTH",
                TextColor = Color.LightGray,
            };
            monthPicker.SelectedIndexChanged += (s, e) => monthPicker.TextColor = monthPicker.SelectedIndex == 0 ? Color.LightGray : Color.Blue;


            var softwareKeyboardTestButton = new Forms9Patch.Button("Software Keyboard Test") { BackgroundColor = Color.White };
            var softwareKeyboardTestPopup = new ModalPopup
            {
                Content =
                new Xamarin.Forms.StackLayout
                {
                    Children = {
                        yearPicker,
                        monthPicker,
                        new Xamarin.Forms.Entry
                        {
                            Placeholder = "ENTER FIRST NAME",
                            TextColor = Color.Blue,
                            PlaceholderColor = Color.LightGray,
                        },
                        new Xamarin.Forms.Entry
                        {
                            Placeholder = "ENTER LAST NAME",
                            TextColor = Color.Blue,
                            PlaceholderColor = Color.LightGray,
                        },
                    }
                }
            };
            softwareKeyboardTestButton.Clicked += (s, e) =>
            {
                softwareKeyboardTestPopup.OutlineColor = Color.Blue;
                softwareKeyboardTestPopup.HasShadow = _hasShadow;
                softwareKeyboardTestPopup.ShadowInverted = _shadowInverted;
                softwareKeyboardTestPopup.OutlineWidth = _blueOutline ? 1 : 0;
                softwareKeyboardTestPopup.IsVisible = true;
            };
            #endregion

            Content = new Xamarin.Forms.StackLayout
            {
                Children = {
                    new BoxView { HeightRequest = 1},
                    _decoration,
                    new BoxView { HeightRequest = 1},
                    showModalButton, showBubbleButton, showActivityPopupButton, showPermissionButton, showToastButton, showTargetedToash, showTargetedMenu, softwareKeyboardTestButton,
                    new BoxView { HeightRequest = 1},
                }
            };

            _decoration.SegmentTapped += (s, e) =>
            {
                switch (e.Segment.Text)
                {
                    case _hasShadowText:
                        _hasShadow = !_hasShadow;
                        break;
                    case _shadowInvertedText:
                        _shadowInverted = !_shadowInverted;
                        break;
                    case _blueOutlineText:
                        _blueOutline = !_blueOutline;
                        break;
                }
            };

            BackgroundColor = Color.LightSlateGray;
        }
    }
}
