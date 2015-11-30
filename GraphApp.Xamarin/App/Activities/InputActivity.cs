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

			Intent i1 = Intent;
			algorithm = i1.GetIntExtra("algorithm", -1);
			title = i1.GetStringExtra("title");
			description = i1.GetStringExtra("description");
			complexity = i1.GetStringExtra("complexity");

			tvTitle = FindViewById<TextView> (Resource.Id.tvTitle);
			tvEnd = FindViewById<TextView> (Resource.Id.tvEnd);
			etStart = FindViewById<EditText> (Resource.Id.etStart);
			etEnd = FindViewById<EditText> (Resource.Id.etEnd);
			bNext = FindViewById<Button> (Resource.Id.bNext);
			bHelp = FindViewById<Button> (Resource.Id.bHelp);

			tvTitle.Text = title;

			if(algorithm!=4){ // if the algorithm is Dijkstra, it needs to get a start and a end to the Dijkstra Path
				tvEnd.Visibility = ViewStates.Invisible;
				etEnd.Visibility = ViewStates.Invisible;
			}

			bNext.Click += delegate {
				String start = etStart.Text.ToString();

				if (start.Equals("")){ // Checking if the gap 'start' is empty
					Toast.MakeText(this, TextsEN.getHelpByPosition(6), ToastLength.Long).Show();
				}else if (graph.vertexLocation(start)!=graph.getVertices().Count) { //Checking if the vertex exist
					if (algorithm == 4) {
						String end = etEnd.Text.ToString();

						if (end.Equals("")){ // Checking if the gap 'end' is empty
							Toast.MakeText(this, TextsEN.getHelpByPosition(6), ToastLength.Long).Show();
						}else if(graph.vertexLocation(end)==graph.getVertices().Count){ //Checking if the vertex exist
							Toast.MakeText(this, TextsEN.getErrorByPosition(3), ToastLength.Long).Show();
						}else if(start.Equals(end)){ //Checking if the start is equal to the end
							Toast.MakeText(this, TextsEN.getErrorByPosition(1), ToastLength.Long).Show();
						}else {
							Intent i2 = new Intent(this, typeof(GraphActivity));
							i2.PutExtra("title", title);
							i2.PutExtra("algorithm", algorithm);
							i2.PutExtra("start", start);
							i2.PutExtra("end", end);
							i2.PutExtra("description", description);
							i2.PutExtra("complexity", complexity);
							StartActivity(i2);
							Finish();
						}

					} else if (algorithm == 5) {
						Intent i2 = new Intent(this, typeof(GraphActivity));
						i2.PutExtra("title", title);
						i2.PutExtra("algorithm", algorithm);
						i2.PutExtra("start", start);
						i2.PutExtra("end", "");
						i2.PutExtra("description", description);
						i2.PutExtra("complexity", complexity);
						StartActivity(i2);
						Finish();
					} else if (algorithm == 6) {
						Intent i2 = new Intent(this, typeof(GraphActivity));
						i2.PutExtra("title", title);
						i2.PutExtra("algorithm", algorithm);
						i2.PutExtra("start", start);
						i2.PutExtra("end", "");
						i2.PutExtra("description", description);
						i2.PutExtra("complexity", complexity);
						StartActivity(i2);
						Finish();
					}
				}else {
					Toast.MakeText(this, TextsEN.getErrorByPosition(3), ToastLength.Long).Show();
				}
			};

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getErrorByPosition(6), ToastLength.Long).Show();
			};

		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

