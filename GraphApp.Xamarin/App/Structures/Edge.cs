using System;

namespace GraphApp.Xamarin
{
	
	public class Edge
	{
		private int weight;
		private Vertex start;
		private Vertex end;
		private bool visited = false;

		public Edge (int weight, Vertex start, Vertex end)
		{
			this.setWeight(weight);
			this.setStart(start);
			this.setEnd(end);
		}
		public bool isVisited() {
			return visited;
		}

		public void setVisited(bool visited) {
			this.visited = visited;
		}

		public int getWeight() {
			return weight;
		}

		public void setWeight(int weight) {
			this.weight = weight;
		}

		public Vertex getStart() {
			return start;
		}

		public void setStart(Vertex start) {

			this.start = start;
		}

		public Vertex getEnd() {
			return end;
		}

		public void setEnd(Vertex end) {

			this.end = end;
		}

		public override String ToString() {
			String s = " ";
			s+= this.getStart().getName() + this.getEnd().getName();
			return s;
		}
	}
}

