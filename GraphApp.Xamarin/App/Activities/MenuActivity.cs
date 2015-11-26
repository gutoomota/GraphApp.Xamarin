using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

using System;

namespace GraphApp.Xamarin
{
	[Activity (Label = "GraphApp.Xamarin", Icon = "@mipmap/icon")]
	public class MenuActivity : Activity
	{
		ListView lvMenu;
		Button bHelp;

		int controllerLog, previous;

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
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_menu);

			lvMenu = FindViewById<ListView> (Resource.Id.lvMenu);
			bHelp = FindViewById<Button> (Resource.Id.bHelp);
		}
	}
}

