using System;
using System.Collections.Generic;

namespace GraphApp.Xamarin
{
	public class Vertex : IComparable<Vertex>
	{
		private String name;
		private int distance;
		private Vertex previous;
		private List<Edge> incidentnts = new List<Edge>();
		private List<Vertex> neighbors = new List<Vertex>();
		private bool visited = false;
		private String color = "white";

		public Vertex(String name){
			this.setName(name);
		}

		public String getColor() {
			return color;
		}

		public void setColor(String color) {
			this.color = color;
		}

		public String getName() {
			return name;
		}

		public void setName(String name) {
			this.name = name;
		}

		public int getDistance() {
			return distance;
		}

		public void setDistance(int distance) {
			this.distance = distance;
		}

		public Vertex getPrevious() {
			return previous;
		}

		public void setPrevious(Vertex previous) {
			this.previous = previous;
		}

		public bool isVisited() {
			return visited;
		}

		public void setVisited(bool visited) {
			this.visited = visited;
		}

		public List<Edge> getIncidents() {
			return incidentnts;
		}

		public void addIncidents(Edge incident) {
			this.incidentnts.Add(incident);

			//adicionando neighbors a lista
			if ( (incident.getStart().getName().Equals(this.getName())) &&
				(!this.isNeighbor(incident.getEnd())) ){

				this.addNeighbors(incident.getEnd());

			}else if ( (incident.getEnd().getName().Equals(this.getName())) &&
				(!this.isNeighbor(incident.getStart())) ){

				this.addNeighbors(incident.getStart());
			}
		}

		public void addNeighbors(Vertex neighbor) {
			this.neighbors.Add(neighbor);
		}

		public List<Vertex> getNeighbors() {
			return neighbors;
		}

		public bool isNeighbor(Vertex neighbor){
			int i;

			for (i=0; i<this.neighbors.Count ; i++)
				if (this.neighbors[i].getName().Equals(neighbor.getName()))
					return true;

			return false;
		}

		public override String ToString() {
			String s = " ";
			s+= this.getName();
			return s;
		}

		public int CompareTo(Vertex vertex) {

			if(this.getDistance() < vertex.getDistance())
				return -1;
			else if(this.getDistance() == vertex.getDistance())
				return 0;

			return 1;
		}
	}
}

