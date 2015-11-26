using System;
using System.Collections.Generic;


namespace GraphApp.Xamarin
{
	public class Graph
	{
		private List<Edge> edges = new List<Edge>();
		private List<Vertex> vertices = new List<Vertex>();
		private bool cycle = false;
		private bool directed = false;
		private bool connected = false;

		public void clearGraph() {
			edges.Clear();
			vertices.Clear();
			cycle = false;
			directed = false;
			connected = false;
		}

		public bool isConnected() {
			return connected;
		}

		public bool isDirected() {
			return directed;
		}

		public void setDirected(bool d) {
			directed = d;
		}

		public List<Vertex> getVertices() {
			return vertices;
		}

		public String printGraph() {
			String stuart = "";

			foreach (Edge edge in getEdges()){
				stuart = stuart + edge.getStart().getName()
					+ edge.getEnd().getName() + " - "
					+ edge.getWeight() + " | ";
				edge.getStart().setVisited(true);
				edge.getEnd().setVisited(true);
			}
			foreach (Vertex v in vertices){
				if(!v.isVisited()){
					stuart = stuart + v.getName()+ " | ";
					v.setVisited(true);
				}
			}
			stuart = stuart + "\n";

			if(directed)
				stuart = stuart + TextsEN.getDescriptionByPosition(7) + "\n";
			else
				stuart = stuart + TextsEN.getDescriptionByPosition(8) + "\n";
			if(cycle)
				stuart = stuart + TextsEN.getDescriptionByPosition(9) + "\n";
			else
				stuart = stuart + TextsEN.getDescriptionByPosition(10) + "\n";
			cleanVisitedVertex();

			return stuart;
		}

		public String printVertices() {
			String stuart = "";

			stuart = stuart + "{";
			for (int i = 0; i < vertices.Count; i++) {
				stuart = stuart + vertices[i];
				if (i < vertices.Count - 1)
					stuart = stuart + " ,";
			}
			stuart = stuart + "}";

			return stuart;
		}

		public void cleanVisitedVertex() {
			foreach (Vertex v in getVertices())
				v.setVisited(false);
		}

		public void cleanVisitedEdge() {
			foreach (Edge e in getEdges())
				e.setVisited(false);
		}

		public List<Edge> getEdges() {
			return edges;
		}
	}

}

