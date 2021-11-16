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
    private GraphNode[,] nodeGraph;
    [SerializeField] GameObject nodePrefab;
    BoundsInt bounds;
    [HideInInspector] public bool IsInitialized { get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        CreateGraph();
        //RenderGraphForTest();

        IsInitialized = true;
    }

    private void CreateGraph()
    {
        bounds = floorTilemap.cellBounds;
        nodeGraph = new GraphNode[bounds.size.x, bounds.size.y];

        //Fill the nodeGraphs with nodes and nulls
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
                    nodeGraph[graphX, graphY] = new GraphNode(graphX, graphY, x + 0.5f, y + 0.5f);
                }
            }
        } 

        //With the graph created, one last thing is to nullify nodes that are on top of HidingPlaces
        GameObject[] hidingPlaceList = GameObject.FindGameObjectsWithTag("HidingPlace");
        foreach (GameObject hidingPlace in hidingPlaceList)
        {
            Vector2 objectDimensions = (hidingPlace.GetComponent<SpriteRenderer>().bounds.size)/2;
            Vector2 objectPosition = hidingPlace.transform.position;
            int minimumWidth = Mathf.FloorToInt(objectPosition.x - objectDimensions.x);
            int maximumWidth = Mathf.FloorToInt(objectPosition.x + objectDimensions.x);
            int minimumHeight = Mathf.FloorToInt(objectPosition.y - objectDimensions.y);
            int maximumHeight = Mathf.FloorToInt(objectPosition.y + objectDimensions.y);

            Debug.Log(minimumWidth+ " " +maximumWidth);
            Debug.Log(minimumHeight+ " " +maximumHeight);
            for (int x = minimumWidth; x <= maximumWidth; x++)
            {
                for (int y = minimumHeight; y <= maximumHeight; y++)
                {
                    try
                    {
                        Debug.Log(x+ " " +y);
                        nodeGraph[x - floorTilemap.cellBounds.min.x, y - floorTilemap.cellBounds.min.y] = null;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
    }

    private void RenderGraphForTest(){
        foreach (GraphNode node in nodeGraph)
        {
            if (node != null){
                Instantiate(nodePrefab, new Vector3(node.worldX, node.worldY, 0), Quaternion.identity);
            }
        }
    }

    public List<GraphNode> RecalculatePathFinding(Vector2 start, Vector2 goal){
        ResetNodes();
        return PathFinding(start, goal);
    }

    private void ResetNodes(){
        foreach (GraphNode node in nodeGraph)
        {
            if (node != null){
                node.ResetNode();
            } 
        }
    }

    public List<GraphNode> PathFinding(Vector2 start, Vector2 goal){
        GraphNode startNode = GetNode(start);
        GraphNode goalNode = GetNode(goal);

        if (startNode == null || goalNode == null){
            return null;
        }

        startNode.gValue = 0;
        startNode.hValue = EuclideanDistance(start.x, start.y, goal.x, goal.y);


        List<GraphNode> TO_VISIT = new List<GraphNode>{startNode};
        List<GraphNode> VISITED = new List<GraphNode>();

        while (TO_VISIT.Count != 0){
            GraphNode nodeSelected = TO_VISIT.OrderBy(n=>n.F()).First();
            TO_VISIT.Remove(nodeSelected);

            if (nodeSelected == goalNode){
                return BuildPath(nodeSelected);
            }

            List<GraphNode> neighbors = GetNeighbors(nodeSelected);

            foreach (GraphNode neighbor in neighbors)
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

    private GraphNode GetNode(Vector2 position){
        int positionXInGraph = (int) (position.x - bounds.min.x);
        int positionYInGraph = (int) (position.y - bounds.min.y);
        GraphNode nodeFound = nodeGraph[positionXInGraph, positionYInGraph];

        //If nodeFound equals null then search for a non-null neighbour
        while (nodeFound == null){
            nodeFound = GetAnyNeighbor(positionXInGraph, positionYInGraph);
        }

        return nodeFound;
    }

    private GraphNode GetAnyNeighbor(int positionX, int positionY){
        GraphNode node;
        for (int x = positionX - 1; x <= positionX + 1; x++)
        {
            for (int y = positionY - 1; y <= positionY + 1; y++)
            {
                if (x == positionX && y == positionY)
                {
                    continue;
                }
                try
                {
                    node = nodeGraph[x,y];
                }
                catch
                {
                    continue;
                }
                if (node == null)
                {
                    continue;
                }

                return node;
            }
        }
        return null;
    }

    private float EuclideanDistance(float x0, float y0, float x1, float y1){
        float dX = x1 - x0;
        float dY = y1 - y0;
        return Mathf.Sqrt(dX * dX + dY * dY);
    }

    private List<GraphNode> GetNeighbors(GraphNode node){
        List<GraphNode> neighbors = new List<GraphNode>();

        for (int x = node.graphX - 1; x <= node.graphX + 1; x++)
        {
            for (int y = node.graphY - 1; y <= node.graphY + 1; y++)
            {
                if (x == node.graphX && y == node.graphY){
                    continue;
                }
                GraphNode neighbor;
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

    private List<GraphNode> BuildPath(GraphNode goalNode){
        List<GraphNode> path = new List<GraphNode>();

        GraphNode currentNode = goalNode;
        while (currentNode != null){
            path.Add(currentNode);
            currentNode = currentNode.cameFrom;
        }

        return path;
    }
}


public class GraphNode
{
    public GraphNode cameFrom;
    public int graphX;
    public int graphY;
    public float worldX;
    public float worldY;
    public int gValue = int.MaxValue;
    public float hValue;

    public GraphNode(int graphX, int graphY, float worldX, float worldY){
        this.graphX = graphX;
        this.graphY = graphY;
        this.worldX = worldX;
        this.worldY = worldY;
    }

    public void ResetNode(){
        gValue = int.MaxValue;
        cameFrom = null;
    }

    public float F(){
        return gValue + hValue;
    }

    public Vector3 GetPosition(){
        return new Vector3(worldX, worldY, 0);
    }
}
