using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ADTGraph : MonoBehaviour
{
    public Nodes[] nodes;

    LinkedListOne<GraphNode> nodeList = new LinkedListOne<GraphNode>();

    public List<GraphNode> debugList = new List<GraphNode>();

    private Graph graph;

    private void Awake()
    {
        //Adding nodes with adjacency list
        for (int i = 0; i < nodes.Length; i++)
        {
            nodeList.InsertAtEnd(new GraphNode(nodes[i].name, i, nodes[i].nodeTransform, nodes[i].diverges));
            Debug.Log(nodeList.GetAtIndex(i).nodeTransform.name);
        }

        graph = new Graph(nodeList);

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

    public Transform GetNextWaypoint(int index)
    {
        return graph.GetNextNode(index).nodeTransform;
    }
}

public class Graph
{
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

    public GraphNode GetNextNode(int index)
    {
        GraphNode currentNode = nodeList.GetAtIndex(index);

        if (currentNode.hasNeighbours)
        {
            int randomNum = Random.Range(1, 10);

            if (randomNum > 5)
            {
                return currentNode.neighbors.GetAtIndex(1);
            }
            else
            {
                return currentNode.neighbors.GetAtIndex(0);
            }
        }
        else
        {
            return nodeList.GetAtIndex(index + 1);
        }
        
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

