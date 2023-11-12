using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ADTGraph : MonoBehaviour
{
    List<GraphNode> nodeList = new List<GraphNode>();
    ArrayList nodeList1 = new ArrayList();

    private void Awake()
    {
        //Adding nodes with adjacency matrix
        nodeList.Add(new GraphNode("A", 0));
        nodeList.Add(new GraphNode("B", 1));
        nodeList.Add(new GraphNode("C", 2));
        nodeList.Add(new GraphNode("D", 3));
        nodeList.Add(new GraphNode("E", 4));

        Graph g = new Graph(nodeList);
        //Adding the links check in workbook
        g.addUndirectedEdge(0, 1);
        g.addUndirectedEdge(0, 2);
        g.addUndirectedEdge(0, 3);
        //B to E
        g.addUndirectedEdge(1,4);
        g.addUndirectedEdge(2,3);
        g.addUndirectedEdge(3,4);
        Debug.Log(g.ToString());

        //Adding nodes with adjacency list
        nodeList1.Add(new GraphNode("A", 0));
        nodeList1.Add(new GraphNode("B", 1));
        nodeList1.Add(new GraphNode("C", 2));
        nodeList1.Add(new GraphNode("D", 3));
        nodeList1.Add(new GraphNode("E", 4));

        Graph g2 = new Graph(nodeList1);
        g2.AddUndirectedEdge(0, 1);
        g2.AddUndirectedEdge(0, 2);
        g2.AddUndirectedEdge(0, 3);
        //B to E
        g2.AddUndirectedEdge(1, 4);
        g2.AddUndirectedEdge(2, 3);
        g2.AddUndirectedEdge(3, 4);
        Debug.Log(g2.toString());


    }
}

public class Graph
{
    List<GraphNode> nodeList = new List<GraphNode>();
    ArrayList nodeList1 = new ArrayList();

    public Graph(ArrayList nodeList1)
    {
        this.nodeList1 = nodeList1;
    }

    public void AddUndirectedEdge(int i, int j)
    {
        GraphNode first = (GraphNode)nodeList1[i];
        GraphNode second = (GraphNode)nodeList1[j];
        //Undriected edge
        first.neighbors.Add(second);
        second.neighbors.Add(first);
    }

    public void AddDirectedEdge(int i, int j)
    {         
        GraphNode first = (GraphNode)nodeList1[i];
        GraphNode second = (GraphNode)nodeList1[j];
        //Directed edge
        first.neighbors.Add(second);
    }


    int[,] adjacencyMatrix;

    public Graph(List<GraphNode> nodeList)
    {
        this.nodeList = nodeList;
        adjacencyMatrix = new int[nodeList.Count, nodeList.Count];
    }

    public void addUndirectedEdge(int i, int j)
    {
        adjacencyMatrix[i, j] = 1;
        adjacencyMatrix[j, i] = 1;
    }

    public void addDirectedEdge(int i, int j)
    {
        adjacencyMatrix[i, j] = 1;
    }

    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        s.Append(" ");
        for (int i = 0; i < nodeList.Count; i++)
        {
            s.Append(nodeList[i].name + " ");
        }
        s.AppendLine();
        for (int i = 0; i < nodeList.Count; i++)
        {
            s.Append(nodeList[i].name + " ");
            for (int j = 0; j < nodeList.Count; j++)
            {
                s.Append(adjacencyMatrix[i, j] + " ");
            }
            s.AppendLine();
        }
        return s.ToString();
    }

    public string toString()
    {
        //Print the adjacency list
        StringBuilder s = new StringBuilder();
        for(int i = 0; i < nodeList1.Count;i++)
        {
            s.Append(((GraphNode)nodeList1[i]).name + ": ");
            for(int j = 0; j < ((GraphNode)nodeList1[i]).neighbors.Count; j++)
            {
                s.AppendLine();
                if(j == ((GraphNode)nodeList1[i]).neighbors.Count - 1)
                {
                    s.Append(" " +((GraphNode)nodeList1[i]).neighbors[j]);
                    break;
                }
                s.Append(((GraphNode)nodeList1[i]).neighbors[j].ToString() + " ");
            }
        }
        return s.ToString();
    }
}

public class GraphNode
{
    public string name;
    public int index;

    public ArrayList neighbors = new ArrayList();

    public GraphNode(string name, int index)
    {
        this.name = name;
        this.index = index;
    }

}

