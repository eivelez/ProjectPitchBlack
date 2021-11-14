using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Graph : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private Tilemap wallTilemap; 
    [SerializeField] private Tilemap objectTilemap; 
    private Node[,] nodeGraph;
    [SerializeField] GameObject nodePrefab;
    BoundsInt bounds;
    [HideInInspector] public bool IsInitialized { get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        CreateGraph();
        RenderGraphForTest();
        /*List<Node> test = PathFinding(new Vector2(20.5f, -0.5f), new Vector2(3.5f, 1.5f));

        foreach (Node node in test)
        {
            Instantiate(prefab, new Vector3(node.worldX, node.worldY, 0), Quaternion.identity);
        }*/

        IsInitialized = true;
    }

    private void CreateGraph()
    {
        bounds = floorTilemap.cellBounds;
        nodeGraph = new Node[bounds.size.x, bounds.size.y];

        for (int x = bounds.x; x < bounds.max.x; x++) {
            for (int y= bounds.min.y; y < bounds.max.y; y++) {
                TileBase floorTile = floorTilemap.GetTile(new Vector3Int(x,y,0));
                TileBase wallTile = wallTilemap.GetTile(new Vector3Int(x,y,0));
                TileBase objectTile = objectTilemap.GetTile(new Vector3Int(x,y,0));
                int graphX = x - floorTilemap.cellBounds.min.x;
                int graphY = y - floorTilemap.cellBounds.min.y;

                if (floorTile == null || wallTile != null || objectTile != null) 
                {
                    nodeGraph[graphX, graphY] = null;
                } 
                else 
                {
                    nodeGraph[graphX, graphY] = new Node(graphX, graphY, x + 0.5f, y + 0.5f);
                }
            }
        } 
    }

    private Node GetNode(Vector2 position){
        int positionXInGraph = (int) (position.x - bounds.min.x);
        int positionYInGraph = (int) (position.y - bounds.min.y);
        return nodeGraph[positionXInGraph, positionYInGraph];
    }

    private void RenderGraphForTest(){
        foreach (Node node in nodeGraph)
        {
            if (node != null){
                Instantiate(nodePrefab, new Vector3(node.worldX, node.worldY, 0), Quaternion.identity);
            }
        }
    }

    public List<Node> RecalculatePathFinding(Vector2 start, Vector2 goal){
        ResetNodes();
        return PathFinding(start, goal);
    }

    private void ResetNodes(){
        foreach (Node node in nodeGraph)
        {
            if (node != null){
                node.ResetNode();
            } 
        }
    }

    public List<Node> PathFinding(Vector2 start, Vector2 goal){
        Node startNode = GetNode(start);
        startNode.gValue = 0;
        startNode.hValue = EuclideanDistance(start.x, start.y, goal.x, goal.y);

        Node goalNode = GetNode(goal);

        List<Node> TO_VISIT = new List<Node>{startNode};
        List<Node> VISITED = new List<Node>();

        while (TO_VISIT.Count != 0){
            Node nodeSelected = TO_VISIT.OrderBy(n=>n.F()).First();
            TO_VISIT.Remove(nodeSelected);

            if (nodeSelected == goalNode){
                return BuildPath(nodeSelected);
            }

            List<Node> neighbors = GetNeighbors(nodeSelected);

            foreach (Node neighbor in neighbors)
            {
                if (VISITED.Contains(neighbor)){
                    continue;
                }

                neighbor.hValue = EuclideanDistance(neighbor.worldX, neighbor.worldY, goal.x, goal.y);

                if (neighbor.gValue > nodeSelected.gValue + 1){
                    neighbor.gValue = nodeSelected.gValue + 1;
                    neighbor.cameFrom = nodeSelected;
                    TO_VISIT.Add(neighbor);
                }
            }

            VISITED.Add(nodeSelected);
        }

        return null;
    }

    private float EuclideanDistance(float x0, float y0, float x1, float y1){
        float dX = x1 - x0;
        float dY = y1 - y0;
        return Mathf.Sqrt(dX * dX + dY * dY);
    }

    private List<Node> GetNeighbors(Node node){
        List<Node> neighbors = new List<Node>();

        for (int x = node.graphX - 1; x <= node.graphX + 1; x++)
        {
            for (int y = node.graphY - 1; y <= node.graphY + 1; y++)
            {
                if (x == node.graphX && y == node.graphY){
                    continue;
                }
                Node neighbor;
                try{
                    neighbor = nodeGraph[x,y];
                }
                catch{
                    continue;
                }
                if (neighbor == null){
                    continue;
                }

                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    private List<Node> BuildPath(Node goalNode){
        List<Node> path = new List<Node>();

        Node currentNode = goalNode;
        while (currentNode != null){
            path.Add(currentNode);
            currentNode = currentNode.cameFrom;
        }

        return path;
    }
}
