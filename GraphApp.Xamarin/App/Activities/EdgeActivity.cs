using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class EdgeActivity : Activity
	{
		Button bHelp, bInsert;
		EditText etWeight, etStart, etEnd;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_edge);

			bHelp = FindViewById<Button>(Resource.Id.bHelp);
			bInsert = FindViewById<Button>(Resource.Id.bInsert);
			etWeight = FindViewById<EditText>(Resource.Id.etWeight);
			etStart = FindViewById<EditText>(Resource.Id.etStart);
			etEnd = FindViewById<EditText>(Resource.Id.etEnd);

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(3), ToastLength.Long).Show();
			};

			bInsert.Click += delegate {
				int weight;

				String start = etStart.Text.ToString();
				String end = etEnd.Text.ToString();

				if ((etWeight.Text.ToString().Equals(""))||(start.Equals(""))||(end.Equals(""))){
					Toast.MakeText(this, TextsEN.getHelpByPosition(3), ToastLength.Long).Show();
				}else if(etWeight.Text.ToString().Equals("0")) {
					Toast.MakeText(this, TextsEN.getErrorByPosition(7), ToastLength.Long).Show();
				}else {
					weight = Int32.Parse(etWeight.Text.ToString());

					Intent i = new Intent(this, typeof(MenuActivity));
					i.PutExtra("previous", 2);
					i.PutExtra("weight", weight);
					i.PutExtra("start", start);
					i.PutExtra("end", end);
					StartActivity(i);
					Finish();
				}
			};
		}

		public override void OnBackPressed() {
			StartActivity(new Intent(this, typeof(MenuActivity)));
			Finish();
		}
	}
}

