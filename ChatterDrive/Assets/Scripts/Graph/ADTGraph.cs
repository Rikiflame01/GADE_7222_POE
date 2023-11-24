using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ADTGraph : Singleton<ADTGraph>
{
    public Nodes[] nodes;

    LinkedListOne<GraphNode> nodeList = new LinkedListOne<GraphNode>();

    public List<GraphNode> debugList = new List<GraphNode>();

    private Graph graph;

    private int currentIndex = 0;

    private void Awake()
    {
        //Adding nodes with adjacency list
        for (int i = 0; i < nodes.Length; i++)
        {
            nodeList.InsertAtEnd(new GraphNode(nodes[i].name, i, nodes[i].nodeTransform, nodes[i].diverges));
        }

        graph = new Graph(nodeList);

        //Add the edges according to diagram
        graph.AddDirectedEdge(0, 1); //A, B, C, D, E, F, G, H, I
        graph.AddDirectedEdge(1, 2); //0, 1, 2, 3, 4, 5, 6, 7, 8
        graph.AddDirectedEdge(1, 3);
        graph.AddDirectedEdge(2, 4);
        graph.AddDirectedEdge(3, 4);
        graph.AddDirectedEdge(4, 5);
        graph.AddDirectedEdge(5, 6);
        graph.AddDirectedEdge(5, 7);
        graph.AddDirectedEdge(6, 8);
        graph.AddDirectedEdge(7, 8);
        graph.AddDirectedEdge(8, 0);
        Debug.Log(graph.ToString()); //Print out the graph for debugging
    }

    public Transform GetNextWaypoint(AIRacerHandler racer)
    {
        //Method for getting transform of the next node, outputting it to the racer
        Transform nextWaypoint = graph.GetNextNode(racer).nodeTransform;
        return nextWaypoint;
    }

    public int GetNumNodes() //Method for getting the number of nodes in the graph
    {
        Debug.Log(nodeList.Size());
        return nodeList.Size();
    }
}

public class Graph
{
    //Using custom linked list for graph 
    LinkedListOne<GraphNode> nodeList = new LinkedListOne<GraphNode>();

    private GraphNode previousNode = null;

    public Graph(LinkedListOne<GraphNode> nodeList) //constructor
    {
        this.nodeList = nodeList;
    }

    //Use Directed Edge for linking the nodes as the racer must go in a specific direction
    public void AddDirectedEdge(int i, int j)
    {         
        GraphNode first = nodeList.GetAtIndex(i);
        GraphNode second = nodeList.GetAtIndex(j);
        //Directed edge
        first.neighbours.InsertAtEnd(second);
    }

    public GraphNode GetNextNode(AIRacerHandler racer) //Method for getting the next node and setting the racers index to the current checkpoint index as
                                                       //racer will only go through 7 checkpoints instead of the 9 nodes
    {
        if(racer.waypointIndex == 0)
        {
            return nodeList.GetAtIndex(0);
        }

        GraphNode currentNode = nodeList.GetAtIndex(racer.waypointIndex);
        GraphNode previousNode = nodeList.GetAtIndex(racer.waypointIndex - 1);

        if(previousNode.hasNeighbours) //If the previous node has neighbours, then the racer must choose between the two
        {
            bool second = (Random.Range(0, 10)) > 4;
            Debug.Log($"Previous Node Index: " + previousNode.index);
            racer.waypointIndex = previousNode.index + 2; //Set index because of diverging node
            if (second)
            {
                
                return previousNode.neighbours.GetAtIndex(1);
            }
            else
            {
                return previousNode.neighbours.GetAtIndex(0);
            }

            
        }
        else
        {
            return currentNode;
        }



    }



    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        //Testing out StringBuilder for printing out the graph
        for(int i = 0; i < nodeList.Size(); i++)
        {
            //Append the node name and its neighbours
            s.Append(nodeList.GetAtIndex(i).name + ": ");
            for(int j = 0; j < nodeList.GetAtIndex(i).neighbours.Size(); j++)
            {
                if( j == nodeList.GetAtIndex(i).neighbours.Size() - 1)
                {
                    s.Append(nodeList.GetAtIndex(i).neighbours.GetAtIndex(j).name);
                }
                else
                {
                    s.Append(nodeList.GetAtIndex(i).neighbours.GetAtIndex(j).name + " -> ");
                    //Show the connection between neighbours
                }   
            }
            s.Append("\n");
        }
        return s.ToString();
    }

}

public class GraphNode //Node class containing waypoint data, Name, Transform, Index and Neighbours
{
    public string name;
    public Transform nodeTransform;
    public int index;
    public bool hasNeighbours = false;

    public LinkedListOne<GraphNode> neighbours = new LinkedListOne<GraphNode>();

    public GraphNode(string name, int index, Transform nodeTransform, bool hasNeigbours) //GraphNode constructor
    {
        this.name = name;
        this.index = index;
        this.nodeTransform = nodeTransform;
        this.hasNeighbours = hasNeigbours;
    }

}
[System.Serializable]
public struct Nodes //Struct for storing node data in an array
{
    public string name;
    public Transform nodeTransform;
    public bool diverges;
}

