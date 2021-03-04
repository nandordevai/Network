using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Node
{
    Vector3 position;
    Node nearest;

    public Node(Vector3 position, Node nearest = null)
    {
        this.position = position;
        this.nearest = nearest;
    }

    public void calculateNearest()
    {
        // float minDistance = Vector3.Distance(nodes[0], nodes[1]);
        // for (var i = 1; i < numNodes; i++)
        // {
        //     float d = Vector3.Distance(nodes[i], nodes[i + 1])
        // }
    }

    public void display()
    {
        GameObject node = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        node.transform.localScale = Vector3.one / 10f;
        node.transform.position = this.position;
    }
}

public class NetworkGenerator : MonoBehaviour
{
    static int numNodes = 50;
    Node[] nodes = new Node[numNodes];
    float height = 10;
    float width = 10;
    float depth = 10;

    void Start()
    {
        generateNodes();
        for (int i = 0; i < numNodes; i++)
        {
            nodes[i].display();
            nodes[i].calculateNearest();
        }
    }

    void generateNodes()
    {
        for (var i = 0; i < numNodes; i++)
        {
            Vector3 p = new Vector3(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2),
                Random.Range(-depth / 2, depth / 2)
            );
            nodes[i] = new Node(p);
        }
    }
}
