using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node cameFrom;
    public int graphX;
    public int graphY;
    public float worldX;
    public float worldY;
    public int gValue = int.MaxValue;
    public float hValue;

    public Node(int graphX, int graphY, float worldX, float worldY){
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

