using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // Helper Function that converts floats to Vector3
    public static Vector3 GetVectorFromAngle(float angle)
    {
        //angle = 0 -> 360 degrees
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }

        return n;
    }

    [SerializeField] private LayerMask layermask;
    private Mesh mesh;
    private float fov;
    private float startingAngle;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        startingAngle = 0f;
        origin = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layermask);

            if (raycastHit2D.collider == null)
            {
                // no collision
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // hit
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
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
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVector(aimDirection) - fov / 2f;
    }
}
