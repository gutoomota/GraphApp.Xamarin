using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class ReferenceActivity :Activity
	{
		TextView tvRef;
		Button bHelp;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_reference);

			tvRef = FindViewById<TextView> (Resource.Id.tvRef);
			bHelp = FindViewById<Button> (Resource.Id.bHelp);

			tvRef.Text = TextsEN.getReference ();

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(5), ToastLength.Long).Show();
			};


		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

