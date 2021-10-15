using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float FOV = 90f;
    [SerializeField] private int RAYCOUNT = 50;
    [SerializeField] private float VIEWDISTANCE = 5f;
    private Mesh mesh;
    private Vector3 origin;
    private float initialAngle;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update() {
        float angle = initialAngle;
        float angleIncrease = FOV/RAYCOUNT;
        origin = Vector3.zero;

        Vector3[] vertices = new Vector3[RAYCOUNT + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[RAYCOUNT * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i=0; i <= RAYCOUNT; i++){
            Vector3 direction = GetVectorFromAngle(angle);
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, direction, VIEWDISTANCE, layerMask);

            if (raycastHit2D.collider == null){
                vertex = origin + direction * VIEWDISTANCE;
            }else{
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;

            if (i>0){
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
    }

    private Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVector3(Vector3 direction){
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n<0){
            n+=360;
        }
        return n;
    }

    public void SetOrigin(Vector3 origin){
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection){
        initialAngle = GetAngleFromVector3(aimDirection) - FOV / 2F;
    }
}
