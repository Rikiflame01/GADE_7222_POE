using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ADTGraph : MonoBehaviour
{
    public Nodes[] nodes;

    LinkedListOne<GraphNode> nodeList = new LinkedListOne<GraphNode>();
    ArrayList nodeList1 = new ArrayList();

    public List<GraphNode> debugList = new List<GraphNode>();

    private void Awake()
    {
        //Adding nodes with adjacency list
        for (int i = 0; i < nodes.Length; i++)
        {
            nodeList.InsertAtEnd(new GraphNode(nodes[i].name, i, nodes[i].nodeTransform, nodes[i].diverges));
            Debug.Log(nodeList.GetAtIndex(i).nodeTransform.name);
        }

        Graph graph = new Graph(nodeList);

        //Add the edges according to diagram
        graph.AddDirectedEdge(0, 1);
        graph.AddDirectedEdge(1, 2);
        graph.AddDirectedEdge(1, 3);
        graph.AddDirectedEdge(2, 4);
        graph.AddDirectedEdge(3, 4);
        graph.AddDirectedEdge(4, 5);
        graph.AddDirectedEdge(5, 6);
        graph.AddDirectedEdge(5, 7);
        graph.AddDirectedEdge(6, 8);
        graph.AddDirectedEdge(7, 8);
        graph.AddDirectedEdge(8, 0);
        Debug.Log(graph.ToString());


    }
}

public class Graph
{
    //List<GraphNode> nodeList = new List<GraphNode>();
    ArrayList nodeList1 = new ArrayList();
    LinkedListOne<GraphNode> nodeList = new LinkedListOne<GraphNode>();

    public Graph(LinkedListOne<GraphNode> nodeList)
    {
        this.nodeList = nodeList;
    }

    public void AddDirectedEdge(int i, int j)
    {         
        GraphNode first = nodeList.GetAtIndex(i);
        GraphNode second = nodeList.GetAtIndex(j);
        //Directed edge
        first.neighbors.InsertAtEnd(second);
    }

    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        for(int i = 0; i < nodeList.Size(); i++)
        {
            s.Append(nodeList.GetAtIndex(i).name + ": ");
            for(int j = 0; j < nodeList.GetAtIndex(i).neighbors.Size(); j++)
            {
                if( j == nodeList.GetAtIndex(i).neighbors.Size() - 1)
                {
                    s.Append(nodeList.GetAtIndex(i).neighbors.GetAtIndex(j).name);
                }
                else
                {
                    s.Append(nodeList.GetAtIndex(i).neighbors.GetAtIndex(j).name + " -> ");
                }   
            }
            s.Append("\n");
        }
        return s.ToString();
    }

    #region Adjacency List BFS
    //BFS Internal
    //void BFSVisitForList(GraphNode node)
    //{
    //    LinkedList<GraphNode> queue = new LinkedList<GraphNode>();
    //    queue.AddFirst(node);
    //    while(queue.Count != 0)
    //    {
    //        GraphNode currentNode = queue.First.Value;
    //        queue.RemoveFirst();
    //        currentNode.isVisited = true;
    //        Debug.Log(currentNode.name + " ");

    //        foreach(GraphNode neighbour in currentNode.neighbors)
    //        {
    //            if(!neighbour.isVisited)
    //            {
    //                queue.AddLast(neighbour);
    //                neighbour.isVisited = true;
    //            }
    //        }
    //    }
    //}

    //public void BFSForList()
    //{
    //    foreach(GraphNode node in nodeList1)
    //    {
    //        if (!node.isVisited)
    //        {
    //            BFSVisitForList(node);
    //        }
    //    }
    //}
    #endregion

}

public class GraphNode
{
    public string name;
    public Transform nodeTransform;
    public int index;
    public bool hasNeighbours = false;

    public LinkedListOne<GraphNode> neighbors = new LinkedListOne<GraphNode>();

    public GraphNode(string name, int index, Transform nodeTransform, bool hasNeigbours)
    {
        this.name = name;
        this.index = index;
        this.nodeTransform = nodeTransform;
        this.hasNeighbours = hasNeigbours;
    }

}
[System.Serializable]
public struct Nodes
{
    public string name;
    public Transform nodeTransform;
    public bool diverges;
}

