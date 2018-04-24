using System;
using Xamarin.Forms;
using Forms9Patch;
namespace Forms9PatchDemo.Pages.Code
{
    public class PopupsPage : Xamarin.Forms.ContentPage
    {
        public PopupsPage()
        {
            Padding = 20;

            var showModalButton = new Forms9Patch.Button("ModalPopup");
            var cancelModalButton = new Forms9Patch.Button("CANCEL");
            var modal = new ModalPopup
            {
                Content = new Xamarin.Forms.StackLayout
                {
                    Children = {
                        new Forms9Patch.Label("ModalPopup") { FontAttributes=FontAttributes.Bold },
                        cancelModalButton
                    }
                }
            };
            cancelModalButton.Clicked += (sender, e) => modal.Cancel();
            showModalButton.Clicked += (sender, e) => modal.IsVisible = true;

            var showBubbleButton = new Forms9Patch.Button("BubblePopup");
            var cancelBubbleButton = new Forms9Patch.Button("CANCEL");
            var bubble = new BubblePopup(showBubbleButton)
            {
                Content = new Xamarin.Forms.StackLayout
                {
                    Children = {
                        new Forms9Patch.Label("BubblePopup") { FontAttributes=FontAttributes.Bold },
                        cancelBubbleButton
                    }
                }
            };
            cancelBubbleButton.Clicked += (sender, e) => bubble.Cancel();
            showBubbleButton.Clicked += (sender, e) => bubble.IsVisible = true;

            var showActivityButton = new Forms9Patch.Button("ActivityIndicatorPopup");
            showActivityButton.Clicked += (sender, e) =>
            {
                var activity = Forms9Patch.ActivityIndicatorPopup.Create();
                activity.CancelOnPageOverlayTouch = true;
            };

            var showPermissionButton = new Forms9Patch.Button("PermissionPopup");
            showPermissionButton.Clicked += (sender, e) =>
            {
                var permission = PermissionPopup.Create("PermissionPopup", "Do you agree?");
            };

            var showToastButton = new Forms9Patch.Button("Toast");
            showToastButton.Clicked += (sender, e) => Toast.Create("Toast", "... of the town!");

            var showTargetedToash = new Forms9Patch.Button("TargetedToast");
            showTargetedToash.Clicked += (sender, e) => TargetedToast.Create(showTargetedToash, "TargetedToast", "... has the far getted most!");

            var showTargetedMenu = new Forms9Patch.Button("TargetedMenu");
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
            showTargetedMenu.Clicked += (s, e) => targetedMenu.IsVisible = true;
            targetedMenu.SegmentTapped += (s, e) => System.Diagnostics.Debug.WriteLine("TargetedMenu.SegmentTapped: " + e.Segment.Text);

            Content = new Xamarin.Forms.StackLayout
            {
                Children = { showModalButton, showBubbleButton, showActivityButton, showPermissionButton, showToastButton, showTargetedToash, showTargetedMenu }
            };
        }
    }
}
