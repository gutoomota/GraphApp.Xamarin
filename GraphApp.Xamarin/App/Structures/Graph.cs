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

		public int addEdge(int weight, String start, String end) {
			int i, j, k;

			if (start.Equals(end))
				return -2;
			if (findEdge(new Vertex(start), new Vertex(end))!=null) //Edge already exists
				return -3;
			if (weight == 0)
				return -4;

			i=vertexLocation(start);
			j=vertexLocation(end);
			k = vertices.Count;

			//Checking if the Vertices can be inserted (the maximum number of vertices is 10)
			if(vertices.Count>=9){
				if (i==vertices.Count)
					k++;
				if (j==vertices.Count)
					k++;
				if (k>10)
					return -1;
			}

			// adding vertices and getting the position of each one
			if (i==k)
				i = addVertex(start);
			if (j==k)
				j = addVertex(end);

			// add edge in the list
			Edge a = new Edge(weight, vertices[i], vertices[j]);

			if (!cycle)
				hasCycle(a);
			
			edges.Add(a);
			k = edges.Count;

			// add edge in the list of incident edges of each vertex
			vertices [i].addIncidents (edges [k - 1]);
			vertices [j].addIncidents (edges [k - 1]);

			if (!connected)
				setConnected();

			return (edges.Count -1);
		}

		public bool setConnected(){
			String start = vertices[0].getName();

			List<Vertex> breadthTree = new List<Vertex>();

			foreach (Vertex v in vertices) {
				v.setColor("white");
			}

			Vertex current = findVertex(start);
			current.setColor("grey");

			List<Vertex> queue = new List<Vertex>();
			queue.Add(current);

			while (queue.Count > 0) {
				current = queue [0];
				queue.Remove(current);
				current.setColor("black");

				foreach (Vertex neighbor in current.getNeighbors()) {
					Edge edge = findEdge(current, neighbor);
					if (neighbor.getColor().Equals("white") &&
						(edge != null) ) {

						neighbor.setColor("grey");
						queue.Add(neighbor);
						breadthTree.Add(current);
						breadthTree.Add(neighbor);
					}
				}
			}

			if(breadthTree.Count<vertices.Count)
				return false;

			connected = true;
			return true;
		}

		// add a vertex returning its position or '-1' if the insertion was not possible
		public int addVertex(String nome) {
			int i = vertexLocation(nome);

			//Checking if the Vertex already exist
			if(i!=vertices.Count)
				return -2;
			//Checking if the Vertex can be inserted (the maximum number of vertices is 10)
			if (vertices.Count==10)
				return -1;

			if (i == vertices.Count) {
				vertices.Add(new Vertex(nome));
				connected = false;
				return (vertices.Count - 1);
			}

			return i;

		}

		// returns the location of a vertex in the list
		public int vertexLocation(String nome) {
			int i;

			for (i = 0; i < vertices.Count; i++)
				if (vertices[i].getName().Equals(nome))
					return i;

			// if it is not found, returns the list's size
			return vertices.Count;

		}

		public Vertex findVertex(String name) {
			return vertices[vertexLocation(name)];
		}

		public Edge findEdge(Vertex vet1, Vertex vet2) {
			if (!vet1.Equals(vet2)) {
				if (directed) {
					foreach (Edge e in edges)
						if (((e.getStart().getName().Equals(vet1.getName())) &&
							(e.getEnd().getName().Equals(vet2.getName()))))
							return e;
				} else {
					foreach (Edge e in edges)
						if (((e.getStart().getName().Equals(vet1.getName())) &&
							(e.getEnd().getName().Equals(vet2.getName()))) ||
							((e.getStart().getName().Equals(vet2.getName())) &&
								(e.getEnd().getName().Equals(vet1.getName()))))
							return e;
				}
			}
			return null;

		}

		public void cleanPreviousVertex() {
			foreach (Vertex v in getVertices())
				v.setPrevious(null);
		}

		public void cleanDistances() {
			foreach (Vertex v in getVertices())
				v.setDistance(0);
		}

		public List<Edge> edgeListCreator (List<Vertex> pathVertex){
			List<Edge> pathEdge = new List<Edge>();
			Edge edge;

			for (int i = 0; i < pathVertex.Count - 1; i++) {
				edge = findEdge(pathVertex[i],
					pathVertex[i + 1]);
				pathEdge.Add(edge);
			}

			return pathEdge;
		}

		public Graph graphCreator (List<Edge> pathEdge){
			Graph graph = new Graph();
			graph.setDirected(directed);

			foreach (Edge e in pathEdge)
				graph.addEdge(e.getWeight(), e.getStart().getName(), e.getEnd().getName());


			return graph;
		}

		public void randomGraphCreator (){
			//1 - add vertices
			//2 - add edges
			//2.1 - pesos serão num aleatórios
			//2.2 - a existencia de uma edge entre vertices depende da paridade de um num aleatório

			//Adding Vertices
			char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
			Random rn = new Random();

			// creates a number between 3 and 10
			int b=rn.Next(3,11);
			for(int i=0;i<= b ; i++){
				addVertex(alphabet[i] + "");
			}
			//Adding Edges

			foreach(Vertex v1 in vertices)
				foreach(Vertex v2 in vertices)
					if (!v1.getName().Equals(v2.getName())){
						Edge edge = findEdge(v1, v2);
						//if the random value is even and the edge doesn't exist, a edge will be added
						if ((rn.Next(3,11) %2 == 0) && (edge==null)){

							addEdge(rn.Next(3,11), v1.getName(), v2.getName());
						}
					}
		}

		// ----------------------KRUSKAL--------------------------------------------

		public Graph kruskal() {
			Edge edge;
			Graph result = new Graph();
			result.setDirected(directed);
			result.addVertex(this.getVertices()[0].getName()); //adding the first vertex

			for (int i = 0; i < getEdges().Count; i++) {
				// look for the unvisited edge with the lower weight
				edge = lowerWeight();
				String start = edge.getStart().getName();
				String end = edge.getEnd().getName();
				int size = result.getVertices().Count;
				// if the edge do not create a cycle and one of the vertices is not in the result graph, it is added to the Kruskal's graph
				// Tree (or forest)
				if ((!result.hasCycle(edge)) &&
					((result.vertexLocation(start)==size)||(result.vertexLocation(end)==size)||(result.isConnected()!=isConnected()))){
					result.addEdge(edge.getWeight(), start, end);
				}
			}

			foreach (Vertex v in vertices){
				if(result.vertexLocation(v.getName())==result.getVertices().Count||!result.isConnected()){
					result.addVertex(v.getName());
				}
			}

			return result;
		}

		// look for the unvisited edge with the lower weight
		public Edge lowerWeight() {
			int j;

			for (j = 0; j < getEdges().Count; j++) {
				if ((getEdges()[j].isVisited() == false)) {
					getEdges()[j].setVisited(true);

					for (int i = (j + 1); i < getEdges().Count; i++) {

						if ((getEdges()[i].isVisited() == false)
							&& (getEdges()[j].getWeight() > getEdges()[i].getWeight())) {

							getEdges()[j].setVisited(false);
							j = i;
							getEdges()[j].setVisited(true);
						}
					}

					break;
				}
			}

			return getEdges()[j];
		}

		// method that returns whether a certain new edge can create a cycle or not
		// in the currentVertex graph
		public bool hasCycle(Edge edge) {

			String start = edge.getStart().getName();
			String end = edge.getEnd().getName();

			for (int i = 0; i < getEdges().Count; i++) {

				if (isDirected()){

					foreach (Edge edge2 in getEdges()) {

						if (edge != edge2) {

							if (end.Equals(edge2.getStart().getName())) {

								if (start.Equals(edge2.getEnd()
									.getName())) {
									cycle = true;
									return true;
								} else
									end = edge2.getEnd().getName();
							}
						}
					}
				}else{

					foreach (Edge edge2 in getEdges()) {

						if (edge != edge2) {

							if (end.Equals(edge2.getStart().getName())) {

								if (start.Equals(edge2.getEnd()
									.getName())) {
									cycle = true;
									return true;
								} else
									end = edge2.getEnd().getName();

							} else if (end.Equals(edge2.getEnd()
								.getName())) {

								if (start.Equals(edge2.getStart()
									.getName())) {
									cycle = true;
									return true;
								} else
									end = edge2.getStart().getName();
							}
						}
					}
				}

			}
			cycle = false;
			return false;
		}

		// ----------------------DIJKSTRA-------------------------------------------

		public Graph dijkstra(String start, String end) {

			Vertex v1 = findVertex(start);
			Vertex v2 = findVertex(end);

			// List of Vertices of the found path
			List<Vertex> pathVertex = new List<Vertex>();

			// Vertex that is being verified in the moment
			Vertex currentVertex;

			// Edge between the Vertices currentVertex and neighbor
			Edge currentEdge;

			// List of the unvisited vertices in the graph
			List<Vertex> unvisited = new List<Vertex>();

			// Setting initial distances
			foreach (Vertex v in getVertices()) {
				// Set the distance of currentVertex to zero, and all others to
				// 9999(infinite)
				if (v.getName().Equals(v1.getName()))
					v.setDistance(0);
				else
					v.setDistance(9999);
				// Insert all vertices in the unvisited list
				unvisited.Add(v);
			}
			// Organize the unvisited list by the order of distances (the distance 0
			// will be the first)
			unvisited.Sort();
			// Creating a loop to visit all vertices
			while (unvisited.Count!=0) {
				// Get the vertex with the lower distance (always the first of the
				// list unvisited)
				currentVertex = unvisited[0];
				/*
			 * For each unvisited neighbor of currentVertex, it is been done a
			 * calculation of its distance from the first vertex on the path.
			 * This calculation is done by the sum of all weights of the
			 * visited edges in the way from the first vertex to the current
			 * neighbor If this distance is lower than the distance of its
			 * neighbor, the distance is updated with the lower one.
			 */

				foreach (Vertex neighbor in currentVertex.getNeighbors()) {

					currentEdge = findEdge(currentVertex, neighbor);

					// Case the Graph is directed, it checks if the currentVertex is
					// the Start of the Edge,
					// if it is not, the edge cannot be inserted on the path.

					if ((!neighbor.isVisited()) && (currentEdge != null)) {

						// Comparing the distance of neighbor with the distance
						// added in the path till the currentVertex
						if (neighbor.getDistance() > (currentVertex.getDistance() + currentEdge.getWeight())) {

							neighbor.setDistance(currentVertex.getDistance()
								+ currentEdge.getWeight());
							neighbor.setPrevious(currentVertex);

							/*
						 * If neighbor is equal to v2, and there was a change of
						 * distance, the list with the previous lower path is
						 * erased, since it is a path lower than this one, that
						 * is created by the neighbor and its previous vertices
						 * till v1.
						 */
							if (neighbor == v2) {
								pathVertex.Clear();
								pathVertex.Add(neighbor);
								Vertex aux = neighbor;
								while (aux.getPrevious() != null) {
									pathVertex.Add(aux.getPrevious());
									aux = aux.getPrevious();
								}
								pathVertex.Sort();
							}
						}
					}

				}
				// Sets currentVertex as visited and takes it out of the unvisited
				// list
				currentVertex.setVisited(true);
				unvisited.Remove(currentVertex);

				unvisited.Sort();

			}
			// clean the value "Vertex.Distance" and "Vertex.Previous" of each
			// Vertex in the graph.
			cleanDistances();
			cleanPreviousVertex();

			// Fills the pathEdge list with the existent edges between the vertices
			// of the pathVertex list (which has the lower path)
			// Fills a graph with the edges from the pathEdge list to be returned by
			// the function

			return graphCreator(edgeListCreator(pathVertex));
		}

		// ------------------BREADTH-FIRST-SEARCH---------------------------------------

		public Graph breadthFirstSearch(String start) {

			List<Edge> breadthTree = new List<Edge>();

			foreach (Vertex v in vertices) {
				v.setColor("white");
			}

			Vertex current = findVertex(start);
			current.setColor("grey");

			List<Vertex> queue = new List<Vertex>();
			queue.Add(current);

			while (queue.Count > 0) {
				current = queue [0];
				queue.Remove(current);
				current.setColor("black");

				foreach (Vertex neighbor in current.getNeighbors()) {
					Edge edge = findEdge(current, neighbor);
					if (neighbor.getColor().Equals("white") &&
						(edge != null) ) {

						neighbor.setColor("grey");
						queue.Add(neighbor);
						breadthTree.Add(edge);
					}
				}
			}

			return graphCreator(breadthTree);
		}

		//------------------DEPTH-FIRST-SEARCH----------------------------------

		//Calls the recursive method of Depth-First Search and returns a Graph with the result
		public Graph depthFirstSearch(String start){

			List<Edge> depthTree = new List<Edge>();

			recursiveSearch(start);

			for (int i=0; i<edges.Count; i++){
				if(edges[i].isVisited())
					depthTree.Add(edges[i]);
			}

			return graphCreator(depthTree);
		}

		//Recursive method that return a bool as response by the search for a vertex and sets as visited all the vertices and edges on the way.
		public void recursiveSearch(String start){

			int startIndex = vertexLocation(start);
			Edge edge;
			Vertex vertex;

			vertices[startIndex].setVisited(true);


			foreach (Vertex v in vertices[startIndex].getNeighbors()){

				if (!v.isVisited()){
					//Finds the edge between the vertices start and v.
					vertex = vertices[startIndex];
					edge = findEdge(vertex, v);
					//Sets this edge as visited and keep searching recursively considering if the graph is directed
					if (edge != null){
						edge.setVisited(true);
						recursiveSearch(v.getName());
					}


				}
			}
		}

		//------------------TOPOLOGICAL-SORTING-----------------------------------

		public void depthFirstTS(Vertex v, List<Vertex> list) {

			Edge edge;
			v.setVisited(true);

			foreach (Vertex neighbor in v.getNeighbors()) {
				edge = findEdge(v, neighbor);
				if( !neighbor.isVisited() && (edge != null) )
					depthFirstTS(neighbor, list);
			}

			list.Add(v);
		}

		public List<Vertex> topologicalSort() {
			List<Vertex> order = new List<Vertex>();

			if(!directed){
				order.Add(new Vertex("Not directed"));
			}else if(cycle){
				order.Add(new Vertex("cycle"));
			}else{
				foreach(Vertex v in vertices){
					if(!v.isVisited())
						depthFirstTS(v, order);
				}
			}

			order.Reverse();
			return order;
		}

		//------------------TRANSITIVE-CLOSURE---------------------------------------

		public Graph transitiveClosure (){
			Graph graph;
			int[,] weightsFW = floydWarshall();
			int weight;

			graph = graphCreator(edges);

			foreach(Vertex v1 in getVertices()){
				recursiveSearch(v1.getName());
				foreach(Vertex v2 in getVertices()){
					Edge edge = graph.findEdge(v1, v2);
					if (v2.isVisited()
						&& !(v1.getName().Equals(v2.getName()))
						&& (edge==null) ){
						weight = weightsFW[vertexLocation(v1.getName()),vertexLocation(v2.getName())];
						graph.addEdge(weight, v1.getName(), v2.getName());
					}
				}
				//GUTOSSAURO DELICIA DA JAC

				cleanVisitedVertex();
			}

			foreach (Vertex v in vertices){
				if(graph.vertexLocation(v.getName())==graph.getVertices().Count){
					graph.addVertex(v.getName());
				}
			}
			return graph;
		}

		//------------------FLOYD-WARSHALL----------------------------------

		public int[,] createGraphMatrix(){
			int n = vertices.Count;
			int[,] matrix = new int[n,n];

			for(int i = 0; i < vertices.Count; i++){
				for(int j = 0; j < vertices.Count; j++){
					if(i==j){
						matrix[i,j] = 0;
					} else {
						Vertex v = vertices[i];
						Edge e = findEdge(v , vertices[j]);

						if(e != null){
							matrix[i,j] = e.getWeight();
						} else {
							matrix[i,j] = 999;//infinity
						}
					}
				}
			}

			return matrix;
		}

		public int[,] floydWarshall(){
			int n = vertices.Count;

			int[,] dist = createGraphMatrix();
			int[,] pred = new int[n,n];

			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					pred[i,j] = 9;

			for (int k = 0; k < n; k++) {
				for (int i = 0; i < n; i++) {
					for (int j = 0; j < n; j++) {
						if(dist[i,j] > dist[i,k] + dist[k,j]) {
							dist[i,j] = dist[i,k] + dist[k,j];
							pred[i,j] = k;
						}
					}
				}
			}
			return dist;
		}

		// -------------------------------------------------------------------------

	}

}

