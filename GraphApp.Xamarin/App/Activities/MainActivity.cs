using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity (MainLauncher = true)]
	public class MainActivity : Activity
	{
		RadioButton rbDirected, rbRandom;
		Button bNext,bHelp;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature(WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_main);

			// Get our button from the layout resource,
			// and attach an event to it
			bNext = FindViewById<Button> (Resource.Id.bNext);
			bHelp = FindViewById<Button> (Resource.Id.bHelp);
			rbDirected = FindViewById<RadioButton> (Resource.Id.rbDirected);
			rbRandom = FindViewById<RadioButton> (Resource.Id.rbRandom);

			bNext.Click += delegate {
				Intent i = new Intent(this,typeof(MenuActivity));
				i.PutExtra("previous",0);
				i.PutExtra("directed",rbDirected.Checked);
				i.PutExtra("random", rbRandom.Checked);
				StartActivity(i);
				Finish();
			};
			/*Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};*/
		}
	}
}


