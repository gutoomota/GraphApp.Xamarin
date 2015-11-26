using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity (Label = "GraphApp.Xamarin", Icon = "@mipmap/icon")]
	public class MenuActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_menu);
		}
	}
}

