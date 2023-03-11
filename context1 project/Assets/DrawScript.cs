using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{

    public Vector3 screenPosition;
    public Vector3 worldPosition;

    private Mesh mesh;
    private Vector3 lastMousePosition;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mouse Pressed
            mesh = new Mesh();

            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];

            vertices[0] = new Vector3(-1, +1);
            vertices[1] = new Vector3(-1, -1);
            vertices[2] = new Vector3(+1, -1);
            vertices[3] = new Vector3(+1, +1);

            uv[0] = Vector2.zero;
            uv[1] = Vector2.zero;
            uv[2] = Vector2.zero;
            uv[3] = Vector2.zero;

            triangles[0] = 0;
            triangles[1] = 3;
            triangles[2] = 1;

            triangles[3] = 1;
            triangles[4] = 3;
            triangles[5] = 2;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.MarkDynamic();

            GetComponent<MeshFilter>().mesh = mesh;

            //mouse position
            screenPosition = Input.mousePosition; //replace with mouse.current.position.readvalue?
            screenPosition.z = Camera.main.nearClipPlane + 1;

            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


            transform.position = worldPosition;

            lastMousePosition = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            //mouse held down

            Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
            Vector2[] uv = new Vector2[mesh.uv.Length + 2];
            int[] triangles = new int[mesh.triangles.Length + 6];

            mesh.vertices.CopyTo(vertices, 0);
            mesh.uv.CopyTo(uv, 0);
            mesh.triangles.CopyTo(triangles, 0);

            int vIndex = vertices.Length - 4;
            int vIndex0 = vIndex + 0;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;

            Vector3 mouseForwardVector = (Camera.main.ScreenToWorldPoint(screenPosition) - lastMousePosition).normalized;
            Vector3 normal2D = new Vector3(0, 0, -1f);
            float lineThickness = 1f;
            Vector3 newvertexUp = Camera.main.ScreenToWorldPoint(screenPosition) + Vector3.Cross(mouseForwardVector, normal2D) * lineThickness;
            Vector3 newvertexDown = Camera.main.ScreenToWorldPoint(screenPosition) + Vector3.Cross(mouseForwardVector, normal2D * -1f) * lineThickness;

            vertices[vIndex2] = newvertexUp;
            vertices[vIndex3] = newvertexDown;

            uv[vIndex2] = Vector2.zero;
            uv[vIndex3] = Vector2.zero;

            int tIndex = triangles.Length - 6;

            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex2;
            triangles[tIndex + 2] = vIndex1;

            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex2;
            triangles[tIndex + 5] = vIndex3;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            lastMousePosition = Camera.main.ScreenToWorldPoint(screenPosition);
        }
    }
}
//tutorial by Code Monkey