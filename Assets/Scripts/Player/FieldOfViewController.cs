using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMaskToObstructLight;
    [SerializeField] private float FOV = 70f;
    [SerializeField] private float VIEWDISTANCE = 5f;
    private int RAYCOUNT = 50;
    private Mesh mesh;
    private Vector3 origin = Vector3.zero;
    private float initialAngle;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void LateUpdate() {
        CreateMeshCone();
    }

    private void CreateMeshCone(){
        float angle = initialAngle;
        float angleIncrease = FOV/RAYCOUNT;

        Vector3[] vertices = new Vector3[RAYCOUNT + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[RAYCOUNT * 3];

        int vertexIndex = 1;
        int triangleIndex = 0;
        //We start locating all of the vertex of the cone by increasing the angle bit by bit
        for (int i=0; i <= RAYCOUNT; i++)
        {
            Vector3 direction = GetVectorFromAngle(angle);
            Vector3 vertex;
            //Cast a raycast to see if any vertex of the cone collides with a wall collider (the wall layer)
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.parent.position, direction, VIEWDISTANCE, layerMaskToObstructLight);

            //If the raycast doesnt hit anything, put the vertex on the maximum distance (VIEWDISTANCE)
            if (raycastHit2D.collider == null)
            {
                vertex = direction * VIEWDISTANCE;
            }
            //If it hits something, put the vertex where it collided
            else
            {
                vertex = raycastHit2D.point - new Vector2(transform.parent.position.x, transform.parent.position.y);
            }

            vertices[vertexIndex] = vertex;

            if (i>0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(transform.parent.position, Vector3.one * 1000f);
    }

    //To obtain a Vector3 from an angle
    private Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    //To obtain an angle from a Vector3 (the inverse of the above function)
    private float GetAngleFromVector3(Vector3 direction){
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n<0){
            n+=360;
        }
        return n;
    }

    //To set direction of the cone to the mouse pointer
    public void SetAimDirection(Vector3 aimDirection){
        initialAngle = GetAngleFromVector3(aimDirection) + FOV / 2F;
    }
}
