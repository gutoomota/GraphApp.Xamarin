using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class VertexActivity :Activity
	{
		Button bHelp, bInsert;
		EditText etVertex;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_vertex);

			bHelp = FindViewById<Button> (Resource.Id.bHelp);
			bInsert = FindViewById<Button> (Resource.Id.bInsert);
			etVertex = FindViewById<EditText> (Resource.Id.etVertex);

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(2), ToastLength.Long).Show();
			};

			bInsert.Click += delegate {
				String vertex = etVertex.Text;

				if (vertex.Equals("")){
					Toast.MakeText(this, TextsEN.getHelpByPosition(2), ToastLength.Long).Show();
				}else {
					Intent i = new Intent(this, typeof(MenuActivity));
					i.PutExtra("previous", 1);
					i.PutExtra("vertex", vertex);
					StartActivity(i);
					Finish();
				}
			};
		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

