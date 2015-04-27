using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SampleAnimations.Droid
{
	[Activity(Label = "SampleAnimations", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			App.OnUnhandledException(e.ExceptionObject as Exception);
		}
	}
}

