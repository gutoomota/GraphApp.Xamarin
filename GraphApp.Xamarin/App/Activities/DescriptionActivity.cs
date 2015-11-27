using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class DescriptionActivity :Activity
	{
		Button bHelp;
		TextView tvTitle, tvDescription, tvComplexity;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_description);


			Intent i = Intent;
			bHelp = FindViewById<Button>(Resource.Id.bHelp);
			tvTitle = FindViewById<TextView>(Resource.Id.tvTitle);
			tvDescription = FindViewById<TextView>(Resource.Id.tvDescription);
			tvComplexity = FindViewById<TextView>(Resource.Id.tvComplexity);

			tvComplexity.Text = i.GetStringExtra("complexity");
			tvDescription.Text = i.GetStringExtra("description");
			tvTitle.Text = i.GetStringExtra("title");

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(5), ToastLength.Long).Show();
			};
		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

