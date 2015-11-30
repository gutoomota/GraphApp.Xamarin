using System;
using System.Collections.Generic;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class TopSortActivity :Activity
	{
		ListView lvTopSort;
		Button bDescription, bHelp;
		String title, description, complexity;
		Graph graph = Controller.getGraph();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			List<Vertex> vertices = graph.topologicalSort();
			String[] topSort = new String[graph.getVertices().Count];

			if (vertices[0].getName().Equals("Not directed")) {
				Toast.MakeText(this, TextsEN.getErrorByPosition(4), ToastLength.Long).Show();
				Finish();
			} else if (vertices[0].getName().Equals("cycle")) {
				Toast.MakeText(this, TextsEN.getErrorByPosition(5), ToastLength.Long).Show();
				Finish();
			}else{
				int count = 1;
				foreach (Vertex v in vertices) {
					topSort[count-1] = count + ". " + v.getName();
					count++;
				}
			}

			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_top_sort);

			Intent i1 = Intent;
			title = i1.GetStringExtra("title");
			description = i1.GetStringExtra("description");
			complexity = i1.GetStringExtra("complexity");

			lvTopSort = FindViewById<ListView>(Resource.Id.lvTopSort);
			bHelp = FindViewById<Button>(Resource.Id.bHelp);
			bDescription = FindViewById<Button>(Resource.Id.bDescription);

			bDescription.Click += delegate {
				Intent i2 = new Intent(this, typeof(DescriptionActivity));
				i2.PutExtra("title",title);
				i2.PutExtra("previous",3);
				i2.PutExtra("description",description);
				i2.PutExtra("complexity", complexity);
				StartActivity (i2);
			};
			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(4), ToastLength.Long).Show();
			};

			ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, topSort);
			lvTopSort.Adapter = adapter;
		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

