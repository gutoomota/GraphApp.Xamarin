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
	public class WarshallActivity :Activity
	{
		Graph graph = Controller.getGraph();

		TextView[,] tvFW = new TextView[12,10];
		Button bDescription, bHelp;
		String title, description, complexity;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_warshall);

			initMatrix();
			displayFWMatrix();

			Intent i1 = Intent;
			title = i1.GetStringExtra("title");
			description = i1.GetStringExtra("description");
			complexity = i1.GetStringExtra("complexity");

			bDescription = FindViewById<Button>(Resource.Id.bDescription);
			bHelp = FindViewById<Button>(Resource.Id.bHelp);

			bHelp.Click += delegate {
				Toast.MakeText(this, TextsEN.getHelpByPosition(4), ToastLength.Long).Show();
			};
			bDescription.Click += delegate {
				Intent i2 = new Intent(this, typeof(DescriptionActivity));
				i2.PutExtra("title",title);
				i2.PutExtra("previous",3);
				i2.PutExtra("description",description);
				i2.PutExtra("complexity",complexity);
				StartActivity (i2);
			};

		}

		public void displayFWMatrix(){
			List<Vertex> vertices = graph.getVertices();
			int[,] fwMatrix = graph.floydWarshall();

			int size = vertices.Count;

			for(int i=0;i<size;i++){
				tvFW[10,i].Text = vertices[i].getName();
				tvFW[11,i].Text = vertices[i].getName();
			}
			for(int i=0;i<size;i++)
				for(int j=0;j<size;j++)
					tvFW[i,j].Text = fwMatrix[i,j].ToString();
		}

		public void initMatrix(){
			tvFW[10,0] = FindViewById<TextView>(Resource.Id.tvVc0);
			tvFW[10,1] = FindViewById<TextView>(Resource.Id.tvVc1);
			tvFW[10,2] = FindViewById<TextView>(Resource.Id.tvVc2);
			tvFW[10,3] = FindViewById<TextView>(Resource.Id.tvVc3);
			tvFW[10,4] = FindViewById<TextView>(Resource.Id.tvVc4);
			tvFW[10,5] = FindViewById<TextView>(Resource.Id.tvVc5);
			tvFW[10,6] = FindViewById<TextView>(Resource.Id.tvVc6);
			tvFW[10,7] = FindViewById<TextView>(Resource.Id.tvVc7);
			tvFW[10,8] = FindViewById<TextView>(Resource.Id.tvVc8);
			tvFW[10,9] = FindViewById<TextView>(Resource.Id.tvVc9);

			tvFW[11,0] = FindViewById<TextView>(Resource.Id.tvVl0);
			tvFW[11,1] = FindViewById<TextView>(Resource.Id.tvVl1);
			tvFW[11,2] = FindViewById<TextView>(Resource.Id.tvVl2);
			tvFW[11,3] = FindViewById<TextView>(Resource.Id.tvVl3);
			tvFW[11,4] = FindViewById<TextView>(Resource.Id.tvVl4);
			tvFW[11,5] = FindViewById<TextView>(Resource.Id.tvVl5);
			tvFW[11,6] = FindViewById<TextView>(Resource.Id.tvVl6);
			tvFW[11,7] = FindViewById<TextView>(Resource.Id.tvVl7);
			tvFW[11,8] = FindViewById<TextView>(Resource.Id.tvVl8);
			tvFW[11,9] = FindViewById<TextView>(Resource.Id.tvVl9);

			tvFW[0,0] = FindViewById<TextView>(Resource.Id.tv00);
			tvFW[0,1] = FindViewById<TextView>(Resource.Id.tv01);
			tvFW[0,2] = FindViewById<TextView>(Resource.Id.tv02);
			tvFW[0,3] = FindViewById<TextView>(Resource.Id.tv03);
			tvFW[0,4] = FindViewById<TextView>(Resource.Id.tv04);
			tvFW[0,5] = FindViewById<TextView>(Resource.Id.tv05);
			tvFW[0,6] = FindViewById<TextView>(Resource.Id.tv06);
			tvFW[0,7] = FindViewById<TextView>(Resource.Id.tv07);
			tvFW[0,8] = FindViewById<TextView>(Resource.Id.tv08);
			tvFW[0,9] = FindViewById<TextView>(Resource.Id.tv09);

			tvFW[1,0] = FindViewById<TextView>(Resource.Id.tv10);
			tvFW[1,1] = FindViewById<TextView>(Resource.Id.tv11);
			tvFW[1,2] = FindViewById<TextView>(Resource.Id.tv12);
			tvFW[1,3] = FindViewById<TextView>(Resource.Id.tv13);
			tvFW[1,4] = FindViewById<TextView>(Resource.Id.tv14);
			tvFW[1,5] = FindViewById<TextView>(Resource.Id.tv15);
			tvFW[1,6] = FindViewById<TextView>(Resource.Id.tv16);
			tvFW[1,7] = FindViewById<TextView>(Resource.Id.tv17);
			tvFW[1,8] = FindViewById<TextView>(Resource.Id.tv18);
			tvFW[1,9] = FindViewById<TextView>(Resource.Id.tv19);

			tvFW[2,0] = FindViewById<TextView>(Resource.Id.tv20);
			tvFW[2,1] = FindViewById<TextView>(Resource.Id.tv21);
			tvFW[2,2] = FindViewById<TextView>(Resource.Id.tv22);
			tvFW[2,3] = FindViewById<TextView>(Resource.Id.tv23);
			tvFW[2,4] = FindViewById<TextView>(Resource.Id.tv24);
			tvFW[2,5] = FindViewById<TextView>(Resource.Id.tv25);
			tvFW[2,6] = FindViewById<TextView>(Resource.Id.tv26);
			tvFW[2,7] = FindViewById<TextView>(Resource.Id.tv27);
			tvFW[2,8] = FindViewById<TextView>(Resource.Id.tv28);
			tvFW[2,9] = FindViewById<TextView>(Resource.Id.tv29);

			tvFW[3,0] = FindViewById<TextView>(Resource.Id.tv30);
			tvFW[3,1] = FindViewById<TextView>(Resource.Id.tv31);
			tvFW[3,2] = FindViewById<TextView>(Resource.Id.tv32);
			tvFW[3,3] = FindViewById<TextView>(Resource.Id.tv33);
			tvFW[3,4] = FindViewById<TextView>(Resource.Id.tv34);
			tvFW[3,5] = FindViewById<TextView>(Resource.Id.tv35);
			tvFW[3,6] = FindViewById<TextView>(Resource.Id.tv36);
			tvFW[3,7] = FindViewById<TextView>(Resource.Id.tv37);
			tvFW[3,8] = FindViewById<TextView>(Resource.Id.tv38);
			tvFW[3,9] = FindViewById<TextView>(Resource.Id.tv39);

			tvFW[4,0] = FindViewById<TextView>(Resource.Id.tv40);
			tvFW[4,1] = FindViewById<TextView>(Resource.Id.tv41);
			tvFW[4,2] = FindViewById<TextView>(Resource.Id.tv42);
			tvFW[4,3] = FindViewById<TextView>(Resource.Id.tv43);
			tvFW[4,4] = FindViewById<TextView>(Resource.Id.tv44);
			tvFW[4,5] = FindViewById<TextView>(Resource.Id.tv45);
			tvFW[4,6] = FindViewById<TextView>(Resource.Id.tv46);
			tvFW[4,7] = FindViewById<TextView>(Resource.Id.tv47);
			tvFW[4,8] = FindViewById<TextView>(Resource.Id.tv48);
			tvFW[4,9] = FindViewById<TextView>(Resource.Id.tv49);

			tvFW[5,0] = FindViewById<TextView>(Resource.Id.tv50);
			tvFW[5,1] = FindViewById<TextView>(Resource.Id.tv51);
			tvFW[5,2] = FindViewById<TextView>(Resource.Id.tv52);
			tvFW[5,3] = FindViewById<TextView>(Resource.Id.tv53);
			tvFW[5,4] = FindViewById<TextView>(Resource.Id.tv54);
			tvFW[5,5] = FindViewById<TextView>(Resource.Id.tv55);
			tvFW[5,6] = FindViewById<TextView>(Resource.Id.tv56);
			tvFW[5,7] = FindViewById<TextView>(Resource.Id.tv57);
			tvFW[5,8] = FindViewById<TextView>(Resource.Id.tv58);
			tvFW[5,9] = FindViewById<TextView>(Resource.Id.tv59);

			tvFW[6,0] = FindViewById<TextView>(Resource.Id.tv60);
			tvFW[6,1] = FindViewById<TextView>(Resource.Id.tv61);
			tvFW[6,2] = FindViewById<TextView>(Resource.Id.tv62);
			tvFW[6,3] = FindViewById<TextView>(Resource.Id.tv63);
			tvFW[6,4] = FindViewById<TextView>(Resource.Id.tv64);
			tvFW[6,5] = FindViewById<TextView>(Resource.Id.tv65);
			tvFW[6,6] = FindViewById<TextView>(Resource.Id.tv66);
			tvFW[6,7] = FindViewById<TextView>(Resource.Id.tv67);
			tvFW[6,8] = FindViewById<TextView>(Resource.Id.tv68);
			tvFW[6,9] = FindViewById<TextView>(Resource.Id.tv69);

			tvFW[7,0] = FindViewById<TextView>(Resource.Id.tv70);
			tvFW[7,1] = FindViewById<TextView>(Resource.Id.tv71);
			tvFW[7,2] = FindViewById<TextView>(Resource.Id.tv72);
			tvFW[7,3] = FindViewById<TextView>(Resource.Id.tv73);
			tvFW[7,4] = FindViewById<TextView>(Resource.Id.tv74);
			tvFW[7,5] = FindViewById<TextView>(Resource.Id.tv75);
			tvFW[7,6] = FindViewById<TextView>(Resource.Id.tv76);
			tvFW[7,7] = FindViewById<TextView>(Resource.Id.tv77);
			tvFW[7,8] = FindViewById<TextView>(Resource.Id.tv78);
			tvFW[7,9] = FindViewById<TextView>(Resource.Id.tv79);

			tvFW[8,0] = FindViewById<TextView>(Resource.Id.tv80);
			tvFW[8,1] = FindViewById<TextView>(Resource.Id.tv81);
			tvFW[8,2] = FindViewById<TextView>(Resource.Id.tv82);
			tvFW[8,3] = FindViewById<TextView>(Resource.Id.tv83);
			tvFW[8,4] = FindViewById<TextView>(Resource.Id.tv84);
			tvFW[8,5] = FindViewById<TextView>(Resource.Id.tv85);
			tvFW[8,6] = FindViewById<TextView>(Resource.Id.tv86);
			tvFW[8,7] = FindViewById<TextView>(Resource.Id.tv87);
			tvFW[8,8] = FindViewById<TextView>(Resource.Id.tv88);
			tvFW[8,9] = FindViewById<TextView>(Resource.Id.tv89);

			tvFW[9,0] = FindViewById<TextView>(Resource.Id.tv90);
			tvFW[9,1] = FindViewById<TextView>(Resource.Id.tv91);
			tvFW[9,2] = FindViewById<TextView>(Resource.Id.tv92);
			tvFW[9,3] = FindViewById<TextView>(Resource.Id.tv93);
			tvFW[9,4] = FindViewById<TextView>(Resource.Id.tv94);
			tvFW[9,5] = FindViewById<TextView>(Resource.Id.tv95);
			tvFW[9,6] = FindViewById<TextView>(Resource.Id.tv96);
			tvFW[9,7] = FindViewById<TextView>(Resource.Id.tv97);
			tvFW[9,8] = FindViewById<TextView>(Resource.Id.tv98);
			tvFW[9,9] = FindViewById<TextView>(Resource.Id.tv99);
		}

		public override void OnBackPressed() {
			Finish();
		}
	}
}

