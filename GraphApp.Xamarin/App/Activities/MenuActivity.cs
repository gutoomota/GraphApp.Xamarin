using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Runtime;

using System;
using System.Collections.Generic;

namespace GraphApp.Xamarin
{
	[Activity ()]
	public class MenuActivity : Activity
	{
		ListView lvMenu;
		Button bHelp;

		int controllerLog, previous;

		//Double Back to Exit Operation
		bool doubleBackToExitPressedOnce = false;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Intent i = Intent;

			previous = i.GetIntExtra("previous", -1);
			if ((previous==0)||(previous==1)||(previous==2)) {
				controllerLog = Controller.main(i);
				switch (controllerLog) {
				case 1:
					Toast.MakeText(this, TextsEN.getErrorByPosition(0), ToastLength.Long).Show();
					break;
				case 2:
					Toast.MakeText(this, TextsEN.getInsertionByPosition(0), ToastLength.Long).Show();
					break;
				case 3:
					Toast.MakeText(this, TextsEN.getErrorByPosition(1), ToastLength.Long).Show();
					break;
				case 4:
					Toast.MakeText(this, TextsEN.getErrorByPosition(2), ToastLength.Long).Show();
					break;
				case 5:
					Toast.MakeText(this, TextsEN.getInsertionByPosition(1), ToastLength.Long).Show();
					break;
				case 6:
					Toast.MakeText(this, TextsEN.getErrorByPosition(6), ToastLength.Long).Show();
					break;
				}
			}

			//Controller.getGraph().getVertices()[0].addIncidents(new Edge(1,new Vertex("a"),new Vertex("b")));

			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_menu);

			lvMenu = FindViewById<ListView> (Resource.Id.lvMenu);
			bHelp = FindViewById<Button> (Resource.Id.bHelp);

			ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, TextsEN.getMenu());

			lvMenu.Adapter = adapter;

			lvMenu.ItemClick += OnListItemClick;	

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(1), ToastLength.Long).Show();
			};
		}

		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Controller.getGraph().cleanVisitedVertex();
			Controller.getGraph().cleanVisitedEdge();

			switch (e.Position){
			case 0: //OK
				StartActivity(new Intent(this, typeof(VertexActivity)));
				Finish();
				break;
			case 1: //OK
				StartActivity(new Intent(this, typeof(EdgeActivity)));
				Finish();
				break;
			case 2: //OK
				Intent i2 = new Intent(this, typeof(GraphActivity));
				i2.PutExtra("title", TextsEN.getMenuByPosition(2));
				i2.PutExtra("algorithm", 2);
				i2.PutExtra("description","");
				i2.PutExtra("complexity", "");
				StartActivity(i2);
				break;
			case 3:
				Intent i3 = new Intent(this, typeof(GraphActivity));
				i3.PutExtra("title", TextsEN.getMenuByPosition(3));
				i3.PutExtra("algorithm", 3);
				i3.PutExtra("description",TextsEN.getDescriptionByPosition(0));
				i3.PutExtra("complexity", TextsEN.getComplexityByPosition(0));
				StartActivity(i3);
				break;
			case 4:
				Intent i4 = new Intent(this, typeof(InputActivity));
				i4.PutExtra("algorithm", 4);
				i4.PutExtra("title", TextsEN.getMenuByPosition(4));
				i4.PutExtra("description",TextsEN.getDescriptionByPosition(1));
				i4.PutExtra("complexity", TextsEN.getComplexityByPosition(1));
				StartActivity(i4);
				break;
			case 5: //OK
				Intent i5 = new Intent(this, typeof(InputActivity));
				i5.PutExtra("algorithm", 5);
				i5.PutExtra("title", TextsEN.getMenuByPosition(5));
				i5.PutExtra("description",TextsEN.getDescriptionByPosition(2));
				i5.PutExtra("complexity", TextsEN.getComplexityByPosition(2));
				StartActivity(i5);
				break;
			case 6: //OK
				Intent i6 = new Intent(this, typeof(InputActivity));
				i6.PutExtra("algorithm", 6);
				i6.PutExtra("title", TextsEN.getMenuByPosition(6));
				i6.PutExtra("description",TextsEN.getDescriptionByPosition(3));
				i6.PutExtra("complexity", TextsEN.getComplexityByPosition(3));
				StartActivity(i6);
				break;
			case 7: //OK
				Intent i7 = new Intent(this, typeof(TopSortActivity));
				i7.PutExtra("title", TextsEN.getMenuByPosition(7));
				i7.PutExtra("description",TextsEN.getDescriptionByPosition(4));
				i7.PutExtra("complexity", TextsEN.getComplexityByPosition(4));
				StartActivity(i7);
				break;
			case 8: //OK
				Intent i8 = new Intent(this, typeof(GraphActivity));
				i8.PutExtra("algorithm", 8);
				i8.PutExtra("title", TextsEN.getMenuByPosition(8));
				i8.PutExtra("description",TextsEN.getDescriptionByPosition(5));
				i8.PutExtra("complexity", TextsEN.getComplexityByPosition(5));
				StartActivity(i8);
				break;
			case 9: //OK
				Intent i9 = new Intent(this, typeof(WarshallActivity));
				i9.PutExtra("title", TextsEN.getMenuByPosition(9));
				i9.PutExtra("description",TextsEN.getDescriptionByPosition(6));
				i9.PutExtra("complexity", TextsEN.getComplexityByPosition(6));
				StartActivity(i9);
				break;
			case 10:
				StartActivity(new Intent(this, typeof(ReferenceActivity)));
				break;
			case 11: //OK
				StartActivity(new Intent(this, typeof(MainActivity)));
				Controller.destroy();
				Finish();
				break;
			}
		}

		public override void OnBackPressed() {
			if (doubleBackToExitPressedOnce) {
				Controller.destroy();
				System.Environment.Exit(0);
				Finish();
				return;
			}

			this.doubleBackToExitPressedOnce = true;
			Toast.MakeText(this, "Please click BACK again to exit", ToastLength.Long).Show();

			new Handler().PostDelayed(new Runnable() {

				public override void run() {
					doubleBackToExitPressedOnce=false;
				}
			}, 2000);
		}
	}
}