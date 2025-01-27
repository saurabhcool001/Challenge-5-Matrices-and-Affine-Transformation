using UnityEngine;
using UnityEngine.UI;

public class AffineTransformation : MonoBehaviour
{
    // Sliders for transformations
    public Slider rotationXSlider, rotationYSlider, rotationZSlider;
    public Slider scaleSlider;
    public Slider translateXSlider, translateYSlider, translateZSlider;

    // The mesh of the triangle
    private Vector3[] originalVertices;
    private Vector3[] transformedVertices;

    private Mesh mesh;

    void Start()
    {
        // Create a triangle mesh
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Define the triangle's vertices and indices
        originalVertices = new Vector3[]
        {
            new Vector3(0, 1, 0),   // Top vertex
            new Vector3(-1, -1, 0), // Bottom-left vertex
            new Vector3(1, -1, 0)   // Bottom-right vertex
        };
        transformedVertices = new Vector3[originalVertices.Length];

        int[] indices = { 0, 1, 2 };

        // Assign the mesh properties
        mesh.vertices = originalVertices;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
    }

    void Update()
    {
        // Get transformation values from sliders
        float rotX = rotationXSlider.value;
        float rotY = rotationYSlider.value;
        float rotZ = rotationZSlider.value;
        float scale = scaleSlider.value;
        float transX = translateXSlider.value;
        float transY = translateYSlider.value;
        float transZ = translateZSlider.value;

        // Create transformation matrices
        Matrix4x4 rotationMatrix = GetRotationMatrix(rotX, rotY, rotZ);
        Matrix4x4 scaleMatrix = GetScaleMatrix(scale);
        Matrix4x4 translationMatrix = GetTranslationMatrix(transX, transY, transZ);

        // Combine transformations: Scale -> Rotate -> Translate
        Matrix4x4 transformationMatrix = translationMatrix * rotationMatrix * scaleMatrix;

        // Apply transformations to each vertex
        for (int i = 0; i < originalVertices.Length; i++)
        {
            transformedVertices[i] = transformationMatrix.MultiplyPoint3x4(originalVertices[i]);
        }

        // Update the mesh with transformed vertices
        mesh.vertices = transformedVertices;
        mesh.RecalculateBounds();
    }

    // Function to create a rotation matrix
    private Matrix4x4 GetRotationMatrix(float rotX, float rotY, float rotZ)
    {
        float radX = Mathf.Deg2Rad * rotX;
        float radY = Mathf.Deg2Rad * rotY;
        float radZ = Mathf.Deg2Rad * rotZ;

        // Rotation around X-axis
        Matrix4x4 rotXMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, Mathf.Cos(radX), -Mathf.Sin(radX), 0),
            new Vector4(0, Mathf.Sin(radX), Mathf.Cos(radX), 0),
            new Vector4(0, 0, 0, 1)
        );

        // Rotation around Y-axis
        Matrix4x4 rotYMatrix = new Matrix4x4(
            new Vector4(Mathf.Cos(radY), 0, Mathf.Sin(radY), 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(-Mathf.Sin(radY), 0, Mathf.Cos(radY), 0),
            new Vector4(0, 0, 0, 1)
        );

        // Rotation around Z-axis
        Matrix4x4 rotZMatrix = new Matrix4x4(
            new Vector4(Mathf.Cos(radZ), -Mathf.Sin(radZ), 0, 0),
            new Vector4(Mathf.Sin(radZ), Mathf.Cos(radZ), 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );

        // Combined rotation: Z * Y * X
        return rotZMatrix * rotYMatrix * rotXMatrix;
    }

    // Function to create a scale matrix
    private Matrix4x4 GetScaleMatrix(float scale)
    {
        return new Matrix4x4(
            new Vector4(scale, 0, 0, 0),
            new Vector4(0, scale, 0, 0),
            new Vector4(0, 0, scale, 0),
            new Vector4(0, 0, 0, 1)
        );
    }

    // Function to create a translation matrix
    private Matrix4x4 GetTranslationMatrix(float transX, float transY, float transZ)
    {
        return new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(transX, transY, transZ, 1)
);

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