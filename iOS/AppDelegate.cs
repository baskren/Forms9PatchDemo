using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Forms9PatchDemo;

namespace Forms9PatchDemo.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			Forms9Patch.iOS.Settings.Initialize("NZPK-RMP4-PJVV-Z7LP-78JF-GNXB-CDJZ-SRYA-BLR2-WBZC-G64K-QJZW-65DB");
			//FormsGestures.iOS.Settings.Init ();
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

