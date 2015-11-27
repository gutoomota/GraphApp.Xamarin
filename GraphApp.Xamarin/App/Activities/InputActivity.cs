using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class InputActivity :Activity
	{
		TextView tvTitle, tvEnd;
		EditText etStart, etEnd;
		Button bNext,bHelp;

		Graph graph = Controller.getGraph();
		String title, description, complexity;
		int algorithm;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_input);
		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

