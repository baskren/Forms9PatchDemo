== Steps to integrate Forms9Patch into Xamarin.Forms UWP app:

1. Follow the following steps to create the UWP project for your Xamarin.Forms app: https://developer.xamarin.com/guides/xamarin-forms/platform-features/windows/installation/universal/
2. Add Forms9Patch nuget package (version >= 0.10.3.5)
3. In the UWP project's App.Xaml.cs file, replace the ```Xamarin.Forms.Init(e);``` line (you added earlier in Step 1) with the following lines:
    
                var assembliesToInclude = Forms9Patch.UWP.Settings.AssembliesToInclude;
                Xamarin.Forms.Forms.Init(e, assembliesToInclude); 
                Forms9Patch.UWP.Settings.Initialize(this, _put_the_Forms9Patch_license_key_for_this_app_here_ );

4. Set the UWP apps display name:
  1. Open the UWP project's app manifest (double click on the Package.appxmanifest file in the UWP project).
  2. In the [Application] section, set the "Display Name:" to the name associated with your Forms9Patch license key.
  3. In the [Packaging] section, set the "Package display name:" to the name associated with your Forms9Patch license key.
5. Enable XAML Compilation:  In every project that has XAML to display, add the following line to the project's ```Properties/AssemblyInfo.cs``` file.  Note: Don't make the same rookie mistake I did and put the following line in the UWP project's (instead of the PCL project's) ```AssemblyInfo.cs``` file.

    [assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]

  


