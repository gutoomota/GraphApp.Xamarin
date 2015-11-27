using System;
using System.Collections.Generic;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace GraphApp.Xamarin
{
	public class GraphActivity :Activity
	{
		Graph graph = Controller.getGraph();
		Button bDescription, bHelp;
		TextView tvTitle, tvGraph;
		TextView[] tvVertices = new TextView[10];
		TextView[,] tvEdges = new TextView[10,10];


		int algorithm;
		String title, start, end, description, complexity;


		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_graph);

			Intent i1 = Intent;
			title = i1.GetStringExtra("title");
			algorithm = i1.GetIntExtra("algorithm", -1);
			start = i1.GetStringExtra("start");
			end = i1.GetStringExtra("end");
			description = i1.GetStringExtra("description");
			complexity = i1.GetStringExtra("complexity");

			initDisplay();

			bHelp = FindViewById<Button> (Resource.Id.bHelp);
			tvTitle = FindViewById<TextView> (Resource.Id.tvTitle);
			tvGraph = FindViewById<TextView> (Resource.Id.tvGraph);
			bDescription = FindViewById<Button> (Resource.Id.bDescription);

			tvTitle.Text = title;

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
			displayGraph();
		}

		public void initDisplay(){

			tvVertices[0] = FindViewById<TextView> (Resource.Id.tv0);
			tvVertices[1] = FindViewById<TextView> (Resource.Id.tv1);
			tvVertices[2] = FindViewById<TextView> (Resource.Id.tv2);
			tvVertices[3] = FindViewById<TextView> (Resource.Id.tv3);
			tvVertices[4] = FindViewById<TextView> (Resource.Id.tv4);
			tvVertices[5] = FindViewById<TextView> (Resource.Id.tv5);
			tvVertices[6] = FindViewById<TextView> (Resource.Id.tv6);
			tvVertices[7] = FindViewById<TextView> (Resource.Id.tv7);
			tvVertices[8] = FindViewById<TextView> (Resource.Id.tv8);
			tvVertices[9] = FindViewById<TextView> (Resource.Id.tv9);

			if(graph.isDirected()) {

				//0
				tvEdges[0,1] = FindViewById<TextView> (Resource.Id.tvE01);
				tvEdges[0,2] = FindViewById<TextView> (Resource.Id.tvE02);
				tvEdges[0,3] = FindViewById<TextView> (Resource.Id.tvE03);
				tvEdges[0,4] = FindViewById<TextView> (Resource.Id.tvE04);
				tvEdges[0,5] = FindViewById<TextView> (Resource.Id.tvE05);
				tvEdges[0,6] = FindViewById<TextView> (Resource.Id.tvE06);
				tvEdges[0,7] = FindViewById<TextView> (Resource.Id.tvE07);
				tvEdges[0,8] = FindViewById<TextView> (Resource.Id.tvE08);
				tvEdges[0,9] = FindViewById<TextView> (Resource.Id.tvE09);
				//1
				tvEdges[1,0] = FindViewById<TextView> (Resource.Id.tvE10);
				tvEdges[1,2] = FindViewById<TextView> (Resource.Id.tvE12);
				tvEdges[1,3] = FindViewById<TextView> (Resource.Id.tvE13);
				tvEdges[1,4] = FindViewById<TextView> (Resource.Id.tvE14);
				tvEdges[1,5] = FindViewById<TextView> (Resource.Id.tvE15);
				tvEdges[1,6] = FindViewById<TextView> (Resource.Id.tvE16);
				tvEdges[1,7] = FindViewById<TextView> (Resource.Id.tvE17);
				tvEdges[1,8] = FindViewById<TextView> (Resource.Id.tvE18);
				tvEdges[1,9] = FindViewById<TextView> (Resource.Id.tvE19);
				//2
				tvEdges[2,0] = FindViewById<TextView> (Resource.Id.tvE20);
				tvEdges[2,1] = FindViewById<TextView> (Resource.Id.tvE21);
				tvEdges[2,3] = FindViewById<TextView> (Resource.Id.tvE23);
				tvEdges[2,4] = FindViewById<TextView> (Resource.Id.tvE24);
				tvEdges[2,5] = FindViewById<TextView> (Resource.Id.tvE25);
				tvEdges[2,6] = FindViewById<TextView> (Resource.Id.tvE26);
				tvEdges[2,7] = FindViewById<TextView> (Resource.Id.tvE27);
				tvEdges[2,8] = FindViewById<TextView> (Resource.Id.tvE28);
				tvEdges[2,9] = FindViewById<TextView> (Resource.Id.tvE29);
				//3
				tvEdges[3,0] = FindViewById<TextView> (Resource.Id.tvE30);
				tvEdges[3,1] = FindViewById<TextView> (Resource.Id.tvE31);
				tvEdges[3,2] = FindViewById<TextView> (Resource.Id.tvE32);
				tvEdges[3,4] = FindViewById<TextView> (Resource.Id.tvE34);
				tvEdges[3,5] = FindViewById<TextView> (Resource.Id.tvE35);
				tvEdges[3,6] = FindViewById<TextView> (Resource.Id.tvE36);
				tvEdges[3,7] = FindViewById<TextView> (Resource.Id.tvE37);
				tvEdges[3,8] = FindViewById<TextView> (Resource.Id.tvE38);
				tvEdges[3,9] = FindViewById<TextView> (Resource.Id.tvE39);
				//4
				tvEdges[4,0] = FindViewById<TextView> (Resource.Id.tvE40);
				tvEdges[4,1] = FindViewById<TextView> (Resource.Id.tvE41);
				tvEdges[4,2] = FindViewById<TextView> (Resource.Id.tvE42);
				tvEdges[4,3] = FindViewById<TextView> (Resource.Id.tvE43);
				tvEdges[4,5] = FindViewById<TextView> (Resource.Id.tvE45);
				tvEdges[4,6] = FindViewById<TextView> (Resource.Id.tvE46);
				tvEdges[4,7] = FindViewById<TextView> (Resource.Id.tvE47);
				tvEdges[4,8] = FindViewById<TextView> (Resource.Id.tvE48);
				tvEdges[4,9] = FindViewById<TextView> (Resource.Id.tvE49);
				//5
				tvEdges[5,0] = FindViewById<TextView> (Resource.Id.tvE50);
				tvEdges[5,1] = FindViewById<TextView> (Resource.Id.tvE51);
				tvEdges[5,2] = FindViewById<TextView> (Resource.Id.tvE52);
				tvEdges[5,3] = FindViewById<TextView> (Resource.Id.tvE53);
				tvEdges[5,4] = FindViewById<TextView> (Resource.Id.tvE54);
				tvEdges[5,6] = FindViewById<TextView> (Resource.Id.tvE56);
				tvEdges[5,7] = FindViewById<TextView> (Resource.Id.tvE57);
				tvEdges[5,8] = FindViewById<TextView> (Resource.Id.tvE58);
				tvEdges[5,9] = FindViewById<TextView> (Resource.Id.tvE59);
				//6
				tvEdges[6,0] = FindViewById<TextView> (Resource.Id.tvE60);
				tvEdges[6,1] = FindViewById<TextView> (Resource.Id.tvE61);
				tvEdges[6,2] = FindViewById<TextView> (Resource.Id.tvE62);
				tvEdges[6,3] = FindViewById<TextView> (Resource.Id.tvE63);
				tvEdges[6,4] = FindViewById<TextView> (Resource.Id.tvE64);
				tvEdges[6,5] = FindViewById<TextView> (Resource.Id.tvE65);
				tvEdges[6,7] = FindViewById<TextView> (Resource.Id.tvE67);
				tvEdges[6,8] = FindViewById<TextView> (Resource.Id.tvE68);
				tvEdges[6,9] = FindViewById<TextView> (Resource.Id.tvE69);
				//7
				tvEdges[7,0] = FindViewById<TextView> (Resource.Id.tvE70);
				tvEdges[7,1] = FindViewById<TextView> (Resource.Id.tvE71);
				tvEdges[7,2] = FindViewById<TextView> (Resource.Id.tvE72);
				tvEdges[7,3] = FindViewById<TextView> (Resource.Id.tvE73);
				tvEdges[7,4] = FindViewById<TextView> (Resource.Id.tvE74);
				tvEdges[7,5] = FindViewById<TextView> (Resource.Id.tvE75);
				tvEdges[7,6] = FindViewById<TextView> (Resource.Id.tvE76);
				tvEdges[7,8] = FindViewById<TextView> (Resource.Id.tvE78);
				tvEdges[7,9] = FindViewById<TextView> (Resource.Id.tvE79);
				//8
				tvEdges[8,0] = FindViewById<TextView> (Resource.Id.tvE80);
				tvEdges[8,1] = FindViewById<TextView> (Resource.Id.tvE81);
				tvEdges[8,2] = FindViewById<TextView> (Resource.Id.tvE82);
				tvEdges[8,3] = FindViewById<TextView> (Resource.Id.tvE83);
				tvEdges[8,4] = FindViewById<TextView> (Resource.Id.tvE84);
				tvEdges[8,5] = FindViewById<TextView> (Resource.Id.tvE85);
				tvEdges[8,6] = FindViewById<TextView> (Resource.Id.tvE86);
				tvEdges[8,7] = FindViewById<TextView> (Resource.Id.tvE87);
				tvEdges[8,9] = FindViewById<TextView> (Resource.Id.tvE89);
				//9
				tvEdges[9,0] = FindViewById<TextView> (Resource.Id.tvE90);
				tvEdges[9,1] = FindViewById<TextView> (Resource.Id.tvE91);
				tvEdges[9,2] = FindViewById<TextView> (Resource.Id.tvE92);
				tvEdges[9,3] = FindViewById<TextView> (Resource.Id.tvE93);
				tvEdges[9,4] = FindViewById<TextView> (Resource.Id.tvE94);
				tvEdges[9,5] = FindViewById<TextView> (Resource.Id.tvE95);
				tvEdges[9,6] = FindViewById<TextView> (Resource.Id.tvE96);
				tvEdges[9,7] = FindViewById<TextView> (Resource.Id.tvE97);
				tvEdges[9,8] = FindViewById<TextView> (Resource.Id.tvE98);
			}else{

				//0
				tvEdges[0,1] = FindViewById<TextView> (Resource.Id.tvE01);
				tvEdges[0,2] = FindViewById<TextView> (Resource.Id.tvE02);
				tvEdges[0,3] = FindViewById<TextView> (Resource.Id.tvE03);
				tvEdges[0,4] = FindViewById<TextView> (Resource.Id.tvE04);
				tvEdges[0,5] = FindViewById<TextView> (Resource.Id.tvE05);
				tvEdges[0,6] = FindViewById<TextView> (Resource.Id.tvE06);
				tvEdges[0,7] = FindViewById<TextView> (Resource.Id.tvE07);
				tvEdges[0,8] = FindViewById<TextView> (Resource.Id.tvE08);
				tvEdges[0,9] = FindViewById<TextView> (Resource.Id.tvE09);
				//1
				tvEdges[1,0] = FindViewById<TextView> (Resource.Id.tvE01);
				tvEdges[1,2] = FindViewById<TextView> (Resource.Id.tvE12);
				tvEdges[1,3] = FindViewById<TextView> (Resource.Id.tvE13);
				tvEdges[1,4] = FindViewById<TextView> (Resource.Id.tvE14);
				tvEdges[1,5] = FindViewById<TextView> (Resource.Id.tvE15);
				tvEdges[1,6] = FindViewById<TextView> (Resource.Id.tvE16);
				tvEdges[1,7] = FindViewById<TextView> (Resource.Id.tvE17);
				tvEdges[1,8] = FindViewById<TextView> (Resource.Id.tvE18);
				tvEdges[1,9] = FindViewById<TextView> (Resource.Id.tvE19);
				//2
				tvEdges[2,0] = FindViewById<TextView> (Resource.Id.tvE02);
				tvEdges[2,1] = FindViewById<TextView> (Resource.Id.tvE12);
				tvEdges[2,3] = FindViewById<TextView> (Resource.Id.tvE23);
				tvEdges[2,4] = FindViewById<TextView> (Resource.Id.tvE24);
				tvEdges[2,5] = FindViewById<TextView> (Resource.Id.tvE25);
				tvEdges[2,6] = FindViewById<TextView> (Resource.Id.tvE26);
				tvEdges[2,7] = FindViewById<TextView> (Resource.Id.tvE27);
				tvEdges[2,8] = FindViewById<TextView> (Resource.Id.tvE28);
				tvEdges[2,9] = FindViewById<TextView> (Resource.Id.tvE29);
				//3
				tvEdges[3,0] = FindViewById<TextView> (Resource.Id.tvE03);
				tvEdges[3,1] = FindViewById<TextView> (Resource.Id.tvE13);
				tvEdges[3,2] = FindViewById<TextView> (Resource.Id.tvE23);
				tvEdges[3,4] = FindViewById<TextView> (Resource.Id.tvE34);
				tvEdges[3,5] = FindViewById<TextView> (Resource.Id.tvE35);
				tvEdges[3,6] = FindViewById<TextView> (Resource.Id.tvE36);
				tvEdges[3,7] = FindViewById<TextView> (Resource.Id.tvE37);
				tvEdges[3,8] = FindViewById<TextView> (Resource.Id.tvE38);
				tvEdges[3,9] = FindViewById<TextView> (Resource.Id.tvE39);
				//4
				tvEdges[4,0] = FindViewById<TextView> (Resource.Id.tvE04);
				tvEdges[4,1] = FindViewById<TextView> (Resource.Id.tvE14);
				tvEdges[4,2] = FindViewById<TextView> (Resource.Id.tvE24);
				tvEdges[4,3] = FindViewById<TextView> (Resource.Id.tvE34);
				tvEdges[4,5] = FindViewById<TextView> (Resource.Id.tvE45);
				tvEdges[4,6] = FindViewById<TextView> (Resource.Id.tvE46);
				tvEdges[4,7] = FindViewById<TextView> (Resource.Id.tvE47);
				tvEdges[4,8] = FindViewById<TextView> (Resource.Id.tvE48);
				tvEdges[4,9] = FindViewById<TextView> (Resource.Id.tvE49);
				//5
				tvEdges[5,0] = FindViewById<TextView> (Resource.Id.tvE05);
				tvEdges[5,1] = FindViewById<TextView> (Resource.Id.tvE15);
				tvEdges[5,2] = FindViewById<TextView> (Resource.Id.tvE25);
				tvEdges[5,3] = FindViewById<TextView> (Resource.Id.tvE35);
				tvEdges[5,4] = FindViewById<TextView> (Resource.Id.tvE45);
				tvEdges[5,6] = FindViewById<TextView> (Resource.Id.tvE56);
				tvEdges[5,7] = FindViewById<TextView> (Resource.Id.tvE57);
				tvEdges[5,8] = FindViewById<TextView> (Resource.Id.tvE58);
				tvEdges[5,9] = FindViewById<TextView> (Resource.Id.tvE59);
				//6
				tvEdges[6,0] = FindViewById<TextView> (Resource.Id.tvE06);
				tvEdges[6,1] = FindViewById<TextView> (Resource.Id.tvE16);
				tvEdges[6,2] = FindViewById<TextView> (Resource.Id.tvE26);
				tvEdges[6,3] = FindViewById<TextView> (Resource.Id.tvE36);
				tvEdges[6,4] = FindViewById<TextView> (Resource.Id.tvE46);
				tvEdges[6,5] = FindViewById<TextView> (Resource.Id.tvE56);
				tvEdges[6,7] = FindViewById<TextView> (Resource.Id.tvE67);
				tvEdges[6,8] = FindViewById<TextView> (Resource.Id.tvE68);
				tvEdges[6,9] = FindViewById<TextView> (Resource.Id.tvE69);
				//7
				tvEdges[7,0] = FindViewById<TextView> (Resource.Id.tvE07);
				tvEdges[7,1] = FindViewById<TextView> (Resource.Id.tvE17);
				tvEdges[7,2] = FindViewById<TextView> (Resource.Id.tvE27);
				tvEdges[7,3] = FindViewById<TextView> (Resource.Id.tvE37);
				tvEdges[7,4] = FindViewById<TextView> (Resource.Id.tvE47);
				tvEdges[7,5] = FindViewById<TextView> (Resource.Id.tvE57);
				tvEdges[7,6] = FindViewById<TextView> (Resource.Id.tvE67);
				tvEdges[7,8] = FindViewById<TextView> (Resource.Id.tvE78);
				tvEdges[7,9] = FindViewById<TextView> (Resource.Id.tvE79);
				//8
				tvEdges[8,0] = FindViewById<TextView> (Resource.Id.tvE08);
				tvEdges[8,1] = FindViewById<TextView> (Resource.Id.tvE18);
				tvEdges[8,2] = FindViewById<TextView> (Resource.Id.tvE28);
				tvEdges[8,3] = FindViewById<TextView> (Resource.Id.tvE38);
				tvEdges[8,4] = FindViewById<TextView> (Resource.Id.tvE48);
				tvEdges[8,5] = FindViewById<TextView> (Resource.Id.tvE58);
				tvEdges[8,6] = FindViewById<TextView> (Resource.Id.tvE68);
				tvEdges[8,7] = FindViewById<TextView> (Resource.Id.tvE78);
				tvEdges[8,9] = FindViewById<TextView> (Resource.Id.tvE89);
				//9
				tvEdges[9,0] = FindViewById<TextView> (Resource.Id.tvE09);
				tvEdges[9,1] = FindViewById<TextView> (Resource.Id.tvE19);
				tvEdges[9,2] = FindViewById<TextView> (Resource.Id.tvE29);
				tvEdges[9,3] = FindViewById<TextView> (Resource.Id.tvE39);
				tvEdges[9,4] = FindViewById<TextView> (Resource.Id.tvE49);
				tvEdges[9,5] = FindViewById<TextView> (Resource.Id.tvE59);
				tvEdges[9,6] = FindViewById<TextView> (Resource.Id.tvE69);
				tvEdges[9,7] = FindViewById<TextView> (Resource.Id.tvE79);
				tvEdges[9,8] = FindViewById<TextView> (Resource.Id.tvE89);

				//Setting background image
				//0
				tvEdges[0,1].SetBackgroundResource(Resource.Drawable.und01);
				tvEdges[0,2].SetBackgroundResource(Resource.Drawable.und02);
				tvEdges[0,3].SetBackgroundResource(Resource.Drawable.und03);
				tvEdges[0,4].SetBackgroundResource(Resource.Drawable.und04);
				tvEdges[0,5].SetBackgroundResource(Resource.Drawable.und05);
				tvEdges[0,6].SetBackgroundResource(Resource.Drawable.und06);
				tvEdges[0,7].SetBackgroundResource(Resource.Drawable.und07);
				tvEdges[0,8].SetBackgroundResource(Resource.Drawable.und08);
				tvEdges[0,9].SetBackgroundResource(Resource.Drawable.und09);
				//1
				tvEdges[1,2].SetBackgroundResource(Resource.Drawable.und12);
				tvEdges[1,3].SetBackgroundResource(Resource.Drawable.und13);
				tvEdges[1,4].SetBackgroundResource(Resource.Drawable.und14);
				tvEdges[1,5].SetBackgroundResource(Resource.Drawable.und15);
				tvEdges[1,6].SetBackgroundResource(Resource.Drawable.und16);
				tvEdges[1,7].SetBackgroundResource(Resource.Drawable.und17);
				tvEdges[1,8].SetBackgroundResource(Resource.Drawable.und18);
				tvEdges[1,9].SetBackgroundResource(Resource.Drawable.und19);
				//2
				tvEdges[2,3].SetBackgroundResource(Resource.Drawable.und23);
				tvEdges[2,4].SetBackgroundResource(Resource.Drawable.und24);
				tvEdges[2,5].SetBackgroundResource(Resource.Drawable.und25);
				tvEdges[2,6].SetBackgroundResource(Resource.Drawable.und26);
				tvEdges[2,7].SetBackgroundResource(Resource.Drawable.und27);
				tvEdges[2,8].SetBackgroundResource(Resource.Drawable.und28);
				tvEdges[2,9].SetBackgroundResource(Resource.Drawable.und29);
				//3
				tvEdges[3,4].SetBackgroundResource(Resource.Drawable.und34);
				tvEdges[3,5].SetBackgroundResource(Resource.Drawable.und35);
				tvEdges[3,6].SetBackgroundResource(Resource.Drawable.und36);
				tvEdges[3,7].SetBackgroundResource(Resource.Drawable.und37);
				tvEdges[3,8].SetBackgroundResource(Resource.Drawable.und38);
				tvEdges[3,9].SetBackgroundResource(Resource.Drawable.und39);
				//4
				tvEdges[4,5].SetBackgroundResource(Resource.Drawable.und45);
				tvEdges[4,6].SetBackgroundResource(Resource.Drawable.und46);
				tvEdges[4,7].SetBackgroundResource(Resource.Drawable.und47);
				tvEdges[4,8].SetBackgroundResource(Resource.Drawable.und48);
				tvEdges[4,9].SetBackgroundResource(Resource.Drawable.und49);
				//5
				tvEdges[5,6].SetBackgroundResource(Resource.Drawable.und56);
				tvEdges[5,7].SetBackgroundResource(Resource.Drawable.und57);
				tvEdges[5,8].SetBackgroundResource(Resource.Drawable.und58);
				tvEdges[5,9].SetBackgroundResource(Resource.Drawable.und59);
				//6
				tvEdges[6,7].SetBackgroundResource(Resource.Drawable.und67);
				tvEdges[6,8].SetBackgroundResource(Resource.Drawable.und68);
				tvEdges[6,9].SetBackgroundResource(Resource.Drawable.und69);
				//7
				tvEdges[7,8].SetBackgroundResource(Resource.Drawable.und78);
				tvEdges[7,9].SetBackgroundResource(Resource.Drawable.und79);
				//8
				tvEdges[8,9].SetBackgroundResource(Resource.Drawable.und89);

			}
		}

		public void displayGraph(){
			List<Vertex> vertices;
			Graph graphAux = new Graph();

			switch (algorithm){
			case 2:
				graphAux = graph;
				bDescription.Enabled = false;
				break;
			case 3:
				graphAux = graph.kruskal();
				break;
			case 4:
				graphAux = graph.dijkstra(start,end);
				break;
			case 5:
				graphAux = graph.breadthFirstSearch(start);
				break;
			case 6:
				graphAux = graph.depthFirstSearch(start);
				break;
			case 8:
				graphAux = graph.transitiveClosure();
				break;
			}
			vertices = graphAux.getVertices();

			for(int i=0;i<vertices.Count;i++){
				tvVertices[i].Text = vertices[i].getName();
				tvVertices[i].Visibility = ViewStates.Visible;
			}	

			for(int i=0;i<vertices.Count;i++) {
				for (int j = 0; j < vertices.Count; j++) {
					Edge edge = graphAux.findEdge(vertices[i], vertices[j]);
					if (edge != null) {

						tvEdges[i,j].Text = (edge.getWeight() +""); // using ' +"" ' as a easy form of conversion from int to String
						tvEdges[i,j].Visibility = ViewStates.Visible;
					}
				}
			}

			tvGraph.Text = graphAux.printGraph();

		}

		public override void OnBackPressed() {
			Finish();
		}

	}
}

