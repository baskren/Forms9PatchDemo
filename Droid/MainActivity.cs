using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Forms9PatchDemo.Droid
{
    [Activity(Label = "asap - The Ascendas-Singbridge App", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Forms9Patch.Droid.Settings.Initialize("NZPK-RMP4-PJVV-Z7LP-78JF-GNXB-CDJZ-SRYA-BLR2-WBZC-G64K-QJZW-65DB");  // for "Forms9Patch Demo"
            Forms9Patch.Droid.Settings.Initialize("EGC8-5NV9-EAWV-3859-4SKY-PQW3-S6SJ-RYN3-JF3R-2P9D-866F-AVT6-52G7");  // for "asap - The Ascendas-Singbridge App"

            LoadApplication(new App());
        }
    }
}

