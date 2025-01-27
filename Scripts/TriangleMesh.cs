using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TriangleMesh : MonoBehaviour
{
    void Start()
    {
        // Create a new Mesh
        Mesh mesh = new Mesh();

        // Define the vertices of the triangle
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 1, 0),   // Top vertex
            new Vector3(-1, -1, 0), // Bottom-left vertex
            new Vector3(1, -1, 0)   // Bottom-right vertex
        };

        // Define the indices of the triangle (connecting the vertices)
        int[] triangles = new int[]
        {
            0, 1, 2 // Triangle made from vertices 0, 1, and 2
        };

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Optionally, define the normals (for lighting)
        Vector3[] normals = new Vector3[]
        {
            Vector3.back, // All normals point backward (Z-negative)
            Vector3.back,
            Vector3.back
        };
        mesh.normals = normals;

        // Optionally, define UVs (for texture mapping)
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0.5f, 1), // Top vertex
            new Vector2(0, 0),    // Bottom-left vertex
            new Vector2(1, 0)     // Bottom-right vertex
        };
        mesh.uv = uvs;

        // Assign the mesh to the MeshFilter
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void OnDrawGizmos()
    {
        // Define the vertices of the triangle
        Vector3[] vertices = new Vector3[]
        {
        new Vector3(0, 1, 0),   // Top vertex
        new Vector3(-1, -1, 0), // Bottom-left vertex
        new Vector3(1, -1, 0)   // Bottom-right vertex
        };

        // Draw edges
        Gizmos.color = Color.red;
        Gizmos.DrawLine(vertices[0], vertices[1]); // Edge 1
        Gizmos.DrawLine(vertices[1], vertices[2]); // Edge 2
        Gizmos.DrawLine(vertices[2], vertices[0]); // Edge 3
    }

}